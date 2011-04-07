using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Myprojekt
{
    public partial class frmSettings : Form
    {
        public Settings appSettings = Settings.Instance;
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            cmbDataUpdates.SelectedIndex = appSettings.updateRate - 1;
            txtServerAddress.Text = appSettings.serverAddress;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            appSettings.serverAddress = txtServerAddress.Text;
            appSettings.updateRate = cmbDataUpdates.SelectedIndex + 1;
            appSettings.saveSettings();
        }
    }
}
