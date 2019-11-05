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
using EO.WebBrowser;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for ObjectsPane.xaml
    /// </summary>
    public partial class ObjectsPane : UserControl
    {
        private WebPage m_Page;

        private class Item
        {
            private object m_Value;
            private string m_szText;
            private Item[] m_ChildItems;

            public Item(string name, object value)
            {
                m_Value = value;
                m_szText = string.Format("{0}={1}", name, m_Value);
            }

            public override string ToString()
            {
                return m_szText;
            }

            public bool MayHaveChildItems
            {
                get
                {
                    return (m_Value is JSObject) &&
                        !(m_Value is JSFunction) &&
                        !object.Equals(m_Value, JSObject.Undefined) &&
                        !object.Equals(m_Value, JSObject.Null);
                }
            }

            public Item[] ChildItems
            {
                get
                {
                    if (m_ChildItems != null)
                        return m_ChildItems;

                    if (MayHaveChildItems)
                    {
                        JSObject jsObject = (JSObject)m_Value;

                        //Get all properties of the current object
                        string[] props = jsObject.GetPropertyNames();
                        if (props != null)
                        {
                            //Get the value of each property
                            m_ChildItems = new Item[props.Length];
                            for (int i = 0; i < m_ChildItems.Length; i++)
                            {
                                string propName = props[i];
                                object propValue = jsObject[propName];
                                m_ChildItems[i] = new Item(propName, propValue);
                            }
                        }
                    }

                    if (m_ChildItems == null)
                        m_ChildItems = new Item[0];

                    return m_ChildItems;
                }
            }
        }

        public ObjectsPane()
        {
            InitializeComponent();
        }

        internal void Attach(WebPage page)
        {
            if (m_Page != null)
                m_Page.WebView.LoadCompleted -= WebView_LoadCompleted;
            m_Page = page;
            tvRoot.Items.Clear();
            if (page != null)
            {
                page.WebView.LoadCompleted += WebView_LoadCompleted;

                //Trigger it immediately in case the page has already been loaded
                WebView_LoadCompleted(this, null);
            }
        }

        void WebView_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            m_Page.WebView.QueueScriptCall(new EO.Base.Action(UpdateObjectsTree));
        }

        private void UpdateObjectsTree()
        {
            //Create a single root item pointing to the JavaScript "window" object
            if (m_Page != null)
            {
                Item[] root = new Item[] { new Item("window", m_Page.WebView.GetDOMWindow()) };
                CreateNodes(tvRoot.Items, root);
            }
        }

        private void CreateNodes(ItemCollection treeNodeItems, Item[] items)
        {
            treeNodeItems.Clear();
            for (int i = 0; i < items.Length; i++)
            {
                Item dataItem = items[i];
                EO.Wpf.TreeViewItem treeViewItem = new EO.Wpf.TreeViewItem();
                treeViewItem.Header = dataItem;
                treeViewItem.LoadChildrenOnExpand = dataItem.MayHaveChildItems;
                treeNodeItems.Add(treeViewItem);
            }
        }

        private void Item_Expanded(object sender, RoutedEventArgs e)
        {
            EO.Wpf.TreeViewItem treeViewItem = (EO.Wpf.TreeViewItem)e.OriginalSource;
            Item dataItem = (Item)treeViewItem.Header;
            treeViewItem.LoadChildrenOnExpand = false;
            CreateNodes(treeViewItem.Items, dataItem.ChildItems);
        }
    }
}
