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
    /// Interaction logic for FuzzySelector2.xaml
    /// </summary>
    public partial class FuzzySelector2 : Window
    {
        public FuzzySelector2()
        {
            InitializeComponent();
        }

        private void Cmd_start_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentTraceList.Clear();
            var paths = Txt_tracepaths.Text.Split(
    new[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
);
            foreach (string item in paths)
            {
                //MessageBox.Show(item);
                App.CurrentTraceList.Add(item);
            }
            DataFuzzy stats = new DataFuzzy();
            stats.ShowDialog();
        }
    }
}
