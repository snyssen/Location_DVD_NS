namespace Location_DVD_NS
{
    partial class EcranDetailsActeur
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
            this.btnModiferBiographie = new System.Windows.Forms.Button();
            this.tbPrenomActeur = new System.Windows.Forms.TextBox();
            this.tbNomActeur = new System.Windows.Forms.TextBox();
            this.llblBiographie = new System.Windows.Forms.LinkLabel();
            this.lblPrenomActeur = new System.Windows.Forms.Label();
            this.lblNomActeur = new System.Windows.Forms.Label();
            this.lbListeFilms = new System.Windows.Forms.ListBox();
            this.lblListeFilms = new System.Windows.Forms.Label();
            this.btnConf_Quitter = new System.Windows.Forms.Button();
            this.btnModif_Annul = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModiferBiographie
            // 
            this.btnModiferBiographie.Enabled = false;
            this.btnModiferBiographie.Location = new System.Drawing.Point(76, 90);
            this.btnModiferBiographie.Name = "btnModiferBiographie";
            this.btnModiferBiographie.Size = new System.Drawing.Size(54, 21);
            this.btnModiferBiographie.TabIndex = 19;
            this.btnModiferBiographie.Text = "Modifier";
            this.btnModiferBiographie.UseVisualStyleBackColor = true;
            this.btnModiferBiographie.Click += new System.EventHandler(this.btnModiferBiographie_Click);
            // 
            // tbPrenomActeur
            // 
            this.tbPrenomActeur.Enabled = false;
            this.tbPrenomActeur.Location = new System.Drawing.Point(10, 64);
            this.tbPrenomActeur.Name = "tbPrenomActeur";
            this.tbPrenomActeur.Size = new System.Drawing.Size(210, 20);
            this.tbPrenomActeur.TabIndex = 18;
            // 
            // tbNomActeur
            // 
            this.tbNomActeur.Enabled = false;
            this.tbNomActeur.Location = new System.Drawing.Point(10, 25);
            this.tbNomActeur.Name = "tbNomActeur";
            this.tbNomActeur.Size = new System.Drawing.Size(210, 20);
            this.tbNomActeur.TabIndex = 17;
            // 
            // llblBiographie
            // 
            this.llblBiographie.AutoSize = true;
            this.llblBiographie.Location = new System.Drawing.Point(13, 94);
            this.llblBiographie.Name = "llblBiographie";
            this.llblBiographie.Size = new System.Drawing.Size(57, 13);
            this.llblBiographie.TabIndex = 16;
            this.llblBiographie.TabStop = true;
            this.llblBiographie.Text = "Biographie";
            this.llblBiographie.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBiographie_LinkClicked);
            // 
            // lblPrenomActeur
            // 
            this.lblPrenomActeur.AutoSize = true;
            this.lblPrenomActeur.Location = new System.Drawing.Point(11, 48);
            this.lblPrenomActeur.Name = "lblPrenomActeur";
            this.lblPrenomActeur.Size = new System.Drawing.Size(43, 13);
            this.lblPrenomActeur.TabIndex = 15;
            this.lblPrenomActeur.Text = "Prénom";
            // 
            // lblNomActeur
            // 
            this.lblNomActeur.AutoSize = true;
            this.lblNomActeur.Location = new System.Drawing.Point(12, 9);
            this.lblNomActeur.Name = "lblNomActeur";
            this.lblNomActeur.Size = new System.Drawing.Size(29, 13);
            this.lblNomActeur.TabIndex = 14;
            this.lblNomActeur.Text = "Nom";
            // 
            // lbListeFilms
            // 
            this.lbListeFilms.Enabled = false;
            this.lbListeFilms.FormattingEnabled = true;
            this.lbListeFilms.Location = new System.Drawing.Point(10, 140);
            this.lbListeFilms.Name = "lbListeFilms";
            this.lbListeFilms.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbListeFilms.Size = new System.Drawing.Size(210, 108);
            this.lbListeFilms.TabIndex = 21;
            // 
            // lblListeFilms
            // 
            this.lblListeFilms.AutoSize = true;
            this.lblListeFilms.Location = new System.Drawing.Point(11, 124);
            this.lblListeFilms.Name = "lblListeFilms";
            this.lblListeFilms.Size = new System.Drawing.Size(63, 13);
            this.lblListeFilms.TabIndex = 20;
            this.lblListeFilms.Text = "A joué dans";
            // 
            // btnConf_Quitter
            // 
            this.btnConf_Quitter.Location = new System.Drawing.Point(10, 292);
            this.btnConf_Quitter.Name = "btnConf_Quitter";
            this.btnConf_Quitter.Size = new System.Drawing.Size(209, 32);
            this.btnConf_Quitter.TabIndex = 23;
            this.btnConf_Quitter.Text = "Quitter";
            this.btnConf_Quitter.UseVisualStyleBackColor = true;
            this.btnConf_Quitter.Click += new System.EventHandler(this.btnConf_Quitter_Click);
            // 
            // btnModif_Annul
            // 
            this.btnModif_Annul.Location = new System.Drawing.Point(10, 254);
            this.btnModif_Annul.Name = "btnModif_Annul";
            this.btnModif_Annul.Size = new System.Drawing.Size(209, 32);
            this.btnModif_Annul.TabIndex = 22;
            this.btnModif_Annul.Text = "Modifier informations";
            this.btnModif_Annul.UseVisualStyleBackColor = true;
            this.btnModif_Annul.Click += new System.EventHandler(this.btnModif_Annul_Click);
            // 
            // EcranDetailsActeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 335);
            this.Controls.Add(this.btnConf_Quitter);
            this.Controls.Add(this.btnModif_Annul);
            this.Controls.Add(this.lbListeFilms);
            this.Controls.Add(this.lblListeFilms);
            this.Controls.Add(this.btnModiferBiographie);
            this.Controls.Add(this.tbPrenomActeur);
            this.Controls.Add(this.tbNomActeur);
            this.Controls.Add(this.llblBiographie);
            this.Controls.Add(this.lblPrenomActeur);
            this.Controls.Add(this.lblNomActeur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranDetailsActeur";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModiferBiographie;
        private System.Windows.Forms.TextBox tbPrenomActeur;
        private System.Windows.Forms.TextBox tbNomActeur;
        private System.Windows.Forms.LinkLabel llblBiographie;
        private System.Windows.Forms.Label lblPrenomActeur;
        private System.Windows.Forms.Label lblNomActeur;
        private System.Windows.Forms.ListBox lbListeFilms;
        private System.Windows.Forms.Label lblListeFilms;
        private System.Windows.Forms.Button btnConf_Quitter;
        private System.Windows.Forms.Button btnModif_Annul;
    }
}