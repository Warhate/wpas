namespace Myprojekt
{
    partial class frmPolygons
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
            this.polygonView = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.polygonView)).BeginInit();
            this.SuspendLayout();
            // 
            // polygonView
            // 
            this.polygonView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.polygonView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.polygonView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Description});
            this.polygonView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonView.Location = new System.Drawing.Point(0, 0);
            this.polygonView.Name = "polygonView";
            this.polygonView.Size = new System.Drawing.Size(521, 317);
            this.polygonView.TabIndex = 0;
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Опис";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 350;
            // 
            // frmPolygons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 317);
            this.Controls.Add(this.polygonView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPolygons";
            this.ShowIcon = false;
            this.Text = "Визначені ділянки";
            ((System.ComponentModel.ISupportInitialize)(this.polygonView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView polygonView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}