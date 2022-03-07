using System;
using System.Windows.Forms;
using OpenCvSharp;

namespace OpenCV01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CvCapture capture;
        IplImage src;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                capture = CvCapture.FromCamera(CaptureDevice.DShow, 0); // 외부 카메라 사용시 index = 1
                capture.SetCaptureProperty(CaptureProperty.FrameWidth, 640);
                capture.SetCaptureProperty(CaptureProperty.FrameHeight, 480);
                
            }
            catch
            {
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            src = capture.QueryFrame();
            pictureBoxIpl1.ImageIpl = src;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cv.ReleaseImage(src);
            if (src != null) src.Dispose();
        }
    }
}
