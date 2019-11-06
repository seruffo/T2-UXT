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
        float Fulltime = 0;
        int[] pos = new int[2];


        public static bool waits = false;
        public static bool scrolls = false;
        public static bool clicks = false;
        public static bool eyes = false;
        public static bool move = true;
        public static List<string> Image = new List<string>();
        public static List<int> ImageScroll = new List<int>();
        private List<HeatPoint> positions = new List<HeatPoint>();
        private List<KeyGroup> keylogging = new List<KeyGroup>();
        List<float> Times { get; set; } = new List<float>();

        public bool AddToKeylogging(Node node)
        {
            if (node.keyText == "" || node.Type != "keyboard")
                return true;
            if (keylogging.Count < 1)
            {
                keylogging.Add(new KeyGroup(node));
                return true;
            }
            for (int y = 0; y < keylogging.Count; y++)
            {
                if (keylogging[y].Name == node.Id)
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

        private void LoadAllPoints(string URL)
        {
            for (int x = 0; x < App.CurrentTraceList.Count; x++)
            {
                List<HeatPoint> response = LoadHeatPointList(App.CurrentTraceList[x] + "\\trace_2.xml", URL);
                Fulltime += time;
                foreach (HeatPoint point in response)
                {
                    positions.Add(point);
                }
            }
        }

        public double GetZ(int w)
        {
            double initial = 0;
            double value = initial = positions[w].Z;
            if (value < 0)
                return value;
            for (int z = 0; z < positions.Count; z++)
            {
                if (positions[w] != positions[z])
                {
                    for (int x = -30; x < 30; x++)
                    {
                        for (int y = -30; y < 30; y++)
                        {
                            HeatPoint last = null;
                            if ((positions[w].X + x == positions[z].X) && (positions[w].Y + y == positions[z].Y) && (positions[z] != last) && (positions[z].Z > -1))
                            {
                                value++;
                                last = positions[z];
                            }
                        }
                    }
                }
            }
            return value;
        }

        int height = 0;
        private List<HeatPoint> LoadHeatPointList(string source, string URL)
        {
            List<Node> node = Node.LoadNodes(source, URL);
            List<HeatPoint> result = new List<HeatPoint>();
            if (node.Count > 0)
            {
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
                            //result[result.Count - 1].Z = -2;
                            result[result.Count - 1].type = -2;
                        }
                        if (loaded.Type == "freeze")
                        {
                            //result[result.Count - 1].Z = -1;
                            result[result.Count - 1].type = -3;
                            freeze += 3;
                        }
                        if (loaded.Type == "eye")
                        {
                            result[result.Count - 1].type = -4;
                            //result[result.Count - 1].Z = 1;
                        }
                        if (loaded.Type == "move")
                        {
                            result[result.Count - 1].type = -5;
                            //result[result.Count - 1].Z = 1;
                        }


                        result[result.Count - 1].Z = 1;

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
            }
            return result;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            App.vieweFull = this;
        }

        public void Clean()
        {
            ImagesCode = "";
            pointData = "data = [";
            keyloggerCode = "";
            Image = new List<string>();
            ImageScroll = new List<int>();
            positions = new List<HeatPoint>();
            keylogging = new List<KeyGroup>();
            Times = new List<float>();
        }

        string ImagesCode = "";
        string pointData = "data = [";
        string keyloggerCode = "";

        public bool AddHeatPoint(double X, double Y, double Z)
        {
            pointData += "[" + X + "," + Y + "," + Z + "],";
            return true;
        }

        public bool AddKeylogger(KeyGroup kg)
        {
            keyloggerCode += "\n<button id=\""+kg.Name+"\" style=\"position: absolute; top: "+ kg.Y+ "px; left: "+ kg.X+ "px\" onclick=\"alert('"+ kg.GetText()+ "'); \">K</button>";
            return true;
        }

        public void EndPointData()
        {
            pointData += "];\n";
        }

        public bool AddImage(string path, int vscroll, int hscroll)
        {
            string uri = path;
            ImagesCode += "<img src =\"" + uri + "\" style=\"width: 100%; position: absolute;top:" + vscroll + "px; left:" + hscroll + "px;\">\n";
            return true;
        }
        int previndex = 0;
        int nextindex = 0;
        public void GenHeatmap(string URL, int index, int maxIndex)
        {
            if (index > 0){
                previndex = index-1;
            }
            if (index != maxIndex)
            {
                nextindex = index+1;
            }
            else
            {
                nextindex = index;
            }

            //for(int h = 0; h < 100; h++)
            //{
            //    grd_viewer.Background = new SolidColorBrush(getHeat(100, h));
            //    await Task.Delay(10);
            //}
            LoadAllPoints(URL);
            //Thickness pos_canvas = cnv_viewer.Margin;
            ////pos_canvas.Left = -542;
            //cnv_viewer.Margin = pos_canvas

            //GENERATE BACKGROUND
            try
            {
                
                double lastRes = 0;
                for(int x=0;x<Image.Count;x++)
                {
                    try
                    {
                        if (System.IO.File.Exists(Image[x]))
                        {
                            Console.WriteLine("imgFound " + Image[x]);
                            if (ImageScroll[x] >= lastRes)
                            {
                                System.Drawing.Image img;
                                img = System.Drawing.Image.FromFile(Image[x]);
                                lastRes = ImageScroll[x] + ((double)img.Height*0.4d);
                                Console.WriteLine(ImageScroll[x]);
                                AddImage(Image[x], ImageScroll[x], 0);
                                Console.WriteLine("Added do Background " + Image[x]+" Height "+ ImageScroll[x]);
                            }
                        }
                    }
                    catch { }
                }
                //for (int z = 0; z < positionsFinal.Count; z++)
                //{
                //    //Console.WriteLine("POINT BEF Z " + positionsFinal[z].Z);
                //    positionsFinal[z].Z = GetZ(z);
                //    //Console.WriteLine("POINT AFT Z " + positionsFinal[z].Z);
                //}
                //positionsFinal = App.ordenador(positionsFinal);
                //maxPoints = positionsFinal[Math.Max(positionsFinal.Count - 1, 0)].Z;
                //if (App.maxClicks > 0)
                //{
                //    maxPoints = App.maxClicks;
                //}
                //lbl_max.Content = maxPoints;
                //lbl_mid.Content = Math.Ceiling(maxPoints / 2);
                //lbl_mid2.Content = Math.Ceiling(maxPoints / 4);
                //lbl_mid3.Content = Math.Ceiling((maxPoints / 4) * 3);
                foreach (HeatPoint point in positions)
                {
                    if (ViewerFull.clicks && point.type == 1)
                        AddHeatPoint(point.X, point.Y, point.Z);
                    if (ViewerFull.scrolls && point.type == -2)
                        AddHeatPoint(point.X, point.Y, point.Z);
                    if (ViewerFull.waits && point.type == -3)
                        AddHeatPoint(point.X, point.Y, point.Z);
                    if (ViewerFull.eyes && point.type == -4)
                        AddHeatPoint(point.X, point.Y, point.Z);
                    if (ViewerFull.move && point.type == -5)
                        AddHeatPoint(point.X, point.Y, point.Z);
                }
                EndPointData();

                Console.WriteLine("keylogging count " + keylogging.Count);
                foreach (KeyGroup grupo in keylogging)
                {
                    AddKeylogger(grupo);
                }

                string heatcode = "<!DOCTYPE html>\n" +
                "<html>\n" +
                "<head>\n" +
                "<meta charset=\"UTF-8\">\n<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"/>\n" +
                "</head>\n" +
                "<body style=\"margin: 0 !important;\">\n" +
                "    <div id=\"container\" style=\"width: \n" + System.Windows.SystemParameters.WorkArea.Width + "px; height: \n" + height + "px; position: relative;\">\n" +
                ImagesCode +
                        "        \n<canvas id=\"plotter\" width=\"\n" + System.Windows.SystemParameters.WorkArea.Width + "\" height=\"\n" + height + "\" style=\"width: \n" + System.Windows.SystemParameters.WorkArea.Width + "px; height: \n" + height + "px; position: absolute; opacity: 75%;\"></canvas>\n" +
                keyloggerCode +
                "\n<button id=\"previous\" style=\"position: absolute; top: 0px; left: 45%\" onclick=\"previous();\">PREVIOUS</button>" +
                "\n<button id=\"previous\" style=\"position: absolute; top: 0px; left: 55%\" onclick=\"next();\">  NEXT  </button>" +
                        "\n    </div>\n" +
                        "    <script>\n" +
                "\nfunction previous()\n"+
                "{\n"+
                "\n    window.location.href = 'trace_2_" + previndex + ".html';" +
                "\n}"+
                "\nfunction next()\n" +
                "{\n" +
                "\n    window.location.href = 'trace_2_" + nextindex + ".html';" +
                "\n}\n" +
                 "   document.onkeydown = checkKey;  \n" +
                 "     " +
                 "   function checkKey(e) {  \n" +
                 "     " +
                 "       e = e || window.event;  \n" +
                 "     " +
                 "       if (e.keyCode == '37') \n{\n  " +
                 "          previous();\n" +
                 "       }\n  " +
                 "       else if (e.keyCode == '39') \n{\n  " +
                 "          next();\n" +
                 "       }\n  " +
                 "     " +
                 "  }\n  "+
                pointData +"\n"+
                "/*\n" +
                " (c) 2014, Vladimir Agafonkin\n" +
                " simpleheat, a tiny JavaScript library for drawing heatmaps with Canvas\n" +
                " https://github.com/mourner/simpleheat\n" +
                "*/\n" +
                "\n" +
                "(function () { \"use strict\";\n" +
                "\n" +
                "function simpleheat(canvas) {\n" +
                "    // jshint newcap: false, validthis: true\n" +
                "    if (!(this instanceof simpleheat)) { return new simpleheat(canvas); }\n" +
                "\n" +
                "    this._canvas = canvas = typeof canvas === \"string\" ? document.getElementById(canvas) : canvas;\n" +
                "\n" +
                "    this._ctx = canvas.getContext(\"2d\");\n" +
                "    this._width = canvas.width;\n" +
                "    this._height = canvas.height;\n" +
                "\n" +
                "    this._max = 1;\n" +
                "    this._data = [];\n" +
                "}\n" +
                "\n" +
                "simpleheat.prototype = {\n" +
                "\n" +
                "    defaultRadius: 25,\n" +
                "\n" +
                "    defaultGradient: {\n" +
                "        0.4: \"blue\",\n" +
                "        0.6: \"cyan\",\n" +
                "        0.7: \"lime\",\n" +
                "        0.8: \"yellow\",\n" +
                "        1.0: \"red\"\n" +
                "    },\n" +
                "\n" +
                "    data: function (data) {\n" +
                "        this._data = data;\n" +
                "        return this;\n" +
                "    },\n" +
                "\n" +
                "    max: function (max) {\n" +
                "        this._max = max;\n" +
                "        return this;\n" +
                "    },\n" +
                "\n" +
                "    add: function (point) {\n" +
                "        this._data.push(point);\n" +
                "        return this;\n" +
                "    },\n" +
                "\n" +
                "    clear: function () {\n" +
                "        this._data = [];\n" +
                "        return this;\n" +
                "    },\n" +
                "\n" +
                "    radius: function (r, blur) {\n" +
                "        blur = blur === undefined ? 15 : blur;\n" +
                "\n" +
                "        // create a grayscale blurred circle image that we\"ll use for drawing points\n" +
                "        var circle = this._circle = document.createElement(\"canvas\"),\n" +
                "            ctx = circle.getContext(\"2d\"),\n" +
                "            r2 = this._r = r + blur;\n" +
                "\n" +
                "        circle.width = circle.height = r2 * 2;\n" +
                "\n" +
                "        ctx.shadowOffsetX = ctx.shadowOffsetY = 200;\n" +
                "        ctx.shadowBlur = blur;\n" +
                "        ctx.shadowColor = \"black\";\n" +
                "\n" +
                "        ctx.beginPath();\n" +
                "        ctx.arc(r2 - 200, r2 - 200, r, 0, Math.PI * 2, true);\n" +
                "        ctx.closePath();\n" +
                "        ctx.fill();\n" +
                "\n" +
                "        return this;\n" +
                "    },\n" +
                "\n" +
                "    gradient: function (grad) {\n" +
                "        // create a 256x1 gradient that we\"ll use to turn a grayscale heatmap into a colored one\n" +
                "        var canvas = document.createElement(\"canvas\"),\n" +
                "            ctx = canvas.getContext(\"2d\"),\n" +
                "            gradient = ctx.createLinearGradient(0, 0, 0, 256);\n" +
                "\n" +
                "        canvas.width = 1;\n" +
                "        canvas.height = 256;\n" +
                "\n" +
                "        for (var i in grad) {\n" +
                "            gradient.addColorStop(i, grad[i]);\n" +
                "        }\n" +
                "\n" +
                "        ctx.fillStyle = gradient;\n" +
                "        ctx.fillRect(0, 0, 1, 256);\n" +
                "\n" +
                "        this._grad = ctx.getImageData(0, 0, 1, 256).data;\n" +
                "\n" +
                "        return this;\n" +
                "    },\n" +
                "\n" +
                "    draw: function (minOpacity) {\n" +
                "        if (!this._circle) {\n" +
                "            this.radius(this.defaultRadius);\n" +
                "        }\n" +
                "        if (!this._grad) {\n" +
                "            this.gradient(this.defaultGradient);\n" +
                "        }\n" +
                "\n" +
                "        var ctx = this._ctx;\n" +
                "\n" +
                "        ctx.clearRect(0, 0, this._width, this._height);\n" +
                "\n" +
                "        // draw a grayscale heatmap by putting a blurred circle at each data point\n" +
                "        for (var i = 0, len = this._data.length, p; i < len; i++) {\n" +
                "            p = this._data[i];\n" +
                "\n" +
                "            ctx.globalAlpha = Math.max(p[2] / this._max, minOpacity === undefined ? 0.05 : minOpacity);\n" +
                "            ctx.drawImage(this._circle, p[0] - this._r, p[1] - this._r);\n" +
                "        }\n" +
                "\n" +
                "        // colorize the heatmap, using opacity value of each pixel to get the right color from our gradient\n" +
                "        var colored = ctx.getImageData(0, 0, this._width, this._height);\n" +
                "        this._colorize(colored.data, this._grad);\n" +
                "        ctx.putImageData(colored, 0, 0);\n" +
                "\n" +
                "        return this;\n" +
                "    },\n" +
                "\n" +
                "    _colorize: function (pixels, gradient) {\n" +
                "        for (var i = 3, len = pixels.length, j; i < len; i += 4) {\n" +
                "            j = pixels[i] * 4; // get gradient color from opacity value\n" +
                "\n" +
                "            if (j) {\n" +
                "                pixels[i - 3] = gradient[j];\n" +
                "                pixels[i - 2] = gradient[j + 1];\n" +
                "                pixels[i - 1] = gradient[j + 2];\n" +
                "            }\n" +
                "        }\n" +
                "    }\n" +
                "};\n" +
                "\n" +
                "window.simpleheat = simpleheat;\n" +
                "\n" +
                "})();\n" +
                        "            window.requestAnimationFrame = window.requestAnimationFrame || window.mozRequestAnimationFrame ||\n" +
                        "                                           window.webkitRequestAnimationFrame || window.msRequestAnimationFrame;\n" +
                        "            \n" +
                        "            function get(id) {\n" +
                        "                return document.getElementById(id);\n" +
                        "            }\n" +
                        "            \n" +
                        "            var heat = simpleheat(\"plotter\").data(data),frame;\n" +
                        "            \n" +
                        "            function draw() {\n" +
                        "                console.time(\"draw\");\n" +
                        "                heat.draw();\n" +
                        "                console.timeEnd(\"draw\");\n" +
                        "                frame = null;\n" +
                        "            }\n" +
                        "            \n" +
                        "            draw();\n" +
                        "            \n" +
                        "            heat.radius("+App.heatSize+ ", " + App.heatBlur + ");\n" +
                        "                frame = frame || window.requestAnimationFrame(draw);\n" +
                        "            \n" +
                        "            </script>\n" +
                        "</body>\n" +
                        "</html>";
                if(File.Exists(System.IO.Path.GetTempPath() + "\\trace_2_" + index + ".html"))
                {
                    File.Delete(System.IO.Path.GetTempPath() + "\\trace_2_" + index + ".html");
                }
                System.IO.File.WriteAllText(System.IO.Path.GetTempPath() + "\\trace_2_"+index+".html", heatcode);
                string uriheat = "file://" + System.IO.Path.GetTempPath();
                uriheat = uriheat.Replace("\\", "/") + "trace_2_" + index + ".html";
                Console.WriteLine(uriheat);
                Clean();
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
        bool firstTime = true;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.Key == Key.Right)
            {
                if (firstTime)
                {
                    grd_info.Visibility = Visibility.Collapsed;
                    firstTime = false;
                    //}
                    //if (App.stats.index < App.stats.urls.Length)
                    //{
                    for (int x = 0; x < Math.Min(App.stats.urls.Length,10); x++)
                    {
                        txb_click.Text = txb_freeze.Text = txb_move.Text = txb_time.Text = "LOADING...";
                        GenHeatmap(App.stats.urls[x], x, App.stats.urls.Length - 1);
                        Console.WriteLine(App.stats.urls[x]);
                    }
                    string uriheat = "file://" + System.IO.Path.GetTempPath();
                    uriheat = uriheat.Replace("\\", "/") + "trace_2_0.html";

                    System.Diagnostics.Process.Start(@uriheat);
                    this.Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
