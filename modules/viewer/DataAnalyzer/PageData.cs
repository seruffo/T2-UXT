using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lades.WebTracer
{
    class PageData
    {
        public PageData()
        {

        }
        public int BackPages { get; set; } = 0;
        public double Distance { get; set; } = 0;
        public double DistanceToFind { get; set; } = 0;
        public double IdealDistance { get; set; } = 0;
        public int Clicks { get; set; } = 0;
        public double WaitForClick { get; set; } =0;
        public string Url { get; set; } = "";
        private float lastTime = 0;
        private float time = 0;
        public bool startCountTimer = true;

        public void SetTime(float val) { time = val; }
        public float Time
        {
            get => time;
            set
            {
                if (startCountTimer)
                {
                    lastTime = value;
                    startCountTimer = false;
                }
                else
                {
                    time += value - lastTime;
                    lastTime = value;
                }
            }
        }

        public int Acessed { get; set; } = 0;


    }
}
