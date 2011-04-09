namespace Myprojekt
{
    partial class frmMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fireSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startEmulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopEmulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBlockSize = new System.Windows.Forms.TextBox();
            this.btnDrawPolygon = new System.Windows.Forms.Button();
            this.btnCalcute = new System.Windows.Forms.Button();
            this.buttonDrawGrid = new System.Windows.Forms.Button();
            this.btnAd = new System.Windows.Forms.Button();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bWDrawGrid = new System.ComponentModel.BackgroundWorker();
            this.bWCalcute = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tmAskServ = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.fireSimulationToolStripMenuItem,
            this.mapsToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProjectToolStripMenuItem,
            this.openProjeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createProjectToolStripMenuItem
            // 
            this.createProjectToolStripMenuItem.Name = "createProjectToolStripMenuItem";
            this.createProjectToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.createProjectToolStripMenuItem.Text = "Create project";
            // 
            // openProjeToolStripMenuItem
            // 
            this.openProjeToolStripMenuItem.Name = "openProjeToolStripMenuItem";
            this.openProjeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openProjeToolStripMenuItem.Text = "Open project";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fireSimulationToolStripMenuItem
            // 
            this.fireSimulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startEmulationToolStripMenuItem,
            this.stopEmulationToolStripMenuItem});
            this.fireSimulationToolStripMenuItem.Name = "fireSimulationToolStripMenuItem";
            this.fireSimulationToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.fireSimulationToolStripMenuItem.Text = "Eimulation";
            this.fireSimulationToolStripMenuItem.Click += new System.EventHandler(this.fireSimulationToolStripMenuItem_Click);
            // 
            // startEmulationToolStripMenuItem
            // 
            this.startEmulationToolStripMenuItem.Name = "startEmulationToolStripMenuItem";
            this.startEmulationToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.startEmulationToolStripMenuItem.Text = "Start emulation";
            this.startEmulationToolStripMenuItem.Click += new System.EventHandler(this.startEmulationToolStripMenuItem_Click);
            // 
            // stopEmulationToolStripMenuItem
            // 
            this.stopEmulationToolStripMenuItem.Name = "stopEmulationToolStripMenuItem";
            this.stopEmulationToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.stopEmulationToolStripMenuItem.Text = "Stop emulation";
            this.stopEmulationToolStripMenuItem.Click += new System.EventHandler(this.stopEmulationToolStripMenuItem_Click);
            // 
            // mapsToolStripMenuItem
            // 
            this.mapsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMapToolStripMenuItem,
            this.openMapToolStripMenuItem});
            this.mapsToolStripMenuItem.Name = "mapsToolStripMenuItem";
            this.mapsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.mapsToolStripMenuItem.Text = "Maps";
            // 
            // createMapToolStripMenuItem
            // 
            this.createMapToolStripMenuItem.Name = "createMapToolStripMenuItem";
            this.createMapToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.createMapToolStripMenuItem.Text = "Create map";
            this.createMapToolStripMenuItem.Click += new System.EventHandler(this.createMapToolStripMenuItem_Click);
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.openMapToolStripMenuItem.Text = "Open map";
            this.openMapToolStripMenuItem.Click += new System.EventHandler(this.openMapToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFiltersToolStripMenuItem,
            this.openFiltersToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // createFiltersToolStripMenuItem
            // 
            this.createFiltersToolStripMenuItem.Name = "createFiltersToolStripMenuItem";
            this.createFiltersToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.createFiltersToolStripMenuItem.Text = "Create filters";
            this.createFiltersToolStripMenuItem.Click += new System.EventHandler(this.createFiltersToolStripMenuItem_Click);
            // 
            // openFiltersToolStripMenuItem
            // 
            this.openFiltersToolStripMenuItem.Name = "openFiltersToolStripMenuItem";
            this.openFiltersToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFiltersToolStripMenuItem.Text = "Open filters";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 612);
            this.panel1.TabIndex = 13;
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Myprojekt.Properties.Resources.map_pripyat;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(3516, 3083);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "1";
            this.pictureBox1.WaitOnLoad = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBlockSize);
            this.panel2.Controls.Add(this.btnDrawPolygon);
            this.panel2.Controls.Add(this.btnCalcute);
            this.panel2.Controls.Add(this.buttonDrawGrid);
            this.panel2.Controls.Add(this.btnAd);
            this.panel2.Controls.Add(this.btnOpenMap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(57, 612);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtBlockSize
            // 
            this.txtBlockSize.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBlockSize.Location = new System.Drawing.Point(5, 282);
            this.txtBlockSize.Name = "txtBlockSize";
            this.txtBlockSize.Size = new System.Drawing.Size(48, 48);
            this.txtBlockSize.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtBlockSize, "Розмір блоку розмітки");
            // 
            // btnDrawPolygon
            // 
            this.btnDrawPolygon.BackgroundImage = global::Myprojekt.Properties.Resources._1301475484_draw_polygon_curves;
            this.btnDrawPolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDrawPolygon.Location = new System.Drawing.Point(5, 228);
            this.btnDrawPolygon.Name = "btnDrawPolygon";
            this.btnDrawPolygon.Size = new System.Drawing.Size(48, 48);
            this.btnDrawPolygon.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnDrawPolygon, "Показати особливі зони мапи");
            this.btnDrawPolygon.UseVisualStyleBackColor = true;
            this.btnDrawPolygon.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // btnCalcute
            // 
            this.btnCalcute.BackgroundImage = global::Myprojekt.Properties.Resources._1301423055_Maps;
            this.btnCalcute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalcute.Location = new System.Drawing.Point(5, 174);
            this.btnCalcute.Name = "btnCalcute";
            this.btnCalcute.Size = new System.Drawing.Size(48, 48);
            this.btnCalcute.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnCalcute, "Розрахувати небезпеку зон мапи");
            this.btnCalcute.UseVisualStyleBackColor = true;
            this.btnCalcute.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonDrawGrid
            // 
            this.buttonDrawGrid.BackgroundImage = global::Myprojekt.Properties.Resources._1301423012_3x3_grid_2;
            this.buttonDrawGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDrawGrid.Location = new System.Drawing.Point(5, 120);
            this.buttonDrawGrid.Name = "buttonDrawGrid";
            this.buttonDrawGrid.Size = new System.Drawing.Size(48, 48);
            this.buttonDrawGrid.TabIndex = 3;
            this.toolTip1.SetToolTip(this.buttonDrawGrid, "Розмітити сітку на мапі");
            this.buttonDrawGrid.UseVisualStyleBackColor = true;
            this.buttonDrawGrid.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAd
            // 
            this.btnAd.BackgroundImage = global::Myprojekt.Properties.Resources._1289309280_11;
            this.btnAd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAd.Location = new System.Drawing.Point(5, 66);
            this.btnAd.Name = "btnAd";
            this.btnAd.Size = new System.Drawing.Size(48, 48);
            this.btnAd.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAd, "Згенерувати новий файл мапи");
            this.btnAd.UseVisualStyleBackColor = true;
            this.btnAd.Click += new System.EventHandler(this.btnCalcute_Click);
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.BackgroundImage = global::Myprojekt.Properties.Resources._1301423033_folder_64;
            this.btnOpenMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenMap.Location = new System.Drawing.Point(5, 12);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(48, 48);
            this.btnOpenMap.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnOpenMap, "Відкрити згенеровану мапу для подальшої роботи.\r\n");
            this.btnOpenMap.UseVisualStyleBackColor = true;
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click_1);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.labelStatus});
            this.statusStrip2.Location = new System.Drawing.Point(0, 636);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1085, 22);
            this.statusStrip2.TabIndex = 14;
            this.statusStrip2.Text = "statusStrip2";
            this.statusStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip2_ItemClicked);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // bWDrawGrid
            // 
            this.bWDrawGrid.WorkerReportsProgress = true;
            this.bWDrawGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWDrawGrid_DoWork);
            this.bWDrawGrid.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWDrawGrid_ProgressChanged);
            this.bWDrawGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWDrawGrid_RunWorkerCompleted);
            // 
            // bWCalcute
            // 
            this.bWCalcute.WorkerReportsProgress = true;
            this.bWCalcute.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWCalcute_DoWork);
            this.bWCalcute.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWCalcute_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Map file(*.map)|*.map";
            this.openFileDialog1.InitialDirectory = "/maps";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1085, 612);
            this.splitContainer1.SplitterDistance = 57;
            this.splitContainer1.TabIndex = 15;
            // 
            // tmAskServ
            // 
            this.tmAskServ.Interval = 1000;
            this.tmAskServ.Tick += new System.EventHandler(this.tmAskServ_Tick);
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1085, 658);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip2);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainWindow";
            this.Text = "WS&P";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fireSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startEmulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopEmulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.Button btnDrawPolygon;
        private System.Windows.Forms.Button btnCalcute;
        private System.Windows.Forms.Button buttonDrawGrid;
        private System.Windows.Forms.Button btnAd;
        private System.Windows.Forms.TextBox txtBlockSize;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.ComponentModel.BackgroundWorker bWDrawGrid;
        private System.ComponentModel.BackgroundWorker bWCalcute;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Timer tmAskServ;
    }
}