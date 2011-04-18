using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Layout
{
    public partial class AddMap : Form
    {
        #region Varibles
        Map map = new Map();
        Bitmap img,bImg;
        Graphics grafLinr;
        bool isDrawLine = false, isDone = false;
        DialogResult dr;
        
        Point tempPoint1 = Point.Empty, tempPoint2 = Point.Empty;
        double radius;

        #endregion

        #region Constructor
        public AddMap()
        {
            InitializeComponent();
        }
        #endregion

        private void AddMap_Load(object sender, EventArgs e)
        {
            
            //radius = Math.Sqrt(Math.Pow((lineShape1.Y2 - lineShape1.Y1), 2) + Math.Pow((lineShape1.X2 - lineShape1.X1), 2));
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(openFileDialog.FileName);
                pictureBox1.BackgroundImage = img;

                img = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                map.Img = img;
                bImg = new Bitmap(img.Width,img.Height);
                pictureBox1.Image = bImg;
                Log.AddLogMessage("Open map image:" + openFileDialog.FileName);
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.Text != "")
                {
                    if (pictureBox1.Image != null)
                    {
                        map.Scale=textBoxScale.Text == "" ? 0 : Convert.ToInt32(textBoxScale.Text);


                        SelectedDirect();



                            



                        SerializHelper.SaveMap(textBoxName.Text, map);
                        MessageBox.Show("Map saved!", "Map saved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Log.AddLogMessage("Map saved:" + textBoxName.Text);
                        isDone = true;
                        this.Close();
                    }
                    else
                    {
                        errorProvider1.SetIconAlignment(pictureBox1, ErrorIconAlignment.TopRight);
                        errorProvider1.SetError(pictureBox1, "Open image file");
                        Log.AddLogMessage("No set image from map");

                    }


                }
                else
                {
                    errorProvider1.SetError(textBoxName, "Enter file name!");
                    Log.AddLogMessage("No set name from map");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.AddLogMessage("Error generation map");
            
            }
        }

        private void SelectedDirect()
        {

                            if(rbN.Checked)
                            {
                                map.WindDirect = Marker.WindDirect.N;

                            }

                            if (rbW.Checked)
                            {
                                map.WindDirect = Marker.WindDirect.W;

                            }
                            if (rbS.Checked)
                            {
                                map.WindDirect = Marker.WindDirect.S;

                            }
                            if (radioButtonE.Checked)
                            {
                                map.WindDirect = Marker.WindDirect.E;

                            }
                            if (rbNE.Checked)
                            {
                                map.WindDirect = Marker.WindDirect.NE;

                            }
                            if (rbSE.Checked)
                            {
                                map.WindDirect = Marker.WindDirect.SE;

                            }
                            if (rbSW.Checked)
                            {
                                map.WindDirect = Marker.WindDirect.SW;

                            }
                            if (rbNW.Checked)
                            {
                                map.WindDirect = Marker.WindDirect.NW;

                            }
        }
        
        
        public Map ShowCreateW()
        {
            this.ShowDialog();
            if (map != null && isDone)
            {
                return map;
            }


            return null;

           
        
        }

        //private void buttonAddLine_Click(object sender, EventArgs e)
        //{
        //    int x1,y1,x2,y2;
        //    String[] paramString;

        //    try
        //    {

        //        x1 = Convert.ToInt32(paramString[0]);
        //        y1 = Convert.ToInt32(paramString[1]);
        //        x2 = Convert.ToInt32(paramString[2]);
        //        y2 = Convert.ToInt32(paramString[3]);
        //        AddLine(x1, y1, x2, y2);


        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Ошибка в роспознаниии координат");
        //        Log.AddLogMessage("Error detected cord");
            
        //    }
        //}


        //public void AddLine(Point p1, Point p2)
        //{

        //    AddLine(p1.X, p1.Y, p2.X, p2.Y);


        //}


        //public void AddLine(int x1, int y1, int x2, int y2)
        //{
        //    try
        //    {
        //        map.StartPoints.Add(new Line(x1, y1, x2, y2));


        //        RefreshLines();
                

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ошибка в додавании линии"+ex.Message);
            
        //    }
        
        //}

        //private void RefreshLines()
        //{
        //    listBox1.Items.Clear();
        //    if (grafLinr != null)
        //    {
        //        grafLinr.Clear(Color.Transparent);
        //    }

        //    for (int i = 0; i < map.StartPoints.Count; i++)
        //    {
        //        if (textBoxScale.Text == "")
        //        {
        //            listBox1.Items.Add(map.StartPoints[i].ToString());
        //        }
        //        else
        //        {
        //            listBox1.Items.Add(map.StartPoints[i].ToString(Convert.ToInt32(textBoxScale.Text)));
        //        }
        //        DrawLineInImage(map.StartPoints[i].Point1.X, map.StartPoints[i].Point1.Y, map.StartPoints[i].Point2.X, map.StartPoints[i].Point2.Y);

        //    }
        //}


        //private void DrawLineInImage(int x1, int y1, int x2, int y2)
        //{
        //    grafLinr = Graphics.FromImage(bImg);
        //    grafLinr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //    pictureBox1.Image = bImg;
        //    grafLinr.DrawLine(new Pen(Color.Yellow,2.0f),new Point(x1,y1),new Point(x2,y2));
        //    pictureBox1.Refresh();



        //}


        //private void buttonDrawLine_Click(object sender, EventArgs e)
        //{
        //    if (pictureBox1.Image != null)
        //    {
        //        isDrawLine = true;
        //        buttonDrawLine.Enabled = false;
        //    }
            
        //}

      
        //private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isDrawLine)
        //    {
        //        Cursor.Current = Cursors.Cross;
               
        //    }
            
        //}

        //private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (isDrawLine)
        //    {
        //        if (tempPoint1.IsEmpty && e.Button == MouseButtons.Left)
        //        {

        //            tempPoint1 = new Point(e.X, e.Y);

                    

        //        }
        //        else if (tempPoint2.IsEmpty && e.Button == MouseButtons.Left) ///12312v j1lihjciohfgqlj khg;erl
        //        {
        //            tempPoint2 = new Point(e.X, e.Y);

        //            AddLine(tempPoint1, tempPoint2);

        //            tempPoint1 = Point.Empty;
        //            tempPoint2 = Point.Empty;
        //            isDrawLine = false;
        //            buttonDrawLine.Enabled = true;

        //        }
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (listBox1.SelectedIndex >-1)
        //    {
        //        map.StartPoints.RemoveAt(listBox1.SelectedIndex);
        //        RefreshLines();
            
        //    }
        //}

        //private void trackBar1_Scroll(object sender, EventArgs e)
        //{
        //    labelTemp.Text = "T="+trackBarTemp.Value;
        //}

        //private void trackBar2_Scroll(object sender, EventArgs e)
        //{
        //    labelHumi.Text = "Humidity =" + trackBarHumi.Value;
        //}

        //private void trackBar3_Scroll(object sender, EventArgs e)
        //{
        //    labelDirection.Text = "Direction =" + trackBarDirection.Value + "%";

        //   // MoveArrowWind();


        //}

        //private void textBoxSpeed_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar))
        //    {

        //        e.KeyChar = '\n';

        //    }
        //}

        //private void textBoxScale_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void textBoxScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {

                e.KeyChar = '\n';

            }
        }





        //private void MoveArrowWind()
        //{
        //    //Длинна стрелки
            
        //    double x0 = lineShape1.X1, y0 = lineShape1.Y1;


        //    lineShape1.X2 = (int)(751 + radius * Math.Cos((trackBarDirection.Value * (Math.PI / 180))));
        //    lineShape1.Y2 = (int)(394 + radius * Math.Sin((trackBarDirection.Value * (Math.PI / 180))));



        //}
    }
}
