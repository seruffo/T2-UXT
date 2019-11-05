using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using EO.Wpf;
using EO.WebBrowser;

namespace EO.TabbedBrowser
{
    //WPF wrapper class that maintains various UI related information and 
    //servers as the "Data Item" for the TabItem
    internal class WebPage: DependencyObject
    {
        //The Wpf WebControl
        private EO.WebBrowser.Wpf.WebControl m_WebControl;

        //The core WebView object
        private EO.WebBrowser.WebView m_WebView;

        //The DevTools window
        private DevToolsWindow m_DevTools;

        //All messages output by the WebView
        private ObservableCollection<string> m_Messages = new ObservableCollection<string>();

        //Title property for data binding purpose. This property
        //is synced with WebView.Title
        private static readonly DependencyPropertyKey TitlePropertyKey =
            DependencyProperty.RegisterReadOnly("Title", typeof(string), typeof(WebPage), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty TitleProperty = TitlePropertyKey.DependencyProperty;

        //Favicon property for data binding purpose. This property
        //is synced with WebView.Favicon
        private static readonly DependencyPropertyKey FaviconPropertyKey =
            DependencyProperty.RegisterReadOnly("Favicon", typeof(BitmapSource), typeof(WebPage), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty FaviconProperty = FaviconPropertyKey.DependencyProperty;

        public WebPage(WebView webView)
        {
            //Create the WebControl and WebView
            m_WebControl = new EO.WebBrowser.Wpf.WebControl();
            if (webView == null)
                webView = new EO.WebBrowser.WebView();
            m_WebView = webView;
            m_WebControl.WebView = m_WebView;

            //Handle various UI related events
            m_WebView.TitleChanged += new EventHandler(m_WebView_TitleChanged);
            m_WebView.FaviconChanged += new EventHandler(m_WebView_FaviconChanged);
            m_WebView.ConsoleMessage += new ConsoleMessageHandler(m_WebView_ConsoleMessage);

            //Register the custom protocol handler
            m_WebView.RegisterResourceHandler(new SampleHandler());
        }

        void m_WebView_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            string message = string.Format("{0} line# {1}:{2}", e.Source, e.LineNumber, e.Message);
            m_Messages.Add(message);
        }

        void m_WebView_FaviconChanged(object sender, EventArgs e)
        {
            if (m_WebView.Favicon == null)
                Favicon = null;
            else
            {
                BitmapImage bitmapImage = new BitmapImage();
                using (MemoryStream ms = new MemoryStream())
                {
                    m_WebView.Favicon.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Seek(0, SeekOrigin.Begin);
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = ms;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
                Favicon = bitmapImage;
            }
        }

        void m_WebView_TitleChanged(object sender, EventArgs e)
        {
            Title = m_WebView.Title;
        }

        public EO.WebBrowser.Wpf.WebControl WebControl
        {
            get
            {
                return m_WebControl;
            }
        }

        public EO.WebBrowser.WebView WebView
        {
            get
            {
                return m_WebView;
            }
        }

        public ObservableCollection<string> Messages
        {
            get
            {
                return m_Messages;
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            private set { SetValue(TitlePropertyKey, value); }
        }

        public BitmapSource Favicon
        {
            get { return (BitmapSource)GetValue(FaviconProperty); }
            private set { SetValue(FaviconPropertyKey, value); }
        }

        public void ShowDevTools()
        {
            if (m_DevTools == null)
            {
                m_DevTools = new DevToolsWindow();
                m_DevTools.Attach(m_WebView);
                m_DevTools.Closed += m_DevTools_Closed;
            }
            m_DevTools.Show();
        }

        void m_DevTools_Closed(object sender, EventArgs e)
        {
            m_DevTools = null;
        }
    }

    //Custom Resource handler
    internal class SampleHandler : ResourceHandler
    {
        public const string SampleUrlPrefix = "sample://";
        public const string EmbeddedPageUrl = "sample://embedded_page/index.html";

        public override bool Match(Request request)
        {
            //Return true if the request Url matches our scheme. In that
            //case ProcessRequest will be called to handle the request
            return request.Url.StartsWith(SampleUrlPrefix, StringComparison.OrdinalIgnoreCase);
        }

        public override void ProcessRequest(Request request, Response response)
        {
            //Only process EmbeddedPageUrl
            if (string.Compare(request.Url, EmbeddedPageUrl, true) == 0)
            {
                //Set content type
                response.ContentType = "text/html";

                //Copy contents of EmbeddedPage.htm to the output stream
                byte[] buffer = new byte[1024];
                Stream stream = typeof(SampleHandler).Assembly.GetManifestResourceStream("EO.TabbedBrowser.EmbeddedPage.htm");
                while (true)
                {
                    int nBytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (nBytesRead <= 0)
                        break;

                    response.OutputStream.Write(buffer, 0, nBytesRead);
                }
            }
        }
    }

    //WebViewItem is a DockItem, which is an item hosted by a DockView. In this
    //sample, the main DockView (whose IsDocumentView is set to true) is used 
    //to host one or multiple WebViewItem objects, each WebViewItem hosts a 
    //WebControl, which in turn hosts a WebView
    internal class WebViewItem : DockItem
    {
        private WebPage m_Page;

        public WebViewItem(WebView webView)
        {
            m_Page = new WebPage(webView);

            //Load the WebControl into this DockItem
            Content = m_Page.WebControl;
        }

        public WebPage Page
        {
            get
            {
                return m_Page;
            }
        }

        //Override OnLoadState and OnSaveState to save the current Url in the
        //DockItem's StateData property. This property is being saved when the
        //DockContainer's SaveLayout method is called (see code in MainWindow)
        public override void OnLoadState()
        {
            m_Page.WebView.Url = (string)StateData;
        }

        public override void OnSaveState()
        {
            StateData = m_Page.WebView.Url;
        }
    }
}