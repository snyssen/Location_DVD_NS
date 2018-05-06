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
        private BindingSource bsClients, bsEmprunts, bsDVD, bsActeurs;

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

        private void RemplirDGV()
        {
            dtEmprunts = new DataTable();
            dtDVD = new DataTable();
            dtActeurs = new DataTable();

            #region dgvClient
            dtClients = new DataTable();
            dtClients.Columns.Add(new DataColumn("Id_Client", System.Type.GetType("System.Int32")));
            dtClients.Columns.Add("C_Nom");
            dtClients.Columns.Add("C_Prenom");
            List<C_T_Client> lTmp = new G_T_Client(sChConn).Lire("C_Nom");
            foreach (C_T_Client Tmp in lTmp)
                dtClients.Rows.Add(Tmp.Id_Client, Tmp.C_Nom, Tmp.C_Prenom);
            // DEBUG
            //C_T_Client test = new G_T_Client(sChConn).Lire_ID(0);
            //dtClients.Rows.Add(test.Id_Client, test.C_Nom, test.C_Prenom);
            bsClients = new BindingSource();
            bsClients.DataSource = dtClients;
            dgvClients.DataSource = bsClients;
            #endregion

            #region dgvEmprunt
            #endregion

            #region dgvDVD
            #endregion

            #region dgvActeurs
            #endregion
        }

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            EcranAjouterClient ajoutclient = new EcranAjouterClient();
            ajoutclient.ShowDialog();
            if (ajoutclient.confirmed)
            {
                MessageBox.Show(ajoutclient.NomClient + " " + ajoutclient.PrenomClient);
                int nID = new G_T_Client(sChConn).Ajouter(ajoutclient.NomClient, ajoutclient.PrenomClient);
                dtClients.Rows.Add(nID, ajoutclient.NomClient, ajoutclient.PrenomClient);
            }
        }


    }
}
