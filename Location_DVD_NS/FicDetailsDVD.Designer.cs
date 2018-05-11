namespace Location_DVD_NS
{
    partial class EcranDetailsDVD
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
            this.lblNomFilm = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.llblSynopsis = new System.Windows.Forms.LinkLabel();
            this.lblEmpruntMax = new System.Windows.Forms.Label();
            this.lblAmende_p_j = new System.Windows.Forms.Label();
            this.lblActeurs = new System.Windows.Forms.Label();
            this.lbActeurs = new System.Windows.Forms.ListBox();
            this.lblClient_actuel = new System.Windows.Forms.Label();
            this.tbClient_actuel = new System.Windows.Forms.TextBox();
            this.lblClients_precedents = new System.Windows.Forms.Label();
            this.lbClients_precedents = new System.Windows.Forms.ListBox();
            this.tbNomFilm = new System.Windows.Forms.TextBox();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.btnModiferSynopsis = new System.Windows.Forms.Button();
            this.nudEmpruntMax = new System.Windows.Forms.NumericUpDown();
            this.nudAmende_p_j = new System.Windows.Forms.NumericUpDown();
            this.btnModif_Annul = new System.Windows.Forms.Button();
            this.btnConf_Quitter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmpruntMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmende_p_j)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomFilm
            // 
            this.lblNomFilm.AutoSize = true;
            this.lblNomFilm.Location = new System.Drawing.Point(13, 13);
            this.lblNomFilm.Name = "lblNomFilm";
            this.lblNomFilm.Size = new System.Drawing.Size(62, 13);
            this.lblNomFilm.TabIndex = 0;
            this.lblNomFilm.Text = "Nom du film";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(12, 52);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(69, 13);
            this.lblGenre.TabIndex = 1;
            this.lblGenre.Text = "Genre du film";
            // 
            // llblSynopsis
            // 
            this.llblSynopsis.AutoSize = true;
            this.llblSynopsis.Location = new System.Drawing.Point(14, 98);
            this.llblSynopsis.Name = "llblSynopsis";
            this.llblSynopsis.Size = new System.Drawing.Size(49, 13);
            this.llblSynopsis.TabIndex = 2;
            this.llblSynopsis.TabStop = true;
            this.llblSynopsis.Text = "Synopsis";
            this.llblSynopsis.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSynopsis_LinkClicked);
            // 
            // lblEmpruntMax
            // 
            this.lblEmpruntMax.AutoSize = true;
            this.lblEmpruntMax.Location = new System.Drawing.Point(13, 118);
            this.lblEmpruntMax.Name = "lblEmpruntMax";
            this.lblEmpruntMax.Size = new System.Drawing.Size(131, 13);
            this.lblEmpruntMax.TabIndex = 3;
            this.lblEmpruntMax.Text = "Durée maximum d\'emprunt";
            // 
            // lblAmende_p_j
            // 
            this.lblAmende_p_j.AutoSize = true;
            this.lblAmende_p_j.Location = new System.Drawing.Point(13, 158);
            this.lblAmende_p_j.Name = "lblAmende_p_j";
            this.lblAmende_p_j.Size = new System.Drawing.Size(129, 13);
            this.lblAmende_p_j.TabIndex = 4;
            this.lblAmende_p_j.Text = "Amende par jour de retard";
            // 
            // lblActeurs
            // 
            this.lblActeurs.AutoSize = true;
            this.lblActeurs.Location = new System.Drawing.Point(12, 197);
            this.lblActeurs.Name = "lblActeurs";
            this.lblActeurs.Size = new System.Drawing.Size(94, 13);
            this.lblActeurs.TabIndex = 5;
            this.lblActeurs.Text = "Acteurs principaux";
            // 
            // lbActeurs
            // 
            this.lbActeurs.Enabled = false;
            this.lbActeurs.FormattingEnabled = true;
            this.lbActeurs.Location = new System.Drawing.Point(11, 213);
            this.lbActeurs.Name = "lbActeurs";
            this.lbActeurs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbActeurs.Size = new System.Drawing.Size(210, 108);
            this.lbActeurs.TabIndex = 6;
            // 
            // lblClient_actuel
            // 
            this.lblClient_actuel.AutoSize = true;
            this.lblClient_actuel.Location = new System.Drawing.Point(14, 327);
            this.lblClient_actuel.Name = "lblClient_actuel";
            this.lblClient_actuel.Size = new System.Drawing.Size(133, 13);
            this.lblClient_actuel.TabIndex = 7;
            this.lblClient_actuel.Text = "Emprunté actuellement par";
            // 
            // tbClient_actuel
            // 
            this.tbClient_actuel.Enabled = false;
            this.tbClient_actuel.Location = new System.Drawing.Point(12, 343);
            this.tbClient_actuel.Name = "tbClient_actuel";
            this.tbClient_actuel.Size = new System.Drawing.Size(210, 20);
            this.tbClient_actuel.TabIndex = 8;
            // 
            // lblClients_precedents
            // 
            this.lblClients_precedents.AutoSize = true;
            this.lblClients_precedents.Location = new System.Drawing.Point(14, 366);
            this.lblClients_precedents.Name = "lblClients_precedents";
            this.lblClients_precedents.Size = new System.Drawing.Size(143, 13);
            this.lblClients_precedents.TabIndex = 9;
            this.lblClients_precedents.Text = "Emprunté précédemment par";
            // 
            // lbClients_precedents
            // 
            this.lbClients_precedents.Enabled = false;
            this.lbClients_precedents.FormattingEnabled = true;
            this.lbClients_precedents.Location = new System.Drawing.Point(12, 382);
            this.lbClients_precedents.Name = "lbClients_precedents";
            this.lbClients_precedents.Size = new System.Drawing.Size(210, 108);
            this.lbClients_precedents.TabIndex = 10;
            // 
            // tbNomFilm
            // 
            this.tbNomFilm.Enabled = false;
            this.tbNomFilm.Location = new System.Drawing.Point(11, 29);
            this.tbNomFilm.Name = "tbNomFilm";
            this.tbNomFilm.Size = new System.Drawing.Size(210, 20);
            this.tbNomFilm.TabIndex = 11;
            // 
            // tbGenre
            // 
            this.tbGenre.Enabled = false;
            this.tbGenre.Location = new System.Drawing.Point(11, 68);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(210, 20);
            this.tbGenre.TabIndex = 12;
            // 
            // btnModiferSynopsis
            // 
            this.btnModiferSynopsis.Enabled = false;
            this.btnModiferSynopsis.Location = new System.Drawing.Point(69, 94);
            this.btnModiferSynopsis.Name = "btnModiferSynopsis";
            this.btnModiferSynopsis.Size = new System.Drawing.Size(54, 21);
            this.btnModiferSynopsis.TabIndex = 13;
            this.btnModiferSynopsis.Text = "Modifier";
            this.btnModiferSynopsis.UseVisualStyleBackColor = true;
            this.btnModiferSynopsis.Click += new System.EventHandler(this.btnModiferSynopsis_Click);
            // 
            // nudEmpruntMax
            // 
            this.nudEmpruntMax.Enabled = false;
            this.nudEmpruntMax.Location = new System.Drawing.Point(11, 135);
            this.nudEmpruntMax.Name = "nudEmpruntMax";
            this.nudEmpruntMax.Size = new System.Drawing.Size(210, 20);
            this.nudEmpruntMax.TabIndex = 14;
            // 
            // nudAmende_p_j
            // 
            this.nudAmende_p_j.DecimalPlaces = 1;
            this.nudAmende_p_j.Enabled = false;
            this.nudAmende_p_j.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudAmende_p_j.Location = new System.Drawing.Point(12, 174);
            this.nudAmende_p_j.Name = "nudAmende_p_j";
            this.nudAmende_p_j.Size = new System.Drawing.Size(210, 20);
            this.nudAmende_p_j.TabIndex = 15;
            // 
            // btnModif_Annul
            // 
            this.btnModif_Annul.Location = new System.Drawing.Point(12, 497);
            this.btnModif_Annul.Name = "btnModif_Annul";
            this.btnModif_Annul.Size = new System.Drawing.Size(209, 32);
            this.btnModif_Annul.TabIndex = 16;
            this.btnModif_Annul.Text = "Modifier informations";
            this.btnModif_Annul.UseVisualStyleBackColor = true;
            this.btnModif_Annul.Click += new System.EventHandler(this.btnModif_Annul_Click);
            // 
            // btnConf_Quitter
            // 
            this.btnConf_Quitter.Location = new System.Drawing.Point(12, 535);
            this.btnConf_Quitter.Name = "btnConf_Quitter";
            this.btnConf_Quitter.Size = new System.Drawing.Size(209, 32);
            this.btnConf_Quitter.TabIndex = 17;
            this.btnConf_Quitter.Text = "Quitter";
            this.btnConf_Quitter.UseVisualStyleBackColor = true;
            this.btnConf_Quitter.Click += new System.EventHandler(this.btnConf_Quitter_Click);
            // 
            // EcranDetailsDVD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 579);
            this.Controls.Add(this.btnConf_Quitter);
            this.Controls.Add(this.btnModif_Annul);
            this.Controls.Add(this.nudAmende_p_j);
            this.Controls.Add(this.nudEmpruntMax);
            this.Controls.Add(this.btnModiferSynopsis);
            this.Controls.Add(this.tbGenre);
            this.Controls.Add(this.tbNomFilm);
            this.Controls.Add(this.lbClients_precedents);
            this.Controls.Add(this.lblClients_precedents);
            this.Controls.Add(this.tbClient_actuel);
            this.Controls.Add(this.lblClient_actuel);
            this.Controls.Add(this.lbActeurs);
            this.Controls.Add(this.lblActeurs);
            this.Controls.Add(this.lblAmende_p_j);
            this.Controls.Add(this.lblEmpruntMax);
            this.Controls.Add(this.llblSynopsis);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblNomFilm);
            this.Name = "EcranDetailsDVD";
            ((System.ComponentModel.ISupportInitialize)(this.nudEmpruntMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmende_p_j)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomFilm;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.LinkLabel llblSynopsis;
        private System.Windows.Forms.Label lblEmpruntMax;
        private System.Windows.Forms.Label lblAmende_p_j;
        private System.Windows.Forms.Label lblActeurs;
        private System.Windows.Forms.ListBox lbActeurs;
        private System.Windows.Forms.Label lblClient_actuel;
        private System.Windows.Forms.TextBox tbClient_actuel;
        private System.Windows.Forms.Label lblClients_precedents;
        private System.Windows.Forms.ListBox lbClients_precedents;
        private System.Windows.Forms.TextBox tbNomFilm;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.Button btnModiferSynopsis;
        private System.Windows.Forms.NumericUpDown nudEmpruntMax;
        private System.Windows.Forms.NumericUpDown nudAmende_p_j;
        private System.Windows.Forms.Button btnModif_Annul;
        private System.Windows.Forms.Button btnConf_Quitter;
    }
}