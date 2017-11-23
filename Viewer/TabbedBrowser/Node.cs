using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace EO.TabbedBrowser
{
    public class Node
    {
        public string Type{get; set;}
        public string ImgPath{get; set;}
        public int Time{get; set;}
        public string mouseId{get; set;}
        public int mouseX{get; set;}
        public int mouseY{get; set;}
        public string keyId{get; set;}
        public int keyX{get; set;}
        public int keyY{get; set;}
        public string keyText{get; set;}

        public Node()
        {

        }

        public static List<Node> LoadNodes(string path)
        {
            List<Node> result = null;
            XmlDocument doc = new XmlDocument();
            if (File.Exists(path))
            {
                result = new List<Node>();
                string readText = File.ReadAllText(path);
                if (readText.Contains("rawtrace"))
                {
                    readText = "<?xml version=\"1.0\"?>\n<usertrace>" + readText.Replace("rawtrace", "trace") + "</usertrace>";
                    File.WriteAllText(path, readText);
                }
                doc.Load(path);
                XmlNode current = doc.SelectSingleNode("/usertrace/trace");
                XmlNodeList list = current.ParentNode.SelectNodes(current.Name);
                foreach(XmlNode node in list)
                {
                    //<trace type="click" image="1.jpg" time="1" x="321" y="184" keys=""\>
                    Node tempNode = new Node();
                    tempNode.Type = node.Attributes["type"].Value;
                    tempNode.ImgPath = node.Attributes["image"].Value;
                    tempNode.Time = int.Parse(node.Attributes["time"].Value);
                    tempNode.mouseId = node.Attributes["mouseId"].Value;
                    tempNode.mouseX = int.Parse(node.Attributes["mouseX"].Value);
                    tempNode.mouseY = int.Parse(node.Attributes["mouseY"].Value);
                    tempNode.keyId = node.Attributes["keyId"].Value;
                    tempNode.keyX = int.Parse(node.Attributes["keyX"].Value);
                    tempNode.keyY = int.Parse(node.Attributes["keyY"].Value);
                    tempNode.keyText = node.Attributes["keys"].Value;
                    result.Add(tempNode);
                }
            }
            return result;
        }


    }
}
