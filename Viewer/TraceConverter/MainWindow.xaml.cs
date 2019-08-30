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
        string finalFile = "TIPO;TEMPO;X;Y;URL\n";
        string click = "";
        string move = "";
        string scroll = "";
        string freeze = "";
        string eye = "";

        public static List<Node> ordenadorTime(List<Node> source)
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
                    allNodes = Node.LoadNodes(Txt_input.Text, true);
                    List<Node> ordenados = ordenadorTime(allNodes);
                    allNodes = ordenados;
                    Pgb_progrress.Maximum = allNodes.Count;
                    Pgb_progrress.Minimum = 0;
                    string separator = Txt_separator.Text;
                    foreach (Node node in allNodes)
                    {
                        counter++;
                        string line = node.Type + separator + node.Time + separator + node.X + separator + node.Y + separator + node.Url + "\n";
                        Updater(line, counter);
                        Txt_log.Text += line;
                        Txt_log.Text += line;
                        if (node.Type == "click")
                        {
                            click += line;
                        }
                        if (node.Type == "move")
                        {
                            move += line;
                        }
                        if (node.Type == "wheel")
                        {
                            scroll += line;
                        }
                        if (node.Type == "freeze")
                        {
                            freeze += line;
                        }
                        if (node.Type == "eye")
                        {
                            eye += line;
                        }
                    }
                    finalFile += click + move + scroll + freeze + eye;
                    Updater("Writing " + Txt_input.Text + "\\trace.csv...", counter);
                    System.IO.File.WriteAllText(Txt_input.Text + "\\trace.csv", finalFile);
                    Updater("_________DONE______________",counter);
                }
            }
            catch(Exception ex)
            {
                Updater("Error converting file",0);
                Updater(ex.Message,0);
            }
        }
    }
}
