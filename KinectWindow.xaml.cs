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
        private int m_TimerCount = 0;
        private int FramesPerFile = 1000;

        private string path = "C:\\Users\\Guang\\Desktop\\KinectData\\video\\";

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
            // this.depthFrameReader.FrameArrived += this.Reader_FrameArrived;

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
                            if ((m_TimerCount++) % FramesPerFile == 0)
                            {
                                System.Drawing.Size size = new System.Drawing.Size(width, height);
                                // string fileName = GetFileName(1);
                                //string fileName = "1 2 3" + ".avi";
                                DateTime dt = DateTime.Now;

                                string fileName = dt.TimeOfDay.ToString().Substring(3, 2) + ".avi";
                                Console.WriteLine(fileName);
                                this.video = new VideoWriter(fileName, -1, 10, size, true);                     
                            }
                            m_TimerCount %= FramesPerFile;
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
                        camera.Source = this.colorBitmap;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the depth frame data arriving from the sensor
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Reader_FrameArrived(object sender, DepthFrameArrivedEventArgs e)
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
                if (this.depth != null)
                {
                    Mat img = new Mat(this.depthFrameDescription.Height, this.depthFrameDescription.Width, Emgu.CV.CvEnum.DepthType.Cv8U, 1, this.depthBitmap.BackBuffer, this.depthFrameDescription.Width);
                    // Image<Gray, Byte> img1 = new Image<Gray, byte>(img.Bitmap);
                    // CvInvoke.cvShowImage("123", img1);
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

        private string GetFileName(int sensorID) 
        {
            string savePath = null;
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string date = currentTime.ToString("t");
            //Console.WriteLine(date + ".avi");
            return date;
        }
    }
}
