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
    /// Interaction logic for ViewsMulti.xaml
    /// </summary>
    public partial class ViewsMulti : Window
    {
        public ViewsMulti()
        {
            InitializeComponent();
        }
        string[] directories;
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            directories = Directory.GetDirectories(App.CurrentTraceFolder);
            Ltb_traces.Items.Clear();
            foreach (string rastro in directories)
            {
                Ltb_traces.Items.Add(System.IO.Path.GetFileNameWithoutExtension(rastro).Replace("_", ":").Replace("-", "/"));
            }
        }

        private void Ltb_traces_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        { 
        }

        private void Ltb_traces_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                App.CurrentTraceList.Clear();
                foreach (object item in Ltb_traces.SelectedItems)
                {
                    App.CurrentTraceList.Add(directories[Ltb_traces.Items.IndexOf(item)]);
                }
                if (App.Compilation)
                {
                    MaxSelector seletor = new MaxSelector();
                    seletor.ShowDialog();
                }
                else
                {
                    Stats stats = new Stats();
                    stats.ShowDialog();
                }

            }
        }
    }
}
