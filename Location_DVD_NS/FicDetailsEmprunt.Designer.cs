namespace Location_DVD_NS
{
    partial class EcranDetailsEmprunt
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
            this.dgvDVD = new System.Windows.Forms.DataGridView();
            this.lblIDClient = new System.Windows.Forms.Label();
            this.lblNomClient = new System.Windows.Forms.Label();
            this.dtpDateEmprunt = new System.Windows.Forms.DateTimePicker();
            this.lblDateEmprunt = new System.Windows.Forms.Label();
            this.lblDVD = new System.Windows.Forms.Label();
            this.btnRetourDVD = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVD)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDVD
            // 
            this.dgvDVD.AllowUserToAddRows = false;
            this.dgvDVD.AllowUserToDeleteRows = false;
            this.dgvDVD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDVD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDVD.Location = new System.Drawing.Point(12, 110);
            this.dgvDVD.Name = "dgvDVD";
            this.dgvDVD.ReadOnly = true;
            this.dgvDVD.RowHeadersVisible = false;
            this.dgvDVD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDVD.Size = new System.Drawing.Size(207, 150);
            this.dgvDVD.TabIndex = 2;
            // 
            // lblIDClient
            // 
            this.lblIDClient.AutoSize = true;
            this.lblIDClient.Location = new System.Drawing.Point(12, 9);
            this.lblIDClient.Name = "lblIDClient";
            this.lblIDClient.Size = new System.Drawing.Size(46, 13);
            this.lblIDClient.TabIndex = 3;
            this.lblIDClient.Text = "Client n°";
            // 
            // lblNomClient
            // 
            this.lblNomClient.AutoSize = true;
            this.lblNomClient.Location = new System.Drawing.Point(12, 22);
            this.lblNomClient.Name = "lblNomClient";
            this.lblNomClient.Size = new System.Drawing.Size(71, 13);
            this.lblNomClient.TabIndex = 4;
            this.lblNomClient.Text = "NOM Prénom";
            // 
            // dtpDateEmprunt
            // 
            this.dtpDateEmprunt.Enabled = false;
            this.dtpDateEmprunt.Location = new System.Drawing.Point(15, 61);
            this.dtpDateEmprunt.Name = "dtpDateEmprunt";
            this.dtpDateEmprunt.Size = new System.Drawing.Size(207, 20);
            this.dtpDateEmprunt.TabIndex = 5;
            // 
            // lblDateEmprunt
            // 
            this.lblDateEmprunt.AutoSize = true;
            this.lblDateEmprunt.Location = new System.Drawing.Point(12, 45);
            this.lblDateEmprunt.Name = "lblDateEmprunt";
            this.lblDateEmprunt.Size = new System.Drawing.Size(58, 13);
            this.lblDateEmprunt.TabIndex = 6;
            this.lblDateEmprunt.Text = "Effectué le";
            // 
            // lblDVD
            // 
            this.lblDVD.AutoSize = true;
            this.lblDVD.Location = new System.Drawing.Point(12, 94);
            this.lblDVD.Name = "lblDVD";
            this.lblDVD.Size = new System.Drawing.Size(107, 13);
            this.lblDVD.TabIndex = 7;
            this.lblDVD.Text = "Contenu de l\'emprunt";
            // 
            // btnRetourDVD
            // 
            this.btnRetourDVD.Location = new System.Drawing.Point(12, 267);
            this.btnRetourDVD.Name = "btnRetourDVD";
            this.btnRetourDVD.Size = new System.Drawing.Size(207, 34);
            this.btnRetourDVD.TabIndex = 8;
            this.btnRetourDVD.Text = "Retourner les DVD sélectionnés ?";
            this.btnRetourDVD.UseVisualStyleBackColor = true;
            this.btnRetourDVD.Click += new System.EventHandler(this.btnRetourDVD_Click);
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(12, 309);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(207, 34);
            this.btnFermer.TabIndex = 9;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // EcranDetailsEmprunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 355);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.btnRetourDVD);
            this.Controls.Add(this.lblDVD);
            this.Controls.Add(this.lblDateEmprunt);
            this.Controls.Add(this.dtpDateEmprunt);
            this.Controls.Add(this.lblNomClient);
            this.Controls.Add(this.lblIDClient);
            this.Controls.Add(this.dgvDVD);
            this.Name = "EcranDetailsEmprunt";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDVD;
        private System.Windows.Forms.Label lblIDClient;
        private System.Windows.Forms.Label lblNomClient;
        private System.Windows.Forms.DateTimePicker dtpDateEmprunt;
        private System.Windows.Forms.Label lblDateEmprunt;
        private System.Windows.Forms.Label lblDVD;
        private System.Windows.Forms.Button btnRetourDVD;
        private System.Windows.Forms.Button btnFermer;
    }
}