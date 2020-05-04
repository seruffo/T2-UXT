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
        List<float> keyloggerTimes = new List<float>();
        List<Node> node = new List<Node>();
        int freeze = 0;
        int clickQuant = 0;
        float time = 0;
        int height = 0;
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
    
            img_read.Width = System.Windows.SystemParameters.WorkArea.Width;
            img_read.Height = System.Windows.SystemParameters.WorkArea.Height;
            node = Node.LoadNodes(App.CurrentTrace+"\\trace.xml");
            for(int x=0;x<node.Count;x++)
            {
                bool Analysis = false;
                if (App.singleViewMouse)
                    Analysis = (node[x].Type == "eye");
                else
                {
                    Analysis = (node[x].Type != "eye");
                    Lbl_clickLabel.Content="Gaze";
                }

                if (!File.Exists(App.CurrentTrace + "\\" + node[x].ImgPath)||Analysis)
                {
                    if(node[x].Type != "eye")
                    {
                        //Console.WriteLine("Removed " + node[x].ImgPath);
                    }
                    node.RemoveAt(x);
                    x--;
                }
            }
            node = App.ordenadorTime(node);
            foreach (Node no in node)
            {
                height = Math.Max(height, no.Height);
            }
            
            canvas.Height = height;
            Thickness pos = canvas.Margin;
            pos.Left = -542;
            canvas.Margin = pos;
            scv_viewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }
        int count = 0;
        int countLines = 0;
        int[] pos = new int[2];
        int[] oldPos = { 0, 0 };


        List<Line> line = new List<Line>();
        List<Triangle> triangle = new List<Triangle>();
        List<Label> number = new List<Label>();
        List<Ellipse> circle = new List<Ellipse>();
        List<Image> image = new List<Image>();
        string lastImg = "";
        string lastImgRemoved = "";
        string lastUrl = "";

        private void nextScene()
        {
            if (count < 0) count = 0;
            grd_info.Visibility = Visibility.Collapsed;
            if (count < node.Count)
            {
                bool clearWHENCHANGEURL = true;

                if (clearWHENCHANGEURL && lastUrl != node[count].Url)
                {
                    var lines = canvas.Children.OfType<Line>().ToList();
                    foreach (var line in lines)
                    {
                        canvas.Children.Remove(line);
                    }
                    var ellipses = canvas.Children.OfType<Ellipse>().ToList();
                    foreach (var ellipse in ellipses)
                    {
                        canvas.Children.Remove(ellipse);
                    }
                    var triangles = canvas.Children.OfType<Triangle>().ToList();
                    foreach (var triangle in triangles)
                    {
                        canvas.Children.Remove(triangle);
                    }
                    var labels = canvas.Children.OfType<Label>().ToList();
                    foreach (var label in labels)
                    {
                        canvas.Children.Remove(label);
                    }
                    lastUrl = node[count].Url;
                }

                bool placeImage = false;
                if (node[count].Type != "keyboard")
                {
                    Thickness position;
                    if (node[count].ImgPath != lastImg)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(App.CurrentTrace + "\\" + node[count].ImgPath);
                        img_read.Width = img.Width;
                        img_read.Height = img.Height;
                        image.Add(new Image());
                        ////Console.WriteLine("position " + count);
                        image[image.Count - 1].Source = LoadBitmapImage(App.CurrentTrace + "\\" + node[count].ImgPath);
                        position = img_read.Margin;
                        position.Top = node[count].Scroll;
                        image[image.Count - 1].Margin = position;
                        lastImg = node[count].ImgPath;
                        placeImage = true;
                        //Console.WriteLine("Path " + node[count].ImgPath + " top " + position.Top);
                    }
                    circle.Add(new Ellipse());
                    number.Add(new Label());
                    ////Console.WriteLine("count " + count);
                    number[number.Count - 1].Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    number[number.Count - 1].Content = count;
                    number[number.Count - 1].FontSize = 10;
                    if (node[count].Type == "click" || node[count].Type == "eye")
                    {
                        circle[circle.Count - 1].Fill = new SolidColorBrush(Color.FromArgb(64, 255, 0, 0));
                        clickQuant++;
                    }
                    if (node[count].Type == "freeze" /*trace[countLines].Contains("_lag")*/)
                    {
                        circle[circle.Count - 1].Fill = new SolidColorBrush(Color.FromArgb(64, 0, 0, 255));
                        freeze += 3;
                    }
                    if (node[count].Type == "wheel" /*trace[countLines].Contains("_Click")*/)
                    {
                        circle[circle.Count - 1].Fill = new SolidColorBrush(Color.FromArgb(64, 0, 255, 0));
                    }

                    //TRACELOG
                    time = node[count].Time;
                    txb_time.Text = time.ToString() + " S";
                    if ((node[count].X + node[count].Y) > 0)
                    {
                        pos[0] = node[count].X;
                        pos[1] = node[count].Y;
                    }
                    //////Console.WriteLine("line1 " + trace[countLines]);
                    //////Console.WriteLine(" x " + pos[0]);
                    //////Console.WriteLine("line2 " + trace[countLines + 1]);
                    //////Console.WriteLine(" y " + trace[countLines + 1].Substring(0, separador));
                    //////Console.WriteLine(" time " + trace[countLines + 1].Substring(separador + 2, trace[countLines + 1].Length - (separador + 2)));

                    circle[circle.Count - 1].Height = circle[circle.Count - 1].Width = 100;
                    //canvas_generator.Children.Add(circle);
                    //Canvas.SetLeft(circle, pos[0]);
                    //Canvas.SetTop(circle, pos[1]);
                    position = new Thickness();
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
                    line[line.Count - 1].HorizontalAlignment = HorizontalAlignment.Left;
                    line[line.Count - 1].VerticalAlignment = VerticalAlignment.Center;
                    line[line.Count - 1].Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                    ////Console.WriteLine(pos[1]);
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
                    line[line.Count - 1].StrokeThickness = 4;


                    triangle.Add(new Triangle());
                    triangle[triangle.Count - 1].SetPosition(0.5f, (float)line[triangle.Count - 1].X1, (float)line[triangle.Count - 1].Y1, (float)line[triangle.Count - 1].X2, (float)line[triangle.Count - 1].Y2);
                    triangle[triangle.Count - 1].SetAngle((float)line[triangle.Count - 1].X1, (float)line[triangle.Count - 1].X2, (float)line[triangle.Count - 1].Y1, (float)line[triangle.Count - 1].Y2);
                    try
                    {
                        canvas.Children.Add(circle[circle.Count - 1]);
                        canvas.Children.Add(number[number.Count - 1]);
                        canvas.Children.Add(triangle[triangle.Count - 1]);
                        canvas.Children.Add(line[line.Count - 1]);
                        if (placeImage)
                        {
                            canvas.Children.Add(image[image.Count - 1]);
                            Canvas.SetZIndex(image[Math.Max(image.Count - 1, 0)], -3);
                            Canvas.SetZIndex(image[image.Count - 1], -2);
                            //Canvas.SetZIndex(ret_white, -1);
                        }
                    }
                    catch
                    {
                        canvas.Children.Remove(circle[circle.Count - 1]);
                        canvas.Children.Remove(number[number.Count - 1]);
                        canvas.Children.Remove(triangle[triangle.Count - 1]);
                        canvas.Children.Remove(line[line.Count - 1]);
                        if (placeImage)
                            canvas.Children.Remove(image[image.Count - 1]);
                        nextScene();
                    }
                    for (int x = 0; x < line.Count; x++)
                    {
                        //line[x].Opacity -= 0.025;
                        triangle[x].Opacity -= 0.025;
                        number[x].Opacity -= 0.025;
                    }
                    oldPos[0] = pos[0];
                    oldPos[1] = pos[1];
                    txb_freeze.Text = freeze.ToString() + " S";
                    txb_move.Text = (time - freeze) + " S";
                    txb_click.Text = clickQuant.ToString();
                    scv_viewer.ScrollToVerticalOffset((double)node[count].Scroll);
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
                        bool canRemove = false;
                        if (lastImgRemoved != node[count].ImgPath)
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromFile(App.CurrentTrace + "\\" + node[count].ImgPath);
                            img_read.Width = img.Width;
                            img_read.Height = img.Height;
                            img_read.Source = LoadBitmapImage(App.CurrentTrace + "\\" + node[count].ImgPath);
                            Thickness position = img_read.Margin;
                            position.Top = node[count].Scroll;
                            img_read.Margin = position;
                            lastImgRemoved=node[count].ImgPath;
                            canRemove = true;
                        }
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
                        if(canRemove)
                            canvas.Children.Remove(image[image.Count - 1]);
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
                        scv_viewer.ScrollToVerticalOffset((double)node[count].Scroll);
                    }

                    catch(Exception) {
                        ////Console.WriteLine(e.ToString());
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
