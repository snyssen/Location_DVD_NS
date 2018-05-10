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
    public partial class EcranAjouterEmprunt : Form
    {
        public int IDClientEmprunt;
        public List<int> Liste_ID_DVD_Emprunt;
        public bool Confirmed = false;
        private string sChConn;
        public EcranAjouterEmprunt(string _sChConn)
        {
            InitializeComponent();
            this.sChConn = _sChConn;
            RemplirListeClients();
            RemplirListeDVD();
        }

        private void RemplirListeClients() // PAS ENCORE DE CONDITION SUR LES RETARDS DU CLIENTS !!!
        {
            lbClientEmprunt.Items.Clear();
            List<C_T_Client> lTmpClient = new G_T_Client(sChConn).Lire("Id_Client");
            foreach (C_T_Client TmpClient in lTmpClient)
                lbClientEmprunt.Items.Add(TmpClient.C_Nom.ToString() + " " + TmpClient.C_Prenom.ToString() + " (ID=" + TmpClient.Id_Client + ")");
        }
        private void RemplirListeDVD()
        {
            lbDVDEmprunt.Items.Clear();
            List<C_T_DVD> lTmpDVD = new G_T_DVD(sChConn).Lire("Id_DVD");
            foreach (C_T_DVD TmpDVD in lTmpDVD)
            {
                if (!TmpDVD.D_Emprunt)
                    lbDVDEmprunt.Items.Add(TmpDVD.D_Nom.ToString() + " (ID=" + TmpDVD.Id_DVD + ")");
            }
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (lbClientEmprunt.SelectedItem == null || lbDVDEmprunt.SelectedItems.Count <= 0)
                MessageBox.Show("Veuillez sélectionner un client et au moins un DVD SVP !");
            else
            {
                string[] TmpTabClient = lbClientEmprunt.SelectedItem.ToString().Split('=');
                TmpTabClient[1] = TmpTabClient[1].Remove(TmpTabClient[1].Length - 1);
                if (!int.TryParse(TmpTabClient[1], out IDClientEmprunt))
                    MessageBox.Show("Erreur lors de la récupération de l'ID du client !");
                Liste_ID_DVD_Emprunt = new List<int>();
                foreach (string lTmpDVD in lbDVDEmprunt.SelectedItems)
                {
                    string[] TmpTabDVD = lTmpDVD.Split('=');
                    TmpTabDVD[1] = TmpTabDVD[1].Remove(TmpTabDVD[1].Length - 1);
                    if (!int.TryParse(TmpTabDVD[1], out int TmpID))
                        MessageBox.Show("Erreur lors de la récupération de l'ID du DVD !");
                    Liste_ID_DVD_Emprunt.Add(TmpID);
                }
                Confirmed = true;
                lbClientEmprunt.Items.Clear();
                lbDVDEmprunt.Items.Clear();
                this.Close();
            }
        }
    }
}
