﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ims
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(Path + "//connect"))
            {

                login log = new login();
                MainClass.showWindow(log, this);
            }
            else
            {
                setting set = new setting();
                MainClass.showWindow(set, this);
            }

        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setting set = new setting();
            MainClass.showWindow(set, this);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI.logoutToolStripMenuItem.Enabled = false;
            login set = new login();
            MainClass.showWindow(set, this);
            
            
        }
    }
}
