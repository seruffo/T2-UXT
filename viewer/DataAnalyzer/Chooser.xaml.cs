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
using System.Windows.Forms;
using System.IO;

namespace Lades.WebTracer
{
    /// <summary>
    /// Interaction logic for Chooser.xaml
    /// </summary>
    public partial class Chooser : Window
    {
        public Chooser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.MessageBox.Show("teste");
            using (var fbd = new FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    App.CurrentTraceFolder = fbd.SelectedPath;
                    ViewsMulti views = new ViewsMulti();
                    App.Compilation = false;
                    views.ShowDialog();
                }
            }
        }
        string lastPath = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();


                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    App.CurrentTraceFolder = fbd.SelectedPath;
                    Views views = new Views();
                    views.ShowDialog();
                }
            }
        }

        private void Cmd_comp_Click_1(object sender, RoutedEventArgs e)
        {
            //System.Windows.MessageBox.Show("teste");
            using (var fbd = new FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);
                        App.CurrentTraceFolder = fbd.SelectedPath;
                        ViewsMulti views = new ViewsMulti();
                        App.Compilation = true;
                        views.ShowDialog();
                    }
                }
            }
        }

        private void Cmd_fuzzy_Click(object sender, RoutedEventArgs e)
        {
            //using (var fbd = new FolderBrowserDialog())
            //{
            //    System.Windows.Forms.DialogResult result = fbd.ShowDialog();

            //    if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            //    {
            //        App.CurrentTraceFolder = fbd.SelectedPath;
            //        FuzzySelect views = new FuzzySelect();
            //        views.ShowDialog();
            //    }
            //}

            FuzzySelector2 selector = new FuzzySelector2();
            selector.ShowDialog();
        }

        private void Cmd_tracecsv_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"traceconverter.exe");
        }

        private void Cmd_client_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"extension");
        }

        private void Cmd_server_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"server");
        }
    }
}
