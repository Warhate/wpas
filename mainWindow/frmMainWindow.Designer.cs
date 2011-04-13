﻿using RibbonLib;
using RibbonLib.Controls;
using RibbonLib.Controls.Events;
using RibbonLib.Interop;

namespace Myprojekt
{
    partial class frmMainWindow
    {
        /// <summary>
        /// Команды меню
        /// </summary>
        public enum RibbonMarkupCommands : uint
        {
            cmdMenuGroupFile=1005,
            cmdButtonCreate=1001,
            cmdButtonOpen=1002,
            cmdButtonSave=1007,
            cmdButtonSettings=1003,
            cmdButtonExit=1004,
            cmdHelpButton = 1014,
            cmdButtonStart=1017,
            cmdButtonStop=1018,
            cmdButtonCreateMap=1021,
            cmdButtonMarkerMap=1022,
            cmdButtonCreateFilters=1025,
            cmdButtonOpenFilters=1026,
            cmdButtonGrid=1029,
            cmdButtonCalculate=1030,
            cmdButtonShowPolygons=1031,
            cmdBlockSize=1032
        }







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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainWindow));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bWDrawGrid = new System.ComponentModel.BackgroundWorker();
            this.bWCalcute = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tmAskServ = new System.Windows.Forms.Timer(this.components);
            this._ribbon = new RibbonLib.Ribbon();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.statusStrip2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // tmAskServ
            // 
            this.tmAskServ.Interval = 1000;
            this.tmAskServ.Tick += new System.EventHandler(this.tmAskServ_Tick);
            // 
            // _ribbon
            // 
            this._ribbon.AllowDrop = true;
            this._ribbon.Location = new System.Drawing.Point(0, 0);
            this._ribbon.Minimized = false;
            this._ribbon.Name = "_ribbon";
            this._ribbon.ResourceName = "Myprojekt.RibbonMarkup.ribbon";
            this._ribbon.ShortcutTableResourceName = null;
            this._ribbon.Size = new System.Drawing.Size(1085, 145);
            this._ribbon.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.labelMessage);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1085, 491);
            this.panel3.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "1";
            this.pictureBox1.WaitOnLoad = true;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMessage.Location = new System.Drawing.Point(12, 12);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(541, 41);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "Для початку роботи відкрийте карту";
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1085, 658);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this._ribbon);
            this.Controls.Add(this.statusStrip2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmMainWindow";
            this.Text = "WS&P";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.ComponentModel.BackgroundWorker bWDrawGrid;
        private System.ComponentModel.BackgroundWorker bWCalcute;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Timer tmAskServ;
        private RibbonLib.Ribbon _ribbon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMessage;




    }
}