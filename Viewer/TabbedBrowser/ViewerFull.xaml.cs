using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for ViewerFull.xaml
    /// </summary>
    public partial class ViewerFull : Window
    {
        public ViewerFull()
        {
            InitializeComponent();
        }
        int freeze = 0;
        int clickQuant = 0;
        int time = 0;
        int Fulltime = 0;
        int[] pos = new int[2];
        private List<HeatPoint> positions = new List<HeatPoint>();
        private List<HeatPoint> positionsFinal = new List<HeatPoint>();
        private List<HeatPoint> positionsTops = new List<HeatPoint>();
        public static BitmapImage LoadBitmapImage(string path)
        {
            string skinpath = path;
            BitmapImage IamgeSource = new BitmapImage();
            IamgeSource.BeginInit();
            IamgeSource.CacheOption = BitmapCacheOption.None;
            IamgeSource.UriCachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            IamgeSource.CacheOption = BitmapCacheOption.OnLoad;
            IamgeSource.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            if (File.Exists(skinpath))
            {
                try
                {
                    IamgeSource.UriSource = new Uri(skinpath, UriKind.Absolute);
                }
                catch
                {
                    IamgeSource.UriSource = new Uri(System.IO.Path.Combine("pack://application:,,,/", "Black.png"), UriKind.Absolute);
                }
            }
            else
            {
                try
                {
                    IamgeSource.UriSource = new Uri(System.IO.Path.Combine("pack://application:,,,/", "Black.png"), UriKind.Absolute);
                }
                catch
                {
                    //do nothing
                }

            }
            IamgeSource.EndInit();
            return IamgeSource;
        }
        private double maxPoints = 0;

        Color getHeat(double reference, double value)
        {
            Color result = new Color();

            value = Math.Min(Math.Max(0, value), reference);
            value /= reference;
            value *= 120;
            value = 120 - value;
            result.A = 255;
            if (false)
            {
                if (value > 119)
                {
                    result.R = 0;
                    result.G = 255;
                    result.B = 0;
                    result.A = 64;
                    return result;
                }
                if (value > 79)
                {
                    result.R = 0;
                    result.G = 255;
                    result.B = 0;
                    result.A = 64;
                    return result;
                }
                if (value > 39)
                {
                    result.R = 255;
                    result.G = 255;
                    result.B = 0;
                    return result;
                }
                if (value > -1)
                {
                    result.R = 255;
                    result.G = 0;
                    result.B = 0;
                    return result;
                }
            }
            else
            {
                if (value > 119)
                {
                    result.R = 0;
                    result.G = (byte)Math.Floor((255 - (((value - 120) / 40) * 255f)));
                    result.B = 255;
                    return result;
                }
                if (value > 79)
                {
                    result.R = 0;
                    result.G = 255;
                    result.B = (byte)Math.Floor((((value - 80) / 40) * 255f));
                    return result;
                }
                if (value > 39)
                {
                    result.R = (byte)Math.Floor((255 - (((value - 40) / 40) * 255f)));
                    result.G = 255;
                    result.B = 0;
                    return result;
                }
                if (value > -1)
                {
                    result.R = 255;
                    result.G = (byte)Math.Floor(((value / 40) * 255f));
                    result.B = 0;
                    return result;
                }
            }
            return result;
        }

        private void LoadAllPoints()
        {
            for (int x = 0; x < App.CurrentTraceList.Count; x++)
            {
                List <HeatPoint> response = ConvertArrayToHeatPointList(File.ReadAllLines(App.CurrentTraceList[x] + "\\trace.txt"));
                Fulltime += time;
                foreach (HeatPoint point in response)
                    positionsFinal.Add(point);
            }
        }

        public double GetZ(int w)
        {
            double value = positionsFinal[w].Z;
            if (value < 0)
                return value;
            for(int z=0;z<positionsFinal.Count;z++)
            {
                if (positionsFinal[w] != positionsFinal[z])
                {
                    for (int x = -30; x < 30; x++)
                    {
                        for (int y = -30; y < 30; y++)
                        {
                            HeatPoint last = null;
                            if((positionsFinal[w].X+x==positionsFinal[z].X)&& (positionsFinal[w].Y+y == positionsFinal[z].Y)&&(positionsFinal[z]!=last) && (positionsFinal[z].Z>-1))
                            {
                                value++;
                                last = positionsFinal[z];
                            }
                        }
                    }
                }
            }
            return value;
        }

        public int Find(string source, string pattern)
        {
            bool b = source.Contains(pattern);
            if (b)
            {
                int index = source.IndexOf(pattern);
                if (index >= 0)
                    return index;
            }
            return -1;
        }
        private List<HeatPoint> ConvertArrayToHeatPointList(string[] source)
        {
            List<HeatPoint> result = new List<HeatPoint>();
            for (int countLines = 0; countLines < source.Length; countLines += 2)
            {
                result.Add(new HeatPoint());
                if (source[countLines].Contains("_Click"))
                {
                    result[result.Count-1].X= Convert.ToInt32(source[countLines].Replace("_Click", ""));
                    result[result.Count - 1].Z = 1;
                    clickQuant++;
                }
                if (source[countLines].Contains("_lag"))
                {
                    result[result.Count - 1].X = Convert.ToInt32(source[countLines].Replace("_lag", ""));
                    result[result.Count - 1].Z = -1;
                    freeze += 3;
                }
                int separador = Find(source[countLines + 1], "||");
                time = Convert.ToInt32(source[countLines + 1].Substring(separador + 2, source[countLines + 1].Length - (separador + 2)));
                txb_time.Text = time.ToString();
                result[result.Count - 1].Y = Convert.ToInt32(source[countLines + 1].Substring(0, separador));
            }
            return result;
        }

        private List<HeatPoint> ordenador(List<HeatPoint> source)
        {
            HeatPoint major = new HeatPoint();
            int pos = -1;
            for (int y = source.Count-1; y>-1; y--)
            {
                major.Z = -2;
                for (int x = 0;x<=y; x++)
                {
                    if (major.Z < source[x].Z)
                    {
                        major.X = source[x].X;
                        major.Y = source[x].Y;
                        major.Z = source[x].Z;
                        pos = x;
                    }
                }
                HeatPoint heat = new HeatPoint();
                heat.X = source[y].X;
                heat.Y = source[y].Y;
                heat.Z = source[y].Z;
                source[y].X = major.X;
                source[y].Y = major.Y;
                source[y].Z = major.Z;
                source[pos].X = heat.X;
                source[pos].Y = heat.Y;
                source[pos].Z = heat.Z;
            }
            //foreach (HeatPoint point in source) result.Insert(0, point);
            return source;
        }

        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            //for(int h = 0; h < 100; h++)
            //{
            //    grd_viewer.Background = new SolidColorBrush(getHeat(100, h));
            //    await Task.Delay(10);
            //}
            LoadAllPoints();
            img_read.Width = System.Windows.SystemParameters.WorkArea.Width;
            img_read.Height = System.Windows.SystemParameters.WorkArea.Height;
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(App.CurrentTraceList[0] + "\\trace3.png");
                img_read.Width = img.Width;
                img_read.Height = img.Height;
                img_read.Source = LoadBitmapImage(App.CurrentTraceList[0] + "\\trace3.png");
                for (int z = 0; z < positionsFinal.Count; z++)
                {
                    positionsFinal[z].Z = GetZ(z);
                }
                positionsFinal = ordenador(positionsFinal);
                maxPoints = positionsFinal[positionsFinal.Count - 1].Z;
                if (App.maxClicks > 0)
                {
                    maxPoints = App.maxClicks;
                }
                lbl_max.Content = maxPoints;
                lbl_mid.Content = Math.Ceiling(maxPoints / 2);
                lbl_mid2.Content = Math.Ceiling(maxPoints / 4);
                lbl_mid3.Content = Math.Ceiling((maxPoints / 4) * 3);
                foreach (HeatPoint point in positionsFinal)
                {
                    Ellipse circle = new Ellipse();
                    Thickness position = new Thickness();
                    //MessageBox.Show(maxPoints.ToString());
                    double stage = (30 * Math.Ceiling(30 / maxPoints));
                    //MessageBox.Show(stage.ToString());
                    double stage2 = Math.Ceiling(stage * 0.77777777d);
                    //MessageBox.Show(stage2.ToString());
                    //MessageBox.Show("z" + point.Z);
                    double stage3 = Math.Max(0.0001,(((maxPoints - (Math.Abs(point.Z)-1)) / maxPoints)));
                    //MessageBox.Show(stage3.ToString());
                    double size = Math.Floor(stage + (stage2 * (stage3)));
                    //MessageBox.Show(size.ToString());
                    position.Left = (int)point.X - size/2;
                    position.Top = (int)point.Y - size / 2;
                    circle.Margin = position;
                    if (point.Z != -1)
                    {
                        if (point.Z == 1)
                        {
                            circle.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255));
                            circle.Opacity = 1;
                        }
                        else
                        {
                            circle.Fill = new SolidColorBrush(getHeat(maxPoints, point.Z));
                            circle.Opacity = 1;
                        }

                        //MessageBox.Show("z " + point.Z+"\nquantidade "+positionsFinal.Count);
                    }
                    else
                    {
                        circle.Fill = new SolidColorBrush(Color.FromArgb(255,255, 0, 255));
                    }
                    circle.Height = circle.Width = size;
                    circle.HorizontalAlignment = HorizontalAlignment.Left;
                    circle.VerticalAlignment = VerticalAlignment.Top;

                    circle.OpacityMask = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/mask.png", UriKind.RelativeOrAbsolute)));
                    cnv_viewer.Children.Add(circle);
                    await Task.Delay(25);
                }
                txb_freeze.Text = freeze.ToString() + " S";
                txb_move.Text = (Fulltime - freeze) + " S";
                txb_click.Text = clickQuant.ToString();
                txb_time.Text = Fulltime + " S";
            }
            catch { }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
