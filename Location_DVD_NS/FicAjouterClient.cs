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
    public partial class EcranAjouterClient : Form
    {
        public string NomClient;
        public string PrenomClient;
        public DateTime DateCotisation;
        public bool confirmed = false;
        public EcranAjouterClient()
        {
            InitializeComponent();
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (tbNom.Text == "" || tbPrenom.Text == "")
                MessageBox.Show("Veuillez renseigner le nom et le prénom du client SVP !");
            else
            {
                NomClient = tbNom.Text;
                PrenomClient = tbPrenom.Text;
                DateCotisation = DateTime.Today;
                confirmed = true;
                this.Close();
            }
        }
    }
}
