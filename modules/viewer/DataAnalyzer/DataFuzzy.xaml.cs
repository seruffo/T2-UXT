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
using Microsoft.Win32;

namespace Lades.WebTracer
{
    /// <summary>
    /// Interaction logic for DataFuzzy.xaml
    /// </summary>
    public partial class DataFuzzy : Window
    {
        public DataFuzzy()
        {
            InitializeComponent();
        }
        List<Node> node = new List<Node>();
        List<int> clickIndex = new List<int>();
        List<float> clickWait = new List<float>();
        List<float> clickWaitFull = new List<float>();
        List<int> clickDistance = new List<int>();
        List<int> pageDistance = new List<int>();
        List<int> clickDistanceIdeal = new List<int>();
        List<PageData> page = new List<PageData>();
        List<string> urlList = new List<string>();
        List<string> urlListGeral = new List<string>();
        private int GetDistance(Node A, Node B)
        {
            int distance = 0;
            distance = (int)Math.Floor(Math.Sqrt((Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2))));
            return distance;
        }

        private void AddToList(string url)
        {
            bool add = true;
            if (urlList[urlList.Count - 1] == url)
            {
                add = false;
            }
            if (urlList.Count > 1000)
                add = false;
            if (add)
            {
                urlList.Add(url);
            }
        }
        private void AddToListGeral(string url)
        {
            bool add = true;
            if (urlListGeral[urlListGeral.Count - 1] == url)
            {
                add = false;
            }
            if (urlList.Count > 1000)
                add = false;
            if (add)
                urlListGeral.Add(url);
        }

