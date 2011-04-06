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
    public partial class AddPoligon : Form
    {


        public AddPoligon()
        {
            InitializeComponent();
        }

        private void AddPoligon_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Add(MarkPlace.PlaceType.Forest);
            comboBoxType.Items.Add(MarkPlace.PlaceType.Housing);
            comboBoxType.Items.Add(MarkPlace.PlaceType.Sand);
            comboBoxType.Items.Add(MarkPlace.PlaceType.Water);
            


        }

        internal void ShowThis(out String description, out MarkPlace.PlaceType type)
        {
            this.StartPosition = FormStartPosition.CenterParent;


            this.ShowDialog();
            type = (MarkPlace.PlaceType)comboBoxType.SelectedItem;
            description = txtDescription.Text;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
