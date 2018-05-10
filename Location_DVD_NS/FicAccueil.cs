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

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            RemplirDGVEmprunt();
        }

        private BindingSource bsClients, bsEmprunts, bsDVD, bsActeurs;

        private void btnAjouterEmprunt_Click(object sender, EventArgs e)
        {
            EcranAjouterEmprunt ajoutemprunt = new EcranAjouterEmprunt(this.sChConn);
            ajoutemprunt.ShowDialog();
            if (ajoutemprunt.Confirmed)
            {
                int nID = new G_T_Emprunt(sChConn).Ajouter(ajoutemprunt.IDClientEmprunt, DateTime.Today);
                dtEmprunts.Rows.Add(nID, DateTime.Today, "non");
                foreach (int ID in ajoutemprunt.Liste_ID_DVD_Emprunt)
                {
                    new G_T_Quantite(sChConn).Ajouter(nID, ID, null);
                }
            }
        }

        private void dgvDVD_SelectionChanged(object sender, EventArgs e)
        {
            RemplirDGVActeurs();
        }

        private void btnWipeDB_Click(object sender, EventArgs e)
        {
            WipeDatabase();
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
            if (dgvClients.SelectedRows.Count > 0) // On s'assure qu'au moins une ligne est sélectionnée (POSSIBLEMENT INUTILE GRACE AU FOR, A VERIFIER)
            {
                for (int i = 0; i < dgvClients.SelectedRows.Count; i++) // On parcourt les lignes sélectionnées
                {
                    int TmpID = (int)dgvClients.SelectedRows[i].Cells[0].Value;
                    List<C_T_Emprunt> lTmpEmprunt = new G_T_Emprunt(sChConn).Lire("Id_Emprunt"); // Tous les emprunts
                    List<C_T_Quantite> lTmpQuantite = new G_T_Quantite(sChConn).Lire("Id_Quantite"); // Toutes les quantités
                    foreach (C_T_Emprunt TmpEmprunt in lTmpEmprunt) // On parcourt les emprunts
                    {
                        if ((int)TmpEmprunt.Id_Client == TmpID) // Si une des tables reprend le client sélectionné...
                        {
                            bool Retour = true; // Vrai si tous les DVD de l'emprunt ont été retournés, sinon faux
                            foreach (C_T_Quantite TmpQuantite in lTmpQuantite) // On parcourt les quantités
                            {
                                if ((int)TmpQuantite.Id_Emprunt == (int)TmpEmprunt.Id_Emprunt) // Si la quantité est reprise dans la liste en cours...
                                {
                                    if (TmpQuantite.Q_Retour == null) // Est-ce que ce DVD a été retourné ?
                                        Retour = false; // Si ne serait-ce qu'un seul DVD de l'emprunt actuel n'est pas retourné, Retour est mis à faux
                                }
                            }
                            dtEmprunts.Rows.Add(TmpEmprunt.Id_Emprunt, TmpEmprunt.E_Emprunt, Retour ? "oui" : "non");
                        }
                    }
                }
            }
            /*
            List<C_T_Emprunt> lTmpEmprunt = new G_T_Emprunt(sChConn).Lire("Id_Emprunt");
            foreach (C_T_Emprunt TmpEmprunt in lTmpEmprunt)
            {
                if (int.Parse(dgvClients.SelectedRows[0].Cells[0].Value.ToString()) == (int)TmpEmprunt.Id_Client) // Ne récupère les emprunts que du (des ?) client(s) sélectionné(s)
                    dtEmprunts.Rows.Add(TmpEmprunt.Id_Emprunt, TmpEmprunt.E_Emprunt, "oui"); // DEBUG
            }
            */
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
            if (dgvDVD.SelectedRows.Count > 0) // On s'assure qu'au moins une ligne est sélectionnée (POSSIBLEMENT INUTILE GRACE AU FOR, A VERIFIER)
            {
                for (int i = 0; i < dgvDVD.SelectedRows.Count; i++) // On parcourt les lignes sélectionnées
                {
                    int TmpID = (int)dgvDVD.SelectedRows[i].Cells[0].Value;
                    List<C_T_Liste_Acteurs> lTmplActeur = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs"); // Toutes les listes d'acteurs
                    List<C_T_Acteur> lTmpActeur = new G_T_Acteur(sChConn).Lire("Id_Acteur"); // Tous les acteurs
                    foreach (C_T_Liste_Acteurs TmplActeur in lTmplActeur) // On parcourt la liste d'acteurs
                    {
                        if ((int)TmplActeur.Id_DVD == TmpID) // Si une des tables reprend le DVD sélectionné...
                        {
                            foreach (C_T_Acteur TmpActeur in lTmpActeur) // On parcourt les acteurs
                            {
                                if ((int)TmpActeur.Id_Acteur == (int)TmplActeur.Id_Acteur) // Si l'acteur est repris dans la liste en cours...
                                    dtActeurs.Rows.Add(TmpActeur.A_Nom, TmpActeur.A_Prenom, TmpActeur.A_Bio);
                            }
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

        private void WipeDatabase() // Supprime l'ensemble des entrées de la base de données
        {
            if (MessageBox.Show("VOUS VOUS APPRETEZ A SUPPRIMER L'ENSEMBLE DES ENTREES DE LA BASE DE DONNEES !\nEtes-vous sûr(e) de vouloir continuer ? (cette action est irréversible !)", "SUPPRIMER LES ENTREES DE LA BASE DE DONNEES ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Dans l'ordre pour éviter les problèmes avec les liaisons
                // T_Liste_Acteurs -> t_Quantite -> T_Emprunt -> T_Client -> T_DVD --> T_Acteur

                // Liste Acteurs
                List<C_T_Liste_Acteurs> lTmplActeurs = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs");
                foreach (C_T_Liste_Acteurs TmplActeurs in lTmplActeurs)
                    new G_T_Liste_Acteurs(sChConn).Supprimer(TmplActeurs.Id_Liste_Acteurs);
                // Quantité
                List<C_T_Quantite> lTmplQuantite = new G_T_Quantite(sChConn).Lire("Id_Quantite");
                foreach (C_T_Quantite TmpQuantite in lTmplQuantite)
                    new G_T_Quantite(sChConn).Supprimer(TmpQuantite.Id_Quantite);
                // Emprunt
                List<C_T_Emprunt> lTmpEmprunt = new G_T_Emprunt(sChConn).Lire("Id_Emprunt");
                foreach (C_T_Emprunt TmpEmprunt in lTmpEmprunt)
                    new G_T_Emprunt(sChConn).Supprimer(TmpEmprunt.Id_Emprunt);
                // Client
                List<C_T_Client> lTmpClient = new G_T_Client(sChConn).Lire("Id_Client");
                foreach (C_T_Client TmpClient in lTmpClient)
                    new G_T_Client(sChConn).Supprimer(TmpClient.Id_Client);
                // DVD
                List<C_T_DVD> lTmpDVD = new G_T_DVD(sChConn).Lire("ID_DVD");
                foreach (C_T_DVD TmpDVD in lTmpDVD)
                    new G_T_DVD(sChConn).Supprimer(TmpDVD.Id_DVD);
                // Acteur
                List<C_T_Acteur> lTmpActeur = new G_T_Acteur(sChConn).Lire("Id_Acteur");
                foreach (C_T_Acteur TmpActeur in lTmpActeur)
                    new G_T_Acteur(sChConn).Supprimer(TmpActeur.Id_Acteur);

                RemplirDGV();
                MessageBox.Show("La base de données est maintenant vide.", "Opération effectuée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
