using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using EO.WebBrowser;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for DownloadsPane.xaml
    /// </summary>
    public partial class DownloadsPane : UserControl
    {
        public DownloadsPane()
        {
            InitializeComponent();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double colUrlWidth = lstDownloads.RenderSize.Width - 
                colFileName.ActualWidth - colTotalSize.ActualWidth - colPercentage.ActualWidth;
            if (colUrlWidth < 100)
                colUrlWidth = 100;
            colUrl.Width = colUrlWidth;
        }

        public void Bind(ObservableCollection<DownloadItem> downloads)
        {
            lstDownloads.ItemsSource = downloads;
        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (lstDownloads.SelectedIndex >= 0)
            {
                DownloadItem item = (DownloadItem)lstDownloads.SelectedItem;
                mnuOpenLocation.IsEnabled = true;
                mnuCancel.IsEnabled = (item.State == DownloadState.InProgress) || (item.State == DownloadState.Paused);
                mnuPauseResume.Header = item.State == DownloadState.Paused ? "Resume" : "Pause";
            }
            else
            {
                mnuOpenLocation.IsEnabled = false;
                mnuCancel.IsEnabled = false;
            }
        }

        private void mnuOpenLocation_Click(object sender, RoutedEventArgs e)
        {
            DownloadItem item = (DownloadItem)lstDownloads.SelectedItem;
            if (item != null)
            {
                string dir = System.IO.Path.GetDirectoryName(item.FullPath);
                System.Diagnostics.Process.Start(dir);
            }
        }

        private void mnuPauseResume_Click(object sender, RoutedEventArgs e)
        {
            DownloadItem item = (DownloadItem)lstDownloads.SelectedItem;
            if (item != null)
            {
                if (item.State == DownloadState.Paused)
                    item.Resume();
                else
                    item.Pause();
            }
        }

        private void mnuCancel_Click(object sender, RoutedEventArgs e)
        {
            DownloadItem item = (DownloadItem)lstDownloads.SelectedItem;
            if (item != null)
                item.Cancel();
        }
    }
}
