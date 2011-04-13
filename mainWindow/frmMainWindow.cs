using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Layout;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using RibbonLib;
using RibbonLib.Controls;
using RibbonLib.Controls.Events;
using RibbonLib.Interop;

namespace Myprojekt
{
    public partial class frmMainWindow : Form
    {
        Graphics graf;
        Bitmap drawableImage, img;
        Marker marker;
        int width, hight;
        Map map;
        frmPolygons frmPoly;
        List<Block> blocks;
        public frmSettings settingsForm;
        frmAbout frmAbout;
                #region Ribbon Start

        

        //Ribbon
        private RibbonButton _buttonCreate;
        private RibbonButton _buttonOpen;
        private RibbonButton _buttonSave;
        private RibbonButton _buttonSettings;
        private RibbonButton _buttonExit;
        private RibbonButton _buttonStart;
        private RibbonButton _buttonStop;
        private RibbonButton _buttonCreateMap;
        private RibbonButton _buttonMarkerMap;
        private RibbonButton _buttonCreateFilters;
        private RibbonButton _buttonOpenFilters;
        private RibbonButton _buttonGrid;
        private RibbonButton _buttonCalculate;
        private RibbonButton _buttonShowPolygons;
        private RibbonHelpButton _helpButton;
        private RibbonSpinner _blockSize;

        #endregion


