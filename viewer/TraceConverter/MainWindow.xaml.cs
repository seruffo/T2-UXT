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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using Lades.WebTracer;

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


                    if ((source[x].Type == "click"))
                    {
                        source[x].Time += 0.2f;
                    }
                    if ((source[x].Type == "keyboard"))
                    {
                        source[x].Time += 0.2f;
                    }
                    if (Convert.ToSingle(source[x].Time.ToString()) < timer)
                    {
                        //System.Windows.MessageBox.Show(source[x].Type + " " + source[x].Time/1.0001 + " test time " + timer/1.0001);
                        source[x].Time += 0.1f;
                        if (Convert.ToSingle(source[x].Time.ToString()) < timer)
                        {
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
                                System.Windows.MessageBox.Show("str1" + str1 + "\nstr2" + str2 + "\nstr3" + str3);
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
                Updater("Stage 2 | Sorting " + source[y].Time, source.Count-y);

            }
            //foreach (HeatPoint point in source) result.Insert(0, point);
            return source;
        }

        private void Cmd_convert_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (System.IO.Directory.Exists(fbd.SelectedPath))
                    {
                        Txt_input.Text = fbd.SelectedPath;
                        //Updater(File.ReadLines(Txt_input.Text).Count() + " lines.",0);
                        Cmd_FIRE.IsEnabled = true;
                    }                  
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Updater(string text, int prg)
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
        }

        public void ForceUpdate(UIElement element)
        {
            Action EmptyDelegate = delegate () { };
            element.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, EmptyDelegate);
        }
        int counter = 0;
        private void Cmd_FIRE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (System.IO.Directory.Exists(Txt_input.Text))
                {
                    counter = 0;
                    Updater("Converting " + Txt_input.Text + "\\trace.xml...", counter);
                    allNodes = Node.LoadNodes(Txt_input.Text, false);
                    Pgb_progrress.Maximum = allNodes.Count;
                    Pgb_progrress.Minimum = 0;
                    List<Node> ordenados = Cleaner(allNodes,1);
                    Pgb_progrress.Maximum = ordenados.Count;
                    ordenados = ordenadorTime(ordenados);
                    //ordenados = Cleaner(allNodes, 2);
                    Pgb_progrress.Maximum = ordenados.Count;
                    allNodes = ordenados;
                    separator = Txt_separator.Text;
                    load.SetValue("Separator", separator);
                    using (StreamWriter writerTracer = new StreamWriter(Txt_input.Text + "\\trace_2.xml"))
                    {
                        foreach (Node node in allNodes)
                        {
                            counter++;
                            string line = node.Type + separator + node.Time + separator + node.X + separator + node.Y + separator + node.Url;
                            Updater("Stage 4 | Writing " + counter + " " + line, counter);
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
                    using (StreamWriter writer = new StreamWriter(Txt_input.Text + "\\trace.csv"))
                    {
                        writer.Write("TIPO" + separator + "TEMPO" + separator + "X" + separator + "Y" + separator + "URL\n");
                        foreach (Node node in allNodes)
                        {
                            counter++;
                            string line = node.Type + separator + node.Time + separator + node.X + separator + node.Y + separator + node.Url;
                            Updater("Stage 4 | Writing "+ counter +" "+ line, counter);
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
                    Updater("Writing " + Txt_input.Text + "\\trace.csv...", counter);
                    Updater("_________DONE______________", counter);
                    //Updater(File.ReadLines(Txt_input.Text + "\\trace.xml").Count() + " lines processed.", 0);
                }
            }
            catch(Exception ex)
            {
                Updater("Error converting file",0);
                Updater(ex.Message,0);
            }
        }
        string separator="";
        Microsoft.Win32.RegistryKey load;

        private void Wnd_traceconverter_ContentRendered(object sender, EventArgs e)
        {
           load= Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\WAVES Systems\\AIMT-UXT\\TraceConverter");
            Txt_separator.Text = (string)load.GetValue("Separator", ";");
        }
    }
}
