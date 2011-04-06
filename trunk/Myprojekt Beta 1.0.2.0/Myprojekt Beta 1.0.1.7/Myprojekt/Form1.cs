using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu;
using Emgu.Util;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Myprojekt
{
    public partial class Form1 : Form
    {

        Filters FLI = new Filters();
        Interface inf = new Interface();
        Image<Bgr, Byte> Image_G;
        Image<Gray, Byte>[] Image_result;

        string[] mas_filter;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        { 
            //CvInvoke.cvSplit(adr,);//Доступ к библиотеке OpenCV за допомогою функції CvInvoke.

                Image_result = FLI.RBG_Filter(Image_G);
                pictureBox1.Image = Image_result[0].Bitmap;
                pictureBox3.Image = Image_result[1].Bitmap;
                pictureBox4.Image = Image_result[2].Bitmap;

                Image_result = FLI.HSV_Filter(Image_G);
                pictureBox7.Image = Image_result[0].Bitmap;
                pictureBox6.Image = Image_result[1].Bitmap;
                pictureBox5.Image = Image_result[2].Bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (trackBar1.Enabled == false)
            {
                trackBar1.Enabled = true;
                trackBar2.Enabled = true;
                trackBar3.Enabled = true;
                trackBar4.Enabled = true;
                trackBar5.Enabled = true;
                trackBar6.Enabled = true;
            }
            else
            {
                trackBar1.Enabled = false;
                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                trackBar4.Enabled = false;
                trackBar5.Enabled = false;
                trackBar6.Enabled = false;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            //filter out all but "the color you want"...seems to be 0 to 128 ?
            pictureBox1.Image = Image_result[0].InRange(new Gray(trackBar2.Value), new Gray(trackBar1.Value)).Bitmap;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Image = Image_result[0].InRange(new Gray(trackBar2.Value), new Gray(trackBar1.Value)).Bitmap;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            pictureBox3.Image = Image_result[1].InRange(new Gray(trackBar4.Value), new Gray(trackBar3.Value)).Bitmap;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            pictureBox3.Image = Image_result[1].InRange(new Gray(trackBar4.Value), new Gray(trackBar3.Value)).Bitmap;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            pictureBox4.Image = Image_result[2].InRange(new Gray(trackBar6.Value), new Gray(trackBar5.Value)).Bitmap;
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            pictureBox4.Image = Image_result[2].InRange(new Gray(trackBar6.Value), new Gray(trackBar5.Value)).Bitmap;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] arg = { " " };
            string[] arg2 = { "###" };
            string[] buf = comboBox1.Text.ToString().Split( arg, StringSplitOptions.RemoveEmptyEntries );
            int index = Convert.ToInt32(buf[0]);
            buf = mas_filter[index].Split(arg2, StringSplitOptions.RemoveEmptyEntries);
            trackBar1.Value = Convert.ToInt32(buf[0]);
            trackBar2.Value = Convert.ToInt32(buf[1]);
            trackBar3.Value = Convert.ToInt32(buf[2]);
            trackBar4.Value = Convert.ToInt32(buf[3]);
            trackBar5.Value = Convert.ToInt32(buf[4]);
            trackBar6.Value = Convert.ToInt32(buf[5]);

            //trackBar1.Scroll;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Text = inf.Open_Dialog_File();

            if (textBox4.Text != "")
            {
                Image_G = new Image<Bgr, Byte>(textBox4.Text);
                pictureBox2.Image = Image_G.Bitmap;
                pictureBox9.Image = Image_G.Bitmap;

                //CvInvoke.cvSplit(adr,);//Доступ к библиотеке OpenCV за допомогою функції CvInvoke.

                Image_result = FLI.RBG_Filter(Image_G);
                pictureBox1.Image = Image_result[0].Bitmap;
                pictureBox3.Image = Image_result[1].Bitmap;
                pictureBox4.Image = Image_result[2].Bitmap;

                Image_result = FLI.HSV_Filter(Image_G);
                pictureBox7.Image = Image_result[0].Bitmap;
                pictureBox6.Image = Image_result[1].Bitmap;
                pictureBox5.Image = Image_result[2].Bitmap;
            }
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                trackBar1.Enabled = true;
                trackBar2.Enabled = true;
                trackBar3.Enabled = true;
                trackBar4.Enabled = true;
                trackBar5.Enabled = true;
                trackBar6.Enabled = true;
                trackBar7.Enabled = true;
                trackBar8.Enabled = true;
                trackBar9.Enabled = true;
                trackBar10.Enabled = true;
                trackBar11.Enabled = true;
                trackBar12.Enabled = true;
            }
            else
            {
                trackBar1.Enabled = false;
                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                trackBar4.Enabled = false;
                trackBar5.Enabled = false;
                trackBar6.Enabled = false;
                trackBar7.Enabled = false;
                trackBar8.Enabled = false;
                trackBar9.Enabled = false;
                trackBar10.Enabled = false;
                trackBar11.Enabled = false;
                trackBar12.Enabled = false;
            }
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            pictureBox7.Image = Image_result[0].InRange(new Gray(trackBar12.Value), new Gray(trackBar11.Value)).Bitmap;
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            pictureBox7.Image = Image_result[0].InRange(new Gray(trackBar12.Value), new Gray(trackBar11.Value)).Bitmap;
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            pictureBox6.Image = Image_result[0].InRange(new Gray(trackBar9.Value), new Gray(trackBar10.Value)).Bitmap;
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            pictureBox6.Image = Image_result[0].InRange(new Gray(trackBar9.Value), new Gray(trackBar10.Value)).Bitmap;
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            pictureBox5.Image = Image_result[0].InRange(new Gray(trackBar7.Value), new Gray(trackBar8.Value)).Bitmap;
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            pictureBox5.Image = Image_result[0].InRange(new Gray(trackBar7.Value), new Gray(trackBar8.Value)).Bitmap;
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label2.Enabled = true;
                comboBox1.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                label2.Enabled = false;
                comboBox1.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void buttonOpen1_Click(object sender, EventArgs e)
        {
            textBoxOpen1.Text = inf.Open_Dialog_File_Filter();
            if (textBoxOpen1.Text != "")
            {
                mas_filter = FLI.DownloadLineFilter(comboBox1, textBoxOpen1.Text);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string[] arg = { " " };
            string[] arg2 = { "###" };
            string[] buf = comboBox1.Text.ToString().Split(arg, StringSplitOptions.RemoveEmptyEntries);
            int index = Convert.ToInt32(buf[0]);
            buf = mas_filter[index].Split(arg2, StringSplitOptions.RemoveEmptyEntries);

            trackBar1.Value = Convert.ToInt32(buf[0]);
            trackBar2.Value = Convert.ToInt32(buf[1]);
            trackBar3.Value = Convert.ToInt32(buf[2]);
            trackBar4.Value = Convert.ToInt32(buf[3]);
            trackBar5.Value = Convert.ToInt32(buf[4]);
            trackBar6.Value = Convert.ToInt32(buf[5]);
            trackBar12.Value = Convert.ToInt32(buf[6]);
            trackBar11.Value = Convert.ToInt32(buf[7]);
            trackBar9.Value = Convert.ToInt32(buf[8]);
            trackBar10.Value = Convert.ToInt32(buf[9]);
            trackBar7.Value = Convert.ToInt32(buf[10]);
            trackBar8.Value = Convert.ToInt32(buf[11]);

            pictureBox1.Image = Image_result[0].InRange(new Gray(trackBar2.Value), new Gray(trackBar1.Value)).Bitmap;
            pictureBox3.Image = Image_result[1].InRange(new Gray(trackBar4.Value), new Gray(trackBar3.Value)).Bitmap;
            pictureBox4.Image = Image_result[2].InRange(new Gray(trackBar6.Value), new Gray(trackBar5.Value)).Bitmap;

            pictureBox7.Image = Image_result[0].InRange(new Gray(trackBar12.Value), new Gray(trackBar11.Value)).Bitmap;
            pictureBox6.Image = Image_result[0].InRange(new Gray(trackBar9.Value), new Gray(trackBar10.Value)).Bitmap;
            pictureBox5.Image = Image_result[0].InRange(new Gray(trackBar7.Value), new Gray(trackBar8.Value)).Bitmap;

            //trackBar1.Scroll;
        }
    }
}
