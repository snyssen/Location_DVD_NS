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
    public partial class EcranNotifications : Form
    {
        private string sChConn;
        public EcranNotifications(string sChConn_)
        {
            InitializeComponent();
            this.sChConn = sChConn_; 
            AfficherNotifs();
        }

        private void cbAfficherpDVD_CheckedChanged(object sender, EventArgs e)
        {
            AfficherNotifs();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AfficherNotifs() // Une ligne = 148 char
        {
            rtbInfos.Text = "";
            if (!cbAfficherpDVD.Checked) // Tri par client
            {
                List<C_T_Client> lTmpClient = new G_T_Client(sChConn).Lire("Id_Client");
                foreach(C_T_Client TmpClient in lTmpClient)
                {
                    double TmpAmende = new EcranAccueil(sChConn).CalculerAmende(TmpClient.Id_Client);
                    bool TmpRetardCot = new EcranAccueil(sChConn).CalculerRetardCot((DateTime)TmpClient.C_Cotisation);
                    if ( TmpAmende > 0 || TmpRetardCot) // Le client a un retard
                    {
                        string TmpString, TmpString2;
                        bool FirstLine = true;
                        TmpString = TmpClient.C_Nom + " " + TmpClient.C_Prenom + "(ID=" + TmpClient.Id_Client.ToString() + ") ";
                        int stringlen = TmpString.Length;
                        if (TmpRetardCot) // Retard de cotisation
                        {
                            DateTime DateCot = (DateTime)TmpClient.C_Cotisation;
                            TimeSpan TpsRetard = DateTime.Today - DateCot.AddDays(1);
                            TmpString2 = " En retard de cotisation de " + TpsRetard.Days.ToString() + " jours";
                            TmpString2 = TmpString2.PadLeft(148 - stringlen, '-'); // On s'assure que le string complet prendra l'ensemble de la rtb
                            TmpString += TmpString2;
                            rtbInfos.Text += TmpString;
                            rtbInfos.Text += "\n";
                            FirstLine = false;
                        }
                        if (TmpAmende > 0)
                        {
                            List<C_T_Emprunt> lTmpEmprunt = new G_T_Emprunt(sChConn).Lire("Id_Emprunt"); // Charge tous les emprunts
                            foreach (C_T_Emprunt TmpEmprunt in lTmpEmprunt) // Parcourt tous les emprunts
                            {
                                if (TmpEmprunt.Id_Client == TmpClient.Id_Client) // Si Id client de l'emprunt parcouru == Id client sélectionné...
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
                                                            TmpString2 = " Retard pour le retour de " + TmpDVD.D_Nom + " (ID=" + TmpDVD.Id_DVD + ") de " + retard.ToString() + " jours => amende = " + (retard * TmpDVD.D_Amende_p_J).ToString() + "€ (" + TmpDVD.D_Amende_p_J.ToString() + "€ par jour)";
                                                            TmpString2 = TmpString2.PadLeft(148 - stringlen, '-'); // On s'assure que le string complet prendra l'ensemble de la rtb
                                                            if (FirstLine)
                                                            {
                                                                TmpString += TmpString2;
                                                                rtbInfos.Text += TmpString;
                                                                FirstLine = false;
                                                            }
                                                            else
                                                            {
                                                                TmpString2 = TmpString2.PadLeft(148);
                                                                rtbInfos.Text += TmpString2;
                                                            }
                                                            rtbInfos.Text += "\n";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        rtbInfos.Text += "\n"; // On saute une ligne avant de passer au client suivant
                    }
                }
            }
            else // Tri par DVD
            {

            }
        }
    }
}
