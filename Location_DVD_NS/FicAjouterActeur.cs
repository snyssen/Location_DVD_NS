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
    public partial class EcranAjouterActeur : Form
    {
        public string NomActeur;
        public string PrenomActeur;
        public string BioActeur;
        public bool confirmed = false;
        public EcranAjouterActeur()
        {
            InitializeComponent();
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (tbNom.Text == "" || tbPrenom.Text == "" || tbBio.Text == "")
                MessageBox.Show("Veuillez renseigner le nom, le prénom et la biographie de l'acteur SVP !");
            else
            {
                NomActeur = tbNom.Text;
                PrenomActeur = tbPrenom.Text;
                BioActeur = tbBio.Text;
                confirmed = true;
                this.Close();
            }
        }
    }
}
