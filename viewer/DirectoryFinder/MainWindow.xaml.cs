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

namespace DirectoryFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_Drop(object sender, DragEventArgs e)
        {

        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            MessageBox.Show("GRID DROP");
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            MessageBox.Show("TESTE TESTE");
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Txt_folders.Text = "";
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    Txt_folders.Text += System.IO.Path.GetDirectoryName(file) + "\n";
                }
            }
        }
    }
}
