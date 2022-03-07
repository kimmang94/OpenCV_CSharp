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
                // 파일을 불러 오는 코드
                capture = CvCapture.FromFile("../../../Images/Saigon.mp4");

                // 카메라를 불러 오는 코드
                /*
                capture = CvCapture.FromCamera(CaptureDevice.DShow, 0); // 외부 카메라 사용시 index = 1
                capture.SetCaptureProperty(CaptureProperty.FrameWidth, 640);
                capture.SetCaptureProperty(CaptureProperty.FrameHeight, 480);
                */
                
            }
            catch
            {
                timer1.Enabled = false;
            }
        }

        int frameCount = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            frameCount++;
            label1.Text = frameCount.ToString() + "/" + capture.FrameCount.ToString();
            src = capture.QueryFrame();

            if (frameCount != capture.FrameCount)
            {
                pictureBoxIpl1.ImageIpl = src;
            }
            else
            {
                frameCount = 0;
                pictureBoxIpl1.ImageIpl = null;
                timer1.Enabled = false;
                // capture = CvCapture.FromFile("../../../Images/Saigon.mp4"); 무한 영상 재생
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cv.ReleaseImage(src);
            if (src != null) src.Dispose();
        }
    }
}
