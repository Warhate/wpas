using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Layout;

namespace Myprojekt
{
    public partial class frmMainWindow : Form
    {
        
        Graphics graf;
        Bitmap drawableImage, img;
        Marker marker;
        int width, hight;
        Map map;
        List<Block> blocks;
        
        public frmMainWindow()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            

            this.BackColor = Color.Transparent;

            //panel2.Parent = pictureBox1;
            marker = new Marker();

            width = pictureBox1.BackgroundImage.Width;
            hight = pictureBox1.BackgroundImage.Height;
            blocks = new List<Block>();
            panel1.AutoScrollPosition = new Point(100, 100);

            this.WindowState = FormWindowState.Maximized;
            
        }

        
        frmFilters FormFilter = new frmFilters();
        AddMap addMap = new AddMap();

        private void fireSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Question",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Application.Exit();
        }

        private void createFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilter.ShowDialog();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void createMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addMap.ShowDialog();
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapForm mf = new MapForm();
            mf.ShowDialog();
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            
           // //panel2.Visible = false;
           // if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
           // {
           //    panel2.Location = new Point(panel2.Location.X + (e.NewValue - e.OldValue), panel2.Location.Y);
           // }
           // else
           // {
           //     panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + (e.NewValue - e.OldValue));

           // }
           //// panel2.Visible = true;
             
             
           
        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            drawableImage = new Bitmap(width, hight);
            graf = Graphics.FromImage(drawableImage);


            ProgressBar.Style = ProgressBarStyle.Marquee;
            labelStatus.Text = "Розраховується градація...";

            bWDrawGrid.RunWorkerAsync(txtBlockSize.Text == "" ? 100 : Convert.ToInt32(txtBlockSize.Text));
            
              

        }

        private void button5_Click(object sender, EventArgs e)
        {

            drawableImage = new Bitmap(width, hight);
            graf = Graphics.FromImage(drawableImage);


            ProgressBar.Style = ProgressBarStyle.Marquee;
            labelStatus.Text = "Розраховується небезпечність зон...";

            bWCalcute.RunWorkerAsync(txtBlockSize.Text == "" ? 100 : Convert.ToInt32(txtBlockSize.Text));




            // Gradation(width, higth, bSize);
            // marker.GetListBlocks(width, higth, bSize);
            //pictureBox.Refresh();
        }

        private void bWDrawGrid_DoWork(object sender, DoWorkEventArgs e)
        {
             marker.DrawGrid(width,
                hight, 
                (int)e.Argument, 
                ref graf);
             
        }

        private void bWDrawGrid_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bWDrawGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Style = ProgressBarStyle.Blocks;
            labelStatus.Text = "";
            pictureBox1.Image = drawableImage;
            pictureBox1.Refresh();

        }

        private void btnCalcute_Click(object sender, EventArgs e)
        {
            
        }

        private void bWCalcute_DoWork(object sender, DoWorkEventArgs e)
        {
            marker.DrawGrid(width, hight, (int)e.Argument, ref graf);

            blocks = marker.GetListBlocks(width, hight, (int)e.Argument);

            marker.DetectedPower(ref blocks, map.Poligons);

            marker.DrawPowerBlocks(ref graf, blocks);
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {

        }

        private void OpenMap(string filename)
        {
            map = SerializHelper.OpenMapFile(filename);

            img = map.Img;
            pictureBox1.BackgroundImage = map.Img;

            

            drawableImage = new Bitmap(img.Width, img.Height);
            pictureBox1.Image = drawableImage;

            width = pictureBox1.BackgroundImage.Width;
            hight = pictureBox1.BackgroundImage.Height;
            graf = Graphics.FromImage(drawableImage);

        }

        private void btnOpenMap_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenMap(openFileDialog1.FileName);
                Log.AddLogMessage("Open map:" + openFileDialog1.FileName);


            }
        }

        private void bWCalcute_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Style = ProgressBarStyle.Blocks;
            labelStatus.Text = "";
            pictureBox1.Image = drawableImage;
            pictureBox1.Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

            
            
        }
    }
}
