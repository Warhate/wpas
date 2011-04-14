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
    public partial class MapForm : Form
    {
        Map map;
        Bitmap img, bImg,gridImg;
        Graphics grafLinr;
        Graphics graf;
        int width, higth;
        bool isDrawPoligon;
        List<Point> points = new List<Point>();
        Marker marker = new Marker();
        List<Block> blocks = new List<Block>();
        Bitmap bmp;
        Graphics grf;

        enum MarketMethod
        { 
            Grid,
            Line
        
        }



        public MapForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddMap am = new AddMap();
            am.ShowDialog();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenMap(openFileDialog1.FileName);
                Log.AddLogMessage("Open map:" + openFileDialog1.FileName);
                toolStripPoly.Enabled = true;
                saveMapButton.Enabled = true;
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void OpenMap(string filename)
        {
            map = SerializHelper.OpenMapFile(filename);

            img = map.Img;
            pictureBox.BackgroundImage = img;

            img = map.Img;

            bImg = new Bitmap(img.Width, img.Height);
            pictureBox.Image = bImg;


            textBoxSpeed.Text = map.Speed.ToString();
            textBoxScale.Text = map.Scale.ToString();

            trackBarDirection.Value = (int)map.Direction;
            labelDirection.Text = "Direction = " + trackBarDirection.Value + "%";

            trackBarHumi.Value = (int)map.Humi;
            labelHumi.Text = "Humidity = " +trackBarHumi.Value+ "%";

            trackBarTemp.Value = (int)map.Temp;
            labelTemp.Text = "Temp = " + trackBarTemp.Value;

            RefreshLines();

            width = pictureBox.BackgroundImage.Width;
            higth = pictureBox.BackgroundImage.Height;
            graf = Graphics.FromImage(bImg);
            
        }

        private void trackBarDirection_Scroll(object sender, EventArgs e)
        {
            labelDirection.Text = "Direction = " + trackBarDirection.Value + "%";
        }

        private void trackBarHumi_Scroll(object sender, EventArgs e)
        {
            labelHumi.Text = "Humidity = " + trackBarHumi.Value + "%";
        }

        private void trackBarTemp_Scroll(object sender, EventArgs e)
        {
            labelTemp.Text = "Temp = " + trackBarTemp.Value;
        }


        /// <summary>
        /// Рисует линию на полтоне
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        private void DrawLineInImage(int x1, int y1, int x2, int y2)
        {
            grafLinr = Graphics.FromImage(bImg);
            grafLinr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pictureBox.Image = bImg;
            grafLinr.DrawLine(new Pen(Color.Yellow, 2.0f), new Point(x1, y1), new Point(x2, y2));
            pictureBox.Refresh();



        }

        /// <summary>
        /// Обновление линий
        /// </summary>
        private void RefreshLines()
        {
            listBox1.Items.Clear();
            if (grafLinr != null)
            {
                grafLinr.Clear(Color.Transparent);
            }

            for (int i = 0; i < map.StartPoints.Count; i++)
            {
                if (textBoxScale.Text == "")
                {
                    listBox1.Items.Add(map.StartPoints[i].ToString());
                }
                else
                {
                    listBox1.Items.Add(map.StartPoints[i].ToString(Convert.ToInt32(textBoxScale.Text)));
                }
                DrawLineInImage(map.StartPoints[i].Point1.X, map.StartPoints[i].Point1.Y, map.StartPoints[i].Point2.X, map.StartPoints[i].Point2.Y);

            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&&e.KeyChar!='\b')
            {

                e.KeyChar = '\n';

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SerializHelper.SaveMap(openFileDialog1.SafeFileName.Split('.')[0], map);
            Log.AddLogMessage("Map save");
        }

        private void textBoxSpeed_Leave(object sender, EventArgs e)
        {
            map.Speed = Convert.ToInt32(textBoxSpeed.Text);
        }

        private void trackBarDirection_Leave(object sender, EventArgs e)
        {
            map.Direction = trackBarDirection.Value;
        }

        private void trackBarHumi_Leave(object sender, EventArgs e)
        {
            map.Humi = trackBarHumi.Value;
        }

        private void trackBarTemp_Leave(object sender, EventArgs e)
        {
            map.Temp = trackBarTemp.Value;
        }

        private void textBoxScale_Leave(object sender, EventArgs e)
        {
            try
            {
                map.Scale = Convert.ToInt32(textBoxScale.Text);
            }
            catch (Exception)
            {
                map.Scale = 0;
            
            }

        }


        public void DrawGrid()
        {
            if (graf != null)
            {
                graf.Clear(Color.Transparent);
            }
            else 
            {
                graf = Graphics.FromImage(bImg);
            
            }
            int width, higth,bSize;
            width = pictureBox.BackgroundImage.Width;
            higth = pictureBox.BackgroundImage.Height;

            if (textBoxBSize.Text == "")
            {
                bSize = 100;


            }
            else
            {
                bSize = Convert.ToInt32(textBoxBSize.Text);
            
            }

            labelInProggres.Visible = true;
            toolStripProgressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync(bSize);
           // Gradation(width, higth, bSize);
           // marker.GetListBlocks(width, higth, bSize);
            //pictureBox.Refresh();
        
        }

        private void Gradation(int width, int higth, int bSize)
        {
            marker.DrawGrid(width, higth, bSize, ref graf);

            blocks = marker.GetListBlocks(width, higth, bSize);

            marker.DetectedPower(ref blocks, map.Poligons);

            marker.DrawPowerBlocks(ref graf, blocks);
        }


        


        private void DrawLineInGrid(int x1, int y1, int x2, int y2)
        {

            
            
            graf = Graphics.FromImage(bImg);
            
            graf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pictureBox.Image = bImg;
            graf.DrawLine(new Pen(Color.SkyBlue, 1.0f), new Point(x1, y1), new Point(x2, y2));
            pictureBox.Refresh();



        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DrawGrid();
        }


        public void DrawMarker(String method)
        {
            switch (method)
            {
                case "Grid":
                    {
                        DrawGrid();
                        break;
                            
                    
                    }

                case "Linar":
                    {
                        RefreshLines();
                        break;


                    }


            
            }
                
        
        }

        

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Log.AddLogMessage("Calcute Lines");

            CalcuteNewLine();
            DrawNewLines();

        }

        public void CalcuteNewLine()
        {
            ///map.NewLines.Clear();

            for (int i = 0; i < map.StartPoints.Count; i++)
            {
                Point p1, p2;

                p1 = new Point(MathHelper.GetNextPoint(map.StartPoints[i].Point1.X,
                    map.StartPoints[i].Point1.Y,
                    map.StartPoints[i].Point2.X,
                    map.StartPoints[i].Point2.Y,
                    0,
                    true),
                    0);

                p2 = new Point(MathHelper.GetNextPoint(map.StartPoints[i].Point1.X,
                    map.StartPoints[i].Point1.Y,
                    map.StartPoints[i].Point2.X,
                    map.StartPoints[i].Point2.Y,
                    higth,
                    true),
                     higth);

                AddNewLine(p1, p2);
                

            }



        
        }

        private void AddNewLine(Point p1, Point p2)
        {
            map.NewLines.Add(new Line(p1, p2));
        }



        public void DrawNewLines()
        {
            for (int i = 0; i < map.NewLines.Count; i++)
            {
                DrawLineInGrid(map.NewLines[i].Point1.X,
                     map.NewLines[i].Point1.Y,
                     map.NewLines[i].Point2.X,
                     map.NewLines[i].Point2.Y);


            }
        
        }

        public void DrawBound(Point[] p1,Color color)
        {
            graf = Graphics.FromImage(bImg);
            Pen p = new Pen(color,4.0f);
            graf.DrawPolygon(p, p1);
            pictureBox.Image = bImg;
            pictureBox.Refresh();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[1].Hide();
            Log.AddLogMessage("Started program");
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isDrawPoligon = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawPoligon)
            {
                Cursor.Current = Cursors.Cross;
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {

            if(isDrawPoligon)
            {

                SetPoligon(e);


               
            }
        }

        private void SetPoligon(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                grf.FillEllipse(Brushes.RoyalBlue, e.X, e.Y, 10.0f, 10.0f);
                pictureBox.Image = bmp;
                pictureBox.Refresh();
                points.Add(new Point(e.X, e.Y));
            }
            else if (e.Button == MouseButtons.Right)
            {

                Point[] ps = new Point[points.Count];

                for (int i = 0; i < points.Count; i++)
                {
                    ps[i] = points[i];

                }

                String desc;
                MarkPlace.PlaceType type;

                AddPoligon ap = new AddPoligon();

                ap.ShowThis(out desc, out type);

                MarkPlace mp = new MarkPlace(ps, type, desc);

                map.Poligons.Add(mp);
                

                isDrawPoligon = false;
                points.Clear();

                AddPoligonToList();

            }
        }

        private void AddPoligonToList()
        {
            

            for (int i = 0; i < map.Poligons.Count; i++)
            {

                
                dataGridView1.Rows.Add(map.Poligons[i].Type, map.Poligons[i].Description, MathHelper.GetPoligonSpace(map.Poligons[i].Points));

                DrawBound(map.Poligons[i].Points, map.Poligons[i].Color);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPoligonToList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.AddLogMessage("Close program");
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            

            Gradation(width, higth, (int)e.Argument);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelInProggres.Visible = false;
            toolStripProgressBar1.Visible = false;
           
            pictureBox.Refresh();

        }

        private void textBoxSizeBlock_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

            int bSize;
            if (textBoxBSize.Text == "")
            {
                bSize = 100;


            }
            else
            {
                bSize = Convert.ToInt32(textBoxBSize.Text);

            }
            graf.Clear(Color.Transparent);

            marker.DrawGrid(width, higth, bSize, ref graf);
            pictureBox.Refresh();
            
                
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            isDrawPoligon = true;
            bmp = new Bitmap(pictureBox.BackgroundImage.Width, pictureBox.BackgroundImage.Height);
            grf = Graphics.FromImage(bmp);

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            AddPoligonToList();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            DrawGrid();
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {


            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                labelInProggres.Location = new Point(labelInProggres.Location.X + (e.NewValue - e.OldValue), labelInProggres.Location.Y);
            }
            else
            {
                labelInProggres.Location = new Point( labelInProggres.Location.X,labelInProggres.Location.Y + (e.NewValue - e.OldValue));
            
            }
        }

        private void groupBoxGrid_Enter(object sender, EventArgs e)
        {

        }








    }
}
