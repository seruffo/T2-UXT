namespace Lades.WebTracer
{
    class Click
    {
        public int NodeIndex { get; set; } = 0;
        public int MouseNodeIndex { get; set; } = 0;
        public int Distance { get; set; } = 0;
        public int IdealDistance { get; set; } = 0;
        public double Time { get; set; } = 0;
        public double Delay { get; set; } = 0;
        public double FindDelay { get; set; } = 0;

        public Click(int x,int mx)
        {
            NodeIndex = x;
            MouseNodeIndex = mx;
        }
    }


}
