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

namespace Lades.WebTracer
{
    /// <summary>
    /// Interaction logic for Viewer.xaml
    /// </summary>
    public partial class Viewer : Window
    {
        public Viewer()
        {
            InitializeComponent();
        }
        List<int> keyloggerTimes = new List<int>();
        List<Node> node = new List<Node>();
        int freeze = 0;
        int clickQuant = 0;
        int time = 0;
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

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            node = Node.LoadNodes(App.CurrentTrace + "\\trace.xml");
            img_read.Width = System.Windows.SystemParameters.WorkArea.Width;
            img_read.Height = System.Windows.SystemParameters.WorkArea.Height;
        }
        int count = 0;
        int countLines = 0;
        int[] pos = new int[2];
        int[] oldPos = { 0, 0 };

        private double getAngle(float x1, float x2, float y1, float y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;
            return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
        }
        public Point Fraction(float frac, float x1, float y1, float x2, float y2)
        {
            return new Point(x1 + frac * (x2 - x1),
                               y1 + frac * (y2 - y1));
        }
        List<Line> line = new List<Line>();
        List<Image> triangle = new List<Image>();
        List<Label> number = new List<Label>();
        List<Ellipse> circle = new List<Ellipse>();

        private void nextScene()
        {
            if (count < 0) count = 0;
            if (node[count].Type != "keyboard")
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(App.CurrentTrace + "//" + node[count].ImgPath);
                img_read.Width = img.Width;
                img_read.Height = img.Height;
                img_read.Source = LoadBitmapImage(App.CurrentTrace + "//" + node[count].ImgPath);

                circle.Add(new Ellipse());
                number.Add(new Label());
                Console.WriteLine("count " + count);
                number[number.Count-1].Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                number[number.Count - 1].Content = count;
                number[number.Count - 1].FontSize = 10;
                if (node[count].Type == "click" /*trace[countLines].Contains("_Click")*/)
                {
                    circle[circle.Count-1].Fill = new SolidColorBrush(Color.FromArgb(64, 255, 0, 0));
                    clickQuant++;
                }
                if (node[count].Type == "freeze" /*trace[countLines].Contains("_lag")*/)
                {
                    circle[circle.Count - 1].Fill = new SolidColorBrush(Color.FromArgb(64, 0, 0, 255));
                    freeze += 3;
                }

                //TRACELOG
                time = node[count].Time;
                txb_time.Text = time.ToString() + " S";
                pos[0] = node[count].X;
                pos[1] = node[count].Y;
                //Console.WriteLine("line1 " + trace[countLines]);
                //Console.WriteLine(" x " + pos[0]);
                //Console.WriteLine("line2 " + trace[countLines + 1]);
                //Console.WriteLine(" y " + trace[countLines + 1].Substring(0, separador));
                //Console.WriteLine(" time " + trace[countLines + 1].Substring(separador + 2, trace[countLines + 1].Length - (separador + 2)));

                circle[circle.Count - 1].Height = circle[circle.Count - 1].Width = 100;
                //canvas_generator.Children.Add(circle);
                //Canvas.SetLeft(circle, pos[0]);
                //Canvas.SetTop(circle, pos[1]);
                Thickness position = new Thickness();
                circle[circle.Count - 1].HorizontalAlignment = HorizontalAlignment.Left;
                circle[circle.Count - 1].VerticalAlignment = VerticalAlignment.Top;
                position.Left = pos[0] - 50;
                position.Top = pos[1] - 50;
                circle[circle.Count - 1].Margin = position;
                circle[circle.Count - 1].OpacityMask = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/mask.png", UriKind.RelativeOrAbsolute)));

                Thickness positionLabel = new Thickness();
                positionLabel.Left = pos[0];
                positionLabel.Top = pos[1];
                number[number.Count - 1].Margin = positionLabel;

                line.Add(new Line());
                line[line.Count-1].HorizontalAlignment = HorizontalAlignment.Left;
                line[line.Count - 1].VerticalAlignment = VerticalAlignment.Center;
                line[line.Count - 1].Stroke = new SolidColorBrush(Color.FromArgb(255, 14, 175, 255));
                Console.WriteLine(pos[1]);
                //if (pos[1] > 539)
                //{
                //    int original = pos[1];
                //    int tryng = pos[1] - 540;
                //    pos[1] = (tryng * 2) + 540;
                //    oldPos[1] += (Math.Abs(oldPos[1] - pos[1]));
                //}
                line[line.Count - 1].X2 = oldPos[0];
                line[line.Count - 1].Y2 = oldPos[1];
                line[line.Count - 1].X1 = pos[0];
                line[line.Count - 1].Y1 = pos[1];
                /*if (pos[1] > 539)
                    pos[1] += 100;*/
                //if()
                line[line.Count - 1].StrokeThickness = 2;


                triangle.Add(new Image());
                Thickness posi = new Thickness();
                triangle[triangle.Count-1].Width = 9;
                triangle[triangle.Count - 1].Height = 17;
                Point middle = Fraction(0.5f, (float)line[triangle.Count - 1].X1, (float)line[triangle.Count - 1].Y1, (float)line[triangle.Count - 1].X2, (float)line[triangle.Count - 1].Y2);
                double angle = getAngle((float)line[triangle.Count - 1  ].X1, (float)line[triangle.Count - 1].X2, (float)line[triangle.Count - 1].Y1, (float)line[triangle.Count - 1].Y2);
                RotateTransform rotateTransform = new RotateTransform(angle);
                triangle[triangle.Count - 1].RenderTransform = rotateTransform;
                posi.Left = (middle.X);
                posi.Top = (middle.Y - 9);
                triangle[triangle.Count - 1].Margin = posi;
                triangle[triangle.Count - 1].Source = new BitmapImage(new Uri("pack://application:,,,/triangle.png", UriKind.RelativeOrAbsolute));
                triangle[triangle.Count - 1].Opacity = 0.75;
                try
                {
                    canvas.Children.Add(circle[circle.Count-1]);
                    canvas.Children.Add(number[number.Count-1]);
                    canvas.Children.Add(triangle[triangle.Count-1]);
                    canvas.Children.Add(line[line.Count-1]);
                }
                catch
                {
                    canvas.Children.Remove(circle[circle.Count - 1]);
                    canvas.Children.Remove(number[number.Count - 1]);
                    canvas.Children.Remove(triangle[triangle.Count - 1]);
                    canvas.Children.Remove(line[line.Count - 1]);
                    nextScene();
                }
                for (int x = 0; x < line.Count; x++)
                {
                    line[x].Opacity -= 0.025;
                    triangle[x].Opacity -= 0.025;
                    number[x].Opacity -= 0.025;
                }
                oldPos[0] = pos[0];
                oldPos[1] = pos[1];
                txb_freeze.Text = freeze.ToString() + " S";
                txb_move.Text = (time - freeze) + " S";
                txb_click.Text = clickQuant.ToString();
            }
            else
            {
                if (node[count].keyText != String.Empty)
                {
                    ltb_keylogger.Items.Add(node[count].keyText);
                    keyloggerTimes.Add(time);
                    if (ltb_keylogger.Items.Count > 0)
                        ltb_keylogger.ScrollIntoView(ltb_keylogger.Items.GetItemAt(ltb_keylogger.Items.Count - 1));
                }
            }
            countLines += 2;
            count++;
        }
            
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.A)
            {
                Thickness pos = canvas.Margin;
                pos.Left--;
                canvas.Margin = pos;
            }
            if (e.Key == Key.D)
            {
                Thickness pos = canvas.Margin;
                pos.Left++;
                canvas.Margin = pos;
            }
            if (e.Key == Key.W)
            {
                Thickness pos = canvas.Margin;
                pos.Top--;
                canvas.Margin = pos;
            }
            if (e.Key == Key.S)
            {
                Thickness pos = canvas.Margin;
                pos.Top++;
                canvas.Margin = pos;
            }
            if (e.Key == Key.Right)
            {
                //try
                //{
                    nextScene();
                //}
                //catch { }

            }
            if (e.Key == Key.Left)
            {
                if (count > 0)
                {
                    try
                    {
                        count--;
                        System.Drawing.Image img = System.Drawing.Image.FromFile(App.CurrentTrace + "\\" + node[count].ImgPath);
                        img_read.Width = img.Width;
                        img_read.Height = img.Height;
                        img_read.Source = LoadBitmapImage(App.CurrentTrace + "\\" + node[count].ImgPath);


                        time = node[count].Time;
                        txb_time.Text = time.ToString() + " S";

                        if (node[count].keyText != String.Empty)
                        {
                            ltb_keylogger.Items.Add(node[count].keyText);
                            keyloggerTimes.Add(time);
                        }

                        if (node[count].Type == "click"/*trace[countLines].Contains("_Click")*/)
                        {
                            clickQuant--;
                        }
                        if (node[count].Type == "freeze")
                        {
                            freeze -= 3;
                        }
                        pos[0] = node[count].X;
                        pos[1] = node[count].Y;
                        //TRACELOG
                        if (time == keyloggerTimes[keyloggerTimes.Count - 1])
                        {
                            keyloggerTimes.RemoveAt(keyloggerTimes.Count - 1);
                            ltb_keylogger.Items.RemoveAt(ltb_keylogger.Items.Count - 1);
                        } 

                        oldPos[0] = (int)line[line.Count-1].X2;
                        oldPos[1] = (int)line[line.Count-1].Y2;
                        canvas.Children.Remove(triangle[triangle.Count-1]);
                        canvas.Children.Remove(line[line.Count-1]);
                        canvas.Children.Remove(circle[circle.Count-1]);
                        canvas.Children.Remove(number[number.Count-1]);
                        txb_freeze.Text = freeze.ToString() + " S";
                        txb_move.Text = (time - freeze) + " S";
                        txb_click.Text = clickQuant.ToString();
                        circle.RemoveAt(circle.Count - 1);
                        number.RemoveAt(number.Count - 1);
                        triangle.RemoveAt(triangle.Count - 1);
                        line.RemoveAt(line.Count - 1);
                        for (int x = 0; x < line.Count; x++)
                        {
                            line[x].Opacity += 0.025;
                            triangle[x].Opacity += 0.025;
                            number[x].Opacity += 0.025;
                        }

                    }

                    catch(Exception) {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
    }
}
