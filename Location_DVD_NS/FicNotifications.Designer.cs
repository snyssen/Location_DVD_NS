namespace Location_DVD_NS
{
    partial class EcranNotifications
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
            this.btnQuitter = new System.Windows.Forms.Button();
            this.rtbInfos = new System.Windows.Forms.RichTextBox();
            this.cbAfficherpDVD = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(12, 367);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(463, 32);
            this.btnQuitter.TabIndex = 1;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // rtbInfos
            // 
            this.rtbInfos.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbInfos.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbInfos.Location = new System.Drawing.Point(0, 0);
            this.rtbInfos.Name = "rtbInfos";
            this.rtbInfos.ReadOnly = true;
            this.rtbInfos.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbInfos.ShortcutsEnabled = false;
            this.rtbInfos.Size = new System.Drawing.Size(584, 361);
            this.rtbInfos.TabIndex = 2;
            this.rtbInfos.TabStop = false;
            this.rtbInfos.Text = "";
            this.rtbInfos.WordWrap = false;
            // 
            // cbAfficherpDVD
            // 
            this.cbAfficherpDVD.AutoSize = true;
            this.cbAfficherpDVD.Location = new System.Drawing.Point(481, 376);
            this.cbAfficherpDVD.Name = "cbAfficherpDVD";
            this.cbAfficherpDVD.Size = new System.Drawing.Size(91, 17);
            this.cbAfficherpDVD.TabIndex = 3;
            this.cbAfficherpDVD.Text = "Trier par DVD";
            this.cbAfficherpDVD.UseVisualStyleBackColor = true;
            this.cbAfficherpDVD.CheckedChanged += new System.EventHandler(this.cbAfficherpDVD_CheckedChanged);
            // 
            // EcranNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.cbAfficherpDVD);
            this.Controls.Add(this.rtbInfos);
            this.Controls.Add(this.btnQuitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranNotifications";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notifications";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.RichTextBox rtbInfos;
        private System.Windows.Forms.CheckBox cbAfficherpDVD;
    }
}