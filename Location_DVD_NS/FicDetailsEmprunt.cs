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
    public partial class EcranDetailsEmprunt : Form
    {
        private C_T_Emprunt SelectedEmprunt;
        private C_T_Client Client;
        private List<C_T_Quantite> lQuantite;
        private List<C_T_DVD> lDVD;
        private DataTable dtDVD;
        private BindingSource bsDVD;
        private string sChConn;
        public EcranDetailsEmprunt(int _ID_Emprunt, string _sChConn)
        {
            InitializeComponent();
            this.sChConn = _sChConn;
            SelectedEmprunt = new G_T_Emprunt(sChConn).Lire_ID(_ID_Emprunt);
            this.Text = "Emprunt n°" + SelectedEmprunt.Id_Emprunt;
            Client = new G_T_Client(sChConn).Lire_ID((int)SelectedEmprunt.Id_Client);
            lblIDClient.Text = "Client n°" + Client.Id_Client;
            lblNomClient.Text = Client.C_Nom.ToUpper() + " " + Client.C_Prenom;
            dtpDateEmprunt.Value = (DateTime)SelectedEmprunt.E_Emprunt;
            RemplirDGVDVD();
        }

        private void RemplirDGVDVD()
        {
            dtDVD = new DataTable();
            dtDVD.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            dtDVD.Columns.Add("Nom");
            dtDVD.Columns.Add("Date limite retour");
            dtDVD.Columns.Add("Rentré le");
            dtDVD.Columns.Add("Retard (o/n)");
            lQuantite = new G_T_Quantite(sChConn).Lire("Id_Quantite");
            lDVD = new G_T_DVD(sChConn).Lire("Id_DVD");
            foreach (C_T_Quantite Quantite in lQuantite)
            {
                foreach (C_T_DVD DVD in lDVD)
                {
                    if (DVD.Id_DVD == Quantite.Id_DVD && Quantite.Id_Emprunt == SelectedEmprunt.Id_Emprunt) // Double condition nécessaire pour ne récupérer les DVD présents que dans cet emprunt-ci
                    {
                        DateTime DateEmprunt = (DateTime)SelectedEmprunt.E_Emprunt;
                        dtDVD.Rows.Add(DVD.Id_DVD, DVD.D_Nom, DateEmprunt.AddDays((double)DVD.D_Emprunt_Max).ToString(), Quantite.Q_Retour == null ? "Non rentré" : Quantite.Q_Retour.ToString(), Quantite.Q_Retour == null ? (DateTime.Today > DateEmprunt.AddDays((double)DVD.D_Emprunt_Max) ? "oui" : "non") : (Quantite.Q_Retour > DateEmprunt.AddDays((double)DVD.D_Emprunt_Max) ? "oui" : "non"));
                    }
                }
            }
            bsDVD = new BindingSource();
            bsDVD.DataSource = dtDVD;
            dgvDVD.DataSource = bsDVD;
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRetourDVD_Click(object sender, EventArgs e)
        {
            if (dgvDVD.SelectedRows.Count <= 0)
                MessageBox.Show("Veuillez sélectionner au moins un DVD à rentrer avant d'effectuer cette action SVP.");
            else
            {
                int i, j = 0;
                for (i = 0; i < dgvDVD.SelectedRows.Count; i++)
                {
                    C_T_DVD TmpDVD = new G_T_DVD(sChConn).Lire_ID((int)dgvDVD.SelectedRows[i].Cells[0].Value);
                    if (TmpDVD.D_Emprunt) // On vérifie que le DVD n'a pas déjà été retourné
                    {
                        new G_T_DVD(sChConn).Modifier(TmpDVD.Id_DVD, TmpDVD.D_Nom, false, TmpDVD.D_Genre, TmpDVD.D_Emprunt_Max, TmpDVD.D_Amende_p_J, TmpDVD.D_Synopsis); // On change le bool d'emprunt du DVD à false => le DVD est à nouveau disponible
                        foreach (C_T_Quantite TmpQuantite in lQuantite)
                        {
                            if (TmpQuantite.Id_DVD == TmpDVD.Id_DVD && TmpQuantite.Id_Emprunt == SelectedEmprunt.Id_Emprunt) // Important de confirmer les 2 conditions pour ne pas modifier la date de rentrée d'un autre emprunt
                            {
                                new G_T_Quantite(sChConn).Modifier(TmpQuantite.Id_Quantite, TmpQuantite.Id_Emprunt, TmpQuantite.Id_DVD, DateTime.Today); // On met la date du jour comme date de rentrée
                            }
                        }
                    }
                    else
                        j++;
                }
                MessageBox.Show((i - j) + " DVD récupérés");
                RemplirDGVDVD();
            }
            
        }
    }
}
