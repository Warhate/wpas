using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Windows.Forms; 

namespace Myprojekt
{
    class Filters
    {
        public Filters() { }

        public Image<Gray, Byte>[] RBG_Filter(Image<Bgr, Byte> Image)
        {
            Image<Gray, Byte>[] Image_result = Image.Split();
            return Image_result;
        }
        public Image<Gray, Byte>[] HSV_Filter(Image<Bgr, Byte> Image)
        {
            Image<Hsv, Byte> hsvimg = Image.Convert<Hsv, Byte>();

            Image<Gray, Byte>[] channels = hsvimg.Split();  //split into components
            Image<Gray, Byte> imghue = channels[0];            //hsv, so channels[0] is hue.
            Image<Gray, Byte> imgval = channels[2];            //hsv, so channels[2] is value.

            //filter out all but "kapton yellow" using InRange
            //Hsv hsv_min = new Hsv(47, 0, 0);        //just care about color channel
            //Hsv hsv_max = new Hsv(53, 255, 255);
            //Image<Hsv, byte> kaptonimg = hsvimg.InRange(hsv_min, hsv_max);


            //use the value channel to filter out all but brighter colors
            Image<Gray, byte> valfilter = imgval.InRange(new Gray(150), new Gray(255));

            //now and the two to get the parts of the imaged that are colored and above some brightness.
            //Image<Gray, byte> colordetimg = huefilter.And(valfilter, imgval);

            return channels;
        }

        public void ShowImage(Image<Bgr, Byte> Image)
        {
            ImageViewer viewer = new ImageViewer();
            viewer.Image = Image;
            viewer.ShowDialog();
        }

        public string[] DownloadLineFilter(ComboBox comboBox, string file_name)
        {
            comboBox.Items.Clear();
            StreamReader streamefile = new StreamReader(file_name);
            String line;

            while ((line = streamefile.ReadLine()) != null)
            {
                line = line.ToString();
                comboBox.Items.Add(line);
            }
            streamefile.Close();

            int index = comboBox.Items.Count;

            string[] mas_filter = new string[index];
            string[] byfer;
            string[] arg = {"#***#"};

            for (int i = 0; i < index; i++)
            {
                byfer = comboBox.Items[i].ToString().Split(arg, StringSplitOptions.RemoveEmptyEntries);
                comboBox.Items[i] = i.ToString()+" "+byfer[0];
                mas_filter[i] = byfer[1];
            }
            return mas_filter;
        }

        public void SaveFilter(ComboBox comboBox, string file_name)
        {
            int index = comboBox.Items.Count;
            string[] lines = new string[index];

            for (int i = 0; i < index; i++)
            {
                lines[i] = comboBox.Items[i].ToString();
            }

            System.IO.File.WriteAllLines(file_name, lines);
        }

        public void CreateFileFilter(string file_name)
        {
            FileInfo fi = new FileInfo(file_name+".txt");
            fi.Create();
  
        }

        public void SaveFilterFile(string file_name, string filter)
        {
            StreamWriter sw;
            FileInfo fi = new FileInfo(file_name);
            sw = fi.AppendText();
            sw.WriteLine(filter);
            sw.Close();
        }
    }
}
