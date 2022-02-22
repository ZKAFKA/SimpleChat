using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Host
    {
        //获取本机IP地址
        public static String GetHostIp()
        {
            IPAddress hostIP = Dns.GetHostAddresses(Dns.GetHostName()).ToList().First(d => d.AddressFamily == AddressFamily.InterNetwork);

            return hostIP.ToString();
        }

        /// <summary>        
        /// 获取操作系统已用的端口号        
        /// </summary>        
        /// <returns></returns>        
        public static IList PortIsUsed()
        {
            //获取本地计算机的网络连接和通信统计数据的信息            
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            //返回本地计算机上的所有Tcp监听程序            
            IPEndPoint[] ipsTCP = ipGlobalProperties.GetActiveTcpListeners();
            //返回本地计算机上的所有UDP监听程序            
            IPEndPoint[] ipsUDP = ipGlobalProperties.GetActiveUdpListeners();
            //返回本地计算机上的Internet协议版本4(IPV4 传输控制协议(TCP)连接的信息。            
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            IList allPorts = new ArrayList();
            foreach (IPEndPoint ep in ipsTCP)
            {
                allPorts.Add(ep.Port);
            }
            foreach (IPEndPoint ep in ipsUDP)
            {
                allPorts.Add(ep.Port);
            }
            foreach (TcpConnectionInformation conn in tcpConnInfoArray)
            {
                allPorts.Add(conn.LocalEndPoint.Port);
            }
            return allPorts;
        }

        public static Int32 GetPort()
        {
            IList HasUsedPort = PortIsUsed();
            int port = 0;
            bool IsRandomOk = true;
            Random random = new Random((int)DateTime.Now.Ticks);
            while (IsRandomOk)
            {
                port = random.Next(1024, 65535);
                IsRandomOk = HasUsedPort.Contains(port);
            }
            return port;
        }
    }
}
