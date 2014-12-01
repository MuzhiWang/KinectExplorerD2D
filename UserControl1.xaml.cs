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
using System.Collections.Generic;

namespace Northwestern.Samples.Kinect.KinectExplorerD2D
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            // Create a list to store task data.
            List<Task> taskList = new List<Task>();
            int itemsCount = 10;
            // Generate some task data and add it to the task list.
            for (int i = 1; i <= itemsCount; i++)
            {
                taskList.Add(new Task()
                {
                    Name = "Task " + i.ToString(),
                    DueDate = DateTime.Now.AddDays(i),
                    Complete = (i % 3 == 0),
                    Notes = "Task " + i.ToString() + " is due on "
                          + DateTime.Now.AddDays(i) + ". Lorum ipsum..."
                });
            }
            this.dataGrid1.ItemsSource = taskList;
        }

        // READ ONLY
        private void cbReadOnly_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
                this.dataGrid1.IsReadOnly = (bool)cb.IsChecked;
        }
        // FREEZE COLUMN
        private void cbFreezeColumn_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
            {
                if (cb.IsChecked == true)
                    this.dataGrid1.FrozenColumnCount = 1;
                else if (cb.IsChecked == false)
                    this.dataGrid1.FrozenColumnCount = 0;
            }
        }
        // HIDE COLUMN
        private void cbHideColumn_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
            {
                if (cb.IsChecked == true)
                    this.dataGrid1.Columns[0].Visibility = Visibility.Collapsed;
                else if (cb.IsChecked == false)
                    this.dataGrid1.Columns[0].Visibility = Visibility.Visible;
            }
        }
        // SELECTION MODE
        private void cbSelectionMode_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
            {
                if (cb.IsChecked == true)
                    this.dataGrid1.SelectionMode = DataGridSelectionMode.Single;
                else if (cb.IsChecked == false)
                    this.dataGrid1.SelectionMode = DataGridSelectionMode.Extended;
            }
        }
        // COLUMN OPTIONS
        private void cbColReorder_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
                this.dataGrid1.CanUserReorderColumns = (bool)cb.IsChecked;
        }
        private void cbColResize_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
                this.dataGrid1.CanUserResizeColumns = (bool)cb.IsChecked;
        }
        private void cbColSort_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
                this.dataGrid1.CanUserSortColumns = (bool)cb.IsChecked;
        }
        // SCROLL BARS VISIBILITY
        private void cbVerticalScroll_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
            {
                if (cb.IsChecked == true)
                    this.dataGrid1.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                else if (cb.IsChecked == false)
                    this.dataGrid1.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                else
                    this.dataGrid1.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }
        private void cbHorizontalScroll_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
            {
                if (cb.IsChecked == true)
                    this.dataGrid1.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                else if (cb.IsChecked == false)
                    this.dataGrid1.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                else
                    this.dataGrid1.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }

        }
        // ROW BRUSH
        private void cbAltRowBrush_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = ((ComboBox)sender).SelectedItem as ComboBoxItem;

            if (this.dataGrid1 != null)
            {
                if (cbi.Content.ToString() == "Custom")
                    this.dataGrid1.AlternatingRowBackground = new SolidColorBrush(Color.FromArgb(255, 130, 175, 200));
                else if (cbi.Content.ToString() == "Default")
                    this.dataGrid1.AlternatingRowBackground = new SolidColorBrush(Color.FromArgb(37, 233, 238, 244));
                else if (cbi.Content.ToString() == "Null")
                    this.dataGrid1.AlternatingRowBackground = null;
            }
        }
        private void cbRowBrush_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = ((ComboBox)sender).SelectedItem as ComboBoxItem;
            if (this.dataGrid1 != null)
            {
                if (cbi.Content.ToString() == "Custom")
                    this.dataGrid1.RowBackground = new SolidColorBrush(Color.FromArgb(255, 135, 185, 195));
                else if (cbi.Content.ToString() == "Default")
                    this.dataGrid1.RowBackground = new SolidColorBrush(Color.FromArgb(00, 255, 255, 255));
                else if (cbi.Content.ToString() == "Null")
                    this.dataGrid1.RowBackground = null;
            }
        }
        // HEADERS VISIBILITY
        private void cbHeaders_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = ((ComboBox)sender).SelectedItem as ComboBoxItem;
            if (this.dataGrid1 != null)
            {
                if (cbi.Content.ToString() == "All")
                    this.dataGrid1.HeadersVisibility = DataGridHeadersVisibility.All;
                else if (cbi.Content.ToString() == "Column (Default)")
                    this.dataGrid1.HeadersVisibility = DataGridHeadersVisibility.Column;
                else if (cbi.Content.ToString() == "Row")
                    this.dataGrid1.HeadersVisibility = DataGridHeadersVisibility.Row;
                else
                    this.dataGrid1.HeadersVisibility = DataGridHeadersVisibility.None;
            }

        }
        // GRIDLINES VISIBILITY
        private void cbGridLines_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = ((ComboBox)sender).SelectedItem as ComboBoxItem;
            if (this.dataGrid1 != null)
            {
                if (cbi.Content.ToString() == "All")
                    this.dataGrid1.GridLinesVisibility = DataGridGridLinesVisibility.All;
                else if (cbi.Content.ToString() == "Vertical (Default)")
                    this.dataGrid1.GridLinesVisibility = DataGridGridLinesVisibility.Vertical;
                else if (cbi.Content.ToString() == "Horizontal")
                    this.dataGrid1.GridLinesVisibility = DataGridGridLinesVisibility.Horizontal;
                else
                    this.dataGrid1.GridLinesVisibility = DataGridGridLinesVisibility.None;
            }

        }
        // CUSTOM GRIDLINES
        private void cbCustomGridLineVert_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
            {
                if (cb.IsChecked == true)
                    this.dataGrid1.VerticalGridLinesBrush = new SolidColorBrush(Colors.Blue);
                else
                    this.dataGrid1.VerticalGridLinesBrush = new SolidColorBrush(Color.FromArgb(255, 223, 227, 230));
            }
        }
        private void cbCustomGridLineHorz_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (this.dataGrid1 != null)
            {
                if (cb.IsChecked == true)
                    this.dataGrid1.HorizontalGridLinesBrush = new SolidColorBrush(Colors.Blue);
                else
                    this.dataGrid1.HorizontalGridLinesBrush = new SolidColorBrush(Color.FromArgb(255, 223, 227, 230));
            }
        }

    }
}
