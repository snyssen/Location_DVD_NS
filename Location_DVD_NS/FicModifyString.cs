using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Location_DVD_NS
{
    public partial class EcranModifyString : Form
    {
        public bool Confirmed = false;
        public string NewString;
        public EcranModifyString()
        {
            InitializeComponent();
        }
        /*
        public EcranModifyString(string OldString)
        {
            InitializeComponent();
            tbModif.Text = OldString;
        }
        */
        public EcranModifyString(string ScreenTitle)
        {
            InitializeComponent();
            this.Text = ScreenTitle;
        }
        public EcranModifyString(string ScreenTitle, string OldString)
        {
            InitializeComponent();
            this.Text = ScreenTitle;
            tbModif.Text = OldString;
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (tbModif.Text == "")
                MessageBox.Show("Veuillez entrer la donnée à modifier SVP.");
            else
            {
                NewString = tbModif.Text;
                Confirmed = true;
                this.Close();
            }
        }
    }
}
