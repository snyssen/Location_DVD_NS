﻿namespace Location_DVD_NS
{
    partial class EcranDetailsClient
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
            this.tbPrenom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.btnConf_Quitter = new System.Windows.Forms.Button();
            this.btnModif_Annul = new System.Windows.Forms.Button();
            this.btnCotisation = new System.Windows.Forms.Button();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.llblMail = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tbPrenom
            // 
            this.tbPrenom.Enabled = false;
            this.tbPrenom.Location = new System.Drawing.Point(12, 64);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(210, 20);
            this.tbPrenom.TabIndex = 7;
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(12, 48);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(43, 13);
            this.lblPrenom.TabIndex = 6;
            this.lblPrenom.Text = "Prénom";
            // 
            // tbNom
            // 
            this.tbNom.Enabled = false;
            this.tbNom.Location = new System.Drawing.Point(12, 25);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(210, 20);
            this.tbNom.TabIndex = 5;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(12, 9);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 4;
            this.lblNom.Text = "Nom";
            // 
            // btnConf_Quitter
            // 
            this.btnConf_Quitter.Location = new System.Drawing.Point(12, 208);
            this.btnConf_Quitter.Name = "btnConf_Quitter";
            this.btnConf_Quitter.Size = new System.Drawing.Size(210, 32);
            this.btnConf_Quitter.TabIndex = 19;
            this.btnConf_Quitter.Text = "Quitter";
            this.btnConf_Quitter.UseVisualStyleBackColor = true;
            this.btnConf_Quitter.Click += new System.EventHandler(this.btnConf_Quitter_Click);
            // 
            // btnModif_Annul
            // 
            this.btnModif_Annul.Location = new System.Drawing.Point(12, 170);
            this.btnModif_Annul.Name = "btnModif_Annul";
            this.btnModif_Annul.Size = new System.Drawing.Size(210, 32);
            this.btnModif_Annul.TabIndex = 18;
            this.btnModif_Annul.Text = "Modifier informations";
            this.btnModif_Annul.UseVisualStyleBackColor = true;
            this.btnModif_Annul.Click += new System.EventHandler(this.btnModif_Annul_Click);
            // 
            // btnCotisation
            // 
            this.btnCotisation.Location = new System.Drawing.Point(12, 132);
            this.btnCotisation.Name = "btnCotisation";
            this.btnCotisation.Size = new System.Drawing.Size(210, 32);
            this.btnCotisation.TabIndex = 20;
            this.btnCotisation.Text = "Payer la cotisation du client";
            this.btnCotisation.UseVisualStyleBackColor = true;
            this.btnCotisation.Click += new System.EventHandler(this.btnCotisation_Click);
            // 
            // tbMail
            // 
            this.tbMail.Enabled = false;
            this.tbMail.Location = new System.Drawing.Point(12, 103);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(210, 20);
            this.tbMail.TabIndex = 22;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(12, 87);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(34, 13);
            this.lblMail.TabIndex = 21;
            this.lblMail.Text = "e-mail";
            // 
            // llblMail
            // 
            this.llblMail.AutoSize = true;
            this.llblMail.Location = new System.Drawing.Point(53, 87);
            this.llblMail.Name = "llblMail";
            this.llblMail.Size = new System.Drawing.Size(82, 13);
            this.llblMail.TabIndex = 23;
            this.llblMail.TabStop = true;
            this.llblMail.Text = "Envoyer un mail";
            this.llblMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblMail_LinkClicked);
            // 
            // EcranDetailsClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 252);
            this.Controls.Add(this.llblMail);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.btnCotisation);
            this.Controls.Add(this.btnConf_Quitter);
            this.Controls.Add(this.btnModif_Annul);
            this.Controls.Add(this.tbPrenom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lblNom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranDetailsClient";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPrenom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Button btnConf_Quitter;
        private System.Windows.Forms.Button btnModif_Annul;
        private System.Windows.Forms.Button btnCotisation;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.LinkLabel llblMail;
    }
}