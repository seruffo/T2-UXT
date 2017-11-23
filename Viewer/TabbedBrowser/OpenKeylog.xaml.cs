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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for OpenKeylog.xaml
    /// </summary>
    public partial class OpenKeylog : UserControl
    {
        public OpenKeylog(KeyGroup grupo)
        {
            InitializeComponent();
            this.grupo = grupo;
        }
        KeyloggerShow shower;
        KeyGroup grupo;
        private void Cmd_open_Click(object sender, RoutedEventArgs e)
        {
            KeyloggerShow show = new KeyloggerShow(grupo);
            show.ShowDialog();
        }
    }
}
