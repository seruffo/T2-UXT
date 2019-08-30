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
        public float Time{get; set;}
        public string Id{get; set;}
        public string Class { get; set; }
        public string MouseId { get; set; }
        public string MouseClass { get; set; }
        public int X{get; set;}
        public int Y{get; set;}
        public int Height { get; set; }
        public int Scroll { get; set; }
        public string keyText{get; set;}
        public string sourcePath { get; set; }
        public string Url { get; set; }    

        public Node()
        {

        }

        public Node Copy()
        {
            return new Node(this.Type, this.ImgPath, this.Time, this.Id, this.Class, this.MouseId, this.MouseClass, this.X, this.Y, this.Height, this.Scroll, this.keyText, this.sourcePath, this.Url);
        }

        public Node(string Type, string ImgPath, float Time, string Id, string Class, string MouseId, string MouseClass, int X, int Y, int Height, int Scroll, string keyText, string sourcePath, string Url)
        {
            this.Type = Type;
            this.ImgPath = ImgPath;
            this.Time = Time;
            this.Id = Id;
            this.Class = Class;
            this.MouseId = MouseId;
            this.MouseClass = MouseClass;
            this.X = X;
            this.Y = Y;
            this.Height = Height;
            this.Scroll = Scroll;
            this.keyText = keyText;
            this.sourcePath = sourcePath;
            this.Url = Url;
        }


        public static List<Node> LoadNodes(string path)
        {
            return LoadNodes(path, false);
        }
 
            public static List<Node> LoadNodes(string path, bool justMouse)
            {
            List<Node> result = null;
            XmlDocument doc = new XmlDocument();
            path += "\\trace.xml";
            if (File.Exists(path))
            {
                try
                {
                    result = new List<Node>();
                    string readText = File.ReadAllText(path);
                    if (readText.Contains("rawtrace"))
                    {
                        readText = "<?xml version=\"1.0\"?>\n<usertrace>" + readText.Replace("rawtrace", "trace") + "</usertrace>";
                        File.WriteAllText(path, readText);
                    }
                    readText = File.ReadAllText(path);
                    if (readText.Contains("&") && !readText.Contains("&amp;"))
                    {
                        File.WriteAllText(path, readText.Replace("&", "&amp;"));
                    }
                    doc.Load(path);
                    XmlNode current = doc.SelectSingleNode("/usertrace/trace");
                    XmlNodeList list = current.ParentNode.SelectNodes(current.Name);
                    foreach (XmlNode node in list)
                    {
                        //<trace type="click" image="1.jpg" time="1" x="321" y="184" keys=""\>
                        Node tempNode = new Node();
                        tempNode.Type = LoadAttribute(node, "type", "click");
                        if (justMouse)
                        {
                            if (tempNode.Type == "keyboard")
                                continue;
                        }
                        tempNode.ImgPath = LoadAttribute(node, "image", "");
                        string timeS = LoadAttribute(node, "time", "0");
                        if (timeS == "")
                            timeS = "0";
                        tempNode.Time = float.Parse(timeS, System.Globalization.CultureInfo.InvariantCulture);
                        tempNode.Id = LoadAttribute(node, "Id", "");
                        tempNode.Class = LoadAttribute(node, "Class", "");
                        tempNode.MouseId = LoadAttribute(node, "MouseId", "");
                        tempNode.MouseClass = LoadAttribute(node, "MouseClass", "");
                        tempNode.X = int.Parse(LoadAttribute(node, "X", "0"));
                        tempNode.Y = int.Parse(LoadAttribute(node, "Y", "0"));
                        tempNode.Height = int.Parse(LoadAttribute(node, "height", "768"));
                        tempNode.Scroll = (int)double.Parse(LoadAttribute(node, "scroll", "0"), System.Globalization.CultureInfo.InvariantCulture);
                        tempNode.keyText = LoadAttribute(node, "keys", "");
                        tempNode.Url = LoadAttribute(node, "url", "").Replace("https://", "").Replace("http://", "");
                        tempNode.sourcePath = System.IO.Path.GetDirectoryName(path);
                        if (tempNode.Type == "eye")
                        {
                            tempNode.Y += tempNode.Scroll;
                        }
                        if ((tempNode.X > 1 && tempNode.Y > 1))
                            result.Add(tempNode);
                    }
                }
                catch(Exception e)
                {
                    System.Windows.MessageBox.Show("____________________________\r\rFalha ao carregar XML!\r\r" + path + "\r\r" + e.ToString()+ "\r\r____________________________");
                }
            }
            return result;
        }

        public static List<Node> LoadNodes(string path, string URL)
        {
            string last_img = "";
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
                readText = File.ReadAllText(path);
                if (readText.Contains("&") && !readText.Contains("&amp;"))
                {
                    File.WriteAllText(path, readText.Replace("&", "&amp;"));
                }
                doc.Load(path);
                XmlNode current = doc.SelectSingleNode("/usertrace/trace");
                XmlNodeList list = current.ParentNode.SelectNodes(current.Name);
                foreach (XmlNode node in list)
                {
                    //<trace type="click" image="1.jpg" time="1" x="321" y="184" keys=""\>
                    Node tempNode = new Node();
                    tempNode.Type = LoadAttribute(node, "type", "click");
                    tempNode.ImgPath = LoadAttribute(node, "image", "");
                    string timeS = LoadAttribute(node, "time", "0");
                    if (timeS == "")
                        timeS = "0";
                    tempNode.Time = float.Parse(timeS, System.Globalization.CultureInfo.InvariantCulture);
                    tempNode.Id = LoadAttribute(node, "Id", "");
                    tempNode.Class = LoadAttribute(node, "Class", "");
                    tempNode.MouseId = LoadAttribute(node, "MouseId", "");
                    tempNode.MouseClass = LoadAttribute(node, "MouseClass", "");
                    tempNode.X = int.Parse(LoadAttribute(node, "X", "0"));
                    tempNode.Y = int.Parse(LoadAttribute(node, "Y", "0"));
                    tempNode.Height = int.Parse(LoadAttribute(node, "height", "768"));
                    tempNode.Scroll = int.Parse(LoadAttribute(node, "scroll", "0"));
                    tempNode.keyText = LoadAttribute(node, "keys", "");
                    tempNode.Url = LoadAttribute(node, "url", "").Replace("https://", "").Replace("http://", "");
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
                ////Console.WriteLine("erro no atributo " + attr);
                return defaultValue;
            }
        }

    }
}
