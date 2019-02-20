using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lades.WebTracer
{
    public class KeyGroup
    {
        public string Name { get; }
        public List<string> Text { get; set; } = new List<string>();
        public int X { get; set; }
        public int Y { get; set; }

        public float Time { get; set; }

        public string path { get; set; }

        public KeyGroup(Node node)
        {
            Name = node.Id;
            X = node.X;
            Y = node.Y;
            Text.Add(node.keyText);
            Time = node.Time;
            path = node.sourcePath;
        }
    }
}
