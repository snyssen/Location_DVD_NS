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
        private bool Modifying = false;
        public EcranDetailsActeur(int _ID_Acteur, string _sChConn)
        {
            InitializeComponent();
            this.sChConn = _sChConn;
            SelectedActeur = new G_T_Acteur(sChConn).Lire_ID(_ID_Acteur);
            RemplirDonnees();
        }

        private void RemplirDonnees()
        {
            SelectedActeur = new G_T_Acteur(sChConn).Lire_ID(SelectedActeur.Id_Acteur);
            this.Text = "Acteur n°" + SelectedActeur.Id_Acteur;
            tbNomActeur.Text = SelectedActeur.A_Nom;
            tbPrenomActeur.Text = SelectedActeur.A_Prenom;
            InternetLink = SelectedActeur.A_Bio;

            // Liste de films
            lbListeFilms.Items.Clear();
            List<C_T_Liste_Acteurs> lTmplActeurs = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs");
            foreach (C_T_Liste_Acteurs TmplActeurs in lTmplActeurs)
            {
                if (TmplActeurs.Id_Acteur == SelectedActeur.Id_Acteur)
                {
                    C_T_DVD TmpDVD = new G_T_DVD(sChConn).Lire_ID((int)TmplActeurs.Id_DVD);
                    lbListeFilms.Items.Add(TmpDVD.D_Nom.ToString());
                }
            }
        }

        private void ChangeState()
        {
            Modifying = !Modifying;
            tbNomActeur.Enabled = tbPrenomActeur.Enabled = btnModiferBiographie.Enabled = Modifying;
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
                lbListeFilms.Items.Clear();
                this.Close();
            }
            else // Confirmer
            {
                if (tbNomActeur.Text == "" || tbPrenomActeur.Text == "" || InternetLink == "")
                    MessageBox.Show("Assurez-vous d'avoir rempli toutes les informations !");
                else
                {
                    new G_T_Acteur(sChConn).Modifier(SelectedActeur.Id_Acteur, tbNomActeur.Text, tbPrenomActeur.Text, InternetLink);
                    ChangeState();
                    RemplirDonnees();
                }
            }
        }

        private void llblBiographie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Modifying)
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
