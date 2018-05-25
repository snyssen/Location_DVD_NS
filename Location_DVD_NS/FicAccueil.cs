using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
                        dlgChargerDB.Filter = "Fichier de base de données Microsoft SQL|*.mdf|Tous fichiers|*.*";
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
                dlgBordereau.Filter = "Fichier texte|*.txt|Tous fichiers|*.*";
                RemplirDGV();
                btnNotifications.NotificationNbr = CalculerNotifications();
            }
        }
        public EcranAccueil(string sChConn_) { this.sChConn = sChConn_; } // Constructeur "poubelle" pour accès aux méthodes du form
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
            if (!cbTousActeurs.Checked)
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
                        if (i >= 1) // On ne veut pas mettre le OR en premier passage
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
                RemplirDGVDVDEmprunt();
            }
        }

        private void dgvDVDEmprunt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDVDEmprunt.SelectedRows.Count == 1)
            {
                EcranDetailsDVD detailsDVD = new EcranDetailsDVD((int)dgvDVDEmprunt.SelectedRows[0].Cells[0].Value, sChConn);
                detailsDVD.ShowDialog();
                RemplirDGVDVD();
                RemplirDGVDVDEmprunt();
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
                btnNotifications.NotificationNbr = CalculerNotifications();
            }
        }

        private void dgvActeurs_SelectionChanged(object sender, EventArgs e)
        {
            if (cbTousActeurs.Checked) // On veut filtrer les DVD en fct des acteurs choisis
            {
                if (dgvActeurs.SelectedRows.Count > 0)
                {
                    string FiltreDVD = "";
                    int i;
                    List<C_T_Liste_Acteurs> lTmplActeurs = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs"); // Chargé en dehors de la boucle pour éviter de réaccéder à la DB à chaque boucle
                    for (i = 0; i < dgvActeurs.SelectedRows.Count; i++)
                    {
                        int TmpID = (int)dgvActeurs.SelectedRows[i].Cells[3].Value; // On récupère l'ID de l'acteur sélectionné
                        if (i >= 1) // On ne veut pas mettre le OR en premier passage
                            FiltreDVD += " OR ";
                        int j = 0;
                        foreach (C_T_Liste_Acteurs TmplActeurs in lTmplActeurs)
                        {
                            if (TmplActeurs.Id_Acteur == TmpID) // On retrouve les tables Liste_Acteurs où l'acteur est repris
                            {
                                if (j >= 1) // On ne veut pas mettre le OR en premier passage
                                    FiltreDVD += " OR ";
                                FiltreDVD += "[ID] = '";
                                FiltreDVD += TmplActeurs.Id_DVD.ToString();
                                FiltreDVD += "'";
                                j++;
                            }
                        }
                    }
                    bsDVD.Filter = FiltreDVD;
                }
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
                        bsClients.Filter = "[Retard(s)] = 'Non'";
                        break;
                    case 2: // Retard (tous)
                        bsClients.Filter = "[Retard(s)] = 'Retour' OR [Retard(s)] = 'Cotisation' OR [Retard(s)] = 'Cotisation et Retour'";
                        break;
                    case 3: // Retard (retour)
                        bsClients.Filter = "[Retard(s)] = 'Retour' OR [Retard(s)] = 'Cotisation et Retour'";
                        break;
                    case 4: // Retard (cotisation)
                        bsClients.Filter = "[Retard(s)] = 'Cotisation' OR [Retard(s)] = 'Cotisation et Retour'";
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
            {
                rbtnFCTous.Checked = false; // On le passe d'abord à false pour être sûr de forcer son event même si il était déjà coché avant
                rbtnFCTous.Checked = true; // Ceci déclenchera l'event "FiltreClients_CheckedChanged" qui va donc remettre le filtre "Tous" | Pas besoin de forcer les autres rbtn.Checked à false vu qu'ils sont dans le même panel et changeront donc leur état automatiquement si nécessaire
            }
        }

        private void cbTousActeurs_CheckedChanged(object sender, EventArgs e)
        {
            rbtnFDTous.Enabled = rbtnFDDispos.Enabled = rbtnFDPret.Enabled = !cbTousActeurs.Checked;
            dgvActeurs_SelectionChanged(dgvActeurs, null);
        }

        private void rbtnFDTous_EnabledChanged(object sender, EventArgs e) // Je n'utilise l'event que sur le premier bouton vu que je change à chaque fois tout le groupe d'un coup mais que je ne veux effectuer une action qu'une seule fois
        {
            if (rbtnFDTous.Enabled) // On force le filtre "Tous"
            {
                rbtnFDTous.Checked = false; // On le passe d'abord à false pour être sûr de forcer son event même si il était déjà coché avant
                rbtnFDTous.Checked = true; // Ceci déclenchera l'event "FiltreDVDheckedChanged" qui va donc remettre le filtre "Tous" | Pas besoin de forcer les autres rbtn.Checked à false vu qu'ils sont dans le même panel et changeront donc leur état automatiquement si nécessaire

            }
        }
        #endregion
        #region Boutons
        private void btnAjouterEmprunt_Click(object sender, EventArgs e)
        {
            EcranAjouterEmprunt ajoutemprunt = new EcranAjouterEmprunt(this.sChConn, dgvClients.SelectedRows.Count == 1 ? (int)dgvClients.SelectedRows[0].Cells[0].Value : -1);
            ajoutemprunt.ShowDialog();
            if (ajoutemprunt.Confirmed)
            {
                int nID = new G_T_Emprunt(sChConn).Ajouter(ajoutemprunt.IDClientEmprunt, DateTime.Today);
                foreach (int ID in ajoutemprunt.Liste_ID_DVD_Emprunt)
                {
                    new G_T_Quantite(sChConn).Ajouter(nID, ID, null);
                    C_T_DVD TmpDVD = new G_T_DVD(sChConn).Lire_ID(ID);
                    new G_T_DVD(sChConn).Modifier(ID, TmpDVD.D_Nom, true, TmpDVD.D_Genre, TmpDVD.D_Emprunt_Max, TmpDVD.D_Amende_p_J, TmpDVD.D_Synopsis);
                }
                if (MessageBox.Show("Souhaitez-vous générer un bordereau d'emprunt ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    GenererBordereauPlainText(ajoutemprunt.IDClientEmprunt, ajoutemprunt.Liste_ID_DVD_Emprunt, nID);
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
                bool Doublon = false;
                List<C_T_DVD> lTmpDVD = new G_T_DVD(sChConn).Lire("Id_DVD");
                foreach (C_T_DVD TmpDVD in lTmpDVD)
                {
                    if (ajoutDVD.NomDVD == TmpDVD.D_Nom)
                        Doublon = true;
                }
                if (!Doublon)
                {
                    int nID = new G_T_DVD(sChConn).Ajouter(ajoutDVD.NomDVD, false, ajoutDVD.GenreDVD, ajoutDVD.EmpruntMaxDVD, (double)ajoutDVD.Amende_p_jourDVD, ajoutDVD.SynopsisDVD);
                    dtDVD.Rows.Add(nID, ajoutDVD.NomDVD, "oui");
                    foreach (int ID in ajoutDVD.Liste_Id_acteurs)
                    {
                        new G_T_Liste_Acteurs(sChConn).Ajouter(nID, ID);
                    }
                    RemplirDGVDVD();
                }
                else
                    MessageBox.Show("Un DVD du même nom est déjà présent dans la base de données !");
            }
        }

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            EcranAjouterClient ajoutclient = new EcranAjouterClient();
            ajoutclient.ShowDialog();
            if (ajoutclient.confirmed)
            {
                bool Doublon = false;
                List<C_T_Client> lTmpCLient = new G_T_Client(sChConn).Lire("Id_Client");
                foreach (C_T_Client TmpClient in lTmpCLient)
                {
                    if (TmpClient.C_Nom == ajoutclient.NomClient && TmpClient.C_Prenom == ajoutclient.PrenomClient)
                        Doublon = true;
                }
                if (!Doublon)
                {
                    int nID = new G_T_Client(sChConn).Ajouter(ajoutclient.NomClient, ajoutclient.PrenomClient, ajoutclient.DateCotisation);
                    dtClients.Rows.Add(nID, ajoutclient.NomClient, ajoutclient.PrenomClient);
                    RemplirDGVClient();

                }
                else
                    MessageBox.Show("Le client entré est déjà présent dans la base de données !");
            }
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
                    RemplirDGVActeurs();
                }
                else
                    MessageBox.Show("Un acteur du même nom et prénom est déjà présent dans la base de données !");
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
                            if (TmpQuantite.Id_DVD == TmpDVD.Id_DVD && TmpQuantite.Q_Retour == null) // Important de confirmer les 2 conditions pour ne pas modifier la date de rentrée d'un autre emprunt 
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
                btnNotifications.NotificationNbr = CalculerNotifications();
            }
        }

        private void btnCotisation_Click(object sender, EventArgs e)
        {
            int i;
            string result = "Cotisation payée ce " + DateTime.Today.ToShortDateString() + " pour :\n";
            for (i = 0;  i < dgvClients.SelectedRows.Count; i++)
            {
                new G_T_Client(sChConn).Modifier((int)dgvClients.SelectedRows[i].Cells[0].Value, dgvClients.SelectedRows[i].Cells[1].Value.ToString(), dgvClients.SelectedRows[i].Cells[2].Value.ToString(), DateTime.Today);
                result += dgvClients.SelectedRows[i].Cells[1].Value.ToString() + " " + dgvClients.SelectedRows[i].Cells[2].Value.ToString() + "\n";
            }
            if (i > 0)
            {
                MessageBox.Show(result);
                RemplirDGVClient();
                btnNotifications.NotificationNbr = CalculerNotifications();
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            EcranNotifications ecrannotif = new EcranNotifications(sChConn);
            ecrannotif.Show();
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
            dtClients.Columns.Add(new DataColumn("Dernier paiement cotisation", System.Type.GetType("System.DateTime")));
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
                    dtEmprunts.Rows.Add(TmpEmprunt.Id_Emprunt, TmpEmprunt.E_Emprunt, Retour ? "Oui" : "Non");
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
                            dtEmprunts.Rows.Add(TmpEmprunt.Id_Emprunt, TmpEmprunt.E_Emprunt, Retour ? "Oui" : "Non");
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
            dtDVD.Columns.Add("Retard (o/n)");
            List<C_T_DVD> lTmpDVD = new G_T_DVD(sChConn).Lire("D_Nom");
            List<C_T_Quantite> lTmpQuantite = new G_T_Quantite(sChConn).Lire("Id_Quantite");
            foreach (C_T_DVD TmpDVD in lTmpDVD)
            {
                if (TmpDVD.D_Emprunt)
                {
                    foreach (C_T_Quantite TmpQuantite in lTmpQuantite)
                    {
                        if (TmpQuantite.Id_DVD == TmpDVD.Id_DVD && TmpQuantite.Q_Retour == null)
                        {
                            C_T_Emprunt SelectedEmprunt = new G_T_Emprunt(sChConn).Lire_ID((int)TmpQuantite.Id_Emprunt);
                            DateTime DateEmprunt = (DateTime)SelectedEmprunt.E_Emprunt;
                            dtDVD.Rows.Add(TmpDVD.Id_DVD, TmpDVD.D_Nom, "Non", TmpQuantite.Q_Retour == null ? (DateTime.Today > DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max) ? "Oui" : "Non") : (TmpQuantite.Q_Retour > DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max) ? "Oui" : "Non"));
                        }
                    }
                }
                else
                    dtDVD.Rows.Add(TmpDVD.Id_DVD, TmpDVD.D_Nom, "Oui", "N/A");
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
            dtActeurs.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));
            if (!cbTousActeurs.Checked)
            {
                for (int i = 0; i < dgvDVD.SelectedRows.Count; i++) // On parcourt les lignes sélectionnées (dans la DGV DVD)
                {
                    int TmpID = (int)dgvDVD.SelectedRows[i].Cells[0].Value;
                    List<C_T_Liste_Acteurs> lTmplActeur = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs"); // Toutes les listes d'acteurs
                    foreach (C_T_Liste_Acteurs TmplActeur in lTmplActeur) // On parcourt la liste d'acteurs
                    {
                        if ((int)TmplActeur.Id_DVD == TmpID) // Si une des tables reprend le DVD sélectionné...
                        {
                            C_T_Acteur TmpActeur = new G_T_Acteur(sChConn).Lire_ID((int)TmplActeur.Id_Acteur);
                            dtActeurs.Rows.Add(TmpActeur.A_Nom, TmpActeur.A_Prenom, TmpActeur.A_Bio, TmpActeur.Id_Acteur);
                        }
                    }
                }
            }
            else
            {
                List<C_T_Acteur> lTmpActeur = new G_T_Acteur(sChConn).Lire("A_Nom");
                foreach (C_T_Acteur TmpActeur in lTmpActeur)
                    dtActeurs.Rows.Add(TmpActeur.A_Nom, TmpActeur.A_Prenom, TmpActeur.A_Bio, TmpActeur.Id_Acteur);
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
            dtDVDEmprunt.Columns.Add(new DataColumn("Date limite retour", System.Type.GetType("System.DateTime")));
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
                        dtDVDEmprunt.Rows.Add(TmpDVD.Id_DVD, TmpDVD.D_Nom, DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max).ToString(), TmpQuantite.Q_Retour == null ? "Non rentré" : ((DateTime)TmpQuantite.Q_Retour).ToShortDateString(), TmpQuantite.Q_Retour == null ? (DateTime.Today > DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max) ? "Oui" : "Non") : (TmpQuantite.Q_Retour > DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max) ? "Oui" : "Non"));
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

        public bool CalculerRetardCot(DateTime DateCot) // retourne vrai si le client est en retard de cotisation (attend la date du dernier paiement de la cotisation en argument)
        {
            // DEBUG
            if (DateTime.Today.Date > DateCot.Date.AddDays(1)) // MIS A 1 JOUR DE RETARD POUR DEMONTRER LE FONCTIONNEMENT DES ALERTES DE RETARD
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

        private void GenererBordereau() // Génère le bordereau dans un fichier PDF (vide pour le moment)
        {

        }

        private void GenererBordereauPlainText(int ID_Client, List<int> lID_DVD, int ID_Emprunt) // Génère le bordereau en ASCII dans un fichier texte
        {
            if (dlgBordereau.ShowDialog() == DialogResult.OK)
            {
                string TmpString, TmpStringR;
                StreamWriter sw = new StreamWriter(dlgBordereau.FileName);
                C_T_Client TmpClient = new G_T_Client(sChConn).Lire_ID(ID_Client);
                C_T_Emprunt TmpEmprunt = new G_T_Emprunt(sChConn).Lire_ID(ID_Emprunt);
                TmpString = "Client n° " + TmpClient.Id_Client;
                TmpString = TmpString.PadRight(43); // 43 = 86/2
                TmpStringR = "Emprunt n° " + TmpEmprunt.Id_Emprunt;
                TmpStringR = TmpStringR.PadLeft(43);
                TmpString += TmpStringR;
                sw.WriteLine(TmpString);
                DateTime DateEmprunt = (DateTime)TmpEmprunt.E_Emprunt;
                TmpString = TmpClient.C_Nom.ToUpper() + " " + TmpClient.C_Prenom;
                TmpString = TmpString.PadRight(43);
                TmpStringR = "Date : " + DateEmprunt.ToShortDateString();
                TmpStringR = TmpStringR.PadLeft(43);
                TmpString += TmpStringR;
                sw.WriteLine(TmpString);
                sw.WriteLine("");
                #region Tableau
                #region Entête
                sw.WriteLine("______________________________________________________________________________________"); // 86 char = largeur tableau
                #region Ligne 1
                TmpString = "| n°";
                TmpString = TmpString.PadRight(7);
                TmpString += "|";
                TmpString = TmpString.PadRight(60);
                TmpString += "| Date";
                TmpString = TmpString.PadRight(73);
                TmpString += "| Amende";
                TmpString = TmpString.PadRight(85);
                TmpString += "|";
                sw.WriteLine(TmpString);
                #endregion
                #region Ligne 2
                TmpString = "| DVD";
                TmpString = TmpString.PadRight(7);
                TmpString += "| Nom du film";
                TmpString = TmpString.PadRight(60);
                TmpString += "| limite";
                TmpString = TmpString.PadRight(73);
                TmpString += "| par jour";
                TmpString = TmpString.PadRight(85);
                TmpString += "|";
                sw.WriteLine(TmpString);
                #endregion
                #region Ligne 3
                TmpString = "|";
                TmpString = TmpString.PadRight(7);
                TmpString += "|";
                TmpString = TmpString.PadRight(60);
                TmpString += "| retour";
                TmpString = TmpString.PadRight(73);
                TmpString += "| de retard";
                TmpString = TmpString.PadRight(85);
                TmpString += "|";
                sw.WriteLine(TmpString);
                #endregion
                TmpString = "|";
                TmpString = TmpString.PadRight(7, '-');
                TmpString += "+";
                TmpString = TmpString.PadRight(60, '-');
                TmpString += "+";
                TmpString = TmpString.PadRight(73, '-');
                TmpString += "+";
                TmpString = TmpString.PadRight(85, '-');
                TmpString += "|";
                sw.WriteLine(TmpString);
                #endregion
                foreach (int ID_DVD in lID_DVD)
                {
                    C_T_DVD TmpDVD = new G_T_DVD(sChConn).Lire_ID(ID_DVD);
                    TmpString = "| ";
                    TmpString += TmpDVD.Id_DVD.ToString();
                    TmpString = TmpString.PadRight(7);
                    TmpString += "| ";
                    TmpString += TmpDVD.D_Nom.ToString();
                    TmpString = TmpString.PadRight(60);
                    TmpString += "| ";
                    TmpString += DateEmprunt.AddDays((double)TmpDVD.D_Emprunt_Max).ToShortDateString();
                    TmpString = TmpString.PadRight(73);
                    TmpString += "| ";
                    TmpString += TmpDVD.D_Amende_p_J.ToString();
                    TmpString += "€";
                    TmpString = TmpString.PadRight(85);
                    TmpString += "|";
                    sw.WriteLine(TmpString);
                }
                #region Dernière ligne
                TmpString = "|";
                TmpString = TmpString.PadRight(7, '_');
                TmpString += "|";
                TmpString = TmpString.PadRight(60, '_');
                TmpString += "|";
                TmpString = TmpString.PadRight(73, '_');
                TmpString += "|";
                TmpString = TmpString.PadRight(85, '_');
                TmpString += "|";
                sw.WriteLine(TmpString);
                #endregion
                #endregion

                sw.Close();
            }
        }

        private int CalculerNotifications() // Calcule le nombre de notifications actuelles. Une notification = Un client en retard (retour ET/OU cotisation)
        {
            int NbrNotifs = 0;
            List<C_T_Client> lTmpClient = new G_T_Client(sChConn).Lire("Id_Client");
            foreach(C_T_Client TmpClient in lTmpClient)
            {
                if (CalculerAmende(TmpClient.Id_Client) > 0 || CalculerRetardCot((DateTime)TmpClient.C_Cotisation))
                    NbrNotifs++;
            }
            return NbrNotifs;
        }
        #endregion
    }
}
