using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
namespace someshittyname
{
    public partial class Form1 : Form
    {
        CascadeClassifier haarhaar = new CascadeClassifier(
                "path to the cascade file, i'd recommend using a haar if you're using this to detect faces."
                );
        Mat frame;
        VideoCapture capture;
        Mat flipped;
        Mat gray;
        public Form1()
        {
            InitializeComponent();
            frame = new Mat();
            capture = new VideoCapture();
            flipped= new Mat();
            gray = new Mat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            capture.Read(frame);

                CvInvoke.CvtColor(frame, gray, ColorConversion.Bgr2Gray, 0);

                Rectangle[] coordinates = haarhaar.DetectMultiScale(gray, 1.1, 6);

                if (coordinates.Length > 0)
                {
                label1.Text = "hello bitch ;)";
                //label1.ForeColor = Color.Green;
                //label1.BackColor = Color.White;
                Rectangle detected = coordinates[0];

                CvInvoke.Rectangle(frame, detected, new MCvScalar(255, 0, 0), 1,
                LineType.EightConnected, 0);
            }

                else
                {
                label1.Text = "No face detected";
                //label1.ForeColor = Color.Red;
                //label1.BackColor = Color.White;
            }

                CvInvoke.Flip(frame, flipped, FlipType.Horizontal);

                CvInvoke.Imshow("camerafeed", flipped);
        }
    }
}