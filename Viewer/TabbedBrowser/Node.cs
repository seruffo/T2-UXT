using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace EO.TabbedBrowser
{
    class Node
    {
        public string Type{get; set;}
        public string ImgPath{get; set;}
        public int Time{get; set;}
        public int X{get; set;}
        public int Y{get; set;}
        public string Keys{get; set;}

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
                    tempNode.X = int.Parse(node.Attributes["x"].Value);
                    tempNode.Y = int.Parse(node.Attributes["y"].Value);
                    tempNode.Keys = node.Attributes["keys"].Value;
                    result.Add(tempNode);
                }
            }
            return result;
        }


    }
}
