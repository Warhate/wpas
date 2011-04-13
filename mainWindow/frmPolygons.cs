﻿using System;
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
    public partial class frmPolygons : Form
    {
        public frmPolygons()
        {
            InitializeComponent();
        }

        public void ShowDialog(List<MarkPlace> polygons)
        {
            
            for (int i = 0; i < polygons.Count; i++)
            {
                polygonView.Rows.Add(polygons[i].Type, polygons[i].Description);
            
            }
            base.ShowDialog();

        
        }


    }
}
