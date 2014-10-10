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
        /// Bitmap to display
        /// </summary>
        private WriteableBitmap colorBitmap = null;
        private VideoWriter video;
        private Thread isRecording;
        private Mat img;

        public KinectWindow()
        {

            
            this.kinectSensor = KinectSensor.GetDefault();

            // open the reader for the color frames
            this.colorFrameReader = this.kinectSensor.ColorFrameSource.OpenReader();

            // wire handler for frame arrival
            this.colorFrameReader.FrameArrived += this.Reader_ColorFrameArrived;

            // create the colorFrameDescription from the ColorFrameSource using Bgra format
            FrameDescription colorFrameDescription = this.kinectSensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Bgra);

            // create the bitmap to display
            this.colorBitmap = new WriteableBitmap(colorFrameDescription.Width, colorFrameDescription.Height, 96.0, 96.0, PixelFormats.Bgr32, null);
            
            
            // open the sensor
            this.kinectSensor.Open();

            InitializeComponent();
            System.Drawing.Size size = new System.Drawing.Size(colorFrameDescription.Width, colorFrameDescription.Height);
            this.video = new VideoWriter(@"123.avi", -1, 25, size, true);

        }

        private void KinectWindow_Closing(object sender, CancelEventArgs e)
        {
            video.Dispose();
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
                    //camera.Source = FrameToBitmap(colorFrame);
                    
                    FrameDescription colorFrameDescription = colorFrame.FrameDescription;
                    int width = colorFrame.FrameDescription.Width;
                    int height = colorFrame.FrameDescription.Height;
                    //byte[] pixels = new byte[width * height * 4];
                    //colorFrame.CopyConvertedFrameDataToArray(pixels, ColorImageFormat.Bgra);
                    //BitmapSource bitmapsource = BitmapSource.Create(width, height, 16, 16, PixelFormats.Bgra32, null, pixels, width * 4);
                    //Image<Bgr, Byte> img = new Image<Bgr, byte>(BytesToBitmap(bitmapsource));
                    // CvInvoke.cvShowImage("123", img);
                    //camera.Source = bitmapsource;//BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgra32, null, pixels, width * 4);
                    // camera.Source = BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgra32, null, pixels, width * 4);
                    using (KinectBuffer colorBuffer = colorFrame.LockRawImageBuffer())
                    {
                        this.colorBitmap.Lock();

                        // verify data and write the new color frame data to the display bitmap
                        if ((colorFrameDescription.Width == this.colorBitmap.PixelWidth) && (colorFrameDescription.Height == this.colorBitmap.PixelHeight))
                        {
                            colorFrame.CopyConvertedFrameDataToIntPtr(
                                this.colorBitmap.BackBuffer,
                                (uint)(colorFrameDescription.Width * colorFrameDescription.Height * 4),
                                ColorImageFormat.Bgra);

                            this.colorBitmap.AddDirtyRect(new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight));
                        }
                        
                        Mat img1 = new Mat(height, width, 0, 4, this.colorBitmap.BackBuffer, width * 4);
                        if (this.video != null)
                        {
                            this.video.Write(img1);
                        }
                        /*if (isRecording == null)
                        {
                            isRecording = new Thread(record);
                            isRecording.Start();
                        }
                        else
                        {
                            isRecording = null;

                        }*/


                       
                        //video.Dispose();
                        //Image<Bgr, Byte> img1 = new Image<Bgr, byte>(img.Bitmap);
                        //CvInvoke.cvShowImage("123", img1);
                        this.colorBitmap.Unlock();
                    }
                    if (this.colorBitmap != null)
                    {
                        camera.Source = this.colorBitmap;
                    }
                }
            }
        }

        public static Bitmap BytesToBitmap(BitmapSource bitmapsource)
        {
            System.Drawing.Bitmap bitmap;
            using (var outStream = new MemoryStream())
            {
                BmpBitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new System.Drawing.Bitmap(outStream);
                return bitmap;
            }
        }

        public static BitmapSource FrameToBitmap(ColorFrame colorFrame)
        {
            FrameDescription colorFrameDescription = colorFrame.FrameDescription;
            int width = colorFrame.FrameDescription.Width;
            int height = colorFrame.FrameDescription.Height;
            byte[] pixels = new byte[width * height * 4];
            colorFrame.CopyConvertedFrameDataToArray(pixels, ColorImageFormat.Bgra);
            BitmapSource bitmapsource = BitmapSource.Create(width, height, 16, 16, PixelFormats.Bgra32, null, pixels, width * 4);
            Image<Bgr, Byte> img = new Image<Bgr, byte>(BytesToBitmap(bitmapsource));
            return bitmapsource;
        }


       /* public void record()
        {

            while (this.isRecording != null)
            {
                this.video.Write(img);
                Thread.Sleep(40);
            }
        }*/
    }
}
