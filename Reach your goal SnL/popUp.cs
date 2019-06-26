using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snakes_and_Ladders
{
    public partial class popUp : Form
    {
        public popUp()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            string trackbar = Convert.ToString(trackBar1.Value);
            lblAdvance.Text = trackbar;
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            popUp popup = new popUp();
            this.Hide();
        }
    }
}
