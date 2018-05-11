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
    public partial class EcranDetailsActeur : Form
    {
        private C_T_Acteur SelectedActeur;
        private string sChConn;
        private string InternetLink;
        private bool Modifiying = false;
        public EcranDetailsActeur(int _ID_Acteur, string _sChConn)
        {
            InitializeComponent();
            this.sChConn = _sChConn;
            SelectedActeur = new G_T_Acteur(sChConn).Lire_ID(_ID_Acteur);
            RemplirDonnees();
        }

        private void RemplirDonnees()
        {
            this.Text = "Acteur n°" + SelectedActeur.Id_Acteur;
            tbNomActeur.Text = SelectedActeur.A_Nom;
            tbPrenomActeur.Text = SelectedActeur.A_Prenom;
            InternetLink = SelectedActeur.A_Bio;

            // Liste de films
            lbListeFilms.Items.Clear();
        }

        private void ChangeState()
        {

        }

        private void btnModif_Annul_Click(object sender, EventArgs e)
        {

        }

        private void btnConf_Quitter_Click(object sender, EventArgs e)
        {
            if (!Modifiying)
            {
                lbListeFilms.Items.Clear();
                this.Close();
            }
        }

        private void llblBiographie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Modifiying)
            {
                if (InternetLink.StartsWith("https://") || InternetLink.StartsWith("http://"))
                {
                    System.Diagnostics.Process.Start(InternetLink);
                    llblBiographie.LinkVisited = true;
                }
                else
                    MessageBox.Show("Le lien n'est pas valide");
            }
        }

        private void btnModiferBiographie_Click(object sender, EventArgs e)
        {
            EcranModifyString modifyString = new EcranModifyString("URL vers le synopsis", InternetLink);
            modifyString.ShowDialog();
            if (modifyString.Confirmed)
                InternetLink = modifyString.NewString;
        }
    }
}
