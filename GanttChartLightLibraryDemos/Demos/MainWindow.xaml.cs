﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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

namespace Demos
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

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            var firstItem = TreeView.Items[0] as TreeViewItem;
            firstItem.IsSelected = true;
        }
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = e.NewValue as TreeViewItem;
            if (selectedItem.HasItems)
            {
                var firstChildItem = selectedItem.Items[0] as TreeViewItem;
                firstChildItem.IsSelected = true;
                selectedItem.IsExpanded = true;
                return;
            }
            else
            {
                if (previousSelectedParentItem != null)
                    previousSelectedParentItem.Style = previousSelectedParentItemStyle;
                var parentItem = selectedItem.Parent as TreeViewItem;
                previousSelectedParentItem = parentItem;
                previousSelectedParentItemStyle = parentItem.Style;
                parentItem.Style = Resources["SelectedTreeViewItemParentStyle"] as Style;
                Dispatcher.BeginInvoke((Action)LoadFiles);
                Dispatcher.BeginInvoke((Action)LoadContent);
            }
        }
        private TreeViewItem previousSelectedParentItem;
        private Style previousSelectedParentItemStyle;
        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            var expandedItem = sender as TreeViewItem;
            if (!expandedItem.HasItems || !expandedItem.IsExpanded)
                return;
            expandedItem.IsSelected = true;
            foreach (TreeViewItem item in TreeView.Items)
            {
                if (item.HasItems && item.IsExpanded && item != expandedItem)
                    item.IsExpanded = false;
            }
        }

        private void TechnologyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)LoadFiles);
            Dispatcher.BeginInvoke((Action)LoadContent);
        }

        private void LoadFiles()
        {
            var fileItemCount = FilesListBox.Items.Count;
            var remainingItems = new[] { FilesListBox.Items[0], FilesListBox.Items[fileItemCount - 2], FilesListBox.Items[fileItemCount - 1] };
            var removingItems = new List<ListBoxItem>();
            foreach (ListBoxItem item in FilesListBox.Items)
            {
                if (!remainingItems.Contains(item))
                    removingItems.Add(item);
            }
            foreach (var item in removingItems)
                FilesListBox.Items.Remove(item);
            var selectedTreeViewItem = TreeView.SelectedItem as TreeViewItem;
            var selectedTreeViewParentItem = selectedTreeViewItem?.Parent as TreeViewItem;
            var selectedTechnologyItem = TechnologyComboBox?.SelectedItem as ComboBoxItem;
            if (selectedTreeViewItem == null || selectedTreeViewParentItem == null || selectedTechnologyItem == null)
                return;
            var component = selectedTreeViewParentItem.Tag as string;
            var feature = selectedTreeViewItem.Tag as string;
            var technology = selectedTechnologyItem.Tag as string;
            var isSilverlight = technology.StartsWith("Silverlight");
            var isVisualBasic = technology.EndsWith("VisualBasic");
            string[] fileItems = null;
            switch (component)
            {
                case "GanttChartDataGrid":
                    switch (feature)
                    {
                        case "MainFeatures":
                            fileItems = new[] {
                                "Main" + (!isSilverlight ? "Window" : "Page") + ".xaml",
                                "Main" + (!isSilverlight ? "Window" : "Page") + ".xaml" + (!isVisualBasic ? ".cs" : ".vb")
                            };
                            break;
                    }
                    break;
                case "GanttChartView":
                    break;
                case "ScheduleChartDataGrid":
                    break;
                case "ScheduleChartView":
                    break;
                case "LoadChartDataGrid":
                    break;
                case "LoadChartView":
                    break;
                case "PertChartView":
                    break;
                case "NetworkDiagramView":
                    break;
            }
            if (fileItems == null)
                return;
            int index = 1;
            foreach (var fileItem in fileItems)
                FilesListBox.Items.Insert(index++, new ListBoxItem { Content = fileItem, Tag = fileItem });
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)LoadContent);
        }

        private void FilesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)LoadContent);
        }

        private void LoadContent()
        {
            var selectedFileItem = FilesListBox.SelectedItem as ListBoxItem;
            if (selectedFileItem == null || selectedFileItem.Visibility != Visibility.Visible)
            {
                var runListBoxItem = FilesListBox.Items[0] as ListBoxItem;
                FilesListBox.SelectedIndex = runListBoxItem.Visibility == Visibility.Visible ? 0 : 1;
                return;
            }
            var selectedFileUrl = selectedFileItem.Tag as string;
            if (selectedFileUrl == null)
            {
                if (containerWindow != null)
                    containerWindow.Close();
                var selectedThemeItem = ThemeComboBox.SelectedItem as ComboBoxItem;
                var theme = selectedThemeItem?.Tag as string;
                containerWindow = new WPF.CSharp.GanttChartDataGrid.MainFeatures.MainWindow(theme);
                ContentPresenter.Content = containerWindow.Content;
                ContentPresenter.Visibility = Visibility.Visible;
                ContentTextBox.Visibility = Visibility.Hidden;
                ContentTextBox.Text = null;
            }
            else
            {
                try
                {
                    var resourceStreamInfo = Application.GetResourceStream(new Uri("/Samples.Resources/WPF-CSharp/GanttChartDataGrid/MainFeatures/" + selectedFileItem.Tag, UriKind.Relative));
                    using (var resourceStreamReader = new StreamReader(resourceStreamInfo.Stream))
                    {
                        ContentTextBox.Text = resourceStreamReader.ReadToEnd();
                    }
                }
                catch (IOException) { }
                ContentTextBox.Visibility = Visibility.Visible;
                ContentPresenter.Visibility = Visibility.Hidden;
                ContentPresenter.Content = null;
            }
        }

        private Window containerWindow;

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (containerWindow != null)
                containerWindow.Close();
        }
    }
}
