﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.utils.clases
{
    public partial class InnerForm : Form
    {
        public InnerForm()
        {
            InitializeComponent();
        }

        private void InnerForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
