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

namespace Lades.WebTracer
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

        public KeyGroup grupo;
        private void Cmd_open_Click(object sender, RoutedEventArgs e)
        {
            //var source = App.vieweFull.img_read.Source;
            //System.Drawing.Image img = System.Drawing.Image.FromFile(grupo.path+ "\\" + grupo.Time + ".jpg");
            //App.vieweFull.img_read.Width = img.Width;
            //App.vieweFull.img_read.Height = img.Height;
            //App.vieweFull.img_read.Source = ViewerFull.LoadBitmapImage(grupo.path + "\\" + grupo.Time + ".jpg");
            KeyloggerShow show = new KeyloggerShow(grupo);
            show.ShowDialog();
            //App.vieweFull.img_read.Source = source;
        }
    }
}
