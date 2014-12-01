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


namespace Northwestern.Samples.Kinect.KinectExplorerD2D
{
    /// <summary>
    /// ClientSignIn.xaml 的交互逻辑
    /// </summary>
    public partial class ClientSignIn : Window
    {
        private Northwestern.Samples.Kinect.KinectExplorerD2D.KinectWindow kinectWindow;
        public ClientSignIn()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!usernameTB.Text.Equals("") && !PasswordBoxPB.Password.Equals("")) {
                if (usernameTB.Text.Equals("lisaliu") && PasswordBoxPB.Password.Equals("123456")) {
                    LoginBTN.Visibility = Visibility.Collapsed;
                    logoutBTN.Visibility = Visibility.Visible;
                    //this.Hide();
                    kinectWindow = new Samples.Kinect.KinectExplorerD2D.KinectWindow();
                    kinectWindow.Show();
                    this.Close();
                    //Northwestern.Samples.Kinect.KinectExplorerD2D.VideoPlayerTest videoTest = new VideoPlayerTest();
                    //videoTest.Show();
                    
                }
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong info!");
            }
        }

        private void logoutBTN_Click(object sender, RoutedEventArgs e)
        {
            //mainImage.Visibility = Visibility.Collapsed; 
            LoginBTN.Visibility = Visibility.Visible; 
            logoutBTN.Visibility = Visibility.Collapsed;
            
        }

    }
}
