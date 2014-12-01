namespace Northwestern.Samples.Kinect.KinectExplorerD2D
{
    using System;
    using System.Windows.Input;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Kinect;
    using Emgu.CV;
    using Emgu.CV.Structure;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Threading;
    using System.Net;
    using System.Text;
    using Microsoft.Win32;
    using System.Windows.Controls.Primitives;
    using System.Windows.Interop;
    using System.Windows.Controls;

    //using System.Web;

    //using Wind
    //using Windows.Storage;
    //using System.Windows.Storage.Pickers;
    
    /// <summary>
    /// Interaction logic for KinectWindow.xaml
    /// </summary>
    public partial class KinectWindow : Window
    {
        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor kinectSensor = null;

        /// <summary>
        /// Reader for color frames
        /// </summary>
        private ColorFrameReader colorFrameReader = null;

        /// <summary>
        /// Reader for depth frames
        /// </summary>
        private DepthFrameReader depthFrameReader = null;

        /// <summary>
        /// Description of the data contained in the depth frame
        /// </summary>
        private FrameDescription depthFrameDescription = null;

        /// <summary>
        /// Bitmap to display
        /// </summary>
        private WriteableBitmap depthBitmap = null;

        /// <summary>
        /// Intermediate storage for frame data converted to color
        /// </summary>
        private byte[] depthPixels = null;

        /// <summary>
        /// Bitmap to display
        /// </summary>
        private WriteableBitmap colorBitmap = null;

        private VideoWriter video = null;

        private VideoWriter depth = null;

        private Boolean rgbRecording = false;

        private Boolean depthRecording = false;

        private int m_TimerCount = 0;
        
        private int colorFramesPerFile = 9000;

        private int depthFramesPerFile = 9000;

        private string path = "C:\\Users\\Desktop\\KinectData\\video\\";

        private bool mediaPlayerIsPlaying = false;

        private bool userIsDraggingSlider = false;

        public KinectWindow()
        {           
            this.kinectSensor = KinectSensor.GetDefault();

            // open the reader for the color frames
            this.colorFrameReader = this.kinectSensor.ColorFrameSource.OpenReader();

            // create the colorFrameDescription from the ColorFrameSource using Bgra format
            FrameDescription colorFrameDescription = this.kinectSensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Bgra);

            // create the bitmap to display
            this.colorBitmap = new WriteableBitmap(colorFrameDescription.Width, colorFrameDescription.Height, 96.0, 96.0, PixelFormats.Bgr32, null);

            // wire handler for frame arrival
            this.colorFrameReader.FrameArrived += this.Reader_ColorFrameArrived;

            // open the reader for the depth frames
            this.depthFrameReader = this.kinectSensor.DepthFrameSource.OpenReader();

            // wire handler for frame arrival
            this.depthFrameReader.FrameArrived += this.Reader_DepthFrameArrived;

            // get FrameDescription from DepthFrameSource
            this.depthFrameDescription = this.kinectSensor.DepthFrameSource.FrameDescription;

            // allocate space to put the pixels being received and converted
            this.depthPixels = new byte[this.depthFrameDescription.Width * this.depthFrameDescription.Height];

            // create the bitmap to display
            this.depthBitmap = new WriteableBitmap(this.depthFrameDescription.Width, this.depthFrameDescription.Height, 96.0, 96.0, PixelFormats.Gray8, null);
            
            //System.Drawing.Size size = new System.Drawing.Size(depthFrameDescription.Width, this.depthFrameDescription.Height);
            //this.depth = new VideoWriter(@"456.avi", -1, 30, size, true);     

            // open the sensor
            this.kinectSensor.Open();

            // string a = GetFileName(5);

            InitializeComponent();

            /******* Media time information *******/
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void KinectWindow_Closing(object sender, CancelEventArgs e)
        {
            if (this.video != null)
            {
                this.video.Dispose();
                this.video = null;
            }
            if (this.depth != null)
            {
                this.depth.Dispose();
                this.depth = null;
            }
        }
        /// <summary>
        /// Handles the color frame data arriving from the sensor
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Reader_ColorFrameArrived(object sender, ColorFrameArrivedEventArgs e)
        {
            // ColorFrame is IDisposable
            using (ColorFrame colorFrame = e.FrameReference.AcquireFrame())
            {
                if (colorFrame != null)
                {
                    FrameDescription colorFrameDescription = colorFrame.FrameDescription;
                    int width = colorFrame.FrameDescription.Width;
                    int height = colorFrame.FrameDescription.Height;

                    using (KinectBuffer colorBuffer = colorFrame.LockRawImageBuffer())
                    {
                        this.colorBitmap.Lock();
                        if (this.rgbRecording == true)
                        {
                            if ((m_TimerCount++) % colorFramesPerFile == 0)
                            {
                                System.Drawing.Size size = new System.Drawing.Size(width, height);
                                // string fileName = GetFileName(1);
                                //string fileName = "1 2 3" + ".avi";
                                // DateTime dt = DateTime.Now;

                                // string fileName = dt.TimeOfDay.ToString().Substring(3, 2) + ".avi";
                                // Console.WriteLine(fileName);
                                this.video = new VideoWriter("15min-30FPS-lossless.avi", -1, 10, size, true);                     
                            }
                            m_TimerCount %= colorFramesPerFile;
                        }

                        // verify data and write the new color frame data to the display bitmap
                        if ((width == this.colorBitmap.PixelWidth) && (height == this.colorBitmap.PixelHeight))
                        {
                            colorFrame.CopyConvertedFrameDataToIntPtr(
                                this.colorBitmap.BackBuffer,
                                (uint)(width * height * 4),
                                ColorImageFormat.Bgra);
                            this.colorBitmap.AddDirtyRect(new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight));
                        }        
                        
                        if (this.rgbRecording == true && this.video != null)
                        {
                            Mat img = new Mat(height, width, Emgu.CV.CvEnum.DepthType.Cv8U, 4, this.colorBitmap.BackBuffer, width * 4);
                            this.video.Write(img);
                        }

                        this.colorBitmap.Unlock();
                    }

                    if (this.colorBitmap != null)
                    {
                        //camera.Source = this.colorBitmap;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the depth frame data arriving from the sensor
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Reader_DepthFrameArrived(object sender, DepthFrameArrivedEventArgs e)
        {
            bool depthFrameProcessed = false;

            using (DepthFrame depthFrame = e.FrameReference.AcquireFrame())
            {
                if (depthFrame != null)
                {
                    // the fastest way to process the body index data is to directly access 
                    // the underlying buffer
                    using (Microsoft.Kinect.KinectBuffer depthBuffer = depthFrame.LockImageBuffer())
                    {
                        if (this.depthRecording == true)
                        {
                            if ((this.m_TimerCount++) % this.depthFramesPerFile == 0)
                            {
                                System.Drawing.Size size = new System.Drawing.Size(this.depthFrameDescription.Width, this.depthFrameDescription.Height);
                                this.video = new VideoWriter("123.avi", -1, 10, size, true);
                            }
                            this.m_TimerCount %= this.depthFramesPerFile;
                        }
                        
                        // verify data and write the color data to the display bitmap
                        if (((this.depthFrameDescription.Width * this.depthFrameDescription.Height) == (depthBuffer.Size / this.depthFrameDescription.BytesPerPixel)))
                        {
                            // Note: In order to see the full range of depth (including the less reliable far field depth)
                            // we are setting maxDepth to the extreme potential depth threshold
                            ushort maxDepth = ushort.MaxValue;

                            // If you wish to filter by reliable depth distance, uncomment the following line:
                            //// maxDepth = depthFrame.DepthMaxReliableDistance

                            this.ProcessDepthFrameData(depthBuffer.UnderlyingBuffer, depthBuffer.Size, depthFrame.DepthMinReliableDistance, maxDepth);
                            depthFrameProcessed = true;                  
                        }
                    }
                }
            }

            if (depthFrameProcessed)
            {             
                this.RenderDepthPixels();
                if (this.depthRecording == true && this.depth != null)
                {
                    Mat img = new Mat(this.depthFrameDescription.Height, this.depthFrameDescription.Width, Emgu.CV.CvEnum.DepthType.Cv8U, 1, this.depthBitmap.BackBuffer, this.depthFrameDescription.Width);
                    this.depth.Write(img);
                }
            }
        }

        /// <summary>
        /// Renders color pixels into the writeableBitmap.
        /// </summary>
        private void RenderDepthPixels()
        {
            this.depthBitmap.WritePixels(
                new Int32Rect(0, 0, this.depthBitmap.PixelWidth, this.depthBitmap.PixelHeight),
                this.depthPixels,
                this.depthBitmap.PixelWidth,
                0);
        }

        /// <summary>
        /// Directly accesses the underlying image buffer of the DepthFrame to 
        /// create a displayable bitmap.
        /// This function requires the /unsafe compiler option as we make use of direct
        /// access to the native memory pointed to by the depthFrameData pointer.
        /// </summary>
        /// <param name="depthFrameData">Pointer to the DepthFrame image data</param>
        /// <param name="depthFrameDataSize">Size of the DepthFrame image data</param>
        /// <param name="minDepth">The minimum reliable depth value for the frame</param>
        /// <param name="maxDepth">The maximum reliable depth value for the frame</param>
        private unsafe void ProcessDepthFrameData(IntPtr depthFrameData, uint depthFrameDataSize, ushort minDepth, ushort maxDepth)
        {
            // depth frame data is a 16 bit value
            ushort* frameData = (ushort*)depthFrameData;

            // convert depth to a visual representation
            for (int i = 0; i < (int)(depthFrameDataSize / this.depthFrameDescription.BytesPerPixel); ++i)
            {
                // Get the depth for this pixel
                ushort depth = frameData[i];

                // To convert to a byte, we're mapping the depth value to the byte range.
                // Values outside the reliable depth range are mapped to 0 (black).
                this.depthPixels[i] = (byte)(depth >= minDepth && depth <= maxDepth ? (depth / (8000 / 256)) : 0);
            }
        }

        private void RGBClick(object sender, RoutedEventArgs e)
        {
            this.rgbRecording = this.rgbRecording ? false : true;
        }

        private void DepthClick(object sender, RoutedEventArgs e)
        {
            this.depthRecording = this.depthRecording ? false : true;
        }

        private string GetFileName(int sensorID) 
        {
            string savePath = null;
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string date = currentTime.ToString("t");
            //Console.WriteLine(date + ".avi");
            return date;
        }

        /**** Media play/stop/pause button ***/
        //private void StopMedia(object sender, RoutedEventArgs e)
        //{
        //    media.Stop();
        //}
        //private void PauseMedia(object sender, RoutedEventArgs e)
        //{
        //    media.Pause();
        //}
        //private void PlayMedia(object sender, RoutedEventArgs e)
        //{
        //    media.Play();
        //}

        /***** Media source open ****/
        
        private void SetLocalMedia(DateTime o)
        {
            string FileName = GetFileName(o) + ".avi";
            Console.WriteLine(FileName);
            this.media.Source = new Uri(FileName, UriKind.RelativeOrAbsolute);
            this.media.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
        } 

        /*********  Log out button  **********/
        private void Logout_click(object sender, RoutedEventArgs e)
        {
            
            //Northwestern.Samples.Kinect.KinectExplorerD2D.ClientSignIn signIn = new ClientSignIn();
            //signIn.Show();

            //Window parentWin = Window.GetWindow(this);
            //parentWin.Close();

            //DependencyObject parent = this.Parent;
            //parent = LogicalTreeHelper.GetParent(parent);
            //Window objLogin = parent as Window;
            //while (parent != null && !(parent is Window))
            //{
            //    parent = LogicalTreeHelper.GetParent(parent);
            //}
            //Window w = parent as Window;
            //if (w != null)
            //    w.Close();

            //HwndSource source = (HwndSource)PresentationSource.FromVisual(sender as Button);
            //System.Windows.Forms.Control ctl = System.Windows.Forms.Control.FromChildHandle(source.Handle);
            //ctl.FindForm().Close();

            this.Close();
        }


        /***** onclick return original time+data information  ****/
        
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime originData;
            string dateString;
            
            if (cal1.SelectedDate == null)
            {
                dateString = "<date not selected>";
                return;
            }
            dateString = cal1.SelectedDate.ToString();
            message1.Text ="Selected Time: " + enterTime.Text.Substring(0,2) + " : " + enterTime.Text.Substring(2) + "\n" +
                "Selected Date: " + dateString;
            //Console.WriteLine(dateString);
            int year = 0, month = 0, day = 0, hour = 0, mins = 0;
            string[] separators = new string[] { "/", " " };
            string[] result = dateString.Split(separators, StringSplitOptions.None);

            //Console.WriteLine(result[0] + " " + result[1] + " " + result[2]);
            month = Int32.Parse(result[0]);
            day = Int32.Parse(result[1]);
            year = Int32.Parse(result[2]);
            //Console.Write(year);
            //Console.Write(month);
            //Console.Write(day);
            //Console.Write(hour);
            //Console.WriteLine(mins);

            originData = new DateTime(year, month, day, hour, mins, 0);
            //Console.WriteLine(originData);
            SetLocalMedia(originData);
        }

        /*******  Time progress bar Slider Setting  ********/
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((media.Source != null) && (media.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = media.Position.TotalSeconds;
            }
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.avi)|*.mp3;*.mpg;*.mpeg;*.avi|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                media.Source = new Uri(openFileDialog.FileName);
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (media != null) && (media.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            media.Play();
            mediaPlayerIsPlaying = true;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            media.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            media.Stop();
            mediaPlayerIsPlaying = false;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            media.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            media.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }




        /****  get file name from server ***/
        public string GetFileName(DateTime o)
        {
            /******/
            FTPDownload ftpTest = new FTPDownload();
            string[] fileNames = ftpTest.GetFileList();
            foreach (string file in fileNames) {
                Console.WriteLine(file);
            }
            string[] downloadFileNames = new string[3];
            // rgb 0, depth 1, csv 2; 
            char[] fileName = "100_0_2014_11_21_23_58_59".ToCharArray();
            string path = "KinectData/Kinect/";
            downloadFileNames[0] = path + "rgb/20141121/" + new string(fileName) + ".avi";
            fileName[4] = '1';
            downloadFileNames[1] = path + "depth/20141121/" + new string(fileName) + ".avi";
            fileName[4] = '2';
            downloadFileNames[2] = path + "csv/20141121/" + new string(fileName) + ".csv";
            //downloadFileNames[3] = path + "text/20141121/" + fileName + ".txt";
            foreach (string file in downloadFileNames)
            {
                Console.WriteLine(file);
                ftpTest.Download(file);
            }
            fileName[4] = '1';
            return "..\\..\\..\\Video\\" + new string(fileName);
        }


        /**********  Slider parameters setting  ************/
        //private dispatchertimer _timer;

        //private void setuptimer()
        //{
        //    _timer = new dispatchertimer();
        //    _timer.interval = timespan.fromseconds(timelineslider.tickfrequency);
        //    starttimer();
        //}

        //private void _timer_tick(object sender, object e)
        //{
        //    if (timelineslider.mousedoubleclick == true)
        //    {
        //        timelineslider.value = media.position.totalseconds;
        //    }
        //}

        //private void starttimer()
        //{
        //    _timer.tick += _timer_tick;
        //    _timer.start();
        //}

        //private void stoptimer()
        //{
        //    _timer.stop();
        //    _timer.tick -= _timer_tick;
        //}

        /*************  Slider event setting  *****************/

        /*********** Http request post test  ************/
        private void HttpRequestPostTest()
        {
            WebRequestPostExample webPost = new WebRequestPostExample();
            webPost.webRequestPostTest();
        }

        /*********************  FTP download testing  *************************/
        
    }




    /***************  Http request class *****************/
    public class WebRequestPostExample
    {
        public void webRequestPostTest()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }

    /***********************  FTP download class  **************************/
    public class FTPDownload
    {
        private bool postFTPReqeust(string fileName, string userName, string password) {
            //string[] files = GetFileList();
            //foreach (string file in files)
            //{
            //    Download(file);
            //}
            //Download(fileName);
            return true;
        }

        public string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                string url = "129.105.36.183";
                string userName = "lisaliu";
                string password = "123456";
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + url + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(userName, password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }                
                downloadFiles = null;
                return downloadFiles;
            }
        }

        
        public void Download(string file)
        {                       
            try
            {   
                string ftpServerIP = "129.105.36.183";
                string ftpUserID = "lisaliu";
                string ftpPassword = "123456";
                string localDestnDir = "..\\..\\..\\Video";
                string uri = "ftp://" + ftpServerIP + "/" + file;
                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return;
                }       
                FtpWebRequest reqFTP;                
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + file));                                
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);                
                reqFTP.KeepAlive = false;                
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;                                
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;                 
                reqFTP.UsePassive = false;

                string[] seperator = new string[] { "/" };
                string[] pathToFile = file.Split(seperator, StringSplitOptions.None);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream writeStream = new FileStream(localDestnDir + "\\" + pathToFile[pathToFile.Length - 1], FileMode.Create);                
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);               
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }                
                writeStream.Close();
                response.Close(); 
            }
            catch (WebException wEx)
            {
                MessageBox.Show(wEx.Message, "Download Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Download Error");
            }
        }
    }


}
