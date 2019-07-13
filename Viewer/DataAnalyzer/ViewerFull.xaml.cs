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
        float time = 0;
        List<float> Times { get; set; } = new List<float>();
        float Fulltime = 0;
        int[] pos = new int[2];
        private List<HeatPoint> positions = new List<HeatPoint>();
        private List<HeatPoint> positionsFinal = new List<HeatPoint>();
        private List<HeatPoint> positionsTops = new List<HeatPoint>();
        private List<KeyGroup> keylogging = new List<KeyGroup>();

        public static bool waits = false;
        public static bool scrolls = false;
        public static bool clicks = false;
        public static bool eyes = false;
        public static List<string> firstImage = new List<string>();
        public static List<int> firstImageScroll = new List<int>();

        public bool AddToKeylogging(Node node)
        {
            if (node.keyText == "" || node.Type!="keyboard")
                return true;
            if (keylogging.Count < 1)
            {
                keylogging.Add(new KeyGroup(node));
                return true;
            }
            for(int y =0; y < keylogging.Count; y++)
            {
                if(keylogging[y].Name == node.Id)
                {
                    keylogging[y].Text.Add(node.keyText);
                    return true;
                }
            }
            keylogging.Add(new KeyGroup(node));
            return true;
        }


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
            //if (false)
            //{
            //if (value > 119)
            //{
            //    result.R = 0;
            //    result.G = 255;
            //    result.B = 0;
            //    result.A = 191;
            //    return result;
            //}
            //if (value > 79)
            //{
            //    result.R = 0;
            //    result.G = 255;
            //    result.B = 0;
            //    result.A = 191;
            //    return result;
            //}
            //if (value > 39)
            //{
            //    result.R = 255;
            //    result.G = 255;
            //    result.B = 0;
            //    return result;
            //}
            //if (value > -1)
            //{
            //    result.R = 255;
            //    result.G = 0;
            //    result.B = 0;
            //    return result;
            //}
            //}
            //else
            //{
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
            ////}
            return result;
        }

        private void LoadAllPoints(string URL)
        {
            for (int x = 0; x < App.CurrentTraceList.Count; x++)
            {
                List <HeatPoint> response = ConvertArrayToHeatPointList(App.CurrentTraceList[x] + "\\trace.xml",URL);
                Fulltime += time;
                foreach (HeatPoint point in response)
                {                    
                    positionsFinal.Add(point);
                }
            }
        }

        public double GetZ(int w)
        {
            double initial = 0;
            double value = initial = positionsFinal[w].Z;
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

        public List<Image> imgList = new List<Image>();
        int height = 0;
        private List<HeatPoint> ConvertArrayToHeatPointList(string source, string URL)
        {
            List<Node> node = Node.LoadNodes(source, URL);
            List<HeatPoint> result = new List<HeatPoint>();
            foreach (Node loaded in node)
            {

                if (loaded.Type != "keyboard")
                {
                    //Console.WriteLine("type " + loaded.Type + "X " + loaded.X + " | Y " + loaded.Y+ " | time "+ loaded.Time);
                    result.Add(new HeatPoint());
                    if (loaded.Type == "click")
                    {
                        result[result.Count - 1].Z = 1;
                        result[result.Count - 1].type = 1;
                        clickQuant++;
                    }
                    if (loaded.Type == "wheel")
                    {
                        result[result.Count - 1].Z = -2;
                        result[result.Count - 1].type = -2;
                    }
                    if (loaded.Type == "freeze")
                    {
                        result[result.Count - 1].Z = -1;
                        result[result.Count - 1].type = -1;
                        freeze += 3;
                    }
                    if (loaded.Type == "eye")
                    {
                        result[result.Count - 1].type = -3;
                        result[result.Count - 1].Z = 1;
                    }
                    result[result.Count - 1].X = loaded.X;
                    result[result.Count - 1].Y = loaded.Y;
                    Times.Add(time = loaded.Time);
                    txb_time.Text = time.ToString();
                }
                else
                {
                    AddToKeylogging(loaded);
                }
                height = Math.Max(height, loaded.Height);
            }
            return result;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            App.vieweFull = this;
        }

        public void Clean()
        {
            var images = cnv_viewer.Children.OfType<Ellipse>().ToList();
            foreach (var image in images)
            {
                cnv_viewer.Children.Remove(image);
            }
            var keys = cnv_viewer.Children.OfType<OpenKeylog>().ToList();
            foreach (var image in keys)
            {
                cnv_viewer.Children.Remove(image);
            }
            var img = cnv_images.Children.OfType<Image>().ToList();
            foreach (var image in img)
            {
                cnv_images.Children.Remove(image);
            }
            imgList.Clear();
            //App.maxClicks = 0;
            //maxPoints = 0;
            freeze = 0;
            clickQuant = 0;
            time = 0;
            Times.Clear();
            positionsFinal.Clear();
            positions.Clear();
            positionsTops.Clear();
            ViewerFull.firstImage.Clear();
            ViewerFull.firstImageScroll.Clear();
        }

        public void GenHeatmap(string URL)
        {


            //for(int h = 0; h < 100; h++)
            //{
            //    grd_viewer.Background = new SolidColorBrush(getHeat(100, h));
            //    await Task.Delay(10);
            //}
            LoadAllPoints(URL);
            img_read.Width = System.Windows.SystemParameters.WorkArea.Width;
            img_read.Height = System.Windows.SystemParameters.WorkArea.Height;
            cnv_container.Height = cnv_viewer.Height = height;
            cnv_container.Width = cnv_viewer.Width = img_read.Width;
            //Thickness pos_canvas = cnv_viewer.Margin;
            ////pos_canvas.Left = -542;
            //cnv_viewer.Margin = pos_canvas;
            scv_viewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;

            try
            {
                System.Drawing.Image img;
                int lastRes = 0;
                int imgCounter = 0;
                img = System.Drawing.Image.FromFile(ViewerFull.firstImage[0]);
                img_read.Width = img.Width;
                img_read.Height = img.Height;
                imgList.Add(new Image());
                imgList[imgList.Count - 1].Source = LoadBitmapImage(ViewerFull.firstImage[0]);
                lastRes = firstImageScroll[0] + img.Height;
                Thickness position_ = img_read.Margin;
                position_.Top = firstImageScroll[0];
                Console.WriteLine(ViewerFull.firstImage[0]);
                Console.WriteLine(firstImageScroll[0]);
                imgList[imgList.Count - 1].Margin = position_;
                cnv_images.Children.Add(imgList[imgList.Count - 1]);
                foreach (string image in ViewerFull.firstImage)
                {
                    try
                    {
                        Console.WriteLine("imgFound "+image);
                        if (System.IO.File.Exists(image))
                        {
                            if (firstImageScroll[imgCounter] > ((float)lastRes * 0.5f)) {
                                img = System.Drawing.Image.FromFile(image);
                                img_read.Width = img.Width;
                                img_read.Height = img.Height;
                                imgList.Add(new Image());
                                imgList[imgList.Count - 1].Source = LoadBitmapImage(image);
                                lastRes = firstImageScroll[imgCounter] + img.Height;
                                Thickness position = img_read.Margin;
                                position.Top = firstImageScroll[imgCounter];
                                Console.WriteLine(firstImageScroll[imgCounter]);
                                imgList[imgList.Count - 1].Margin = position;
                                cnv_images.Children.Add(imgList[imgList.Count - 1]);
                            }
                        }
                        imgCounter++;
                        Console.WriteLine("imgCounter " + imgCounter);
                    }
                    catch { }
                }
                for (int z = 0; z < positionsFinal.Count; z++)
                {
                    //Console.WriteLine("POINT BEF Z " + positionsFinal[z].Z);
                    positionsFinal[z].Z = GetZ(z);
                    //Console.WriteLine("POINT AFT Z " + positionsFinal[z].Z);
                }
                positionsFinal = App.ordenador(positionsFinal);
                maxPoints = positionsFinal[Math.Max(positionsFinal.Count - 1,0)].Z;
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
                    //Console.WriteLine("POINT Z " + point.Z);
                    Ellipse circle = new Ellipse();
                    Thickness position = new Thickness();
                    //MessageBox.Show(maxPoints.ToString());
                    double stage = (30 * Math.Ceiling(30 / (double)App.sizeFactor));
                    //MessageBox.Show(stage.ToString());
                    double stage2 = Math.Ceiling(stage * 0.77777777d);
                    //MessageBox.Show(stage2.ToString());
                    //MessageBox.Show("z" + point.Z);

                    double stage3 = Math.Max(0.0001, ((((double)App.sizeFactor - (Math.Abs(point.Z) - 1)) / (double)App.sizeFactor)));
                    //MessageBox.Show(stage3.ToString());
                    double size = Math.Floor(stage + (stage2 * (stage3)));
                    if (point.Z == -1)
                    {
                        //Console.WriteLine("---------------- Z -1 size " + size);
                    }
                    //MessageBox.Show(size.ToString());
                    position.Left = (int)point.X - size / 2;
                    position.Top = (int)point.Y - size / 2;
                    circle.Margin = position;
                    circle.Opacity = 1;
                    bool add = false;
                    if (eyes)
                    {
                        Txt_concentra.Content = "Gaze concentration";
                    }

                    if (eyes && point.type==-3)
                    {
                        Console.WriteLine(point.X+" "+point.Y);
                        circle.Fill = new SolidColorBrush(getHeat(maxPoints, point.Z));
                        add = true;
                    }
                    else
                    {
                        if (clicks && point.type == 1)
                        {
                            circle.Fill = new SolidColorBrush(getHeat(maxPoints, point.Z));
                            add = true;
                        }
                        else
                        {
                            if (point.Z == -1 && waits)
                            {
                                circle.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 255));
                                add = true;
                            }
                            else
                            {
                                if (point.Z == -2 && scrolls)
                                {
                                    circle.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                                    add = true;
                                }
                            }
                        }
                    }
                    circle.Height = circle.Width = size;
                    circle.HorizontalAlignment = HorizontalAlignment.Left;
                    circle.VerticalAlignment = VerticalAlignment.Top;

                    circle.OpacityMask = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/mask.png", UriKind.RelativeOrAbsolute)));
                    if (add)
                    {
                        Console.WriteLine("add  "+point.X + " " + point.Y);
                        cnv_viewer.Children.Add(circle);
                        //await Task.Delay(25);
                    }
                }
                foreach (KeyGroup grupo in keylogging)
                {
                    OpenKeylog keylogger = new OpenKeylog(grupo);
                    keylogger.Width = 25;
                    keylogger.Height = 25;
                    Thickness pos = new Thickness();
                    pos.Left = grupo.X - 35;
                    pos.Top = grupo.Y;
                    keylogger.Margin = pos;
                    cnv_viewer.Children.Add(keylogger);
                }
                txb_freeze.Text = freeze.ToString() + " S";
                txb_move.Text = (Fulltime - freeze) + " S";
                txb_click.Text = clickQuant.ToString();
                txb_time.Text = Fulltime + " S";
            }
            catch(Exception e) { MessageBox.Show(e.ToString()); }
        }
        bool firstTime = true;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (firstTime)
            {
                cnv_viewer.Visibility = Visibility.Visible;
                grd_info.Visibility = Visibility.Collapsed;
            }
            
            if(e.Key == Key.Right)
            {
                if (App.stats.index < App.stats.urls.Length)
                {
                    txb_click.Text = txb_freeze.Text = txb_move.Text = txb_time.Text = "LOADING...";
                    Clean();
                    GenHeatmap(App.stats.urls[App.stats.index]);
                    Console.WriteLine(App.stats.urls[App.stats.index]);
                    App.stats.index++;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cnv_viewer.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
