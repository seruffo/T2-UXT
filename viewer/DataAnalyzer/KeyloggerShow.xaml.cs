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
    /// Interaction logic for KeyloggerShow.xaml
    /// </summary>
    public partial class KeyloggerShow : Window
    {
        private KeyGroup Grupo { get; }
        public KeyloggerShow(KeyGroup grupo)
        {
            InitializeComponent();
            Grupo =grupo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = Grupo.Name;

            List<string> result = FuzzySearch.Search(Grupo.Text[0], Grupo.Text, 0.75);
            foreach (string item in result)
                Ltb_words.Items.Add(item);
        }
    }
}
