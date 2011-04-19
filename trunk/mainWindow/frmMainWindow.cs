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
using wParams;
using System.Runtime.Serialization.Formatters.Binary;

namespace Myprojekt
{
    public partial class frmMainWindow : Form
    {
        Graphics graf,graf1;
        Bitmap drawableImage, img, bImg;
        Marker marker;
        int width, hight;
        Map map;
        frmPolygons frmPoly;
        List<Block> blocks;
        public frmSettings settingsForm;
        frmAbout frmAbout;
        EnviParams servData = new EnviParams();
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
        private RibbonButton _buttonShowFire;
        private RibbonButton _buttonCalcFire;
        private RibbonComboBox _comboBoxWindDirect;
        private RibbonSpinner _windSpeed;
        private RibbonSpinner _temp;
        private RibbonButton _buttonStartDemo;

        private UICollectionChangedEvent _uiCollectionChangedEvent;

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
            _buttonShowFire = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonShowFire);
            _buttonCalcFire = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonCalcFire);
            _comboBoxWindDirect = new RibbonComboBox(_ribbon, (uint)RibbonMarkupCommands.cmdComboBoxWind);
            _temp = new RibbonSpinner(_ribbon, (uint)RibbonMarkupCommands.cmdTemp);
            _windSpeed = new RibbonSpinner(_ribbon, (uint)RibbonMarkupCommands.cmdSpeedWind);
            _buttonStartDemo = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonStartDemo);

            _temp.MaxValue=100;
            _temp.MinValue = 0;
            _windSpeed.MaxValue = 100;
            _windSpeed.MinValue = 0;

            _comboBoxWindDirect.Label = "Wind Direct";
            _comboBoxWindDirect.RepresentativeString = "NWE";


            _uiCollectionChangedEvent = new UICollectionChangedEvent();

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
             _buttonShowFire.ExecuteEvent+=new EventHandler<ExecuteEventArgs>(_buttonShowFire_ExecuteEvent);
             _buttonCalcFire.ExecuteEvent += new EventHandler<ExecuteEventArgs>(_buttonCalcFire_ExecuteEvent);
             _comboBoxWindDirect.ExecuteEvent += new EventHandler<ExecuteEventArgs>(_comboBoxWindDirect_ExecuteEvent);
             _comboBoxWindDirect.ItemsSourceReady += new EventHandler<EventArgs>(_comboBoxWindDirect_ItemsSourceReady);
             _buttonStartDemo.ExecuteEvent += new EventHandler<ExecuteEventArgs>(_buttonStartDemo_ExecuteEvent);
             _temp.ExecuteEvent += new EventHandler<ExecuteEventArgs>(_temp_ExecuteEvent);
             _windSpeed.ExecuteEvent += new EventHandler<ExecuteEventArgs>(_windSpeed_ExecuteEvent);
            #endregion
            
        }

        void _windSpeed_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            try
            {
                map.Speed = (int?)_windSpeed.DecimalValue;

            }
            catch (Exception)
            { 
            
            }
        }

        void _temp_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            try
            {
                map.Temp = (int?)_temp.DecimalValue;

            }
            catch (Exception)
            {

            }
        }

        void _buttonStartDemo_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            try
            {
                graf.Clear(Color.Transparent);
                graf = Graphics.FromImage(drawableImage);

                for (int i = 0; i < 0.3*map.Speed+0.1*(int)map.Temp; i++)
                {
                    marker.MakeFaire(ref graf, map.FirePoint, i, map.WindDirect);
                    pictureBox1.Image = drawableImage;
                    pictureBox1.Update();
                    Thread.Sleep(50);
                }
            }
            catch (Exception)
            { }
        }

        void _comboBoxWindDirect_ItemsSourceReady(object sender, EventArgs e)
        {
            IUICollection itemsSource3 = _comboBoxWindDirect.ItemsSource;
            itemsSource3.Clear();
            itemsSource3.Add(new GalleryItemPropertySet() { Label = "N", CategoryID = Constants.UI_Collection_InvalidIndex });
            itemsSource3.Add(new GalleryItemPropertySet() { Label = "W", CategoryID = Constants.UI_Collection_InvalidIndex });
            itemsSource3.Add(new GalleryItemPropertySet() { Label = "S", CategoryID = Constants.UI_Collection_InvalidIndex });
            itemsSource3.Add(new GalleryItemPropertySet() { Label = "E", CategoryID = Constants.UI_Collection_InvalidIndex });
            itemsSource3.Add(new GalleryItemPropertySet() { Label = "NE", CategoryID = Constants.UI_Collection_InvalidIndex });
            itemsSource3.Add(new GalleryItemPropertySet() { Label = "SE", CategoryID = Constants.UI_Collection_InvalidIndex });
            itemsSource3.Add(new GalleryItemPropertySet() { Label = "NW", CategoryID = Constants.UI_Collection_InvalidIndex });
            itemsSource3.Add(new GalleryItemPropertySet() { Label = "SW", CategoryID = Constants.UI_Collection_InvalidIndex });
        }

        void _comboBoxWindDirect_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            if (_comboBoxWindDirect.StringValue=="N")
            {
                map.WindDirect = Marker.WindDirect.N;

            }

            if (_comboBoxWindDirect.StringValue == "W")
            {
                map.WindDirect = Marker.WindDirect.W;

            }
            if (_comboBoxWindDirect.StringValue == "S")
            {
                map.WindDirect = Marker.WindDirect.S;

            }
            if (_comboBoxWindDirect.StringValue == "E")
            {
                map.WindDirect = Marker.WindDirect.E;

            }
            if (_comboBoxWindDirect.StringValue == "NE")
            {
                map.WindDirect = Marker.WindDirect.NE;

            }
            if (_comboBoxWindDirect.StringValue == "SE")
            {
                map.WindDirect = Marker.WindDirect.SE;

            }
            if (_comboBoxWindDirect.StringValue == "SW")
            {
                map.WindDirect = Marker.WindDirect.SW;

            }
            if (_comboBoxWindDirect.StringValue == "NW")
            {
                map.WindDirect = Marker.WindDirect.NW;

            }
        }

        void _buttonCalcFire_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            try
            {
                graf = Graphics.FromImage(drawableImage);

                for (int i = 0; i < 100; i++)
                {
                    marker.MakeFaire(ref graf, map.FirePoint, i, map.WindDirect);
                    pictureBox1.Image = drawableImage;
                    pictureBox1.Update();
                    Thread.Sleep(50);
                }
            }
            catch (Exception)
            { }
        }

        void _buttonShowFire_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            try
            {
                DrawBound(map.FirePoint.Points, Color.Red);
            }
            catch (Exception)
            { }
        }



        #region Ribbon events

        void _helpButton_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            frmAbout = new frmAbout();
            frmAbout.ShowDialog();
        }

        void _buttonShowPolygons_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
            
            if (map != null)
            {
                /*
                drawableImage = new Bitmap(width, hight);
                graf = Graphics.FromImage(drawableImage);

                for (int i = 0; i < 100;i++ )
                {
                    marker.MakeFaire(ref graf, map.Poligons[0],i,Marker.WindDirect.E);
                    pictureBox1.Image = drawableImage;
                    pictureBox1.Update();
                    Thread.Sleep(50);
                }

                */

                for (int i = 0; i < map.Poligons.Count; i++)
                {

                    DrawBound(map.Poligons[i].Points, map.Poligons[i].Color);
                
                }


            }
            else
            {
                MessageBox.Show("Для розрахунку карти її необхідно відкрити.", "Карту невідкрито", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        void _buttonCalculate_ExecuteEvent(object sender, ExecuteEventArgs e)
        {


            if (map != null)
            {
                
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
            mf.ShowThis(map);
        }

        void _buttonCreateMap_ExecuteEvent(object sender, ExecuteEventArgs e)
        {
           
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
            if (map != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SerializHelper.SaveMap(saveFileDialog1.FileName, map,0);
                }
            }
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
           CreateMap(addMap.ShowCreateW());
        }



        #endregion

        public void DrawBound(Point[] p1, Color color)
        {
            if (p1 != null && p1.Length != 0)
            {
                graf1 = Graphics.FromImage(drawableImage);
                Pen p = new Pen(color, 4.0f);
                graf1.DrawPolygon(p, p1);
                pictureBox1.Image = drawableImage;
                pictureBox1.Refresh();
            }

        }


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
            bImg = new Bitmap(img.Width, img.Height);
            

            drawableImage = new Bitmap(img.Width, img.Height);
            pictureBox1.Image = drawableImage;

            width = pictureBox1.BackgroundImage.Width;
            hight = pictureBox1.BackgroundImage.Height;
            graf = Graphics.FromImage(drawableImage);

            labelMessage.Visible = false;

            setMapLocal();
            FireToCenter();

        }

        private void FireToCenter()
        {
        //    pictureBox1.Location = new Point(pictureBox1.Location.X - pictureBox1.Width / 2 - map.FirePoint.Points[0].X,
        //        pictureBox1.Location.Y - pictureBox1.Height / 2 - map.FirePoint.Points[0].Y);

            panel3.VerticalScroll.Value = Math.Abs((map.FirePoint.Points[0].Y -pictureBox1.Height)/2 );
            panel3.HorizontalScroll.Value = Math.Abs((map.FirePoint.Points[0].X - pictureBox1.Width) / 2);
            //pictureBox1.Location = new Point(pictureBox1.Location.X - 10 ,
            //    pictureBox1.Location.Y - 10 );

        
        
        }


        private void CreateMap(Map cMap)
        {
            if (cMap != null)
            {
                map = cMap;

                img = map.Img;
                pictureBox1.BackgroundImage = map.Img;

                drawableImage = new Bitmap(img.Width, img.Height);
                bImg = new Bitmap(img.Width, img.Height);
                pictureBox1.Image = drawableImage;

                width = pictureBox1.BackgroundImage.Width;
                hight = pictureBox1.BackgroundImage.Height;
                graf = Graphics.FromImage(drawableImage);

                labelMessage.Visible = false;

                setMapLocal();
                FireToCenter();
            }
        
        
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

            try
            {
                NetworkStream clientStream = client.GetStream();

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes("gibe_me_some_stats");
                clientStream.Write(buffer, 0, buffer.Length);

                BinaryFormatter bf = new BinaryFormatter();
                servData = (EnviParams)bf.Deserialize(clientStream);
                MessageBox.Show("Wind force is: " + servData.Windforce, "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clientStream.Flush();
                tmAskServ.Interval = settingsForm.appSettings.updateRate * 60000;
            }
            catch
            {
                MessageBox.Show("Bad server output.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmMainWindow_SizeChanged(object sender, EventArgs e)
        {
            setMapLocal();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //SizeF sf = new SizeF(0.01f,0.01f);
            //pictureBox1.BackgroundImage.SScale(sf);
        }





    }
}
