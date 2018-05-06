﻿namespace Location_DVD_NS
{
    partial class EcranAccueil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.dgvDVD = new System.Windows.Forms.DataGridView();
            this.dgvEmprunts = new System.Windows.Forms.DataGridView();
            this.dgvActeurs = new System.Windows.Forms.DataGridView();
            this.pFiltreClients = new System.Windows.Forms.Panel();
            this.lblFiltreClients = new System.Windows.Forms.Label();
            this.rbtnFCRetardCot = new System.Windows.Forms.RadioButton();
            this.rbtnFCRetardRetour = new System.Windows.Forms.RadioButton();
            this.rbtnFCRetards = new System.Windows.Forms.RadioButton();
            this.rbtnFCTous = new System.Windows.Forms.RadioButton();
            this.pFiltreDVD = new System.Windows.Forms.Panel();
            this.lblFiltreDVD = new System.Windows.Forms.Label();
            this.rbtnFDPret = new System.Windows.Forms.RadioButton();
            this.rbtnFDDispos = new System.Windows.Forms.RadioButton();
            this.rbtnFDTous = new System.Windows.Forms.RadioButton();
            this.tbAmende = new System.Windows.Forms.TextBox();
            this.lblAmende = new System.Windows.Forms.Label();
            this.NomActeur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrenomActeur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BioActeur = new System.Windows.Forms.DataGridViewLinkColumn();
            this.IDClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgC_Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgC_Prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgC_Retard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomDVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpruntDVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDEmprunt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Emprunt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retour_Emprunt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlgChargerDB = new System.Windows.Forms.OpenFileDialog();
            this.btnAjouterClient = new System.Windows.Forms.Button();
            this.btnAjouterEmprunt = new System.Windows.Forms.Button();
            this.btnAjouterDVD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActeurs)).BeginInit();
            this.pFiltreClients.SuspendLayout();
            this.pFiltreDVD.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDClient,
            this.dtgC_Nom,
            this.dtgC_Prenom,
            this.dtgC_Retard});
            this.dgvClients.Location = new System.Drawing.Point(12, 12);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.Size = new System.Drawing.Size(240, 150);
            this.dgvClients.TabIndex = 0;
            // 
            // dgvDVD
            // 
            this.dgvDVD.AllowUserToAddRows = false;
            this.dgvDVD.AllowUserToDeleteRows = false;
            this.dgvDVD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDVD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDVD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDDVD,
            this.NomDVD,
            this.EmpruntDVD});
            this.dgvDVD.Location = new System.Drawing.Point(12, 288);
            this.dgvDVD.Name = "dgvDVD";
            this.dgvDVD.ReadOnly = true;
            this.dgvDVD.RowHeadersVisible = false;
            this.dgvDVD.Size = new System.Drawing.Size(240, 150);
            this.dgvDVD.TabIndex = 1;
            // 
            // dgvEmprunts
            // 
            this.dgvEmprunts.AllowUserToAddRows = false;
            this.dgvEmprunts.AllowUserToDeleteRows = false;
            this.dgvEmprunts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvEmprunts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprunts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDEmprunt,
            this.Date_Emprunt,
            this.Retour_Emprunt});
            this.dgvEmprunts.Location = new System.Drawing.Point(419, 12);
            this.dgvEmprunts.Name = "dgvEmprunts";
            this.dgvEmprunts.ReadOnly = true;
            this.dgvEmprunts.RowHeadersVisible = false;
            this.dgvEmprunts.Size = new System.Drawing.Size(240, 150);
            this.dgvEmprunts.TabIndex = 2;
            // 
            // dgvActeurs
            // 
            this.dgvActeurs.AllowUserToAddRows = false;
            this.dgvActeurs.AllowUserToDeleteRows = false;
            this.dgvActeurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvActeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActeurs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomActeur,
            this.PrenomActeur,
            this.BioActeur});
            this.dgvActeurs.Location = new System.Drawing.Point(419, 288);
            this.dgvActeurs.Name = "dgvActeurs";
            this.dgvActeurs.ReadOnly = true;
            this.dgvActeurs.RowHeadersVisible = false;
            this.dgvActeurs.Size = new System.Drawing.Size(240, 150);
            this.dgvActeurs.TabIndex = 3;
            // 
            // pFiltreClients
            // 
            this.pFiltreClients.Controls.Add(this.lblAmende);
            this.pFiltreClients.Controls.Add(this.tbAmende);
            this.pFiltreClients.Controls.Add(this.lblFiltreClients);
            this.pFiltreClients.Controls.Add(this.rbtnFCRetardCot);
            this.pFiltreClients.Controls.Add(this.rbtnFCRetardRetour);
            this.pFiltreClients.Controls.Add(this.rbtnFCRetards);
            this.pFiltreClients.Controls.Add(this.rbtnFCTous);
            this.pFiltreClients.Location = new System.Drawing.Point(258, 13);
            this.pFiltreClients.Name = "pFiltreClients";
            this.pFiltreClients.Size = new System.Drawing.Size(155, 149);
            this.pFiltreClients.TabIndex = 4;
            // 
            // lblFiltreClients
            // 
            this.lblFiltreClients.AutoSize = true;
            this.lblFiltreClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltreClients.Location = new System.Drawing.Point(4, 4);
            this.lblFiltreClients.Name = "lblFiltreClients";
            this.lblFiltreClients.Size = new System.Drawing.Size(39, 13);
            this.lblFiltreClients.TabIndex = 4;
            this.lblFiltreClients.Text = "Filtrer";
            // 
            // rbtnFCRetardCot
            // 
            this.rbtnFCRetardCot.AutoSize = true;
            this.rbtnFCRetardCot.Location = new System.Drawing.Point(7, 89);
            this.rbtnFCRetardCot.Name = "rbtnFCRetardCot";
            this.rbtnFCRetardCot.Size = new System.Drawing.Size(120, 17);
            this.rbtnFCRetardCot.TabIndex = 3;
            this.rbtnFCRetardCot.Text = "Retardataires (DVD)";
            this.rbtnFCRetardCot.UseVisualStyleBackColor = true;
            // 
            // rbtnFCRetardRetour
            // 
            this.rbtnFCRetardRetour.AutoSize = true;
            this.rbtnFCRetardRetour.Location = new System.Drawing.Point(7, 66);
            this.rbtnFCRetardRetour.Name = "rbtnFCRetardRetour";
            this.rbtnFCRetardRetour.Size = new System.Drawing.Size(129, 17);
            this.rbtnFCRetardRetour.TabIndex = 2;
            this.rbtnFCRetardRetour.Text = "Retardataires (retours)";
            this.rbtnFCRetardRetour.UseVisualStyleBackColor = true;
            // 
            // rbtnFCRetards
            // 
            this.rbtnFCRetards.AutoSize = true;
            this.rbtnFCRetards.Location = new System.Drawing.Point(7, 43);
            this.rbtnFCRetards.Name = "rbtnFCRetards";
            this.rbtnFCRetards.Size = new System.Drawing.Size(117, 17);
            this.rbtnFCRetards.TabIndex = 1;
            this.rbtnFCRetards.Text = "Retardataires (tous)";
            this.rbtnFCRetards.UseVisualStyleBackColor = true;
            // 
            // rbtnFCTous
            // 
            this.rbtnFCTous.AutoSize = true;
            this.rbtnFCTous.Checked = true;
            this.rbtnFCTous.Location = new System.Drawing.Point(7, 20);
            this.rbtnFCTous.Name = "rbtnFCTous";
            this.rbtnFCTous.Size = new System.Drawing.Size(49, 17);
            this.rbtnFCTous.TabIndex = 0;
            this.rbtnFCTous.TabStop = true;
            this.rbtnFCTous.Text = "Tous";
            this.rbtnFCTous.UseVisualStyleBackColor = true;
            // 
            // pFiltreDVD
            // 
            this.pFiltreDVD.Controls.Add(this.lblFiltreDVD);
            this.pFiltreDVD.Controls.Add(this.rbtnFDPret);
            this.pFiltreDVD.Controls.Add(this.rbtnFDDispos);
            this.pFiltreDVD.Controls.Add(this.rbtnFDTous);
            this.pFiltreDVD.Location = new System.Drawing.Point(258, 288);
            this.pFiltreDVD.Name = "pFiltreDVD";
            this.pFiltreDVD.Size = new System.Drawing.Size(155, 149);
            this.pFiltreDVD.TabIndex = 5;
            // 
            // lblFiltreDVD
            // 
            this.lblFiltreDVD.AutoSize = true;
            this.lblFiltreDVD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltreDVD.Location = new System.Drawing.Point(4, 4);
            this.lblFiltreDVD.Name = "lblFiltreDVD";
            this.lblFiltreDVD.Size = new System.Drawing.Size(39, 13);
            this.lblFiltreDVD.TabIndex = 4;
            this.lblFiltreDVD.Text = "Filtrer";
            // 
            // rbtnFDPret
            // 
            this.rbtnFDPret.AutoSize = true;
            this.rbtnFDPret.Location = new System.Drawing.Point(7, 66);
            this.rbtnFDPret.Name = "rbtnFDPret";
            this.rbtnFDPret.Size = new System.Drawing.Size(59, 17);
            this.rbtnFDPret.TabIndex = 2;
            this.rbtnFDPret.Text = "En prêt";
            this.rbtnFDPret.UseVisualStyleBackColor = true;
            // 
            // rbtnFDDispos
            // 
            this.rbtnFDDispos.AutoSize = true;
            this.rbtnFDDispos.Location = new System.Drawing.Point(7, 43);
            this.rbtnFDDispos.Name = "rbtnFDDispos";
            this.rbtnFDDispos.Size = new System.Drawing.Size(79, 17);
            this.rbtnFDDispos.TabIndex = 1;
            this.rbtnFDDispos.Text = "Disponibles";
            this.rbtnFDDispos.UseVisualStyleBackColor = true;
            // 
            // rbtnFDTous
            // 
            this.rbtnFDTous.AutoSize = true;
            this.rbtnFDTous.Checked = true;
            this.rbtnFDTous.Location = new System.Drawing.Point(7, 20);
            this.rbtnFDTous.Name = "rbtnFDTous";
            this.rbtnFDTous.Size = new System.Drawing.Size(49, 17);
            this.rbtnFDTous.TabIndex = 0;
            this.rbtnFDTous.TabStop = true;
            this.rbtnFDTous.Text = "Tous";
            this.rbtnFDTous.UseVisualStyleBackColor = true;
            // 
            // tbAmende
            // 
            this.tbAmende.Location = new System.Drawing.Point(7, 126);
            this.tbAmende.Name = "tbAmende";
            this.tbAmende.ReadOnly = true;
            this.tbAmende.Size = new System.Drawing.Size(129, 20);
            this.tbAmende.TabIndex = 5;
            // 
            // lblAmende
            // 
            this.lblAmende.AutoSize = true;
            this.lblAmende.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmende.Location = new System.Drawing.Point(4, 109);
            this.lblAmende.Name = "lblAmende";
            this.lblAmende.Size = new System.Drawing.Size(105, 13);
            this.lblAmende.TabIndex = 6;
            this.lblAmende.Text = "Amende du client";
            // 
            // NomActeur
            // 
            this.NomActeur.HeaderText = "Nom";
            this.NomActeur.Name = "NomActeur";
            this.NomActeur.ReadOnly = true;
            this.NomActeur.Width = 54;
            // 
            // PrenomActeur
            // 
            this.PrenomActeur.HeaderText = "Prénom";
            this.PrenomActeur.Name = "PrenomActeur";
            this.PrenomActeur.ReadOnly = true;
            this.PrenomActeur.Width = 68;
            // 
            // BioActeur
            // 
            this.BioActeur.HeaderText = "En savoir plus";
            this.BioActeur.Name = "BioActeur";
            this.BioActeur.ReadOnly = true;
            this.BioActeur.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BioActeur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BioActeur.Width = 98;
            // 
            // IDClient
            // 
            this.IDClient.HeaderText = "ID";
            this.IDClient.Name = "IDClient";
            this.IDClient.ReadOnly = true;
            this.IDClient.Width = 43;
            // 
            // dtgC_Nom
            // 
            this.dtgC_Nom.HeaderText = "Nom";
            this.dtgC_Nom.Name = "dtgC_Nom";
            this.dtgC_Nom.ReadOnly = true;
            this.dtgC_Nom.Width = 54;
            // 
            // dtgC_Prenom
            // 
            this.dtgC_Prenom.HeaderText = "Prénom";
            this.dtgC_Prenom.Name = "dtgC_Prenom";
            this.dtgC_Prenom.ReadOnly = true;
            this.dtgC_Prenom.Width = 68;
            // 
            // dtgC_Retard
            // 
            this.dtgC_Retard.HeaderText = "Retard (o/n)";
            this.dtgC_Retard.Name = "dtgC_Retard";
            this.dtgC_Retard.ReadOnly = true;
            this.dtgC_Retard.Width = 90;
            // 
            // IDDVD
            // 
            this.IDDVD.HeaderText = "ID";
            this.IDDVD.Name = "IDDVD";
            this.IDDVD.ReadOnly = true;
            this.IDDVD.Width = 43;
            // 
            // NomDVD
            // 
            this.NomDVD.HeaderText = "Nom";
            this.NomDVD.Name = "NomDVD";
            this.NomDVD.ReadOnly = true;
            this.NomDVD.Width = 54;
            // 
            // EmpruntDVD
            // 
            this.EmpruntDVD.HeaderText = "Disponible (o/n)";
            this.EmpruntDVD.Name = "EmpruntDVD";
            this.EmpruntDVD.ReadOnly = true;
            this.EmpruntDVD.Width = 98;
            // 
            // IDEmprunt
            // 
            this.IDEmprunt.HeaderText = "ID";
            this.IDEmprunt.Name = "IDEmprunt";
            this.IDEmprunt.ReadOnly = true;
            this.IDEmprunt.Width = 43;
            // 
            // Date_Emprunt
            // 
            this.Date_Emprunt.HeaderText = "Date";
            this.Date_Emprunt.Name = "Date_Emprunt";
            this.Date_Emprunt.ReadOnly = true;
            this.Date_Emprunt.Width = 55;
            // 
            // Retour_Emprunt
            // 
            this.Retour_Emprunt.HeaderText = "Retourné (o/n)";
            this.Retour_Emprunt.Name = "Retour_Emprunt";
            this.Retour_Emprunt.ReadOnly = true;
            this.Retour_Emprunt.Width = 102;
            // 
            // dlgChargerDB
            // 
            this.dlgChargerDB.FileName = "Location_DVD.mdf";
            this.dlgChargerDB.Filter = "Fichier de base de données|*.mdf|Tous les fichiers|*.*";
            this.dlgChargerDB.Title = "Veuillez indiquer l\'emplacement de la base de données";
            // 
            // btnAjouterClient
            // 
            this.btnAjouterClient.Location = new System.Drawing.Point(12, 169);
            this.btnAjouterClient.Name = "btnAjouterClient";
            this.btnAjouterClient.Size = new System.Drawing.Size(240, 33);
            this.btnAjouterClient.TabIndex = 6;
            this.btnAjouterClient.Text = "Nouveau client";
            this.btnAjouterClient.UseVisualStyleBackColor = true;
            this.btnAjouterClient.Click += new System.EventHandler(this.btnAjouterClient_Click);
            // 
            // btnAjouterEmprunt
            // 
            this.btnAjouterEmprunt.Location = new System.Drawing.Point(12, 208);
            this.btnAjouterEmprunt.Name = "btnAjouterEmprunt";
            this.btnAjouterEmprunt.Size = new System.Drawing.Size(240, 35);
            this.btnAjouterEmprunt.TabIndex = 7;
            this.btnAjouterEmprunt.Text = "Nouvel emprunt";
            this.btnAjouterEmprunt.UseVisualStyleBackColor = true;
            // 
            // btnAjouterDVD
            // 
            this.btnAjouterDVD.Location = new System.Drawing.Point(12, 249);
            this.btnAjouterDVD.Name = "btnAjouterDVD";
            this.btnAjouterDVD.Size = new System.Drawing.Size(240, 33);
            this.btnAjouterDVD.TabIndex = 8;
            this.btnAjouterDVD.Text = "Nouveau DVD";
            this.btnAjouterDVD.UseVisualStyleBackColor = true;
            // 
            // EcranAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 450);
            this.Controls.Add(this.btnAjouterDVD);
            this.Controls.Add(this.btnAjouterEmprunt);
            this.Controls.Add(this.btnAjouterClient);
            this.Controls.Add(this.pFiltreDVD);
            this.Controls.Add(this.pFiltreClients);
            this.Controls.Add(this.dgvActeurs);
            this.Controls.Add(this.dgvEmprunts);
            this.Controls.Add(this.dgvDVD);
            this.Controls.Add(this.dgvClients);
            this.Name = "EcranAccueil";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActeurs)).EndInit();
            this.pFiltreClients.ResumeLayout(false);
            this.pFiltreClients.PerformLayout();
            this.pFiltreDVD.ResumeLayout(false);
            this.pFiltreDVD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.DataGridView dgvDVD;
        private System.Windows.Forms.DataGridView dgvEmprunts;
        private System.Windows.Forms.DataGridView dgvActeurs;
        private System.Windows.Forms.Panel pFiltreClients;
        private System.Windows.Forms.Label lblFiltreClients;
        private System.Windows.Forms.RadioButton rbtnFCRetardCot;
        private System.Windows.Forms.RadioButton rbtnFCRetardRetour;
        private System.Windows.Forms.RadioButton rbtnFCRetards;
        private System.Windows.Forms.RadioButton rbtnFCTous;
        private System.Windows.Forms.Panel pFiltreDVD;
        private System.Windows.Forms.Label lblFiltreDVD;
        private System.Windows.Forms.RadioButton rbtnFDPret;
        private System.Windows.Forms.RadioButton rbtnFDDispos;
        private System.Windows.Forms.RadioButton rbtnFDTous;
        private System.Windows.Forms.Label lblAmende;
        private System.Windows.Forms.TextBox tbAmende;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgC_Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgC_Prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgC_Retard;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDVD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomDVD;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpruntDVD;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEmprunt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Emprunt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retour_Emprunt;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomActeur;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrenomActeur;
        private System.Windows.Forms.DataGridViewLinkColumn BioActeur;
        private System.Windows.Forms.OpenFileDialog dlgChargerDB;
        private System.Windows.Forms.Button btnAjouterClient;
        private System.Windows.Forms.Button btnAjouterEmprunt;
        private System.Windows.Forms.Button btnAjouterDVD;
    }
}

