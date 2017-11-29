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
    /// Interaction logic for MaxSelector.xaml
    /// </summary>
    public partial class MaxSelector : Window
    {
        public MaxSelector()
        {
            InitializeComponent();
        }

        private void Cmd_set_Click(object sender, RoutedEventArgs e)
        {
            App.maxClicks = Convert.ToInt32(lbl_max.Text);
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                App.maxClicks = Convert.ToInt32(lbl_max.Text);
                this.Close();
            }
        }
    }
}
