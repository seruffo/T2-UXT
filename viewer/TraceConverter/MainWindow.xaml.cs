using Lades.WebTracer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TraceConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Node> allNodes = new List<Node>();
        string finalFile;
        string click = "";
        string move = "";
        string scroll = "";
        string freeze = "";
        string eye = "";
        int statuscleaner = 0;
        public List<Node> Cleaner(List<Node> source,int phase)
        {
            if (phase == 1)
            {
                float timer = 0;
                for (int x = 0; x < source.Count; x++)
                {
                    Updater("Stage 1 | Cleaning " + source[x].Time, x);


                    //if ((source[x].Type == "click"))
                    //{
                    //    source[x].Time += 0.2f;
                    //}
                    //if ((source[x].Type == "keyboard"))
                    //{
                    //    source[x].Time += 0.2f;
                    //}
                    if (Convert.ToSingle(source[x].Time.ToString()) < timer)
                    {
                        source[x].Time += 0.1f;
                        if (Convert.ToSingle(source[x].Time.ToString()) < timer)
                        {
                            Updater("_________REMOVED due bad TIME sequence: " + x,0);
                            source.RemoveAt(x);
                            x--;
                        }
                    }
                    else
                    {
                        timer = Convert.ToSingle(source[x].Time.ToString());
                    }
                }
            }
            else
            {
                for (int x = 0; x < source.Count; x++)
                {
                    try
                    {
                        string str1 = source[x - 1].Url;
                        string str2 = source[x].Url;
                        string str3 = source[x + 1].Url;
                        if (str1.Equals(str3))
                        {
                            if (!str1.Equals(str2))
                            {
                                Updater("_________REMOVED due bad URL sequence: str1" + str1 + "\nstr2" + str2 + "\nstr3" + str3, counter);
                                source.RemoveAt(x);
                                x--;
                                continue;
                            }
                        }
                        Updater("Stage 3 | Cleaning " + source[x].Url, x);
                    }
                    catch
                    {
                        Updater("Processing error", x);
                    }
                }
            }
            return source;
        }

        public List<Node> ordenadorTime(List<Node> source)
        {

                Node major = new Node();
                int pos = -1;
                for (int y = source.Count - 1; y > -1; y--)
                {
                    major.Time = -3;
                    for (int x = 0; x <= y; x++)
                    {
                        if (major.Time < source[x].Time)
                        {

                            major = source[x].Copy();
                            pos = x;
                        }
                    }
                    Node heat = source[y].Copy();
                    source[y] = major.Copy();
                    source[pos] = heat.Copy();
                    Updater("Stage 2 | Sorting " + source[y].Time, source.Count - y);
                }


            
            //foreach (HeatPoint point in source) result.Insert(0, point);
            return source;
        }

        private void Cmd_convert_Click(object sender, RoutedEventArgs e)
        {
            MultipleFiles = false;
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = (string)load.GetValue("lastPath", "");
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (System.IO.Directory.Exists(fbd.SelectedPath))
                    {
                        Txt_input.Text = fbd.SelectedPath;
                        //Updater(File.ReadLines(Txt_input.Text).Count() + " lines.",0);
                        Cmd_FIRE.IsEnabled = true;
                        load.SetValue("lastPath", fbd.SelectedPath);
                    }                  
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        string LogPath = "";

        private void Updater(string text, int prg)
        {
            Updater(text, prg, LogPath);
        }

        private void Updater(string text, int prg, string path)
        {
            statuscleaner++;
            if (statuscleaner > 50)
            {
                statuscleaner = 0;
                Txt_log.Text = "";
            }
            Txt_log.Text += "\n" + text;
            Txt_log.ScrollToEnd();
            Pgb_progrress.Value = prg;
            ForceUpdate(Txt_log);
            ForceUpdate(Pgb_progrress);
            using (StreamWriter writerTracer = File.AppendText(path + "\\convert.log"))
            {
                writerTracer.WriteLine(text);
            }
        }

        public void ForceUpdate(UIElement element)
        {
            Action EmptyDelegate = delegate () { };
            element.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, EmptyDelegate);
        }
        int counter = 0;
        private void Cmd_FIRE_Click(object sender, RoutedEventArgs e)
        {
            LogPath = Txt_input.Text;
            if (MultipleFiles)
            {
                MultipleFiles = false;
            }
            else
            {
                Fire(Txt_input.Text);
            }
        }

        public void Fire(string majorpath)
        {

            try
            {
                if (System.IO.Directory.Exists(majorpath))
                {
                    string[] subdirectoryEntries = Directory.GetDirectories(majorpath);
                    List<string[]> subsub = new List<string[]>();
                    List<string> filePaths = new List<string>();
                    List<string> filePathsOrg = new List<string>();
                    foreach (string subdirectory in subdirectoryEntries)
                    {
                        subsub.Add(Directory.GetDirectories(subdirectory));
                        foreach (string[] subpaths in subsub)
                        {
                            filePaths.Add(subsub[subsub.Count - 1][0] + "\\trace.xml");
                            //System.Windows.MessageBox.Show(subsub[subsub.Count - 1][0] + "\\trace.xml");
                        }
                    }
                    for (int x = 0; x < filePaths.Count; x++)
                    {
                        for (int y = x; y < filePaths.Count; y++)
                        {
                            FileInfo f1 = new FileInfo(filePaths[x]);
                            FileInfo f2 = new FileInfo(filePaths[y]);
                            if (f1.LastWriteTime > f2.LastWriteTime)
                            {
                                var vaga = filePaths[x];
                                filePaths[x] = filePaths[y];
                                filePaths[y] = vaga;
                            }
                        }
                    }

                    allNodes = new List<Node>();
                    float lastTime = 0;
                    foreach (string tracepath in filePaths)
                    {
                        counter = 0;
                        Updater("Converting " + majorpath + "\\trace.xml...", counter,majorpath);
                        //System.Windows.MessageBox.Show("TRACE PATH " + tracepath);
                        List<Node> newNodes = Node.LoadNodes(tracepath, false);

                        foreach (Node newnode in newNodes)
                        {
                            //newnode.Time += lastTime;
                            allNodes.Add(newnode);
                        }


                        Updater("_______ " + Node.dead + " TRACES REMOVED DUE INVALID CONDITIONS.", counter, majorpath);
                        Pgb_progrress.Maximum = allNodes.Count;
                        Pgb_progrress.Minimum = 0;
                        List<Node> ordenados = ordenadorTime(allNodes);
                        Pgb_progrress.Maximum = ordenados.Count;
                        ordenados = Cleaner(ordenados, 1);
                        ordenados = Cleaner(ordenados, 2);
                        Pgb_progrress.Maximum = ordenados.Count;
                        allNodes = ordenados;
                        separator = Txt_separator.Text;
                        load.SetValue("Separator", separator);
                        using (StreamWriter writerTracer = new StreamWriter(tracepath.Replace("trace.xml", "trace_2.xml")))
                        {
                            foreach (Node node in allNodes)
                            {
                                counter++;
                                string line = node.Type + separator + node.Time + separator + node.X + separator + node.Y + separator + node.Url;
                                Updater("Stage 4 | Writing " + counter + " " + line, counter, majorpath);
                                //Txt_log.Text += line;
                                //if (node.Type == "click")
                                //{
                                //    click += line;
                                //}
                                //if (node.Type == "move")
                                //{
                                //    move += line;
                                //}
                                //if (node.Type == "wheel")
                                //{
                                //    scroll += line;
                                //}
                                //if (node.Type == "freeze")
                                //{
                                //    freeze += line;
                                //}
                                //if (node.Type == "eye")
                                //{
                                //    eye += line;
                                //}
                                writerTracer.WriteLine(node.ToRawTrace());
                            }
                        }
                        counter = 0;
                    }
                    using (StreamWriter writer = File.AppendText(majorpath + "\\trace.csv"))
                    {
                        writer.Write("TIPO" + separator + "TEMPO" + separator + "X" + separator + "Y" + separator + "KEYS" + separator + "URL\n");
                        foreach (Node node in allNodes)
                        {
                            counter++;
                            string line = node.Type + separator + node.Time + separator + node.X + separator + node.Y + separator + node.keyText + separator + node.Url;
                            Updater("Stage 4 | Writing " + counter + " " + line, counter, majorpath);
                            //Txt_log.Text += line;
                            //if (node.Type == "click")
                            //{
                            //    click += line;
                            //}
                            //if (node.Type == "move")
                            //{
                            //    move += line;
                            //}
                            //if (node.Type == "wheel")
                            //{
                            //    scroll += line;
                            //}
                            //if (node.Type == "freeze")
                            //{
                            //    freeze += line;
                            //}
                            //if (node.Type == "eye")
                            //{
                            //    eye += line;
                            //}
                            writer.WriteLine(line);
                        }
                    }
                    //finalFile += click + move + scroll + freeze + eye;
                    Updater("Writing " + majorpath + "\\trace.csv...", counter, majorpath);
                    Updater("_________DONE______________", counter, majorpath);
                    //Updater(File.ReadLines(Txt_input.Text + "\\trace.xml").Count() + " lines processed.", 0);
                }
            }
            catch (Exception ex)
            {
                Updater("Error converting file", 0, majorpath);
                Updater(ex.Message, 0, majorpath);
                Updater(ex.StackTrace, 0, majorpath);
            }
        }
        string separator="";
        Microsoft.Win32.RegistryKey load;
        bool MultipleFiles=false;
        private void Wnd_traceconverter_ContentRendered(object sender, EventArgs e)
        {
           load= Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\WAVES Systems\\AIMT-UXT\\TraceConverter");
            Txt_separator.Text = (string)load.GetValue("Separator", ";");
            if (App.Args.Count > 0)
            {
                int x = 0;
                foreach(string path in App.Args)
                {
                    x++;
                    LogPath = path;
                    Txt_input.Text = "SAMPLE " + x + "/" + App.Args.Count + " | " + path;
                    Fire(path);
                }
            }

        }

        private void Txt_input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
