namespace Location_DVD_NS
{
    partial class EcranAjouterDVD
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
            this.lblNom = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblEmpruntMax = new System.Windows.Forms.Label();
            this.nudEmpruntMax = new System.Windows.Forms.NumericUpDown();
            this.nudAmende_p_jour = new System.Windows.Forms.NumericUpDown();
            this.lblAmende_p_Jour = new System.Windows.Forms.Label();
            this.tbSynopsis = new System.Windows.Forms.TextBox();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.lblListeActeurs = new System.Windows.Forms.Label();
            this.btnAjouterActeur = new System.Windows.Forms.Button();
            this.btnConfirmer = new System.Windows.Forms.Button();
            this.lbListeActeurs = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmpruntMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmende_p_jour)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(13, 13);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(62, 13);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom du film";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(12, 29);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(210, 20);
            this.tbNom.TabIndex = 1;
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(11, 68);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(211, 20);
            this.tbGenre.TabIndex = 3;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(12, 52);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 2;
            this.lblGenre.Text = "Genre";
            // 
            // lblEmpruntMax
            // 
            this.lblEmpruntMax.AutoSize = true;
            this.lblEmpruntMax.Location = new System.Drawing.Point(13, 91);
            this.lblEmpruntMax.Name = "lblEmpruntMax";
            this.lblEmpruntMax.Size = new System.Drawing.Size(172, 13);
            this.lblEmpruntMax.TabIndex = 4;
            this.lblEmpruntMax.Text = "Durée d\'emprunt maximum (en jour)";
            // 
            // nudEmpruntMax
            // 
            this.nudEmpruntMax.Location = new System.Drawing.Point(11, 108);
            this.nudEmpruntMax.Maximum = new decimal(new int[] {
            62,
            0,
            0,
            0});
            this.nudEmpruntMax.Name = "nudEmpruntMax";
            this.nudEmpruntMax.Size = new System.Drawing.Size(211, 20);
            this.nudEmpruntMax.TabIndex = 5;
            // 
            // nudAmende_p_jour
            // 
            this.nudAmende_p_jour.DecimalPlaces = 1;
            this.nudAmende_p_jour.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudAmende_p_jour.Location = new System.Drawing.Point(11, 148);
            this.nudAmende_p_jour.Name = "nudAmende_p_jour";
            this.nudAmende_p_jour.Size = new System.Drawing.Size(211, 20);
            this.nudAmende_p_jour.TabIndex = 7;
            // 
            // lblAmende_p_Jour
            // 
            this.lblAmende_p_Jour.AutoSize = true;
            this.lblAmende_p_Jour.Location = new System.Drawing.Point(13, 131);
            this.lblAmende_p_Jour.Name = "lblAmende_p_Jour";
            this.lblAmende_p_Jour.Size = new System.Drawing.Size(129, 13);
            this.lblAmende_p_Jour.TabIndex = 6;
            this.lblAmende_p_Jour.Text = "Amende par jour de retard";
            // 
            // tbSynopsis
            // 
            this.tbSynopsis.Location = new System.Drawing.Point(12, 187);
            this.tbSynopsis.Name = "tbSynopsis";
            this.tbSynopsis.Size = new System.Drawing.Size(210, 20);
            this.tbSynopsis.TabIndex = 9;
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.AutoSize = true;
            this.lblSynopsis.Location = new System.Drawing.Point(13, 171);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(124, 13);
            this.lblSynopsis.TabIndex = 8;
            this.lblSynopsis.Text = "Synopsis (indiquer un url)";
            // 
            // lblListeActeurs
            // 
            this.lblListeActeurs.AutoSize = true;
            this.lblListeActeurs.Location = new System.Drawing.Point(11, 214);
            this.lblListeActeurs.Name = "lblListeActeurs";
            this.lblListeActeurs.Size = new System.Drawing.Size(145, 13);
            this.lblListeActeurs.TabIndex = 11;
            this.lblListeActeurs.Text = "Acteurs principaux (sélection)";
            // 
            // btnAjouterActeur
            // 
            this.btnAjouterActeur.Location = new System.Drawing.Point(11, 381);
            this.btnAjouterActeur.Name = "btnAjouterActeur";
            this.btnAjouterActeur.Size = new System.Drawing.Size(211, 23);
            this.btnAjouterActeur.TabIndex = 12;
            this.btnAjouterActeur.Text = "Nouvel acteur";
            this.btnAjouterActeur.UseVisualStyleBackColor = true;
            this.btnAjouterActeur.Click += new System.EventHandler(this.btnAjouterActeur_Click);
            // 
            // btnConfirmer
            // 
            this.btnConfirmer.Location = new System.Drawing.Point(11, 411);
            this.btnConfirmer.Name = "btnConfirmer";
            this.btnConfirmer.Size = new System.Drawing.Size(211, 23);
            this.btnConfirmer.TabIndex = 13;
            this.btnConfirmer.Text = "Confirmer";
            this.btnConfirmer.UseVisualStyleBackColor = true;
            this.btnConfirmer.Click += new System.EventHandler(this.btnConfirmer_Click);
            // 
            // lbListeActeurs
            // 
            this.lbListeActeurs.FormattingEnabled = true;
            this.lbListeActeurs.Location = new System.Drawing.Point(11, 231);
            this.lbListeActeurs.Name = "lbListeActeurs";
            this.lbListeActeurs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbListeActeurs.Size = new System.Drawing.Size(211, 147);
            this.lbListeActeurs.TabIndex = 14;
            // 
            // EcranAjouterDVD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 446);
            this.Controls.Add(this.lbListeActeurs);
            this.Controls.Add(this.btnConfirmer);
            this.Controls.Add(this.btnAjouterActeur);
            this.Controls.Add(this.lblListeActeurs);
            this.Controls.Add(this.tbSynopsis);
            this.Controls.Add(this.lblSynopsis);
            this.Controls.Add(this.nudAmende_p_jour);
            this.Controls.Add(this.lblAmende_p_Jour);
            this.Controls.Add(this.nudEmpruntMax);
            this.Controls.Add(this.lblEmpruntMax);
            this.Controls.Add(this.tbGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lblNom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranAjouterDVD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouveau DVD";
            ((System.ComponentModel.ISupportInitialize)(this.nudEmpruntMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmende_p_jour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblEmpruntMax;
        private System.Windows.Forms.NumericUpDown nudEmpruntMax;
        private System.Windows.Forms.NumericUpDown nudAmende_p_jour;
        private System.Windows.Forms.Label lblAmende_p_Jour;
        private System.Windows.Forms.TextBox tbSynopsis;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.Label lblListeActeurs;
        private System.Windows.Forms.Button btnAjouterActeur;
        private System.Windows.Forms.Button btnConfirmer;
        private System.Windows.Forms.ListBox lbListeActeurs;
    }
}