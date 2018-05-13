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
    public partial class EcranDetailsDVD : Form
    {
        private C_T_DVD SelectedDVD;
        private string sChConn;
        private string InternetLink;
        private bool Modifying = false;
        private int NbrActeurs = 0; // Nombres d'acteurs jouant dans le film = Nombre de tables Liste_Acteurs liées à ce DVD
        public EcranDetailsDVD(int _ID_DVD, string _sChConn)
        {
            InitializeComponent();
            this.sChConn = _sChConn;
            SelectedDVD = new G_T_DVD(sChConn).Lire_ID(_ID_DVD);
            RemplirDonnees();
        }
        private void RemplirDonnees()
        {
            SelectedDVD = new G_T_DVD(sChConn).Lire_ID(SelectedDVD.Id_DVD);
            this.Text = "DVD n°" + SelectedDVD.Id_DVD;
            tbNomFilm.Text = SelectedDVD.D_Nom;
            tbGenre.Text = SelectedDVD.D_Genre;
            InternetLink = SelectedDVD.D_Synopsis;
            nudEmpruntMax.Value = (decimal)SelectedDVD.D_Emprunt_Max;
            nudAmende_p_j.Value = (decimal)SelectedDVD.D_Amende_p_J;

            // Acteurs
            lbActeurs.Items.Clear();
            if (!Modifying) // On n'est pas en train de modifier les données => On n'affiche que les acteurs qui jouent dans le film
            {
                List<C_T_Liste_Acteurs> lTmplActeur = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs"); // Toutes les listes d'acteurs
                NbrActeurs = 0;
                foreach (C_T_Liste_Acteurs TmplActeur in lTmplActeur)
                {
                    if ((int)TmplActeur.Id_DVD == SelectedDVD.Id_DVD)
                    {
                        C_T_Acteur TmpActeur = new G_T_Acteur(sChConn).Lire_ID((int)TmplActeur.Id_Acteur);
                        lbActeurs.Items.Add(TmpActeur.A_Nom + " " + TmpActeur.A_Prenom + " (ID=" + TmpActeur.Id_Acteur + ")");
                        NbrActeurs++;
                    }
                }
            }
            else // On est en train de modifier les données => Il faut afficher tous les acteurs de la base de données
            {
                List<C_T_Acteur> lTmpActeur = new G_T_Acteur(sChConn).Lire("Id_Acteur");
                foreach (C_T_Acteur TmpActeur in lTmpActeur)
                {
                    lbActeurs.Items.Add(TmpActeur.A_Nom + " " + TmpActeur.A_Prenom + " (ID=" + TmpActeur.Id_Acteur + ")");
                }
            }

            //Emprunt actuel et précédents
            lbClients_precedents.Items.Clear();
            List<C_T_Quantite> lTmpQuantite = new G_T_Quantite(sChConn).Lire("Id_Emprunt");
            foreach (C_T_Quantite TmpQuantite in lTmpQuantite)
            {
                if (TmpQuantite.Id_DVD == SelectedDVD.Id_DVD)
                {
                    C_T_Emprunt TmpEmprunt = new G_T_Emprunt(sChConn).Lire_ID((int)TmpQuantite.Id_Emprunt);
                    C_T_Client TmpClient = new G_T_Client(sChConn).Lire_ID((int)TmpEmprunt.Id_Client); // On remonte à la source pour récupérer le client
                    if (TmpQuantite.Q_Retour == null) // Le DVD est actuellement emprunté par ce client
                        tbClient_actuel.Text = TmpClient.C_Nom.ToUpper() + " " + TmpClient.C_Prenom + " (ID=" + TmpClient.Id_Client + ")";
                    else
                        lbClients_precedents.Items.Add(TmpClient.C_Nom.ToUpper() + " " + TmpClient.C_Prenom + " (ID=" + TmpClient.Id_Client + ")");
                }
            }
            if (!SelectedDVD.D_Emprunt)
                tbClient_actuel.Text = "N/A";
        }

        private void ChangeState()
        {
            Modifying = !Modifying; // Inversion de Modifying
            tbNomFilm.Enabled = tbGenre.Enabled = btnModiferSynopsis.Enabled = nudEmpruntMax.Enabled = nudAmende_p_j.Enabled = lbActeurs.Enabled = Modifying; // Active/Désactive tous les éléments pouvant être modifiés
            if (Modifying)
            {
                btnModif_Annul.Text = "Annuler";
                btnConf_Quitter.Text = "Confirmer";
                lblActeurs.Text = "Acteurs principaux (sélection)";
            }
            else
            {
                btnModif_Annul.Text = "Modifier informations";
                btnConf_Quitter.Text = "Quitter";
                lblActeurs.Text = "Acteurs principaux";
            }
        }

        private void llblSynopsis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Modifying)
            {
                if (InternetLink.StartsWith("https://") || InternetLink.StartsWith("http://"))
                {
                    System.Diagnostics.Process.Start(InternetLink);
                    llblSynopsis.LinkVisited = true;
                }
                else
                    MessageBox.Show("Le lien n'est pas valide");
            }
        }

        private void btnConf_Quitter_Click(object sender, EventArgs e)
        {
            if (!Modifying) // Quitter
            {
                lbActeurs.Items.Clear();
                lbClients_precedents.Items.Clear();
                this.Close();
            }
            else // Confirmer
            {
                if (tbNomFilm.Text == "" || tbGenre.Text == "" || InternetLink == "" || nudEmpruntMax.Value <= 0 || nudAmende_p_j.Value <= 0 || lbActeurs.SelectedItems.Count <= 0)
                    MessageBox.Show("Assurez-vous d'avoir rempli toutes les informations !");
                else
                {
                    if (NbrActeurs <= 0)
                        MessageBox.Show("ERREUR : Nombre d'acteurs = " + NbrActeurs);
                    else
                    {
                        new G_T_DVD(sChConn).Modifier(SelectedDVD.Id_DVD, tbNomFilm.Text, SelectedDVD.D_Emprunt, tbGenre.Text, (int)nudEmpruntMax.Value, (double)nudAmende_p_j.Value, InternetLink);
                        int NbrActeursModifs = 0; // Nombres d'acteurs qui ont déjà été modifiés => sert de compteur
                        do // Modification des acteurs jouant dans le film. 3 cas: 1) Moins d'acteurs qu'avant la modification; 2) Même nombre d'acteurs qu'avant; 3) Plus d'acteurs qu'avant.
                        {
                            List<C_T_Liste_Acteurs> lTmplActeurs = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs");
                            foreach (C_T_Liste_Acteurs TmplActeurs in lTmplActeurs)
                            {
                                if (TmplActeurs.Id_DVD == SelectedDVD.Id_DVD) // On se place sur le bon DVD
                                {
                                    string[] TmpTabString = lbActeurs.SelectedItems[NbrActeursModifs].ToString().Split('=');
                                    TmpTabString[1] = TmpTabString[1].Remove(TmpTabString[1].Length - 1);
                                    if (!int.TryParse(TmpTabString[1], out int TmpID))
                                        MessageBox.Show("Erreur lors de la récupération de l'ID de l'acteur !");
                                    else
                                    {
                                        new G_T_Liste_Acteurs(sChConn).Modifier(TmplActeurs.Id_Liste_Acteurs, SelectedDVD.Id_DVD, TmpID);
                                        NbrActeursModifs++;
                                    }
                                    if (NbrActeursModifs == lbActeurs.SelectedItems.Count)
                                        break;
                                }
                            }
                        }
                        while (NbrActeursModifs < NbrActeurs && NbrActeursModifs < lbActeurs.SelectedItems.Count); // On boucle tant qu'on a pas modifié autant d'acteurs que ceux qu'il y en avait avant => encore des tables dispos (cas où on AJOUTE des acteurs par rapport à avant)
                                                                                                                   // ET tant qu'on a pas modifié autant d'acteurs que ceux qui sont sélectionnés => on évite de modifier plus d'acteurs que ce qui est demandé (cas où on RETIRE des acteurs par rapport à avant)
                        if (NbrActeursModifs < NbrActeurs) // On a modifié moins d'acteurs que ce qu'il y en avait avant => il faut supprimer des tables
                        {
                            List<C_T_Liste_Acteurs> lTmplActeurs = new G_T_Liste_Acteurs(sChConn).Lire("Id_Liste_Acteurs");
                            foreach (C_T_Liste_Acteurs TmplActeurs in lTmplActeurs)
                            {
                                if (TmplActeurs.Id_DVD == SelectedDVD.Id_DVD) // On se place sur le bon DVD
                                {
                                    int NbrIDIdentiques = 0;
                                    for (int i = 0; i < lbActeurs.SelectedItems.Count; i++)
                                    {
                                        string[] TmpTabString = lbActeurs.SelectedItems[i].ToString().Split('=');
                                        TmpTabString[1] = TmpTabString[1].Remove(TmpTabString[1].Length - 1);
                                        if (!int.TryParse(TmpTabString[1], out int TmpID))
                                            MessageBox.Show("Erreur lors de la récupération de l'ID de l'acteur !");
                                        else
                                        {
                                            if (TmpID == TmplActeurs.Id_Acteur)
                                                NbrIDIdentiques++;
                                        }
                                    }
                                    if (NbrIDIdentiques <= 0) // On a aucun match d'ID => la table est de trop
                                        new G_T_Liste_Acteurs(sChConn).Supprimer(TmplActeurs.Id_Liste_Acteurs); // => On la supprime
                                }
                            }
                        }
                        else
                        {
                            if (lbActeurs.SelectedItems.Count > NbrActeurs) // On ajout des acteurs par rapport à avant => Il faut rajouter des tables
                            {
                                for (int i = NbrActeursModifs; i < lbActeurs.SelectedItems.Count; i++)
                                {
                                    string[] TmpTabString = lbActeurs.SelectedItems[i].ToString().Split('=');
                                    TmpTabString[1] = TmpTabString[1].Remove(TmpTabString[1].Length - 1);
                                    if (!int.TryParse(TmpTabString[1], out int TmpID))
                                        MessageBox.Show("Erreur lors de la récupération de l'ID de l'acteur !");
                                    else
                                        new G_T_Liste_Acteurs(sChConn).Ajouter(SelectedDVD.Id_DVD, TmpID);
                                }
                            }
                        }
                        ChangeState();
                        RemplirDonnees();
                    }
                }
            }
        }

        private void btnModif_Annul_Click(object sender, EventArgs e)
        {
            ChangeState();
            RemplirDonnees();
        }

        private void btnModiferSynopsis_Click(object sender, EventArgs e)
        {
            EcranModifyString modifyString = new EcranModifyString("URL vers le synopsis", InternetLink);
            modifyString.ShowDialog();
            if (modifyString.Confirmed)
                InternetLink = modifyString.NewString;
        }
    }
}
