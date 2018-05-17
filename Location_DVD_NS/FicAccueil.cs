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
        private DataTable dtClients, dtEmprunts, dtDVD, dtActeurs, dtDVDEmprunt;
        private BindingSource bsClients, bsEmprunts, bsDVD, bsActeurs, bsDVDEmprunt;

        #region Constructeurs
        public EcranAccueil() // Constructeur par défaut
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
            {
                RemplirDGV();
            }
        }
        public EcranAccueil(bool Acces) { } // Constructeur "poubelle" pour accès aux méthodes du form
        #endregion

        #region Event handlers
        #region DGVs
        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (!cbTousEmprunts.Checked)
                RemplirDGVEmprunt();
            if (dgvClients.SelectedRows.Count != 1) // On ne calcule une éventuelle amende que si il n'y a qu'un seul client de sélectionné
                tbAmende.Text = "N/A";
            else
                tbAmende.Text = CalculerAmende((int)dgvClients.SelectedRows[0].Cells[0].Value).ToString();

        }

        private void dgvDVD_SelectionChanged(object sender, EventArgs e)
        {
            RemplirDGVActeurs();
        }

        private void dgvEmprunts_SelectionChanged(object sender, EventArgs e)
        {
            RemplirDGVDVDEmprunt();
            if (cbTousEmprunts.Checked) // On veut filtrer les clients qui ont fait le/les emprunt(s) sélectionné(s)
            {
                if (dgvEmprunts.SelectedRows.Count > 0)
                {
                    string FiltreClients = "";
                    int i;
                    for (i = 0; i < dgvEmprunts.SelectedRows.Count; i++)
                    {
                        int TmpID = (int)dgvEmprunts.SelectedRows[i].Cells[0].Value;
                        C_T_Emprunt TmpEmprunt = new G_T_Emprunt(sChConn).Lire_ID(TmpID);
                        if (i >= 1)
                            FiltreClients += " OR ";
                        FiltreClients += "[ID] = '";
                        FiltreClients += TmpEmprunt.Id_Client.ToString();
                        FiltreClients += "'";
                    }
                    bsClients.Filter = FiltreClients;
                }
            }
        }

        private void dgvEmprunts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmprunts.SelectedRows.Count == 1)
            {
                EcranDetailsEmprunt detailsEmprunt = new EcranDetailsEmprunt((int)dgvEmprunts.SelectedRows[0].Cells[0].Value, sChConn);
                detailsEmprunt.ShowDialog();
                RemplirDGV();
            }
        }

        private void dgvDVD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDVD.SelectedRows.Count == 1)
            {
                EcranDetailsDVD detailsDVD = new EcranDetailsDVD((int)dgvDVD.SelectedRows[0].Cells[0].Value, sChConn);
                detailsDVD.ShowDialog();
                RemplirDGVDVD();
            }
        }

        private void dgvActeurs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvActeurs.SelectedRows.Count == 1)
            {
                EcranDetailsActeur detailsActeur = new EcranDetailsActeur((int)dgvActeurs.SelectedRows[0].Cells[3].Value, sChConn);
                detailsActeur.ShowDialog();
                RemplirDGVActeurs();
            }
        }

        private void dgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 1)
            {
                EcranDetailsClient detailsClient = new EcranDetailsClient((int)dgvClients.SelectedRows[0].Cells[0].Value, sChConn);
                detailsClient.ShowDialog();
                RemplirDGVClient();
            }
        }
        #endregion
        #region Filtres
        private void FiltreDVD_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                short IndexFiltreDVD = short.Parse(rb.Tag.ToString());
                switch (IndexFiltreDVD)
                {
                    case 0: // tous
                        bsDVD.Filter = null;
                        break;
                    case 1: // Disponibles
                        bsDVD.Filter = "[Disponible (o/n)] = 'Oui'";
                        break;
                    case 2: // En prêt
                        bsDVD.Filter = "[Disponible (o/n)] = 'Non'";
                        break;
                }
            }
        }

        private void FiltreClients_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                short IndexFiltreClient = short.Parse(rb.Tag.ToString());
                switch (IndexFiltreClient)
                {
                    case 0: // Tous
                        bsClients.Filter = null;
                        break;
                    case 1: // En ordre
                        bsClients.Filter = "'Retard(s)' = 'Non'";
                        break;
                    case 2: // Retard (tous)
                        bsClients.Filter = "'Retard(s)' = 'Retour' OR 'Retard(s)' = 'Cotisation' OR 'Retard(s)' = 'Cotisation et Retour'";
                        break;
                    case 3: // Retard (retour)
                        bsClients.Filter = "'Retard(s)' = 'Retour' OR 'Retard(s)' = 'Cotisation et Retour'";
                        break;
                    case 4: // Retard (cotisation)
                        bsClients.Filter = "'Retard(s)' = 'Cotisation' OR 'Retard(s)' = 'Cotisation et Retour'";
                        break;
                }
            }
        }

        private void cbTousEmprunts_CheckedChanged(object sender, EventArgs e)
        {
            RemplirDGVEmprunt();
            rbtnFCTous.Enabled = rbtnFCEnOrdre.Enabled = rbtnFCRetards.Enabled = rbtnFCRetardRetour.Enabled = rbtnFCRetardCot.Enabled = !cbTousEmprunts.Checked;
        }

        private void rbtnFCTous_EnabledChanged(object sender, EventArgs e) // Je n'utilise l'event que sur le premier bouton vu que je change à chaque fois tout le groupe d'un coup mais que je ne veux effectuer une action qu'une seule fois
        {
            if (rbtnFCTous.Enabled) // On force le filtre "Tous"
                rbtnFCTous.Checked = true; // Ceci déclenchera l'event "FiltreClients_CheckedChanged" qui va donc remettre le filtre "Tous" | Pas besoin de forcer les autres rbtn.Checked à false vu qu'ils sont dans le même panel et changeront donc leur état automatiquement si nécessaire
        }

        #endregion
        #region Boutons
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
                    C_T_DVD TmpDVD = new G_T_DVD(sChConn).Lire_ID(ID);
                    new G_T_DVD(sChConn).Modifier(ID, TmpDVD.D_Nom, true, TmpDVD.D_Genre, TmpDVD.D_Emprunt_Max, TmpDVD.D_Amende_p_J, TmpDVD.D_Synopsis);
                }
                RemplirDGV();
            }
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
                RemplirDGVDVD();
            }
        }

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            EcranAjouterClient ajoutclient = new EcranAjouterClient();
            ajoutclient.ShowDialog();
            if (ajoutclient.confirmed)
            {
                int nID = new G_T_Client(sChConn).Ajouter(ajoutclient.NomClient, ajoutclient.PrenomClient, ajoutclient.DateCotisation);
                dtClients.Rows.Add(nID, ajoutclient.NomClient, ajoutclient.PrenomClient);
                RemplirDGVClient();
            }
        }

        private void btnRetourDVD_Click(object sender, EventArgs e)
        {
            if (dgvDVDEmprunt.SelectedRows.Count <= 0)
                MessageBox.Show("Veuillez sélectionner au moins un DVD à rentrer avant d'effectuer cette action SVP.");
            else
            {
                int i, j = 0;
                for (i = 0; i < dgvDVDEmprunt.SelectedRows.Count; i++)
                {
                    C_T_DVD TmpDVD = new G_T_DVD(sChConn).Lire_ID((int)dgvDVDEmprunt.SelectedRows[i].Cells[0].Value);
                    if (TmpDVD.D_Emprunt) // On vérifie que le DVD n'a pas déjà été retourné
                    {
                        new G_T_DVD(sChConn).Modifier(TmpDVD.Id_DVD, TmpDVD.D_Nom, false, TmpDVD.D_Genre, TmpDVD.D_Emprunt_Max, TmpDVD.D_Amende_p_J, TmpDVD.D_Synopsis); // On change le bool d'emprunt du DVD à false => le DVD est à nouveau disponible
                        List<C_T_Quantite> lTmpQuantite = new G_T_Quantite(sChConn).Lire("Id_Quantite");
                        foreach (C_T_Quantite TmpQuantite in lTmpQuantite)
                        {
                            if (TmpQuantite.Id_DVD == TmpDVD.Id_DVD && TmpQuantite.Id_Emprunt == (int)dgvDVDEmprunt.SelectedRows[i].Cells[0].Value) // Important de confirmer les 2 conditions pour ne pas modifier la date de rentrée d'un autre emprunt
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
                RemplirDGVEmprunt();
                RemplirDGVDVDEmprunt();
            }
        }
        #endregion
        #endregion

        #region Remplir DGVs
        private void RemplirDGV()
        {
            RemplirDGVClient();
            RemplirDGVEmprunt();
            RemplirDGVDVD();
            RemplirDGVActeurs();
            RemplirDGVDVDEmprunt();
        }

        private void RemplirDGVClient()
        {
            dtClients = new DataTable();
            dtClients.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            dtClients.Columns.Add("Nom");
            dtClients.Columns.Add("Prénom");
            dtClients.Columns.Add("Dernier paiement cotisation");
            dtClients.Columns.Add("Retard(s)");
            List<C_T_Client> lTmpClient = new G_T_Client(sChConn).Lire("C_Nom");
            foreach (C_T_Client TmpClient in lTmpClient)
            {
                string retard;
                if (CalculerRetardCot((DateTime)TmpClient.C_Cotisation) && CalculerAmende(TmpClient.Id_Client) > 0)
                    retard = "Cotisation et Retour";
                else if (CalculerRetardCot((DateTime)TmpClient.C_Cotisation))
                    retard = "Cotisation";
                else if (CalculerAmende(TmpClient.Id_Client) > 0)
                    retard = "Retour";
                else
                    retard = "Non";
                dtClients.Rows.Add(TmpClient.Id_Client, TmpClient.C_Nom, TmpClient.C_Prenom, TmpClient.C_Cotisation, retard);
            }
            bsClients = new BindingSource();
            bsClients.DataSource = dtClients;
            dgvClients.DataSource = bsClients;
        }

        private void RemplirDGVEmprunt()
        {
            dtEmprunts = new DataTable();
            dtEmprunts.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            dtEmprunts.Columns.Add(new DataColumn("Date", System.Type.GetType("System.DateTime")));
            dtEmprunts.Columns.Add("Retourné (o/n)");
            if (cbTousEmprunts.Checked)
            {
                List<C_T_Emprunt> lTmpEmprunt = new G_T_Emprunt(sChConn).Lire("Id_Emprunt"); // Tous les emprunts
                List<C_T_Quantite> lTmpQuantite = new G_T_Quantite(sChConn).Lire("Id_Quantite"); // Toutes les quantités
                foreach (C_T_Emprunt TmpEmprunt in lTmpEmprunt) // On parcourt les emprunts
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
            else
            {
                for (int i = 0; i < dgvClients.SelectedRows.Count; i++) // On parcourt les lignes sélectionnées (dans la DGV client)
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
                dtDVD.Rows.Add(TmpDVD.Id_DVD, TmpDVD.D_Nom, TmpDVD.D_Emprunt ? "Non" : "Oui");
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
            dtActeurs.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            for (int i = 0; i < dgvDVD.SelectedRows.Count; i++) // On parcourt les lignes sélectionnées (dans la DGV DVD)
            {
                int TmpID = (int)dgvDVD.SelectedRows[i].Cells[0].Value;
                List<C_T_Liste_Acteurs> lTmplActeur = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs"); // Toutes les listes d'acteurs
                List<C_T_Acteur> lTmpActeur = new G_T_Acteur(sChConn).Lire("Id_Acteur"); // Tous les acteurs
                foreach (C_T_Liste_Acteurs TmplActeur in lTmplActeur) // On parcourt la liste d'acteurs
                {
                    if ((int)TmplActeur.Id_DVD == TmpID) // Si une des tables reprend le DVD sélectionné...
                    {
                        foreach (C_T_Acteur TmpActeur in lTmpActeur) // On parcourt les acteurs                /!\ A SIMPLIFIER AVEC LIRE_ID /!\
                        {
                            if ((int)TmpActeur.Id_Acteur == (int)TmplActeur.Id_Acteur) // Si l'acteur est repris dans la liste en cours...
                                dtActeurs.Rows.Add(TmpActeur.A_Nom, TmpActeur.A_Prenom, TmpActeur.A_Bio, TmpActeur.Id_Acteur);
                        }
                    }
                }
            }
            bsActeurs = new BindingSource();
            bsActeurs.DataSource = dtActeurs;
            dgvActeurs.DataSource = bsActeurs;
        }

        private void RemplirDGVDVDEmprunt()
        {
            dtDVDEmprunt = new DataTable();
            dtDVDEmprunt.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            dtDVDEmprunt.Columns.Add("Nom");
            dtDVDEmprunt.Columns.Add("Date limite retour");
            dtDVDEmprunt.Columns.Add("Rentré le");
            dtDVDEmprunt.Columns.Add("Retard (o/n)");
            for (int i = 0; i < dgvEmprunts.SelectedRows.Count; i++) // On parcourt les lignes sélectionnées (dans la DGV Emprunt)
            {
                int TmpID = (int)dgvEmprunts.SelectedRows[i].Cells[0].Value;
                C_T_Emprunt SelectedEmprunt = new G_T_Emprunt(sChConn).Lire_ID(TmpID);
                List<C_T_Quantite> lTmpQuantite = new G_T_Quantite(sChConn).Lire("Id_Quantite");
                foreach (C_T_Quantite TmpQuantite in lTmpQuantite)
                {
                    if (TmpQuantite.Id_Emprunt == TmpID)
                    {
                        C_T_DVD TmpDVD = new G_T_DVD(sChConn).Lire_ID((int)TmpQuantite.Id_DVD);
                        DateTime DateEmprunt = (DateTime)SelectedEmprunt.E_Emprunt;
                        dtDVDEmprunt.Rows.Add(TmpDVD.Id_DVD, TmpDVD.D_Nom, DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max).ToString(), TmpQuantite.Q_Retour == null ? "Non rentré" : TmpQuantite.Q_Retour.ToString(), TmpQuantite.Q_Retour == null ? (DateTime.Today > DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max) ? "oui" : "non") : (TmpQuantite.Q_Retour > DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max) ? "oui" : "non"));
                    }
                }
            }
            bsDVDEmprunt = new BindingSource();
            bsDVDEmprunt.DataSource = dtDVDEmprunt;
            dgvDVDEmprunt.DataSource = bsDVDEmprunt;
        }

        #endregion

        #region Méthodes
        public double CalculerAmende(int ID_Client)
        {
            double amende = 0;
            List<C_T_Emprunt> lTmpEmprunt = new G_T_Emprunt(sChConn).Lire("Id_Emprunt"); // Charge tous les emprunts
            foreach (C_T_Emprunt TmpEmprunt in lTmpEmprunt) // Parcourt tous les emprunts
            {
                if (TmpEmprunt.Id_Client == ID_Client) // Si Id client de l'emprunt parcouru == Id client sélectionné...
                {
                    List<C_T_Quantite> lTmpQuantite = new G_T_Quantite(sChConn).Lire("Id_Quantite"); // Charge toutes les quantités
                    foreach (C_T_Quantite TmpQuantite in lTmpQuantite) // Parcourt toutes les quantités
                    {
                        if (TmpQuantite.Id_Emprunt == TmpEmprunt.Id_Emprunt) // Si Id Quantité parcouru == Id Emprunt questionné...
                        {
                            if (TmpQuantite.Q_Retour == null) // Si la date de retour == null (=> DVD non retourné)...
                            {
                                List<C_T_DVD> lTmpDVD = new G_T_DVD(sChConn).Lire("Id_DVD"); // Charge tous les DVD
                                foreach (C_T_DVD TmpDVD in lTmpDVD) // Parcourt tous les DVD
                                {
                                    if (TmpDVD.Id_DVD == TmpQuantite.Id_DVD) // Si IDs identiques => DVD repris dans l'emprunt
                                    {
                                        DateTime DateLimite = (DateTime)TmpEmprunt.E_Emprunt; // On récupère la date de l'emprunt...
                                        DateLimite.AddDays((double)TmpDVD.D_Emprunt_Max); // Et on y ajoute la durée max d'emprunt du DVD pour déterminer la date limite de retour de ce DVD
                                        TimeSpan tspan = DateTime.Today.Subtract(DateLimite); // On détermine la durée de temps entre aujourd'hui et la date limite de retour...
                                        int retard = tspan.Days - 1; // Et on la transforme en un nombre de jour => si > 0, retard; sinon encore dans les temps ( -1 sinon il compte le jour limite de rentrée)
                                        if (retard > 0) // Si retard > 0 => retard => Amende à appliquer !
                                        {
                                            amende += (double)(retard * TmpDVD.D_Amende_p_J); // On ajoute donc à l'amende générale du client celle du DVD = nbr jour de retards * prix par jour de retard
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return amende;
        }

        public bool CalculerRetardCot(DateTime DateCot) // retourne vrai 
        {
            //if (DateTime.Today.Date > DateCot.Date.AddMonths(1))
            // DEBUG
            if (DateTime.Today.Date > DateCot.Date.AddDays(1))
                return true;
            else
                return false;
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
        #endregion
    }
}
