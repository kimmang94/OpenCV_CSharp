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

        IplImage src;

        private void Form1_Load(object sender, EventArgs e)
        {
            src = new IplImage("../../../Images/Italia.jpg");
            pictureBoxIpl1.ImageIpl = src;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cv.ReleaseImage(src);
            if (src != null) src.Dispose();
        }
    }
}
