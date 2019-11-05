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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for ConsolePane.xaml
    /// </summary>
    public partial class ConsolePane : UserControl
    {
        private WebPage m_Page;

        public ConsolePane()
        {
            InitializeComponent();
        }

        internal void Attach(WebPage page)
        {
            m_Page = page;
            lstOutput.ItemsSource = page.Messages;
            txtScript.Text = string.Empty;
        }

        private void txtScript_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string script = txtScript.Text;
                try
                {
                    //Evaluate the JavaScript code and display the result
                    object result = m_Page.WebView.EvalScript(script, true);
                    if (result == null)
                        m_Page.Messages.Add("Failed to evaluate script. Script engine is not ready. Please try again later.");
                    else
                        m_Page.Messages.Add(result.ToString());
                }
                catch (Exception ex)
                {
                    m_Page.Messages.Add("An exception occured, exception message:" + ex.Message);
                }

                txtScript.SelectAll();
            }
        }

        private void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!object.Equals(e.OriginalSource, txtScript))
                txtScript.Focus();
        }
    }
}
