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

namespace Lades.WebTracer
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        public Stats()
        {
            InitializeComponent();
        }
        List<string> urlPaths = new List<string>();
        List<string> urlList = new List<string>();
        List<int> points = new List<int>();


        private bool AddToUrlList(string url)
        {
            for (int x = 0; x < urlList.Count; x++)
            {
                if (urlList[x] == url)
                {
                    return false;
                }
            }
            urlList.Add(url);
            return true;
        }
        private void LoadAllPoints()
        {
            for (int x = 0; x < App.CurrentTraceList.Count; x++)
            {
                List<Node> node = Node.LoadNodes(App.CurrentTraceList[x] + "\\trace.xml");
                string rota = "";
                string lastUrl = "";
                foreach (Node no in node)
                {
                    no.Url = no.Url.ToLower();
                    if (no.Url != lastUrl)
                    {
                        AddToUrlList(no.Url);
                        rota += no.Url + " - > ";
                        lastUrl = no.Url;
                    }
                }
                urlPaths.Add(rota.Remove(rota.Length-5));
            }
        }

        private void ordenador()
        {
            int major = 0;
            string pathMajor = "";
            int pos = -1;
            for (int y = points.Count - 1; y > -1; y--)
            {
                major = int.MinValue;
                for (int x = 0; x <= y; x++)
                {
                    if (major < points[x])
                    {
                        pathMajor = urlPaths[x];
                        major = points[x];
                        pos = x;
                    }
                }
                string path = urlPaths[y];
                int value = points[y];
                points[y] = major;
                urlPaths[y] = pathMajor;
                points[pos] = value;
                urlPaths[pos] = path;
            }
            //foreach (HeatPoint point in source) result.Insert(0, point);
        }


        private void Window_ContentRendered(object sender, EventArgs e)
        {
            App.stats = this;

            LoadAllPoints();

            for (int x = 0; x < urlPaths.Count; x++)
            {
                points.Add(0);
                for (int y = 0; y < urlPaths.Count; y++)
                {
                    if (urlPaths[y] == urlPaths[x] && x != y)
                    {
                        urlPaths[y] = "*_-*";
                        points[x]++;
                    }
                }
            }
            ordenador();
            List<string> toFuzzy = new List<string>();
            for (int x = points.Count-1; x>-1;x--)
            {
                if (urlPaths[x] != "*_-*")
                {
                    Ltb_freq.Items.Add("QT."+points[x]+" "+urlPaths[x]);
                    toFuzzy.Add(urlPaths[x]);
                }
            }
            
            List<string> result = FuzzySearch.Search(toFuzzy[0], toFuzzy, 0.5 );
            foreach (string item in result)
                Ltb_Levh.Items.Add(item);
        }
        public string[] urls;
        private void Ltb_freq_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string rota = Ltb_freq.SelectedItem.ToString();
            int index = rota.IndexOf(" ");
            rota = rota.Remove(0, index);
            //Console.WriteLine("rota "+rota);
            rota = rota.Replace(" - > ", "ª").Replace(" ","");
            urls = rota.Split('ª');
            MaxSelector seletor = new MaxSelector();
            seletor.ShowDialog();
        }
    }
}
