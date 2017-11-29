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
            using (var fbd = new FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    DateTime localDate = DateTime.Now;
                    NameSelector namer = new NameSelector();
                    namer.ShowDialog();
                    if(App.CurrentTrace == "")
                        App.CurrentTrace = System.IO.Path.Combine(fbd.SelectedPath, localDate.ToString().Replace("/", "-").Replace(":", "_"));
                    else
                        App.CurrentTrace = System.IO.Path.Combine(fbd.SelectedPath, App.CurrentTrace);
                    Directory.CreateDirectory(App.CurrentTrace);
                    //MainWindow browser = new MainWindow();
                    //browser.ShowDialog();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);
                        App.CurrentTraceFolder = fbd.SelectedPath;
                        Views views = new Views();
                        views.ShowDialog();
                    }
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
                        views.ShowDialog();
                    }
                }
            }
        }
    }
}
