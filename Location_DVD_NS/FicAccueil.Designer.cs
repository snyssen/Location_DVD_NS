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
            this.btnCotisation = new System.Windows.Forms.Button();
            this.rbtnFCEnOrdre = new System.Windows.Forms.RadioButton();
            this.lblAmende = new System.Windows.Forms.Label();
            this.tbAmende = new System.Windows.Forms.TextBox();
            this.lblFiltreClients = new System.Windows.Forms.Label();
            this.rbtnFCRetardCot = new System.Windows.Forms.RadioButton();
            this.rbtnFCRetardRetour = new System.Windows.Forms.RadioButton();
            this.rbtnFCRetards = new System.Windows.Forms.RadioButton();
            this.rbtnFCTous = new System.Windows.Forms.RadioButton();
            this.pFiltreDVD = new System.Windows.Forms.Panel();
            this.llblCopyright = new System.Windows.Forms.LinkLabel();
            this.lblFiltreDVD = new System.Windows.Forms.Label();
            this.rbtnFDPret = new System.Windows.Forms.RadioButton();
            this.rbtnFDDispos = new System.Windows.Forms.RadioButton();
            this.rbtnFDTous = new System.Windows.Forms.RadioButton();
            this.dlgChargerDB = new System.Windows.Forms.OpenFileDialog();
            this.btnAjouterClient = new System.Windows.Forms.Button();
            this.btnAjouterEmprunt = new System.Windows.Forms.Button();
            this.btnAjouterDVD = new System.Windows.Forms.Button();
            this.btnWipeDB = new System.Windows.Forms.Button();
            this.dgvDVDEmprunt = new System.Windows.Forms.DataGridView();
            this.btnRetourDVD = new System.Windows.Forms.Button();
            this.cbTousEmprunts = new System.Windows.Forms.CheckBox();
            this.dlgBordereau = new System.Windows.Forms.SaveFileDialog();
            this.btnAjouterActeur = new System.Windows.Forms.Button();
            this.cbTousActeurs = new System.Windows.Forms.CheckBox();
            this.lbldgvClients = new System.Windows.Forms.Label();
            this.lbldgvDVD = new System.Windows.Forms.Label();
            this.lbldgvActeurs = new System.Windows.Forms.Label();
            this.lbldgvDVDSelectEmprunt = new System.Windows.Forms.Label();
            this.lbldgvEmprunts = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTendances = new System.Windows.Forms.Button();
            this.btnNotifications = new Location_DVD_NS.NotificationButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActeurs)).BeginInit();
            this.pFiltreClients.SuspendLayout();
            this.pFiltreDVD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVDEmprunt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(176, 32);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(300, 202);
            this.dgvClients.TabIndex = 0;
            this.dgvClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellDoubleClick);
            this.dgvClients.SelectionChanged += new System.EventHandler(this.dgvClients_SelectionChanged);
            // 
            // dgvDVD
            // 
            this.dgvDVD.AllowUserToAddRows = false;
            this.dgvDVD.AllowUserToDeleteRows = false;
            this.dgvDVD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDVD.Location = new System.Drawing.Point(176, 341);
            this.dgvDVD.Name = "dgvDVD";
            this.dgvDVD.ReadOnly = true;
            this.dgvDVD.RowHeadersVisible = false;
            this.dgvDVD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDVD.Size = new System.Drawing.Size(300, 202);
            this.dgvDVD.TabIndex = 1;
            this.dgvDVD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDVD_CellDoubleClick);
            this.dgvDVD.SelectionChanged += new System.EventHandler(this.dgvDVD_SelectionChanged);
            // 
            // dgvEmprunts
            // 
            this.dgvEmprunts.AllowUserToAddRows = false;
            this.dgvEmprunts.AllowUserToDeleteRows = false;
            this.dgvEmprunts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprunts.Location = new System.Drawing.Point(482, 32);
            this.dgvEmprunts.Name = "dgvEmprunts";
            this.dgvEmprunts.ReadOnly = true;
            this.dgvEmprunts.RowHeadersVisible = false;
            this.dgvEmprunts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmprunts.Size = new System.Drawing.Size(300, 202);
            this.dgvEmprunts.TabIndex = 2;
            this.dgvEmprunts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmprunts_CellDoubleClick);
            this.dgvEmprunts.SelectionChanged += new System.EventHandler(this.dgvEmprunts_SelectionChanged);
            // 
            // dgvActeurs
            // 
            this.dgvActeurs.AllowUserToAddRows = false;
            this.dgvActeurs.AllowUserToDeleteRows = false;
            this.dgvActeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActeurs.Location = new System.Drawing.Point(788, 341);
            this.dgvActeurs.Name = "dgvActeurs";
            this.dgvActeurs.ReadOnly = true;
            this.dgvActeurs.RowHeadersVisible = false;
            this.dgvActeurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActeurs.Size = new System.Drawing.Size(300, 202);
            this.dgvActeurs.TabIndex = 3;
            this.dgvActeurs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActeurs_CellDoubleClick);
            this.dgvActeurs.SelectionChanged += new System.EventHandler(this.dgvActeurs_SelectionChanged);
            // 
            // pFiltreClients
            // 
            this.pFiltreClients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFiltreClients.Controls.Add(this.btnCotisation);
            this.pFiltreClients.Controls.Add(this.rbtnFCEnOrdre);
            this.pFiltreClients.Controls.Add(this.lblAmende);
            this.pFiltreClients.Controls.Add(this.tbAmende);
            this.pFiltreClients.Controls.Add(this.lblFiltreClients);
            this.pFiltreClients.Controls.Add(this.rbtnFCRetardCot);
            this.pFiltreClients.Controls.Add(this.rbtnFCRetardRetour);
            this.pFiltreClients.Controls.Add(this.rbtnFCRetards);
            this.pFiltreClients.Controls.Add(this.rbtnFCTous);
            this.pFiltreClients.Location = new System.Drawing.Point(12, 12);
            this.pFiltreClients.Name = "pFiltreClients";
            this.pFiltreClients.Size = new System.Drawing.Size(155, 230);
            this.pFiltreClients.TabIndex = 4;
            // 
            // btnCotisation
            // 
            this.btnCotisation.Location = new System.Drawing.Point(3, 182);
            this.btnCotisation.Name = "btnCotisation";
            this.btnCotisation.Size = new System.Drawing.Size(149, 40);
            this.btnCotisation.TabIndex = 13;
            this.btnCotisation.Text = "Payer la cotisation du/des client(s) sélectionné(s) ?";
            this.btnCotisation.UseVisualStyleBackColor = true;
            this.btnCotisation.Click += new System.EventHandler(this.btnCotisation_Click);
            // 
            // rbtnFCEnOrdre
            // 
            this.rbtnFCEnOrdre.AutoSize = true;
            this.rbtnFCEnOrdre.Location = new System.Drawing.Point(7, 43);
            this.rbtnFCEnOrdre.Name = "rbtnFCEnOrdre";
            this.rbtnFCEnOrdre.Size = new System.Drawing.Size(65, 17);
            this.rbtnFCEnOrdre.TabIndex = 7;
            this.rbtnFCEnOrdre.Tag = "1";
            this.rbtnFCEnOrdre.Text = "En ordre";
            this.rbtnFCEnOrdre.UseVisualStyleBackColor = true;
            this.rbtnFCEnOrdre.CheckedChanged += new System.EventHandler(this.FiltreClients_CheckedChanged);
            // 
            // lblAmende
            // 
            this.lblAmende.AutoSize = true;
            this.lblAmende.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmende.Location = new System.Drawing.Point(4, 136);
            this.lblAmende.Name = "lblAmende";
            this.lblAmende.Size = new System.Drawing.Size(105, 13);
            this.lblAmende.TabIndex = 6;
            this.lblAmende.Text = "Amende du client";
            // 
            // tbAmende
            // 
            this.tbAmende.Location = new System.Drawing.Point(7, 156);
            this.tbAmende.Name = "tbAmende";
            this.tbAmende.ReadOnly = true;
            this.tbAmende.Size = new System.Drawing.Size(143, 20);
            this.tbAmende.TabIndex = 5;
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
            this.rbtnFCRetardCot.Location = new System.Drawing.Point(7, 112);
            this.rbtnFCRetardCot.Name = "rbtnFCRetardCot";
            this.rbtnFCRetardCot.Size = new System.Drawing.Size(143, 17);
            this.rbtnFCRetardCot.TabIndex = 3;
            this.rbtnFCRetardCot.Tag = "4";
            this.rbtnFCRetardCot.Text = "Retardataires (Cotisation)";
            this.rbtnFCRetardCot.UseVisualStyleBackColor = true;
            this.rbtnFCRetardCot.CheckedChanged += new System.EventHandler(this.FiltreClients_CheckedChanged);
            // 
            // rbtnFCRetardRetour
            // 
            this.rbtnFCRetardRetour.AutoSize = true;
            this.rbtnFCRetardRetour.Location = new System.Drawing.Point(7, 89);
            this.rbtnFCRetardRetour.Name = "rbtnFCRetardRetour";
            this.rbtnFCRetardRetour.Size = new System.Drawing.Size(124, 17);
            this.rbtnFCRetardRetour.TabIndex = 2;
            this.rbtnFCRetardRetour.Tag = "3";
            this.rbtnFCRetardRetour.Text = "Retardataires (retour)";
            this.rbtnFCRetardRetour.UseVisualStyleBackColor = true;
            this.rbtnFCRetardRetour.CheckedChanged += new System.EventHandler(this.FiltreClients_CheckedChanged);
            // 
            // rbtnFCRetards
            // 
            this.rbtnFCRetards.AutoSize = true;
            this.rbtnFCRetards.Location = new System.Drawing.Point(7, 66);
            this.rbtnFCRetards.Name = "rbtnFCRetards";
            this.rbtnFCRetards.Size = new System.Drawing.Size(117, 17);
            this.rbtnFCRetards.TabIndex = 1;
            this.rbtnFCRetards.Tag = "2";
            this.rbtnFCRetards.Text = "Retardataires (tous)";
            this.rbtnFCRetards.UseVisualStyleBackColor = true;
            this.rbtnFCRetards.CheckedChanged += new System.EventHandler(this.FiltreClients_CheckedChanged);
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
            this.rbtnFCTous.Tag = "0";
            this.rbtnFCTous.Text = "Tous";
            this.rbtnFCTous.UseVisualStyleBackColor = true;
            this.rbtnFCTous.CheckedChanged += new System.EventHandler(this.FiltreClients_CheckedChanged);
            this.rbtnFCTous.EnabledChanged += new System.EventHandler(this.rbtnFCTous_EnabledChanged);
            // 
            // pFiltreDVD
            // 
            this.pFiltreDVD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFiltreDVD.Controls.Add(this.llblCopyright);
            this.pFiltreDVD.Controls.Add(this.lblFiltreDVD);
            this.pFiltreDVD.Controls.Add(this.rbtnFDPret);
            this.pFiltreDVD.Controls.Add(this.rbtnFDDispos);
            this.pFiltreDVD.Controls.Add(this.rbtnFDTous);
            this.pFiltreDVD.Location = new System.Drawing.Point(12, 321);
            this.pFiltreDVD.Name = "pFiltreDVD";
            this.pFiltreDVD.Size = new System.Drawing.Size(155, 222);
            this.pFiltreDVD.TabIndex = 5;
            // 
            // llblCopyright
            // 
            this.llblCopyright.AutoSize = true;
            this.llblCopyright.Location = new System.Drawing.Point(0, 205);
            this.llblCopyright.Name = "llblCopyright";
            this.llblCopyright.Size = new System.Drawing.Size(86, 13);
            this.llblCopyright.TabIndex = 23;
            this.llblCopyright.TabStop = true;
            this.llblCopyright.Text = "© Simon Nyssen";
            this.llblCopyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCopyright_LinkClicked);
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
            this.rbtnFDPret.Tag = "2";
            this.rbtnFDPret.Text = "En prêt";
            this.rbtnFDPret.UseVisualStyleBackColor = true;
            this.rbtnFDPret.CheckedChanged += new System.EventHandler(this.FiltreDVD_CheckedChanged);
            // 
            // rbtnFDDispos
            // 
            this.rbtnFDDispos.AutoSize = true;
            this.rbtnFDDispos.Location = new System.Drawing.Point(7, 43);
            this.rbtnFDDispos.Name = "rbtnFDDispos";
            this.rbtnFDDispos.Size = new System.Drawing.Size(79, 17);
            this.rbtnFDDispos.TabIndex = 1;
            this.rbtnFDDispos.Tag = "1";
            this.rbtnFDDispos.Text = "Disponibles";
            this.rbtnFDDispos.UseVisualStyleBackColor = true;
            this.rbtnFDDispos.CheckedChanged += new System.EventHandler(this.FiltreDVD_CheckedChanged);
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
            this.rbtnFDTous.Tag = "0";
            this.rbtnFDTous.Text = "Tous";
            this.rbtnFDTous.UseVisualStyleBackColor = true;
            this.rbtnFDTous.CheckedChanged += new System.EventHandler(this.FiltreDVD_CheckedChanged);
            this.rbtnFDTous.EnabledChanged += new System.EventHandler(this.rbtnFDTous_EnabledChanged);
            // 
            // dlgChargerDB
            // 
            this.dlgChargerDB.FileName = "Location_DVD.mdf";
            this.dlgChargerDB.Filter = "Fichier de base de données|*.mdf|Tous les fichiers|*.*";
            this.dlgChargerDB.Title = "Veuillez indiquer l\'emplacement de la base de données";
            // 
            // btnAjouterClient
            // 
            this.btnAjouterClient.Location = new System.Drawing.Point(482, 341);
            this.btnAjouterClient.Name = "btnAjouterClient";
            this.btnAjouterClient.Size = new System.Drawing.Size(300, 33);
            this.btnAjouterClient.TabIndex = 6;
            this.btnAjouterClient.Text = "Nouveau client";
            this.btnAjouterClient.UseVisualStyleBackColor = true;
            this.btnAjouterClient.Click += new System.EventHandler(this.btnAjouterClient_Click);
            // 
            // btnAjouterEmprunt
            // 
            this.btnAjouterEmprunt.Location = new System.Drawing.Point(482, 380);
            this.btnAjouterEmprunt.Name = "btnAjouterEmprunt";
            this.btnAjouterEmprunt.Size = new System.Drawing.Size(300, 35);
            this.btnAjouterEmprunt.TabIndex = 7;
            this.btnAjouterEmprunt.Text = "Nouvel emprunt";
            this.btnAjouterEmprunt.UseVisualStyleBackColor = true;
            this.btnAjouterEmprunt.Click += new System.EventHandler(this.btnAjouterEmprunt_Click);
            // 
            // btnAjouterDVD
            // 
            this.btnAjouterDVD.Location = new System.Drawing.Point(482, 471);
            this.btnAjouterDVD.Name = "btnAjouterDVD";
            this.btnAjouterDVD.Size = new System.Drawing.Size(300, 33);
            this.btnAjouterDVD.TabIndex = 8;
            this.btnAjouterDVD.Text = "Nouveau DVD";
            this.btnAjouterDVD.UseVisualStyleBackColor = true;
            this.btnAjouterDVD.Click += new System.EventHandler(this.btnAjouterDVD_Click);
            // 
            // btnWipeDB
            // 
            this.btnWipeDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWipeDB.ForeColor = System.Drawing.Color.Red;
            this.btnWipeDB.Location = new System.Drawing.Point(12, 256);
            this.btnWipeDB.Name = "btnWipeDB";
            this.btnWipeDB.Size = new System.Drawing.Size(98, 42);
            this.btnWipeDB.TabIndex = 9;
            this.btnWipeDB.Text = "Vider la base de données ?";
            this.btnWipeDB.UseVisualStyleBackColor = true;
            this.btnWipeDB.Click += new System.EventHandler(this.btnWipeDB_Click);
            // 
            // dgvDVDEmprunt
            // 
            this.dgvDVDEmprunt.AllowUserToAddRows = false;
            this.dgvDVDEmprunt.AllowUserToDeleteRows = false;
            this.dgvDVDEmprunt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDVDEmprunt.Location = new System.Drawing.Point(788, 32);
            this.dgvDVDEmprunt.Name = "dgvDVDEmprunt";
            this.dgvDVDEmprunt.ReadOnly = true;
            this.dgvDVDEmprunt.RowHeadersVisible = false;
            this.dgvDVDEmprunt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDVDEmprunt.Size = new System.Drawing.Size(300, 202);
            this.dgvDVDEmprunt.TabIndex = 10;
            this.dgvDVDEmprunt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDVDEmprunt_CellDoubleClick);
            // 
            // btnRetourDVD
            // 
            this.btnRetourDVD.Location = new System.Drawing.Point(788, 240);
            this.btnRetourDVD.Name = "btnRetourDVD";
            this.btnRetourDVD.Size = new System.Drawing.Size(300, 33);
            this.btnRetourDVD.TabIndex = 11;
            this.btnRetourDVD.Text = "Retourner le/les DVD sélectionné(s) ?";
            this.btnRetourDVD.UseVisualStyleBackColor = true;
            this.btnRetourDVD.Click += new System.EventHandler(this.btnRetourDVD_Click);
            // 
            // cbTousEmprunts
            // 
            this.cbTousEmprunts.AutoSize = true;
            this.cbTousEmprunts.Location = new System.Drawing.Point(635, 14);
            this.cbTousEmprunts.Name = "cbTousEmprunts";
            this.cbTousEmprunts.Size = new System.Drawing.Size(147, 17);
            this.cbTousEmprunts.TabIndex = 12;
            this.cbTousEmprunts.Text = "Afficher tous les emprunts";
            this.cbTousEmprunts.UseVisualStyleBackColor = true;
            this.cbTousEmprunts.CheckedChanged += new System.EventHandler(this.cbTousEmprunts_CheckedChanged);
            // 
            // btnAjouterActeur
            // 
            this.btnAjouterActeur.Location = new System.Drawing.Point(482, 510);
            this.btnAjouterActeur.Name = "btnAjouterActeur";
            this.btnAjouterActeur.Size = new System.Drawing.Size(300, 33);
            this.btnAjouterActeur.TabIndex = 13;
            this.btnAjouterActeur.Text = "Nouvel acteur";
            this.btnAjouterActeur.UseVisualStyleBackColor = true;
            this.btnAjouterActeur.Click += new System.EventHandler(this.btnAjouterActeur_Click);
            // 
            // cbTousActeurs
            // 
            this.cbTousActeurs.AutoSize = true;
            this.cbTousActeurs.Location = new System.Drawing.Point(949, 324);
            this.cbTousActeurs.Name = "cbTousActeurs";
            this.cbTousActeurs.Size = new System.Drawing.Size(139, 17);
            this.cbTousActeurs.TabIndex = 15;
            this.cbTousActeurs.Text = "Afficher tous les acteurs";
            this.cbTousActeurs.UseVisualStyleBackColor = true;
            this.cbTousActeurs.CheckedChanged += new System.EventHandler(this.cbTousActeurs_CheckedChanged);
            // 
            // lbldgvClients
            // 
            this.lbldgvClients.AutoSize = true;
            this.lbldgvClients.Location = new System.Drawing.Point(173, 16);
            this.lbldgvClients.Name = "lbldgvClients";
            this.lbldgvClients.Size = new System.Drawing.Size(38, 13);
            this.lbldgvClients.TabIndex = 16;
            this.lbldgvClients.Text = "Clients";
            // 
            // lbldgvDVD
            // 
            this.lbldgvDVD.AutoSize = true;
            this.lbldgvDVD.Location = new System.Drawing.Point(173, 325);
            this.lbldgvDVD.Name = "lbldgvDVD";
            this.lbldgvDVD.Size = new System.Drawing.Size(30, 13);
            this.lbldgvDVD.TabIndex = 17;
            this.lbldgvDVD.Text = "DVD";
            // 
            // lbldgvActeurs
            // 
            this.lbldgvActeurs.AutoSize = true;
            this.lbldgvActeurs.Location = new System.Drawing.Point(788, 325);
            this.lbldgvActeurs.Name = "lbldgvActeurs";
            this.lbldgvActeurs.Size = new System.Drawing.Size(43, 13);
            this.lbldgvActeurs.TabIndex = 18;
            this.lbldgvActeurs.Text = "Acteurs";
            // 
            // lbldgvDVDSelectEmprunt
            // 
            this.lbldgvDVDSelectEmprunt.AutoSize = true;
            this.lbldgvDVDSelectEmprunt.Location = new System.Drawing.Point(788, 16);
            this.lbldgvDVDSelectEmprunt.Name = "lbldgvDVDSelectEmprunt";
            this.lbldgvDVDSelectEmprunt.Size = new System.Drawing.Size(147, 13);
            this.lbldgvDVDSelectEmprunt.TabIndex = 19;
            this.lbldgvDVDSelectEmprunt.Text = "DVD de l\'emprunt sélectionné";
            // 
            // lbldgvEmprunts
            // 
            this.lbldgvEmprunts.AutoSize = true;
            this.lbldgvEmprunts.Location = new System.Drawing.Point(479, 15);
            this.lbldgvEmprunts.Name = "lbldgvEmprunts";
            this.lbldgvEmprunts.Size = new System.Drawing.Size(51, 13);
            this.lbldgvEmprunts.TabIndex = 20;
            this.lbldgvEmprunts.Text = "Emprunts";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Location_DVD_NS.Properties.Resources.Refresh_32x32;
            this.btnRefresh.Location = new System.Drawing.Point(116, 261);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Location_DVD_NS.Properties.Resources.LogoDVD;
            this.pictureBox1.Location = new System.Drawing.Point(482, 240);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnTendances
            // 
            this.btnTendances.Location = new System.Drawing.Point(788, 285);
            this.btnTendances.Name = "btnTendances";
            this.btnTendances.Size = new System.Drawing.Size(300, 33);
            this.btnTendances.TabIndex = 23;
            this.btnTendances.Text = "Tendances";
            this.btnTendances.UseVisualStyleBackColor = true;
            this.btnTendances.Click += new System.EventHandler(this.btnTendances_Click);
            // 
            // btnNotifications
            // 
            this.btnNotifications.ExteriorColor = System.Drawing.Color.DarkRed;
            this.btnNotifications.InteriorColor = System.Drawing.Color.OrangeRed;
            this.btnNotifications.Location = new System.Drawing.Point(482, 421);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.NotificationEnabled = true;
            this.btnNotifications.NotificationNbr = 0;
            this.btnNotifications.NumberColor = System.Drawing.Color.White;
            this.btnNotifications.Size = new System.Drawing.Size(300, 44);
            this.btnNotifications.TabIndex = 14;
            this.btnNotifications.Text = "Notifications";
            this.btnNotifications.UseVisualStyleBackColor = true;
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // EcranAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 555);
            this.Controls.Add(this.btnTendances);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbldgvEmprunts);
            this.Controls.Add(this.lbldgvDVDSelectEmprunt);
            this.Controls.Add(this.lbldgvActeurs);
            this.Controls.Add(this.lbldgvDVD);
            this.Controls.Add(this.lbldgvClients);
            this.Controls.Add(this.cbTousActeurs);
            this.Controls.Add(this.btnNotifications);
            this.Controls.Add(this.btnAjouterActeur);
            this.Controls.Add(this.cbTousEmprunts);
            this.Controls.Add(this.btnRetourDVD);
            this.Controls.Add(this.dgvDVDEmprunt);
            this.Controls.Add(this.btnWipeDB);
            this.Controls.Add(this.btnAjouterDVD);
            this.Controls.Add(this.btnAjouterEmprunt);
            this.Controls.Add(this.btnAjouterClient);
            this.Controls.Add(this.pFiltreDVD);
            this.Controls.Add(this.pFiltreClients);
            this.Controls.Add(this.dgvActeurs);
            this.Controls.Add(this.dgvEmprunts);
            this.Controls.Add(this.dgvDVD);
            this.Controls.Add(this.dgvClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EcranAccueil";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tableau de bord";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActeurs)).EndInit();
            this.pFiltreClients.ResumeLayout(false);
            this.pFiltreClients.PerformLayout();
            this.pFiltreDVD.ResumeLayout(false);
            this.pFiltreDVD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVDEmprunt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.OpenFileDialog dlgChargerDB;
        private System.Windows.Forms.Button btnAjouterClient;
        private System.Windows.Forms.Button btnAjouterEmprunt;
        private System.Windows.Forms.Button btnAjouterDVD;
        private System.Windows.Forms.Button btnWipeDB;
        private System.Windows.Forms.DataGridView dgvDVDEmprunt;
        private System.Windows.Forms.Button btnRetourDVD;
        private System.Windows.Forms.RadioButton rbtnFCEnOrdre;
        private System.Windows.Forms.CheckBox cbTousEmprunts;
        private System.Windows.Forms.SaveFileDialog dlgBordereau;
        private System.Windows.Forms.Button btnCotisation;
        private System.Windows.Forms.Button btnAjouterActeur;
        private NotificationButton btnNotifications;
        private System.Windows.Forms.CheckBox cbTousActeurs;
        private System.Windows.Forms.Label lbldgvClients;
        private System.Windows.Forms.Label lbldgvDVD;
        private System.Windows.Forms.Label lbldgvActeurs;
        private System.Windows.Forms.Label lbldgvDVDSelectEmprunt;
        private System.Windows.Forms.Label lbldgvEmprunts;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.LinkLabel llblCopyright;
        private System.Windows.Forms.Button btnTendances;
    }
}

