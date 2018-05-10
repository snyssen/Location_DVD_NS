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
                    if (DVD.Id_DVD == Quantite.Id_DVD)
                    {
                        DateTime DateEmprunt = (DateTime)SelectedEmprunt.E_Emprunt;
                        dtDVD.Rows.Add(DVD.D_Nom, DateEmprunt.AddDays((double)DVD.D_Emprunt_Max).ToString(), Quantite.Q_Retour == null ? "Non rentré" : Quantite.Q_Retour.ToString(), Quantite.Q_Retour == null ? (DateTime.Today > DateEmprunt.AddDays((double)DVD.D_Emprunt_Max) ? "oui" : "non") : (Quantite.Q_Retour > DateEmprunt.AddDays((double)DVD.D_Emprunt_Max) ? "oui" : "non"));
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

        }
    }
}
