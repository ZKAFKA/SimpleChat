using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Server
{
    class XmlHandler
    {
        private string xmlPath = "Person_IP.xml";
        public XmlHandler() {
            if (!Directory.Exists(xmlPath))
            {
                initialXmlDoc();     
            }
        }
        public void initialXmlDoc()
        {
            XElement xElement = new XElement(
                new XElement("Person_IP")
                );

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;
            XmlWriter xw = XmlWriter.Create(xmlPath, settings);
            xElement.Save(xw);
            
            //写入文件
            xw.Flush();
            xw.Close();
        }

        public void xmlAdd(string person, string ip, string port)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            var root = xmlDoc.DocumentElement;//取到根结点
            XmlNode newNode = xmlDoc.CreateNode("element", person, "");
            XmlNode newNodeIP = xmlDoc.CreateNode("element", "Address", "");
            newNodeIP.InnerText = ip +":"+port;
            //添加为根元素的第一层子结点
            root.AppendChild(newNode);
            newNode.AppendChild(newNodeIP);

            xmlDoc.Save(xmlPath);
        }
            
        public void xmlDel(string delPerson)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            var root = xmlDoc.DocumentElement;//取到根结点
            var delElement = xmlDoc.SelectSingleNode("Person_IP/" + delPerson);
            root.RemoveChild(delElement);
            xmlDoc.Save(xmlPath);
        }

        public string xmlSearch(string findPerson)
        {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);
                //取根节点
                XmlNode findNode = xmlDoc.SelectSingleNode("Person_IP/" + findPerson + "/Address");

                //未找到对应信息则返回“0”
                if (findNode == null)
                {
                    return "0";
                }
                else
                {
                    string ip = findNode.InnerText;
                    return ip;
                }
        }
    }
}
