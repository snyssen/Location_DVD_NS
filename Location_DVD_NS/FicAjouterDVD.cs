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
    public partial class EcranAjouterDVD : Form
    {
        public string NomDVD;
        public string GenreDVD;
        public int EmpruntMaxDVD;
        public double Amende_p_jourDVD;
        public string SynopsisDVD;
        public List<int> Liste_Id_acteurs;
        public bool Confirmed = false;
        private string sChConn;
        public EcranAjouterDVD(string _sChConn)
        {
            InitializeComponent();
            this.sChConn = _sChConn;
            RemplirListeActeurs();
        }

        private void RemplirListeActeurs()
        {
            lbListeActeurs.Items.Clear();
            List<C_T_Acteur> lTmpActeur = new G_T_Acteur(sChConn).Lire("A_Nom");
            foreach (C_T_Acteur TmpActeur in lTmpActeur)
                lbListeActeurs.Items.Add(TmpActeur.A_Nom.ToString() + " " + TmpActeur.A_Prenom.ToString() + " (ID=" + TmpActeur.Id_Acteur + ")");
        }

        private void btnAjouterActeur_Click(object sender, EventArgs e)
        {
            EcranAjouterActeur ajoutacteur = new EcranAjouterActeur();
            ajoutacteur.ShowDialog();
            if (ajoutacteur.confirmed)
            {
                bool Doublon = false;
                List<C_T_Acteur> lTmpActeur = new G_T_Acteur(sChConn).Lire("Id_Acteur");
                foreach (C_T_Acteur TmpActeur in lTmpActeur)
                {
                    if (TmpActeur.A_Nom == ajoutacteur.NomActeur && TmpActeur.A_Prenom == ajoutacteur.PrenomActeur)
                        Doublon = true;
                }
                if (!Doublon)
                {
                    new G_T_Acteur(sChConn).Ajouter(ajoutacteur.NomActeur, ajoutacteur.PrenomActeur, ajoutacteur.BioActeur);
                    RemplirListeActeurs();
                }
                else
                    MessageBox.Show("Un acteur du même nom et prénom est déjà présent dans la base de données !");
            }
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (tbNom.Text == "" || tbGenre.Text == "" || nudEmpruntMax.Value <= 0 || nudAmende_p_jour.Value <= 0 || tbSynopsis.Text == "" || lbListeActeurs.SelectedItems.Count <= 0)
                MessageBox.Show("Assurez-vous d'avoir rempli toutes les informations !");
            else
            {
                NomDVD = tbNom.Text;
                GenreDVD = tbGenre.Text;
                EmpruntMaxDVD = (int)nudEmpruntMax.Value;
                Amende_p_jourDVD = (double)nudAmende_p_jour.Value;
                SynopsisDVD = tbSynopsis.Text;
                Liste_Id_acteurs = new List<int>();
                foreach (string lTmp in lbListeActeurs.SelectedItems)
                {
                    string[] TmpTab = lTmp.Split('=');
                    TmpTab[1] = TmpTab[1].Remove(TmpTab[1].Length - 1);
                    if (!int.TryParse(TmpTab[1], out int TmpID))
                        MessageBox.Show("Erreur lors de la récupération de l'ID de l'acteur !");
                    Liste_Id_acteurs.Add(TmpID);
                }
                Confirmed = true;
                lbListeActeurs.Items.Clear();
                this.Close();
            }
        }
    }
}
