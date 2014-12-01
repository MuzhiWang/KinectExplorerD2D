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

namespace Northwestern.Samples.Kinect.KinectExplorerD2D
{
    /// <summary>
    /// DataGrid.xaml 的交互逻辑
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            users.Add(new User() { Id = 4, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 5, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 6, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            users.Add(new User() { Id = 7, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 8, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 9, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            users.Add(new User() { Id = 10, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 11, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 12, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            users.Add(new User() { Id = 13, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 14, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 15, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            dgUsers.ItemsSource = users;
        }


    }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Details
        {
            get
            {
                return String.Format("{0} was born on {1} and this is a long description of the person.", this.Name, this.Birthday.ToLongDateString());
            }
        }
    }
}
