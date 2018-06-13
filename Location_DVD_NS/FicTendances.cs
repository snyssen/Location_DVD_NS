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

using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Location_DVD_NS
{
    public partial class EcranTendances : Form
    {
        private string sChConn;
        private List<NameAndEntries> lDVDEntries;
        private int Filtre = 0;
        public EcranTendances(string _sChConn)
        {
            InitializeComponent();
            this.sChConn = _sChConn;
            RemplirListeTendanceSQL();
        }

        private void RemplirListeTendanceSQL()
        {
            lbTendances.Items.Clear();
            ADBase sql = new ADBase(sChConn);
            sql.CreerCommande("SelectionnerTendances");
            sql.Commande.Connection.Open();
            SqlDataReader dr = sql.Commande.ExecuteReader();
            List<T_Tendances> res = new List<T_Tendances>();
            while (dr.Read())
            {
                T_Tendances tmp = new T_Tendances();
                tmp.D_Nom = dr["D_Nom"].ToString();
                tmp.quantite = int.Parse(dr["quantite"].ToString());
                res.Add(tmp);
            }
            dr.Close();
            sql.Commande.Connection.Close();

            res = res.OrderBy(x => x.quantite).ToList();
            for (int i = res.Count - 1; i >= 0; i--) // Liste ordonnée par ordre croissant => On la charge à l'envers
            {
                lbTendances.Items.Add(res[i].D_Nom + " (" + res[i].quantite.ToString() + " emprunts)");
            }
        }

        private void RemplirListeTendance()
        {
            lbTendances.Items.Clear();
            lDVDEntries = new List<NameAndEntries>();
            List<C_T_Quantite> lTmpQuantite = new G_T_Quantite(sChConn).Lire("Id_Emprunt");
            foreach (C_T_Quantite TmpQuantite in lTmpQuantite)
            {
                bool Trouve = false;
                C_T_DVD TmpDVD = new G_T_DVD(sChConn).Lire_ID((int)TmpQuantite.Id_DVD);
                for (int i = 0; i < lDVDEntries.Count; i++)
                {
                    if (lDVDEntries[i].Name == TmpDVD.D_Nom)
                    {
                        C_T_Emprunt TmpEmprunt = new G_T_Emprunt(sChConn).Lire_ID((int)TmpQuantite.Id_Emprunt);
                        switch (Filtre)
                        {
                            default:
                            case 0: // Tous
                                lDVDEntries[i].Entries++;
                                Trouve = true;
                                break;
                            case 1: // mois
                                if (TmpEmprunt.E_Emprunt >= DateTime.Today.AddMonths(-1))
                                    lDVDEntries[i].Entries++;
                                Trouve = true;
                                break;
                            case 2: // Semaine
                                if (TmpEmprunt.E_Emprunt >= DateTime.Today.AddDays(-7))
                                    lDVDEntries[i].Entries++;
                                Trouve = true;
                                break;
                            case 3: // Ajd
                                if (TmpEmprunt.E_Emprunt >= DateTime.Today)
                                    lDVDEntries[i].Entries++;
                                Trouve = true;
                                break;
                        }
                        break;
                    }
                }
                if (!Trouve)
                {
                    //lDVDEntries.Add(new NameAndEntries(TmpDVD.D_Nom));
                    C_T_Emprunt TmpEmprunt = new G_T_Emprunt(sChConn).Lire_ID((int)TmpQuantite.Id_Emprunt);
                    switch (Filtre)
                    {
                        default:
                        case 0: // Tous
                            lDVDEntries.Add(new NameAndEntries(TmpDVD.D_Nom));
                            Trouve = true;
                            break;
                        case 1: // mois
                            if (TmpEmprunt.E_Emprunt >= DateTime.Today.AddMonths(-1))
                                lDVDEntries.Add(new NameAndEntries(TmpDVD.D_Nom));
                            Trouve = true;
                            break;
                        case 2: // Semaine
                            if (TmpEmprunt.E_Emprunt >= DateTime.Today.AddDays(-7))
                                lDVDEntries.Add(new NameAndEntries(TmpDVD.D_Nom));
                            Trouve = true;
                            break;
                        case 3: // Ajd
                            if (TmpEmprunt.E_Emprunt >= DateTime.Today)
                                lDVDEntries.Add(new NameAndEntries(TmpDVD.D_Nom));
                            Trouve = true;
                            break;
                    }

                }
            }
            lDVDEntries = lDVDEntries.OrderBy(x => x.Entries).ToList();
            for (int i = lDVDEntries.Count - 1; i >= 0; i--) // Liste ordonnée par ordre croissant => On la charge à l'envers
            {
                lbTendances.Items.Add(lDVDEntries[i].Name + " (" + lDVDEntries[i].Entries.ToString() + " emprunts)");
            }
        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;
            if (rbtn.Checked)
            {
                Filtre = int.Parse(rbtn.Tag.ToString());
                if (Filtre == 0)
                    RemplirListeTendanceSQL();
                else
                    RemplirListeTendance();
            }
        }
    }
    public class NameAndEntries
    {
        public string Name { get; set; }
        public int Entries { get; set; }

        public NameAndEntries(string Name_)
        {
            this.Name = Name_;
            this.Entries = 1;
        }
    }

    public class T_Tendances
    {
        public string D_Nom { get; set; }
        public int quantite { get; set; }

        public T_Tendances()
        { }
    }
}
