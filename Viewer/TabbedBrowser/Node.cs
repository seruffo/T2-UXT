using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Lades.WebTracer
{
    public class Node
    {
        public string Type{get; set;}
        public string ImgPath{get; set;}
        public int Time{get; set;}
        public string Id{get; set;}
        public int X{get; set;}
        public int Y{get; set;}
        public string keyText{get; set;}

        public string sourcePath { get; set; }

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
                    tempNode.Type = LoadAttribute(node,"type","click");
                    tempNode.ImgPath = LoadAttribute(node, "image", "");
                    tempNode.Time = int.Parse(LoadAttribute(node, "time","0"));
                    tempNode.Id = LoadAttribute(node, "Id","");
                    tempNode.X = int.Parse(LoadAttribute(node, "X","0"));
                    tempNode.Y = int.Parse(LoadAttribute(node, "Y","0"));
                    tempNode.keyText = LoadAttribute(node, "Typed","0");
                    tempNode.sourcePath = System.IO.Path.GetDirectoryName(path);
                    result.Add(tempNode);
                }
            }
            return result;
        }
        private static string LoadAttribute(XmlNode node, string attr, string defaultValue)
        {
            string result;
            try
            {
                result = node.Attributes[attr].Value;
                return result;
            }
            catch
            {
                //Console.WriteLine("erro no atributo " + attr);
                return defaultValue;
            }
        }

    }
}
