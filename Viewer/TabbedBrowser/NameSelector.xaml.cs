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
    /// Interaction logic for NameSelector.xaml
    /// </summary>
    public partial class NameSelector : Window
    {
        public NameSelector()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime localDate = DateTime.Now;
            txt_name.Text = localDate.ToString().Replace("/", "-").Replace(":", "_");
        }

        private void Cmd_set_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentTrace = txt_name.Text;
            this.Close();
        }
    }
}
