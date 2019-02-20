using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lades.WebTracer
{

    /*
                         triangle.Add(new Image());
                    Thickness posi = new Thickness();
                    triangle[triangle.Count - 1].Width = 9;
                    triangle[triangle.Count - 1].Height = 17;
                    Point middle = Fraction(0.5f, (float)line[triangle.Count - 1].X1, (float)line[triangle.Count - 1].Y1, (float)line[triangle.Count - 1].X2, (float)line[triangle.Count - 1].Y2);
                    double angle = getAngle((float)line[triangle.Count - 1].X1, (float)line[triangle.Count - 1].X2, (float)line[triangle.Count - 1].Y1, (float)line[triangle.Count - 1].Y2);
                    RotateTransform rotateTransform = new RotateTransform(angle);
                    triangle[triangle.Count - 1].RenderTransform = rotateTransform;
                    posi.Left = (middle.X);
                    posi.Top = (middle.Y - 9);
                    triangle[triangle.Count - 1].Margin = posi;
                    triangle[triangle.Count - 1].Source = new BitmapImage(new Uri("pack://application:,,,/triangle.png", UriKind.RelativeOrAbsolute));
                    triangle[triangle.Count - 1].Opacity = 0.75;
         */

    class Triangle : System.Windows.Controls.Image
    {

        public Triangle()
        {
            this.Source = new BitmapImage(new Uri("pack://application:,,,/triangle.png", UriKind.RelativeOrAbsolute));
            this.Width = 9;
            this.Height = 17;
            this.Opacity = 0.75;
        }

        private double getAngle(float x1, float x2, float y1, float y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;
            return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
        }
        private Point Fraction(float frac, float x1, float y1, float x2, float y2)
        {
            return new Point(x1 + frac * (x2 - x1),
                               y1 + frac * (y2 - y1));
        }

        public void SetPosition(float frac, float x1, float y1, float x2, float y2)
        {
            Point middle = Fraction(frac, x1, y1,x2,y2);
            Thickness posi = new Thickness();
            posi.Left = (middle.X);
            posi.Top = (middle.Y - 9);
            this.Margin = posi;
        }

        public void SetAngle(float x1, float x2, float y1, float y2)
        {
            double angle = getAngle(x1, x2, y1, y2);
            RotateTransform rotateTransform = new RotateTransform(angle);
            this.RenderTransform = rotateTransform;
        }

    }
}
