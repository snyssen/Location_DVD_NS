namespace Location_DVD_NS
{
    partial class EcranTendances
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
            this.lbTendances = new System.Windows.Forms.ListBox();
            this.lblTendances = new System.Windows.Forms.Label();
            this.gbFiltres = new System.Windows.Forms.GroupBox();
            this.rbtnTous = new System.Windows.Forms.RadioButton();
            this.rbtnMois = new System.Windows.Forms.RadioButton();
            this.rbtnSemaine = new System.Windows.Forms.RadioButton();
            this.rbtnAjd = new System.Windows.Forms.RadioButton();
            this.gbFiltres.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTendances
            // 
            this.lbTendances.FormattingEnabled = true;
            this.lbTendances.Location = new System.Drawing.Point(16, 29);
            this.lbTendances.Name = "lbTendances";
            this.lbTendances.Size = new System.Drawing.Size(198, 407);
            this.lbTendances.TabIndex = 0;
            // 
            // lblTendances
            // 
            this.lblTendances.AutoSize = true;
            this.lblTendances.Location = new System.Drawing.Point(13, 13);
            this.lblTendances.Name = "lblTendances";
            this.lblTendances.Size = new System.Drawing.Size(61, 13);
            this.lblTendances.TabIndex = 1;
            this.lblTendances.Text = "Tendances";
            // 
            // gbFiltres
            // 
            this.gbFiltres.Controls.Add(this.rbtnAjd);
            this.gbFiltres.Controls.Add(this.rbtnSemaine);
            this.gbFiltres.Controls.Add(this.rbtnMois);
            this.gbFiltres.Controls.Add(this.rbtnTous);
            this.gbFiltres.Location = new System.Drawing.Point(221, 29);
            this.gbFiltres.Name = "gbFiltres";
            this.gbFiltres.Size = new System.Drawing.Size(187, 407);
            this.gbFiltres.TabIndex = 2;
            this.gbFiltres.TabStop = false;
            this.gbFiltres.Text = "Filtrer";
            // 
            // rbtnTous
            // 
            this.rbtnTous.AutoSize = true;
            this.rbtnTous.Checked = true;
            this.rbtnTous.Location = new System.Drawing.Point(7, 20);
            this.rbtnTous.Name = "rbtnTous";
            this.rbtnTous.Size = new System.Drawing.Size(80, 17);
            this.rbtnTous.TabIndex = 0;
            this.rbtnTous.TabStop = true;
            this.rbtnTous.Tag = "0";
            this.rbtnTous.Text = "Tous temps";
            this.rbtnTous.UseVisualStyleBackColor = true;
            this.rbtnTous.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnMois
            // 
            this.rbtnMois.AutoSize = true;
            this.rbtnMois.Location = new System.Drawing.Point(7, 43);
            this.rbtnMois.Name = "rbtnMois";
            this.rbtnMois.Size = new System.Drawing.Size(83, 17);
            this.rbtnMois.TabIndex = 1;
            this.rbtnMois.Tag = "1";
            this.rbtnMois.Text = "Dernier mois";
            this.rbtnMois.UseVisualStyleBackColor = true;
            this.rbtnMois.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnSemaine
            // 
            this.rbtnSemaine.AutoSize = true;
            this.rbtnSemaine.Location = new System.Drawing.Point(6, 66);
            this.rbtnSemaine.Name = "rbtnSemaine";
            this.rbtnSemaine.Size = new System.Drawing.Size(107, 17);
            this.rbtnSemaine.TabIndex = 2;
            this.rbtnSemaine.Tag = "2";
            this.rbtnSemaine.Text = "Dernière semaine";
            this.rbtnSemaine.UseVisualStyleBackColor = true;
            this.rbtnSemaine.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnAjd
            // 
            this.rbtnAjd.AutoSize = true;
            this.rbtnAjd.Location = new System.Drawing.Point(7, 89);
            this.rbtnAjd.Name = "rbtnAjd";
            this.rbtnAjd.Size = new System.Drawing.Size(71, 17);
            this.rbtnAjd.TabIndex = 3;
            this.rbtnAjd.Tag = "3";
            this.rbtnAjd.Text = "Ajourd\'hui";
            this.rbtnAjd.UseVisualStyleBackColor = true;
            this.rbtnAjd.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // EcranTendances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 450);
            this.Controls.Add(this.gbFiltres);
            this.Controls.Add(this.lblTendances);
            this.Controls.Add(this.lbTendances);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranTendances";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tendances";
            this.gbFiltres.ResumeLayout(false);
            this.gbFiltres.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTendances;
        private System.Windows.Forms.Label lblTendances;
        private System.Windows.Forms.GroupBox gbFiltres;
        private System.Windows.Forms.RadioButton rbtnAjd;
        private System.Windows.Forms.RadioButton rbtnSemaine;
        private System.Windows.Forms.RadioButton rbtnMois;
        private System.Windows.Forms.RadioButton rbtnTous;
    }
}