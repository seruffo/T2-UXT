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
            ViewerFull.clicks = false;
            ViewerFull.scrolls = false;
            ViewerFull.waits = false;
            ViewerFull.eyes = false;
        }

        private void Cmd_set_Click(object sender, RoutedEventArgs e)
        {
            App.maxClicks = Convert.ToInt32(lbl_max.Text);
            App.sizeFactor = Convert.ToInt32(lbl_size.Text);
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ViewerFull.clicks = true;
        }

        private void Chk_scrolls_Checked(object sender, RoutedEventArgs e)
        {
            ViewerFull.scrolls = true;
        }

        private void Chk_waits_Checked(object sender, RoutedEventArgs e)
        {
            ViewerFull.waits = true;
        }

        private void Chk_clicks_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewerFull.clicks = false;
        }

        private void Chk_scrolls_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewerFull.scrolls = false;
        }

        private void Chk_waits_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewerFull.waits = false;
        }

        private void Chk_gaze_Checked(object sender, RoutedEventArgs e)
        {
            ViewerFull.eyes = true;
        }

        private void Chk_gaze_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewerFull.eyes = false;
        }
    }
}
