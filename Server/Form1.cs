using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;

/*  应用层协议
 *  CNNN + （控制命令）
 *      C000 + clientA_name:clientA_ip:clientA_port  客户端上线报文
 *      C101 + ipA:clientB_name     客户端连接信息请求报文
 *      C001 + ip:port:(签名)   服务器向clientA信息传送报文
 *      C010 + ip:(签名)        服务器向clientB验证报文
 *      C011 + ip:(签名)        clientA向clientB验证报文
 *      C111 + (签名)           客户端验证通过报文
 *      C100 + (error message)  错误报文
 *  TEXT + （文本消息）
 */

namespace Server
{
    public partial class MAIN : Form
    {
        private IPAddress myIP = IPAddress.Parse("127.0.0.1");
        private IPEndPoint MyServer;
        private Socket sock;
        private Socket accSock;
        private XmlHandler xmlServer;

        public MAIN()
        {
            InitializeComponent();
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            xmlServer = new XmlHandler();
        }


        private void button_start_Click(object sender, EventArgs e)
        {
            try
            {
                myIP = IPAddress.Parse(textBox_ip.Text);
            }
            catch { MessageBox.Show("您输入的IP地址格式不正确，请重新输入"); }

            try
            {
                Thread thread = new Thread(new ThreadStart(accp));
                thread.Start();
            }
            catch (Exception ee) { textBox_status.AppendText(ee.Message); }
        }

        // 自定义端口输入异常
        public class PortException : ApplicationException
        {
            public PortException() : base()
            {
            }
        }

        // 判断指定端口号是否被占用且端口号是否合法
        public static Boolean IsPortOccuped(Int32 port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            if (port > 65535)
            {
                inUse = true;
            }

            return inUse;
        }

        // 监听并接收连接
        private void accp()
        {
            try
            {
                int port = Int32.Parse(textBox_port.Text);
                //判断端口号是否正常
                if (IsPortOccuped(port))
                {
                    throw (new PortException());
                }

                MyServer = new IPEndPoint(myIP, port);
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Bind(MyServer);
                sock.Listen(50);
                this.Invoke(new EventHandler(delegate
                {
                    textBox_status.AppendText("主机" + textBox_ip.Text + "端口" + textBox_port.Text + "开始监听.....\r\n");
                }));

                //建立连接
                while (true)
                {
                    accSock = sock.Accept();
                    if (accSock.Connected)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            textBox_status.AppendText("接收到客户连接请求\r\n");
                        }));
                        Thread thread = new Thread(new ThreadStart(round));
                        thread.Start();
                    }
                }
            }
            catch (PortException) {
                MessageBox.Show("您输入的端口号错误，请重新输入");
            }
            catch { }
        }

        private void round()
        {
            while (true)
            {
                try
                {
                    Byte[] Rec = new byte[64];
                    NetworkStream netStream = new NetworkStream(accSock);
                    netStream.Read(Rec, 0, Rec.Length);
                    string RecMessage = System.Text.Encoding.BigEndianUnicode.GetString(Rec);

                    //应用层解析
                    string control = RecMessage.Substring(0, 4);
                    if (control == "C000")
                    {
                        //获取客户信息
                        string[] Info = RecMessage.Split(':');
                        string clientAName = Info[1];
                        string clientAIP = Info[2];
                        string clientAPort = Info[3];
                        this.Invoke(new EventHandler(delegate
                        {
                            richTextBox_recv.AppendText("客户:" + clientAName + "上线   客户IP:" + clientAIP + " 客户聊天连接端口号:" + clientAPort + "\n");
                        }));

                        //客户信息登记入xml文件
                        xmlServer.xmlAdd(clientAName, clientAIP, clientAPort);
                    }
                    if (control == "C101")
                    {
                        //连接ClientB
                        string[] Info = RecMessage.Split(':');
                        string requestIP = Info[1];
                        string clientBName = Info[2];

                        //在服务器库中寻找对应联系人的IP地址
                        string clientB_ip_port = xmlServer.xmlSearch(clientBName);

                        //发送响应消息
                        //未找到对方IP的情况
                        if (clientB_ip_port == "0")
                        {
                            this.Invoke(new EventHandler(delegate
                            {
                                richTextBox_recv.AppendText("未找到对应客户 " + clientBName + " 的IP地址\n");
                            }));
                            Byte[] sendByte = new byte[64];
                            string send = "C100" + ":" + "对方未上线";
                            sendByte = System.Text.Encoding.BigEndianUnicode.GetBytes(send.ToCharArray());
                            netStream.Write(sendByte, 0, sendByte.Length);
                        }
                        //找到对方IP的情况
                        else
                        {
                            string[] IP_Port = clientB_ip_port.Split(':');
                            string clientB_ip = IP_Port[0];
                            string clientB_port = IP_Port[1];
                            string signature = Tap.GenerateTap();

                            //向另一方请求连接，发送签名
                            TcpClient connectToOther = new TcpClient();
                            connectToOther.Connect(clientB_ip, Int32.Parse(clientB_port));
                            NetworkStream otherStream = connectToOther.GetStream();

                            Byte[] send2Byte = new byte[64];
                            string send2 = "C010" + ":" + requestIP + ":" + signature + ":";
                            send2Byte = System.Text.Encoding.BigEndianUnicode.GetBytes(send2.ToCharArray());
                            otherStream.Write(send2Byte, 0, send2Byte.Length);
                            otherStream.Flush();

                            this.Invoke(new EventHandler(delegate
                            {
                                richTextBox_recv.AppendText("向通信另一方发送验证签名（ip+签名):" + send2 + "\n");
                            }));

                            //等待ACK响应
                            while (true)
                            {
                                Byte[] Response = new byte[64];
                                otherStream.Read(Response, 0, Response.Length);
                                string Res = System.Text.Encoding.BigEndianUnicode.GetString(Response);
                                if (Res.Substring(0,3).Equals("ACK"))
                                {
                                    //发送完后断开与clientB的连接
                                    connectToOther.Close();
                                    break;
                                }
                            }

                            //向请求方回送对方IP及端口信息
                            Byte[] sendByte = new byte[64];
                            string send = "C001" + ":" + clientB_ip + ":" + clientB_port + ":" + signature + ":";
                            sendByte = System.Text.Encoding.BigEndianUnicode.GetBytes(send.ToCharArray());
                            netStream.Write(sendByte, 0, sendByte.Length);

                            this.Invoke(new EventHandler(delegate
                            {
                                richTextBox_recv.AppendText("向连接请求方发送ip、端口及签名:" + send + "\n");
                            }));
                        }
                    }
                }
                catch { }
            }
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            try
            {
                sock.Close();
                this.Invoke(new EventHandler(delegate
                {
                    textBox_status.AppendText("主机" + textBox_ip.Text + "端口" + textBox_port.Text + "监听停止！\r\n");
                }));
            }
            catch { MessageBox.Show("监听尚未开始，关闭无效\r\n"); }
        }
    }
}