        private int GetRightIndex(string url)
        {
            for (int x = 0; x < page.Count; x++)
            {
                if (page[x].Url == url)
                {
                    page[x].startCountTimer = true;
                    return x;
                }
            }
            page.Add(new PageData());
            page[page.Count - 1].Url = url;
            return page.Count - 1;
        }
        int pageX = 0;
        int backPages = -1;
        string printBackUp = "";
        private void Print(object text)
        {
            string result = text.ToString();
            printBackUp += "\r"+result;
            txt_analysis.Text = printBackUp;
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            try
            {
                urlListGeral.Add("");
                PageData geral = new PageData();
                PageData ideal = new PageData();
                foreach (string currentTrace in App.CurrentTraceList)
                {
                    App.CurrentTrace = currentTrace;
                    node.Clear();
                    clickIndex.Clear();
                    clickWait.Clear();
                    clickWaitFull.Clear();
                    clickDistance.Clear();
                    pageDistance.Clear();
                    clickDistanceIdeal.Clear();
                    page.Clear();
                    urlList.Clear();
                    urlList.Add("");
                    //carregar todos os nós
                    node = Node.LoadNodes(currentTrace + "\\trace.xml", true);
                    string url = "";
                    //ler nós individualmente
                    for (int x = 0; x < node.Count; x++)
                    {
                        Console.WriteLine("url " + url);
                        if (url != node[x].Url)
                        {
                            Console.WriteLine("url was equal");
                            url = node[x].Url;
                            AddToList(url);
                            AddToListGeral(url);
                            pageX = GetRightIndex(node[x].Url);
                            page[pageX].Acessed++;
                        }else
                            Console.WriteLine("url was diferent");

                        Console.WriteLine("node a " + Math.Max(x - 1, 0));
                        Console.WriteLine("node b " + x);
                        Console.WriteLine("node LIST SIZE " + node.Count);
                        Console.WriteLine("page LIST SIZE " + page.Count);
                        Console.WriteLine("current pos " + x);
                        page[pageX].Distance += GetDistance(node[Math.Max(x - 1, 0)], node[x]);
                        if (node[x].Time > 0)
                        {
                            page[pageX].Time = node[x].Time;
                            if (page[pageX].Time < 0)
                            {
                                MessageBox.Show("Negative Time detected at \r" + currentTrace);
                            }
                        }
                        if (node[x].Type == "click")
                        {
                            page[pageX].Clicks++;
                            clickIndex.Add(x);
                            clickWait.Add(0);
                            clickWaitFull.Add(0);
                            clickDistance.Add(0);
                            pageDistance.Add(0);
                            clickDistanceIdeal.Add(0);
                        }

                    }
                    //analisar cliques
                    for (int x = 0; x < clickIndex.Count; x++)
                    {
                        pageX = GetRightIndex(node[clickIndex[x]].Url);
                        int beforeClick = clickIndex[x] - 1;
                        Node clickNode = node[clickIndex[x]];
                        int waitCounter = 0;
                        while (beforeClick > -1 && node[beforeClick].MouseId == node[clickIndex[x]].MouseId && node[beforeClick].MouseClass == node[clickIndex[x]].MouseClass && node[beforeClick].Url == node[clickIndex[x]].Url && node[beforeClick].Type != "click")
                        {
                            waitCounter++;
                            clickWait[x] = node[beforeClick].Time;
                            clickNode = node[beforeClick];
                            beforeClick--;
                        }
                        if (waitCounter > 0)
                            clickWait[x] = node[clickIndex[x]].Time - clickWait[x];
                        Print("\r\r==========================");
                        Print("\rOBJECT " + node[clickIndex[x]].Id + " | " + node[clickIndex[x]].Class + "\rin " + node[clickIndex[x]].Url + "\r\rWait to Click (s): " + clickWait[x]);
                        page[pageX].WaitForClick += clickWait[x];
                        waitCounter = 0;
                        beforeClick = clickIndex[x] - 1;
                        while (beforeClick > -1 && node[beforeClick].Url == node[clickIndex[x]].Url && node[beforeClick].Type != "click")
                        {
                            waitCounter++;
                            if(node[beforeClick].MouseId == node[clickIndex[x]].MouseId && node[beforeClick].MouseClass == node[clickIndex[x]].MouseClass)
                            {
                                clickDistance[x] += GetDistance(clickNode, node[beforeClick]);
                            }
                            pageDistance[x] += GetDistance(clickNode, node[beforeClick]);
                            clickWaitFull[x] = node[beforeClick].Time;
                            clickNode = node[beforeClick];
                            beforeClick--;
                        }
                        if (waitCounter > 0)
                            clickWaitFull[x] = node[clickIndex[x]].Time - clickWaitFull[x];

                        beforeClick = clickIndex[x] - 1;
                        while (beforeClick > -1 && node[beforeClick].Url == node[clickIndex[x]].Url)
                        {
                            clickDistanceIdeal[x] = GetDistance(node[clickIndex[x]], node[beforeClick]);
                            beforeClick--;
                        }

                        Print("Time to Find (s): " + (clickWaitFull[x] - clickWait[x]));
                        Print("Total click Time (s): " + clickWaitFull[x]);
                        Print("Total distance (px): " + clickDistance[x]);
                        Print("Ideal Distance (px): " + clickDistanceIdeal[x]);
                        try
                        {
                            Print("Total/Ideal Distance: " + Math.Round((float)clickDistance[x] / clickDistanceIdeal[x], 4) + " X");
                        }
                        catch
                        { //do nothing
                        }
                        page[pageX].IdealDistance += clickDistanceIdeal[x];
                        page[pageX].DistanceToFind += pageDistance[x];
                    }

                    for (int x = 0; x < urlList.Count; x++)
                    {
                        try
                        {
                            if (urlList[x] == urlList[x - 2])
                            {
                                page[GetRightIndex(urlList[x])].BackPages++;
                            }
                            if (urlList[x] == urlList[x - 3])
                            {
                                page[GetRightIndex(urlList[x])].BackPages++;
                            }
                        }
                        catch { /*Print("Inicio da análise encontrado."); */}
                    }
                    PageData final = new PageData();
                    final.Url = page[0].Url;
                    int repeat = -1;
                    foreach (PageData samplePage in page)
                    {
                        Print("");
                        Print("");
                        Print("BY PAGE _________________________________________ ");
                        Print("");
                        Print("");
                        Print("URL: " + samplePage.Url);
                        Print("Views: " + samplePage.Acessed);
                        final.Acessed += samplePage.Acessed - 1;
                        Print("Time spent (s): " + samplePage.Time);
                        final.SetTime(final.Time + samplePage.Time);
                        Print("Clicks: " + samplePage.Clicks);
                        final.Clicks += samplePage.Clicks;
                        Print("Distance to find objects (px): " + samplePage.DistanceToFind);
                        final.DistanceToFind += samplePage.DistanceToFind;
                        Print("Total Distance (px): " + samplePage.Distance);
                        final.Distance += samplePage.Distance;
                        Print("Ideal Distance (px): " + samplePage.IdealDistance);
                        final.IdealDistance += samplePage.IdealDistance;
                        Print("Total Distance / Ideal: " + Math.Round(((float)samplePage.Distance / samplePage.IdealDistance), 4) + " X");
                        Print("Wait To Click (s): " + samplePage.WaitForClick);
                        final.WaitForClick += samplePage.WaitForClick;
                        Print("Page returns: " + samplePage.BackPages);
                        final.BackPages += samplePage.BackPages;
                        Print("");
                        Print("");
                    }
                    Print("___________________________________________________");
                    Print("");
                    Print("");

                    Print("SAMPLE DATA _______________________________________ ");
                    Print("");
                    Print("USER ID: "+System.IO.Path.GetFileNameWithoutExtension(currentTrace));
                    Print("");
                    Print("URL: " + final.Url);
                    geral.SetTime(final.Time + geral.Time);
                    Print("Time spent (s): " + final.Time);
                    //Print("Times acessed " + final.Acessed);
                    Print("Clicks: " + final.Clicks);
                    geral.Clicks += final.Clicks;
                    Print("Distance to find objects (px): " + final.DistanceToFind);
                    geral.DistanceToFind += final.DistanceToFind;
                    Print("Total Distance (px): " + final.Distance);
                    geral.Distance += final.Distance;
                    Print("Ideal Distance (px): " + final.IdealDistance);
                    geral.IdealDistance += final.IdealDistance;
                    Print("Total / Ideal Distance: " + Math.Round(((float)final.Distance / final.IdealDistance), 4) + " X");
                    Print("Wait To Click (s): " + final.WaitForClick);
                    geral.WaitForClick += final.WaitForClick;
                    Print("Page returns: " + final.BackPages);
                    geral.BackPages += final.BackPages;
                    Print("Page repeatitions: " + final.Acessed);
                    geral.Acessed += final.Acessed;
                    Print("");
                    Print("");
                    if (currentTrace.Contains("IDEAL"))
                    {
                        ideal.Url = final.Url;
                        ideal.Acessed = final.Acessed;
                        ideal.BackPages = final.BackPages;
                        ideal.Clicks = final.Clicks;
                        ideal.Distance = final.Distance;
                        ideal.IdealDistance = final.IdealDistance;
                        ideal.SetTime(final.Time);
                        ideal.WaitForClick = final.WaitForClick;
                    }
                    Print("URL TRACE __________________________________________");
                    foreach (string urls in urlList)
                    {
                        Print(urls);
                    }
                    Print("");
                    Print("");
                }
                Print("TASK DATA ______________________________________________");
                Print("");
                Print("");
                Print("Time spent (s): " + geral.Time);
                Print("Clicks: " + geral.Clicks);
                Print("Distance to find objects (px): " + geral.DistanceToFind);
                Print("Total Distance (px): " + geral.Distance);
                Print("Ideal Distance (px): " + geral.IdealDistance);
                Print("Total / Ideal Distance " + Math.Round(((float)geral.Distance / geral.IdealDistance), 4) + " X");
                Print("Wait To Click (s): " + geral.WaitForClick);
                Print("Page returns: " + geral.BackPages);
                Print("Page repeatitions: " + geral.Acessed);
                Print("");
                Print("");
                Print("TASK DATA AVERAGE______________________________________________");
                Print("");
                Print("");
                Print("Time spent (s): " + geral.Time/App.CurrentTraceList.Count);
                Print("Clicks: " + Math.Floor((float)geral.Clicks / App.CurrentTraceList.Count));
                Print("Total Distance (px): " + Math.Ceiling(geral.Distance / App.CurrentTraceList.Count));
                Print("Ideal Distance (px): " + Math.Ceiling(geral.IdealDistance / App.CurrentTraceList.Count));
                Print("Total / Ideal Distance " + Math.Round((((float)geral.Distance / App.CurrentTraceList.Count) / ((float)geral.IdealDistance / App.CurrentTraceList.Count)), 4) + " X");
                Print("Wait To Click (s): " + Math.Round((geral.WaitForClick / App.CurrentTraceList.Count), 4));
                Print("Page returns: " + Math.Floor((double)geral.BackPages / App.CurrentTraceList.Count));
                Print("Page repeatitions: " + Math.Floor((double)geral.Acessed / App.CurrentTraceList.Count));
                Print("");
                Print("");
                Print("IDEAL SAMPLE DATA______________________________________________");
                Print("");
                Print("");
                Print("Time spent (s): " + ideal.Time);
                Print("Clicks: " + ideal.Clicks);
                Print("Total Distance (px): " + ideal.Distance);
                Print("Ideal Distance (px): " + ideal.IdealDistance);
                Print("Total / Ideal Distance " + Math.Round(((float)ideal.Distance / ideal.IdealDistance), 4) + " X");
                Print("Wait To Click (s): " + ideal.WaitForClick);
                Print("Page returns: " + ideal.BackPages);
                Print("Page repeatitions: " + ideal.Acessed);
                Print("");
                Print("");

                Print("URL TRACE __________________________________________");
                foreach (string url in urlListGeral)
                {
                    Print(url);
                }
                Print("");
                Print("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Failure at " + App.CurrentTrace + "\r\r" + ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saver = new SaveFileDialog();
            saver.Filter = "Text file (*.txt)|*.txt";
            if (saver.ShowDialog() == true)
                System.IO.File.WriteAllText(saver.FileName, printBackUp.Replace("\r", "\r;"));
        }
    }
}
