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
            ViewerFull.move = false;
        }
        public ViewerFull Target;
        private void Cmd_set_Click(object sender, RoutedEventArgs e)
        {
            Target = new ViewerFull();
            App.heatSize = ((Convert.ToSingle(lbl_size.Text)/100)*40)+10;
            App.heatBlur = ((Convert.ToSingle(lbl_blur.Text) / 100)*40)+10;
            App.realisticHeat = Rdb_heatreal.IsChecked.Value;
            Target.ShowDialog();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void Chk_moves_Checked(object sender, RoutedEventArgs e)
        {
            ViewerFull.move = true;
        }

        private void Chk_moves_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewerFull.move = false;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            lbl_blur.Text = (((App.heatBlur-10)/40d)*100).ToString();
            lbl_size.Text = (((App.heatSize - 10) / 40d) * 100).ToString();
        }
    }
}
