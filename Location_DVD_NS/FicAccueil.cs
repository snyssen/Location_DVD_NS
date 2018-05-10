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
    public partial class EcranAccueil : Form
    {
        private string sChConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\picho\Nextcloud\Cours\Informatique\2e bac\POO\Q2\db\Location_DVD.mdf;Integrated Security=True";
        private short IndexFiltreClient = 0, // 0 = tous / 1 = Retards (tous) / 2 = Retards (retour) / 3 = Retards (cotisation)
            IndexFiltreDVD = 0; // 0 = tous / 1 = Disponibles / 2 = En prêt
        private DataTable dtClients, dtEmprunts, dtDVD, dtActeurs;

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            RemplirDGVEmprunt();
        }

        private BindingSource bsClients, bsEmprunts, bsDVD, bsActeurs;

        private void btnAjouterEmprunt_Click(object sender, EventArgs e)
        {

        }

        private void btnAjouterDVD_Click(object sender, EventArgs e)
        {
            EcranAjouterDVD ajoutDVD = new EcranAjouterDVD(this.sChConn);
            ajoutDVD.ShowDialog();
            if (ajoutDVD.Confirmed)
            {
                int nID = new G_T_DVD(sChConn).Ajouter(ajoutDVD.NomDVD, false, ajoutDVD.GenreDVD, ajoutDVD.EmpruntMaxDVD, (double)ajoutDVD.Amende_p_jourDVD, ajoutDVD.SynopsisDVD);
                dtDVD.Rows.Add(nID, ajoutDVD.NomDVD, "oui");
                foreach (int ID in ajoutDVD.Liste_Id_acteurs)
                {
                    new G_T_Liste_Acteurs(sChConn).Ajouter(nID, ID);
                }
            }
        }

        public EcranAccueil()
        {
            InitializeComponent();
            string[] stab = sChConn.Split('=');
            string[] stab2 = stab[2].Split(';');
            if (!System.IO.File.Exists(stab2[0]))
            {
                bool boucle = false;
                do
                {
                    if (MessageBox.Show("La base de donnée par défaut est introuvable.\nSouhaitez-vous indiquer un autre emplacement ?", "Base de données introuvable", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (dlgChargerDB.ShowDialog() == DialogResult.OK)
                        {
                            sChConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dlgChargerDB.FileName + ";Integrated Security=True";
                            boucle = false;
                        }
                        else
                            boucle = true;
                    }
                    else
                    {
                        boucle = false;
                        this.Close();
                    }
                }
                while (boucle);
            }
            if (System.IO.File.Exists(stab2[0]) || System.IO.File.Exists(dlgChargerDB.FileName))
                RemplirDGV();
        }

        #region Remplir DGVs
        private void RemplirDGV()
        {
            RemplirDGVClient();
            RemplirDGVEmprunt();
            RemplirDGVDVD();
            RemplirDGVActeurs();
        }

        private void RemplirDGVClient()
        {
            dtClients = new DataTable();
            dtClients.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            dtClients.Columns.Add("Nom");
            dtClients.Columns.Add("Prénom");
            List<C_T_Client> lTmpClient = new G_T_Client(sChConn).Lire("C_Nom");
            foreach (C_T_Client TmpClient in lTmpClient)
                dtClients.Rows.Add(TmpClient.Id_Client, TmpClient.C_Nom, TmpClient.C_Prenom);
            bsClients = new BindingSource();
            bsClients.DataSource = dtClients;
            dgvClients.DataSource = bsClients;
        }

        private void RemplirDGVEmprunt()
        {
            dtEmprunts = new DataTable();
            dtEmprunts.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            dtEmprunts.Columns.Add(new DataColumn("Date", System.Type.GetType("System.DateTime"))); // Type date ???
            dtEmprunts.Columns.Add("Retourné (o/n)");
            List<C_T_Emprunt> lTmpEmprunt = new G_T_Emprunt(sChConn).Lire("Id_Emprunt");
            foreach (C_T_Emprunt TmpEmprunt in lTmpEmprunt)
            {
                if (int.Parse(dgvClients.SelectedRows[0].Cells[0].Value.ToString()) == (int)TmpEmprunt.Id_Client) // Ne récupère les emprunts que du (des ?) client(s) sélectionné(s)
                    dtEmprunts.Rows.Add(TmpEmprunt.Id_Emprunt, TmpEmprunt.E_Emprunt, "oui"); // DEBUG
            }
            bsEmprunts = new BindingSource();
            bsEmprunts.DataSource = dtEmprunts;
            dgvEmprunts.DataSource = bsEmprunts;
        }

        private void RemplirDGVDVD()
        {
            dtDVD = new DataTable();
            dtDVD.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            dtDVD.Columns.Add("Nom");
            dtDVD.Columns.Add("Disponible (o/n)");
            List<C_T_DVD> lTmpDVD = new G_T_DVD(sChConn).Lire("D_Nom");
            foreach (C_T_DVD TmpDVD in lTmpDVD)
            {
                dtDVD.Rows.Add(TmpDVD.Id_DVD, TmpDVD.D_Nom, TmpDVD.D_Emprunt ? "non" : "oui");
            }
            bsDVD = new BindingSource();
            bsDVD.DataSource = dtDVD;
            dgvDVD.DataSource = bsDVD;
        }

        private void RemplirDGVActeurs()
        {
            dtActeurs = new DataTable();
            dtActeurs.Columns.Add("Nom");
            dtActeurs.Columns.Add("Prénom");
            dtActeurs.Columns.Add("En savoir plus");
            if (dgvDVD.SelectedRows.Count > 0)
            {
                List<C_T_Liste_Acteurs> lTmplActeur = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs");
                List<C_T_Acteur> lTmpActeur = new G_T_Acteur(sChConn).Lire("Id_Acteur");
                foreach (C_T_Liste_Acteurs TmplActeur in lTmplActeur)
                {
                    if (int.Parse(dgvDVD.SelectedRows[0].Cells[0].Value.ToString()) == (int)TmplActeur.Id_DVD) // N'affiche les acteurs que présents dans le film sélectionné
                    {
                        foreach (C_T_Acteur TmpActeur in lTmpActeur)
                        {
                            if (TmpActeur.Id_Acteur == TmplActeur.Id_Acteur)
                                dtActeurs.Rows.Add(TmpActeur.A_Nom, TmpActeur.A_Prenom, TmpActeur.A_Bio);
                        }
                    }
                }
            }
            bsActeurs = new BindingSource();
            bsActeurs.DataSource = dtActeurs;
            dgvActeurs.DataSource = bsActeurs;
        }

        #endregion

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            EcranAjouterClient ajoutclient = new EcranAjouterClient();
            ajoutclient.ShowDialog();
            if (ajoutclient.confirmed)
            {
                int nID = new G_T_Client(sChConn).Ajouter(ajoutclient.NomClient, ajoutclient.PrenomClient);
                dtClients.Rows.Add(nID, ajoutclient.NomClient, ajoutclient.PrenomClient);
            }
        }


    }
}
