using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EO.WebBrowser;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for JSPrompt.xaml
    /// </summary>
    public partial class JSPrompt : Window
    {
        public JSPrompt(JSDialogEventArgs e)
        {
            InitializeComponent();
        }

        public string Message
        {
            get
            {
                return lblMsg.Text;
            }
            set
            {
                lblMsg.Text = value;
            }
        }

        public string Value
        {
            get
            {
                return txtPrompt.Text;
            }
            set
            {
                txtPrompt.Text = value;
            }
        }
    }
}