        public frmMainWindow()
        {
            settingsForm = new frmSettings();
            // загрузка настроек приложения
            settingsForm.appSettings.loadSettings();

            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            

            this.BackColor = Color.Transparent;

            //panel2.Parent = pictureBox1;
            marker = new Marker();


            blocks = new List<Block>();


            this.WindowState = FormWindowState.Maximized;

            #region Ribbon init


            //Ribbon init
            _buttonCreate = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonCreate);
            _buttonCalculate = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonCalculate);
            _buttonCreateFilters = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonCreateFilters);
            _buttonCreateMap = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonCreateMap);
            _buttonExit = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonExit);
            _buttonGrid = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonGrid);
            _buttonMarkerMap = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonMarkerMap);
            _buttonOpen = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonOpen);
            _buttonOpenFilters = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonOpenFilters);
            _buttonSave = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonSave);
            _buttonSettings = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonSettings);
            _buttonShowPolygons = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonShowPolygons);
            _buttonStart = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonStart);
            _buttonStop = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonStop);
            _helpButton = new RibbonHelpButton(_ribbon, (uint)RibbonMarkupCommands.cmdHelpButton);
            _blockSize = new RibbonSpinner(_ribbon, (uint)RibbonMarkupCommands.cmdBlockSize);

            //Ribbon events
            _buttonCreate.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonCreate_ExecuteEvent);
            _buttonOpen.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonOpen_ExecuteEvent);
            _buttonSave.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonSave_ExecuteEvent);
            _buttonSettings.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonSettings_ExecuteEvent);
            _buttonExit.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonExit_ExecuteEvent);
            _buttonStart.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonStart_ExecuteEvent);
            _buttonStop.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonStop_ExecuteEvent);
            _buttonCreateMap.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonCreateMap_ExecuteEvent);
            _buttonMarkerMap.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonMarkerMap_ExecuteEvent);
            _buttonCreateFilters.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonCreateFilters_ExecuteEvent);
            _buttonOpenFilters.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonOpenFilters_ExecuteEvent);
            _buttonGrid.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonGrid_ExecuteEvent);
            _buttonCalculate.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonCalculate_ExecuteEvent);
            _buttonShowPolygons.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_buttonShowPolygons_ExecuteEvent);
            _helpButton.ExecuteEvent += new System.EventHandler<ExecuteEventArgs>(_helpButton_ExecuteEvent);

            #endregion
            
        }



        #region Ribbon events

        void _helpButton_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            frmAbout = new frmAbout();
            frmAbout.ShowDialog();
        }

        void _buttonShowPolygons_ExecuteEvent(object sender, ExecuteEventArgs e)
        {

          
            
        }

        void _buttonCalculate_ExecuteEvent(object sender, ExecuteEventArgs e)
        {


            if (map != null)
            {
                drawableImage = new Bitmap(width, hight);
                graf = Graphics.FromImage(drawableImage);


                ProgressBar.Style = ProgressBarStyle.Marquee;
                labelStatus.Text = "Розраховується небезпечність зон...";

                bWCalcute.RunWorkerAsync(_blockSize.DecimalValue <= 0 ? 100 : (int)_blockSize.DecimalValue);


            }
            else
            {
                MessageBox.Show("Для розрахунку карти її необхідно відкрити.", "Карту невідкрито", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            // Gradation(width, higth, bSize);
            // marker.GetListBlocks(width, higth, bSize);
            //pictureBox.Refresh();
        }

        void _buttonGrid_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            if (map != null)
            {
                drawableImage = new Bitmap(width, hight);
                graf = Graphics.FromImage(drawableImage);


                ProgressBar.Style = ProgressBarStyle.Marquee;
                labelStatus.Text = "Розраховується градація...";

                bWDrawGrid.RunWorkerAsync(_blockSize.DecimalValue <= 0 ? 100 : (int)_blockSize.DecimalValue);
            }
            else
            {
                MessageBox.Show("Для розрахунку карти її необхідно відкрити.", "Карту невідкрито", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        void _buttonOpenFilters_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            if (map != null && map.Poligons.Count > 0)
            {
                frmPoly = new frmPolygons();
                frmPoly.ShowDialog(map.Poligons);
            }
           
        }

        void _buttonCreateFilters_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            FormFilter.ShowDialog();
        }

        void _buttonMarkerMap_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            MapForm mf = new MapForm();
            mf.ShowDialog();
        }

        void _buttonCreateMap_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            addMap.ShowDialog();
        }

        void _buttonStop_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            tmAskServ.Enabled = false;
        }

        void _buttonStart_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            tmAskServ.Enabled = true;
        }

        void _buttonExit_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Question",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Application.Exit();
        }

        void _buttonSettings_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            settingsForm.ShowDialog();
        }

        void _buttonSave_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
           
        }

        void _buttonOpen_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenMap(openFileDialog1.FileName);
                Log.AddLogMessage("Open map:" + openFileDialog1.FileName);


            }
        }

        void _buttonCreate_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            
        }



        #endregion

        frmFilters FormFilter = new frmFilters();
        AddMap addMap = new AddMap();


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
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


        private void bWDrawGrid_DoWork(object sender, DoWorkEventArgs e)
        {
             marker.DrawGrid(width,
                hight, 
                (int)e.Argument, 
                ref graf);
             
        }



        private void bWDrawGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Style = ProgressBarStyle.Blocks;
            labelStatus.Text = "";
            pictureBox1.Image = drawableImage;
            pictureBox1.Refresh();

        }



        private void bWCalcute_DoWork(object sender, DoWorkEventArgs e)
        {



            marker.DrawGrid(width, hight, (int)e.Argument, ref graf);

            blocks = marker.GetListBlocks(width, hight, (int)e.Argument);

            marker.DetectedPower(ref blocks, map.Poligons);

            marker.DrawPowerBlocks(ref graf, blocks);
        }


        /// <summary>
        /// Открытие карты
        /// </summary>
        /// <param name="filename">Имя файла</param>
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

            labelMessage.Visible = false;

            setMapLocal();

        }

        /// <summary>
        /// Отцентровует карту, если она меньше ширины окна
        /// </summary>
        private void setMapLocal()
        {
            if (this.Size.Width > hight)
            {
                pictureBox1.Location = new Point((this.Size.Width - hight) / 2);

            }
            else
            {
                pictureBox1.Location = new Point(0,0);
            
            }
        }


        private void bWCalcute_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Style = ProgressBarStyle.Blocks;
            labelStatus.Text = "";
            pictureBox1.Image = drawableImage;
            pictureBox1.Refresh();
        }

 

        private void tmAskServ_Tick(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(settingsForm.appSettings.serverAddress), 3000);
            try
            {
                client.Connect(serverEndPoint);
            }
            catch
            {
                tmAskServ.Enabled = false;
                MessageBox.Show("Check your connection options.", "Error connecting to server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("Hello Server!");

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

            tmAskServ.Interval = settingsForm.appSettings.updateRate * 60000;
        }

        private void frmMainWindow_SizeChanged(object sender, EventArgs e)
        {
            setMapLocal();
        }





    }
}
