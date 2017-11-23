using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EO.TabbedBrowser
{
    public class KeyGroup
    {
        public string Name { get; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public KeyGroup(Node node)
        {
            Name = node.keyId;
            X = node.keyX;
            Y = node.keyY;
            Text = node.keyText;
        }
    }
}
