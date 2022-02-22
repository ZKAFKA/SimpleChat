using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

/*  应用层协议
 *  CNNN + （控制命令）
 *      C000 + clientA_name:clientA_ip:clientA_port  客户端上线报文
 *      C101 + IPA:clientB_name     客户端连接信息请求报文
 *      C001 + ip:port:(签名)   服务器向clientA信息传送报文
 *      C010 + ip:(签名)        服务器向clientB验证报文
 *      C011 + ip:(签名)        clientA向clientB验证报文
 *      C111 + (签名)           客户端验证通过报文
 *      C100 + (error message)  错误报文
 *  TEXT + （文本消息）
 */

namespace Client
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button_online;
        private System.Windows.Forms.Button button_send;
        private TcpClient client;
        private TcpClient client2;
        private NetworkStream netStream;
        private System.Windows.Forms.Button button_break;
        private IPAddress myIP;
        private Int32 myPort;
        private string connect_signature;


        public Form1()
        {
            //初始化主机地址及端口
            try
            {
                myIP = IPAddress.Parse(Host.GetHostIp());
                myPort = Host.GetPort();
            }
            catch { MessageBox.Show("网络存在问题"); }


            InitializeComponent();

            //开启客户端监听
            try
            {
                Thread thread = new Thread(new ThreadStart(accp));
                thread.Start();
            }
            catch (Exception ee) { status_label.Text = ee.Message; }
        }
        private void accp()
        {
            try
            {
                TcpListener tcpListener = new TcpListener(myIP, myPort);
                tcpListener.Start();
                client2 = new TcpClient();

                //建立连接
                while (true)
                {
                    client2 = tcpListener.AcceptTcpClient();
                    if (client2.Connected)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            status_label.Text = "与联系方建立连接";
                        }));
                        Thread thread = new Thread(new ThreadStart(listen));
                        thread.Start();
                    }
                }
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void listen()
        {
            string ip2 = "";
            string signature2 = "";

            while (true)
            {     
                try 
                {
                Byte[] Rec = new byte[64];
                NetworkStream netStream = client2.GetStream();
                netStream.Read(Rec, 0, Rec.Length);

                string RecMessage = System.Text.Encoding.BigEndianUnicode.GetString(Rec);
                
                string control = RecMessage.Substring(0, 4);


                if (control == "C010")
                {
                    //服务器发来的验证连接消息
                    string[] message = RecMessage.Split(':');
                    ip2 = message[1];
                    signature2 = message[2];

                    this.Invoke(new EventHandler(delegate
                    {
                        richTextBox_recv.AppendText("对方ip：" + ip2 + "  签名:" + signature2 + "\n");
                        status_label.Text = "等待与 " + ip2 + " 建立连接";
                    }));

                    Byte[] ackArray = new byte[64];
                    string ack = "ACK";
                    ackArray = System.Text.Encoding.BigEndianUnicode.GetBytes(ack.ToCharArray());
                    netStream.Write(ackArray, 0, ackArray.Length);
                    netStream.Flush();
                }
                
                if (control == "TEXT")
                {
                    //聊天文本消息
                    string[] message = RecMessage.Split(':');
                    string ChatPerson = message[1];
                    string ChatMessage = message[2];
                    this.Invoke(new EventHandler(delegate
                    {
                        richTextBox_recv.AppendText(ChatPerson + ":");
                        richTextBox_recv.AppendText(ChatMessage + "\n");
                        status_label.Text = "正在进行通信";
                    }));
                }
                else if (control == "C011")
                {
                    //客户端传来的连接请求消息
                    string[] message = RecMessage.Split(':');
                    string get_ip = message[1];
                    string get_signature = message[2];
                    this.Invoke(new EventHandler(delegate
                    {
                        richTextBox_recv.AppendText("收到验证签名" + get_signature);
                        richTextBox_recv.AppendText("本机验证签名" + signature2);
                        richTextBox_recv.AppendText("验证IP" + get_ip);
                        richTextBox_recv.AppendText("本机IP" + myIP +"\n");
                    }));

                    if (get_signature.Equals(signature2))
                    {
                        //若签名正确，则返回验证正确报文C111
                        string send = "C111" + ":" + signature2 + ":";
                        byte[] messageByte = System.Text.Encoding.BigEndianUnicode.GetBytes(send.ToCharArray());
                        netStream.Write(messageByte, 0, messageByte.Length);
                        netStream.Flush();
                        this.Invoke(new EventHandler(delegate
                        {
                            richTextBox_recv.AppendText("验证通过\n");
                        }));
                    }
                    else
                    {
                        //若签名错误，返回错误报告
                        string send = "C100" + ":" + "签名未通过";
                        byte[] messageByte = System.Text.Encoding.BigEndianUnicode.GetBytes(send.ToCharArray());
                        netStream.Write(messageByte, 0, messageByte.Length);
                        netStream.Flush();
                        this.Invoke(new EventHandler(delegate
                        {
                            richTextBox_recv.AppendText("签名验证未通过，连接断开\n");
                        }));
                        client2.Close();
                        break;
                    }
                }
                else
                {
                    //该接口不应收到控制字段为其余的报文，应响应错误
                    this.Invoke(new EventHandler(delegate
                    {
                        status_label.Text = "连接出现异常";
                    }));
                }
                
                }
                catch { continue; }
            }
        }

        /* 
        * 上线
        * client  用于与服务器的连接
        * client2 用于与另一客户端的连接
        */
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Int32.Parse(textBox_port.Text);
                client = new TcpClient();
                client.Connect(textBox_ip.Text, port);
                this.Invoke(new EventHandler(delegate
                {
                    status_label.Text = "与服务器建立连接";
                }));

                //向服务器发送昵称及IP，端口
                String myName = textBox_name.Text;

                netStream = client.GetStream();
                string send = "C000" + ":" + myName + ":" + myIP + ":" + myPort + ":";
                byte[] messageByte = System.Text.Encoding.BigEndianUnicode.GetBytes(send.ToCharArray());
                netStream.Write(messageByte, 0, messageByte.Length);
                richTextBox_recv.AppendText("向服务器发送上线消息：" + send + "\n");
                netStream.Flush();

                //开启线程用于接收服务器发送的验证消息

            }
            catch
            {
                MessageBox.Show("无法连接! 客户端未上线");
            }
        }

        /*
         * 发送信息 
         * 通过client2发送
         */
        private void button2_Click(object sender, EventArgs e)
        {
            string myName = textBox_name.Text;
            try
            {

                NetworkStream chatStream = client2.GetStream();
                string send = "TEXT" + ":" + myName + ":" + richTextBox_send.Text;
                byte[] messageByte = System.Text.Encoding.BigEndianUnicode.GetBytes(send.ToCharArray());
                chatStream.Write(messageByte, 0, messageByte.Length);
                netStream.Flush();

                string show = myName + ":" + richTextBox_send.Text;
                this.Invoke(new EventHandler(delegate
                {
                    richTextBox_recv.AppendText(show + "\n");
                    richTextBox_send.Text = "";
                }));
            }
            catch { MessageBox.Show("连接尚未建立！无法发送！"); }
        }

        //断开连接
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                client.Close();
                client2.Close();
            }
            catch { }
        }

        /* 
         * 建立连接
         * 通过client获取联系人信息
         * 建立client2进行通信
         */
        private void button_connect_Click(object sender, EventArgs e)
        {
            try
            {
                client2 = new TcpClient();

                netStream = client.GetStream();
                String connetedPerson = textBox_Person.Text;

                // 发送连接请求
                if (connetedPerson == "")
                {
                    MessageBox.Show("联系人不能为空！");
                }
                string send = "C101" + ":" + myIP + ":" + connetedPerson;
                byte[] messageByte = System.Text.Encoding.BigEndianUnicode.GetBytes(send.ToCharArray());
                netStream.Write(messageByte, 0, messageByte.Length);

                Thread thread = new Thread(new ThreadStart(connect));
                thread.Start();
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
            //catch { MessageBox.Show("连接建立失败"); }

        }

        private void connect()
        {
            try
            {
                while (true)
                {
                    // 接收服务器返回信息
                    byte[] return_messageByte = new byte[64];
                    netStream.Read(return_messageByte, 0, return_messageByte.Length);
                    string readMessage = System.Text.Encoding.BigEndianUnicode.GetString(return_messageByte);

                    // 应用层协议解析
                    string control_message = readMessage.Substring(0, 4);
                    if (control_message == "C001")
                    {
                        //服务器返回信息：对方ip及端口
                        string[] message = readMessage.Split(':');
                        string ip = message[1];
                        string port = message[2];
                        connect_signature = message[3];

                        this.Invoke(new EventHandler(delegate
                        {
                            richTextBox_recv.AppendText("对方ip:" + ip + ":" + port + "  签名:" + connect_signature + "\n");
                        }));

                        //开始向对方发起连接请求
                        //使用client2进行连接   
                        client2.Connect(ip, Int32.Parse(port));

                        //传输验证消息
                        NetworkStream verifyStream = client2.GetStream();
                        string send = "C011" + ":" + ip + ":" + connect_signature + ":";
                        byte[] verify_messageByte = System.Text.Encoding.BigEndianUnicode.GetBytes(send.ToCharArray());
                        verifyStream.Write(verify_messageByte, 0, verify_messageByte.Length);
                        verifyStream.Flush();
                        this.Invoke(new EventHandler(delegate
                        {
                            richTextBox_recv.AppendText("发送验证消息：" + send + "\n");
                        }));

                        //接收验证响应
                        while (true)
                        {
                            verifyStream = client2.GetStream();
                            byte[] responseByte = new byte[64];
                            verifyStream.Read(responseByte, 0, responseByte.Length);
                            string readResponseMessage = System.Text.Encoding.BigEndianUnicode.GetString(responseByte);

                            //应用层协议解析
                            string response_control_message = readResponseMessage.Substring(0, 4);
                            if (response_control_message == "C111")
                            {
                                string[] message2 = readResponseMessage.Split(':');
                                string response_content = message2[1];

                                if (response_content == connect_signature)
                                {
                                    //验证通过，开启线程接收消息
                                    System.Threading.Thread thread2 = new System.Threading.Thread(new ThreadStart(receive));
                                    thread2.Start();
                                    this.Invoke(new EventHandler(delegate
                                    {
                                        status_label.Text = "正在与对方通信";
                                        richTextBox_recv.AppendText("验证通过，开始通信\n");
                                    }));
                                    break;
                                }

                            }
                            else if (response_control_message == "C100")
                            {
                                //错误报告
                                string[] message2 = readResponseMessage.Split(':');
                                string response_content = message2[1];

                                this.Invoke(new EventHandler(delegate
                                {
                                    status_label.Text = response_content;
                                }));
                                client2.Close();
                                break;
                            }
                            else
                            {
                                //验证未通过
                                this.Invoke(new EventHandler(delegate
                                {
                                    status_label.Text = "连接失败";
                                }));
                                MessageBox.Show("与联系人连接失败");
                                client2.Close();
                                break;
                            }
                        }
                    }
                    if (control_message == "C100")
                    {
                        //错误报告
                        string[] message = readMessage.Split(':');
                        string errorMessage = message[1];
                        this.Invoke(new EventHandler(delegate
                        {
                            richTextBox_recv.AppendText(errorMessage + "\n");
                        }));
                    }
                    else
                    {
                        //该接口不应收到控制字段为其余的报文，应响应错误
                        this.Invoke(new EventHandler(delegate
                        {
                            status_label.Text = "连接出现异常";
                        }));
                    }
                }
            }
            catch { MessageBox.Show("连接建立失败！"); }
        }


        private void receive()
        {
            while (true)
            {

                netStream = client2.GetStream();
                byte[] messageByte = new byte[64];
                netStream.Read(messageByte, 0, messageByte.Length);
                string readMessage = System.Text.Encoding.BigEndianUnicode.GetString(messageByte);

                // 应用层协议解析
                string control_message = readMessage.Substring(0, 4);
                string[] message = readMessage.Split(':');
                string ChatPerson = message[1];
                string ChatMessage = message[2];

                if (control_message == "TEXT")
                {
                    //聊天文本消息
                    
                    this.Invoke(new EventHandler(delegate
                    {
                        richTextBox_recv.AppendText(ChatPerson + ":");
                        richTextBox_recv.AppendText(ChatMessage + "\n");
                        status_label.Text = "正在进行通信";
                    }));
                }
                else
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        status_label.Text = "连接出现异常";
                    }));
                }
            }
        }

    }
}
