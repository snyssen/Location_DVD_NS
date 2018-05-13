using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Projet_LOCATION_DVD.Classes;
using Projet_LOCATION_DVD.Acces;
using Projet_LOCATION_DVD.Gestion;

namespace Location_DVD_NS
{
    public partial class EcranDetailsClient : Form
    {
        private C_T_Client SelectedClient;
        private string sChConn;
        private bool Modifying = false;
        public EcranDetailsClient(int _ID_Client, string _sChConn)
        {
            InitializeComponent();
            this.sChConn = _sChConn;
            SelectedClient = new G_T_Client(sChConn).Lire_ID(_ID_Client);
            RemplirDonnees();
        }

        private void RemplirDonnees()
        {
            SelectedClient = new G_T_Client(sChConn).Lire_ID(SelectedClient.Id_Client);
            this.Text = "Client n°" + SelectedClient.Id_Client;
            tbNom.Text = SelectedClient.C_Nom;
            tbPrenom.Text = SelectedClient.C_Prenom;
        }

        private void ChangeState()
        {
            Modifying = !Modifying;
            tbNom.Enabled = tbPrenom.Enabled = Modifying;
            if (Modifying)
            {
                btnModif_Annul.Text = "Annuler";
                btnConf_Quitter.Text = "Confirmer";
            }
            else
            {
                btnModif_Annul.Text = "Modifier informations";
                btnConf_Quitter.Text = "Quitter";
            }
        }

        private void btnModif_Annul_Click(object sender, EventArgs e)
        {
            ChangeState();
            RemplirDonnees();
        }

        private void btnConf_Quitter_Click(object sender, EventArgs e)
        {
            if (!Modifying) // Quitter
            {
                this.Close();
            }
            else // Confirmer
            {
                if (tbNom.Text == "" || tbPrenom.Text == "")
                    MessageBox.Show("Assurez-vous d'avoir rempli toutes les informations !");
                else
                {
                    new G_T_Client(sChConn).Modifier(SelectedClient.Id_Client, tbNom.Text, tbPrenom.Text);
                    ChangeState();
                    RemplirDonnees();
                }
            }
        }
    }
}
