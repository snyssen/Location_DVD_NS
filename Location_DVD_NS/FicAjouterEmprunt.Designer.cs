namespace Location_DVD_NS
{
    partial class EcranAjouterEmprunt
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
            this.lbClientEmprunt = new System.Windows.Forms.ListBox();
            this.lblClientEmprunt = new System.Windows.Forms.Label();
            this.lbDVDEmprunt = new System.Windows.Forms.ListBox();
            this.lblDVDEmprunt = new System.Windows.Forms.Label();
            this.btnConfirmer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbClientEmprunt
            // 
            this.lbClientEmprunt.FormattingEnabled = true;
            this.lbClientEmprunt.Location = new System.Drawing.Point(12, 26);
            this.lbClientEmprunt.Name = "lbClientEmprunt";
            this.lbClientEmprunt.Size = new System.Drawing.Size(211, 147);
            this.lbClientEmprunt.TabIndex = 16;
            // 
            // lblClientEmprunt
            // 
            this.lblClientEmprunt.AutoSize = true;
            this.lblClientEmprunt.Location = new System.Drawing.Point(12, 10);
            this.lblClientEmprunt.Name = "lblClientEmprunt";
            this.lblClientEmprunt.Size = new System.Drawing.Size(84, 13);
            this.lblClientEmprunt.TabIndex = 15;
            this.lblClientEmprunt.Text = "Client (sélection)";
            // 
            // lbDVDEmprunt
            // 
            this.lbDVDEmprunt.FormattingEnabled = true;
            this.lbDVDEmprunt.Location = new System.Drawing.Point(261, 26);
            this.lbDVDEmprunt.Name = "lbDVDEmprunt";
            this.lbDVDEmprunt.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbDVDEmprunt.Size = new System.Drawing.Size(211, 147);
            this.lbDVDEmprunt.TabIndex = 18;
            // 
            // lblDVDEmprunt
            // 
            this.lblDVDEmprunt.AutoSize = true;
            this.lblDVDEmprunt.Location = new System.Drawing.Point(332, 9);
            this.lblDVDEmprunt.Name = "lblDVDEmprunt";
            this.lblDVDEmprunt.Size = new System.Drawing.Size(140, 13);
            this.lblDVDEmprunt.TabIndex = 17;
            this.lblDVDEmprunt.Text = "DVD à emprunter (sélection)";
            // 
            // btnConfirmer
            // 
            this.btnConfirmer.Location = new System.Drawing.Point(13, 180);
            this.btnConfirmer.Name = "btnConfirmer";
            this.btnConfirmer.Size = new System.Drawing.Size(459, 27);
            this.btnConfirmer.TabIndex = 19;
            this.btnConfirmer.Text = "Confirmer";
            this.btnConfirmer.UseVisualStyleBackColor = true;
            this.btnConfirmer.Click += new System.EventHandler(this.btnConfirmer_Click);
            // 
            // EcranAjouterEmprunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 219);
            this.Controls.Add(this.btnConfirmer);
            this.Controls.Add(this.lbDVDEmprunt);
            this.Controls.Add(this.lblDVDEmprunt);
            this.Controls.Add(this.lbClientEmprunt);
            this.Controls.Add(this.lblClientEmprunt);
            this.Name = "EcranAjouterEmprunt";
            this.Text = "Nouvel Emprunt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbClientEmprunt;
        private System.Windows.Forms.Label lblClientEmprunt;
        private System.Windows.Forms.ListBox lbDVDEmprunt;
        private System.Windows.Forms.Label lblDVDEmprunt;
        private System.Windows.Forms.Button btnConfirmer;
    }
}