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
using System.Text;
using Microsoft.Win32;

namespace Northwestern.Samples.Kinect.KinectExplorerD2D
{
    /// <summary>
    /// MultiWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MultiWindow : Window
    {
        public MultiWindow()
        {
            InitializeComponent();
        }


        /******  R1C1S1  ******/
        private void r1c1s1_stop(object sender, RoutedEventArgs e)
        {
            R1C1S1.Stop();
        }
        private void r1c1s1_pause(object sender, RoutedEventArgs e)
        {
            R1C1S1.Pause();
        }
        private void r1c1s1_play(object sender, RoutedEventArgs e)
        {
            if (R1C1S1.Source == null) {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R1C1S1.Play();
            }
        }

        private void r1c1s1_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R1C1S1.Source = new Uri(openFileDialog.FileName);
                R1C1S1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
                

        }
        private void r1c1s1_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }

        /******  R1C1S2  ******/
        private void r1c1s2_stop(object sender, RoutedEventArgs e)
        {
            R1C1S2.Stop();
        }
        private void r1c1s2_pause(object sender, RoutedEventArgs e)
        {
            R1C1S2.Pause();
        }
        private void r1c1s2_play(object sender, RoutedEventArgs e)
        {
            if (R1C1S2.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R1C1S2.Play();
            }
        }

        private void r1c1s2_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R1C1S2.Source = new Uri(openFileDialog.FileName);
                R1C1S2.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r1c1s2_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }


        /******  R1C2S1  ******/
        private void r1c2s1_stop(object sender, RoutedEventArgs e)
        {
            R1C2S1.Stop();
        }
        private void r1c2s1_pause(object sender, RoutedEventArgs e)
        {
            R1C2S1.Pause();
        }
        private void r1c2s1_play(object sender, RoutedEventArgs e)
        {
            if (R1C2S1.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R1C2S1.Play();
            }
        }

        private void r1c2s1_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R1C2S1.Source = new Uri(openFileDialog.FileName);
                R1C2S1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r1c2s1_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }

        /******  R1C2S2  ******/
        private void r1c2s2_stop(object sender, RoutedEventArgs e)
        {
            R1C2S2.Stop();
        }
        private void r1c2s2_pause(object sender, RoutedEventArgs e)
        {
            R1C2S2.Pause();
        }
        private void r1c2s2_play(object sender, RoutedEventArgs e)
        {
            if (R1C2S2.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R1C2S2.Play();
            }
        }

        private void r1c2s2_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R1C2S2.Source = new Uri(openFileDialog.FileName);
                R1C2S2.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r1c2s2_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }

        /******  R1C3S1  ******/
        private void r1c3s1_stop(object sender, RoutedEventArgs e)
        {
            R1C3S1.Stop();
        }
        private void r1c3s1_pause(object sender, RoutedEventArgs e)
        {
            R1C3S1.Pause();
        }
        private void r1c3s1_play(object sender, RoutedEventArgs e)
        {
            if (R1C3S1.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R1C3S1.Play();
            }
        }

        private void r1c3s1_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R1C3S1.Source = new Uri(openFileDialog.FileName);
                R1C3S1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r1c3s1_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }


        /******  R1C3S2  ******/
        private void r1c3s2_stop(object sender, RoutedEventArgs e)
        {
            R1C3S2.Stop();
        }
        private void r1c3s2_pause(object sender, RoutedEventArgs e)
        {
            R1C3S2.Pause();
        }
        private void r1c3s2_play(object sender, RoutedEventArgs e)
        {
            if (R1C3S2.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R1C3S2.Play();
            }
        }

        private void r1c3s2_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R1C3S2.Source = new Uri(openFileDialog.FileName);
                R1C3S2.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r1c3s2_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }


        /******  R2C1S1  ******/
        private void r2c1s1_stop(object sender, RoutedEventArgs e)
        {
            R2C1S1.Stop();
        }
        private void r2c1s1_pause(object sender, RoutedEventArgs e)
        {
            R2C1S1.Pause();
        }
        private void r2c1s1_play(object sender, RoutedEventArgs e)
        {
            if (R2C1S1.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R2C1S1.Play();
            }
        }

        private void r2c1s1_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R2C1S1.Source = new Uri(openFileDialog.FileName);
                R2C1S1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r2c1s1_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }

        /******  R2C1S2  ******/
        private void r2c1s2_stop(object sender, RoutedEventArgs e)
        {
            R2C1S2.Stop();
        }
        private void r2c1s2_pause(object sender, RoutedEventArgs e)
        {
            R2C1S2.Pause();
        }
        private void r2c1s2_play(object sender, RoutedEventArgs e)
        {
            if (R2C1S2.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R2C1S2.Play();
            }
        }

        private void r2c1s2_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R2C1S2.Source = new Uri(openFileDialog.FileName);
                R2C1S2.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r2c1s2_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }


        /******  R2C2S1  ******/
        private void r2c2s1_stop(object sender, RoutedEventArgs e)
        {
            R2C2S1.Stop();
        }
        private void r2c2s1_pause(object sender, RoutedEventArgs e)
        {
            R2C2S1.Pause();
        }
        private void r2c2s1_play(object sender, RoutedEventArgs e)
        {
            if (R2C2S1.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R2C2S1.Play();
            }
        }

        private void r2c2s1_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R2C2S1.Source = new Uri(openFileDialog.FileName);
                R2C2S1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r2c2s1_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }


        /******  R2C2S2  ******/
        private void r2c2s2_stop(object sender, RoutedEventArgs e)
        {
            R2C2S2.Stop();
        }
        private void r2c2s2_pause(object sender, RoutedEventArgs e)
        {
            R2C2S2.Pause();
        }
        private void r2c2s2_play(object sender, RoutedEventArgs e)
        {
            if (R2C2S2.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R2C2S2.Play();
            }
        }

        private void r2c2s2_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R2C2S2.Source = new Uri(openFileDialog.FileName);
                R2C2S2.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r2c2s2_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }

        /******  R2C3S1  ******/
        private void r2c3s1_stop(object sender, RoutedEventArgs e)
        {
            R2C3S1.Stop();
        }
        private void r2c3s1_pause(object sender, RoutedEventArgs e)
        {
            R2C3S1.Pause();
        }
        private void r2c3s1_play(object sender, RoutedEventArgs e)
        {
            if (R2C3S1.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R2C3S1.Play();
            }
        }

        private void r2c3s1_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R2C3S1.Source = new Uri(openFileDialog.FileName);
                R2C3S1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r2c3s1_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }


        /******  R2C3S2  ******/
        private void r2c3s2_stop(object sender, RoutedEventArgs e)
        {
            R2C3S2.Stop();
        }
        private void r2c3s2_pause(object sender, RoutedEventArgs e)
        {
            R2C3S2.Pause();
        }
        private void r2c3s2_play(object sender, RoutedEventArgs e)
        {
            if (R2C3S2.Source == null)
            {
                MessageBox.Show("There is no video source be selected! ");
            }
            else
            {
                R2C3S2.Play();
            }
        }

        private void r2c3s2_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                R2C3S2.Source = new Uri(openFileDialog.FileName);
                R2C3S2.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            }
        }
        private void r2c3s2_screen_click(object sender, MouseButtonEventArgs e)
        {
            KinectWindow kinectWindow = new KinectWindow();
            kinectWindow.Show();
        }










    }
}
