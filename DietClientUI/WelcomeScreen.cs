using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DietClientUI
{
    public partial class WelcomeScreen : Form
    {
        
        //Use timer class
        Timer tmr;

        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void WelcomeScreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            DietMasterPage dm = new DietMasterPage();
            dm.Show();
            dm.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height-100;
            dm.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width-100;
            //hide this form
            this.Hide();
        }

       
    }
}
