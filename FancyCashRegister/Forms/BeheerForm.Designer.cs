
namespace FancyCashRegister.Forms
{
    partial class BeheerForm
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
            this.btnAfsluiten = new System.Windows.Forms.Button();
            this.gbGebruikerBeheer = new System.Windows.Forms.GroupBox();
            this.btnTerug = new System.Windows.Forms.Button();
            this.lbGebruikers = new System.Windows.Forms.ListBox();
            this.lblGebruikerId = new System.Windows.Forms.Label();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.txtGebruikerId = new System.Windows.Forms.TextBox();
            this.txtGebruikersnaam = new System.Windows.Forms.TextBox();
            this.lblPincode = new System.Windows.Forms.Label();
            this.lblGebruikersnaam = new System.Windows.Forms.Label();
            this.txtVolledigeNaam = new System.Windows.Forms.TextBox();
            this.lblVolledigenaam = new System.Windows.Forms.Label();
            this.txtPincode = new System.Windows.Forms.MaskedTextBox();
            this.chkKanInloggen = new System.Windows.Forms.CheckBox();
            this.btnAfmelden = new System.Windows.Forms.Button();
            this.lblRol = new System.Windows.Forms.Label();
            this.lbRollen = new System.Windows.Forms.ListBox();
            this.gbGebruikerBeheer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAfsluiten
            // 
            this.btnAfsluiten.Location = new System.Drawing.Point(14, 204);
            this.btnAfsluiten.Name = "btnAfsluiten";
            this.btnAfsluiten.Size = new System.Drawing.Size(135, 91);
            this.btnAfsluiten.TabIndex = 0;
            this.btnAfsluiten.Text = "Afsluiten";
            this.btnAfsluiten.UseVisualStyleBackColor = true;
            this.btnAfsluiten.Click += new System.EventHandler(this.btnAfsluiten_Click);
            // 
            // gbGebruikerBeheer
            // 
            this.gbGebruikerBeheer.Controls.Add(this.lbRollen);
            this.gbGebruikerBeheer.Controls.Add(this.lbGebruikers);
            this.gbGebruikerBeheer.Controls.Add(this.lblRol);
            this.gbGebruikerBeheer.Controls.Add(this.txtPincode);
            this.gbGebruikerBeheer.Controls.Add(this.lblGebruikerId);
            this.gbGebruikerBeheer.Controls.Add(this.chkKanInloggen);
            this.gbGebruikerBeheer.Controls.Add(this.btnOpslaan);
            this.gbGebruikerBeheer.Controls.Add(this.txtGebruikerId);
            this.gbGebruikerBeheer.Controls.Add(this.txtVolledigeNaam);
            this.gbGebruikerBeheer.Controls.Add(this.lblPincode);
            this.gbGebruikerBeheer.Controls.Add(this.lblGebruikersnaam);
            this.gbGebruikerBeheer.Controls.Add(this.lblVolledigenaam);
            this.gbGebruikerBeheer.Controls.Add(this.txtGebruikersnaam);
            this.gbGebruikerBeheer.Enabled = false;
            this.gbGebruikerBeheer.Location = new System.Drawing.Point(169, 12);
            this.gbGebruikerBeheer.Name = "gbGebruikerBeheer";
            this.gbGebruikerBeheer.Size = new System.Drawing.Size(648, 565);
            this.gbGebruikerBeheer.TabIndex = 1;
            this.gbGebruikerBeheer.TabStop = false;
            this.gbGebruikerBeheer.Text = "Gebruiker beheer";
            // 
            // btnTerug
            // 
            this.btnTerug.Location = new System.Drawing.Point(11, 12);
            this.btnTerug.Name = "btnTerug";
            this.btnTerug.Size = new System.Drawing.Size(135, 91);
            this.btnTerug.TabIndex = 2;
            this.btnTerug.Text = "Terug";
            this.btnTerug.UseVisualStyleBackColor = true;
            this.btnTerug.Click += new System.EventHandler(this.btnTerug_Click);
            // 
            // lbGebruikers
            // 
            this.lbGebruikers.FormattingEnabled = true;
            this.lbGebruikers.ItemHeight = 20;
            this.lbGebruikers.Location = new System.Drawing.Point(6, 26);
            this.lbGebruikers.Name = "lbGebruikers";
            this.lbGebruikers.Size = new System.Drawing.Size(150, 344);
            this.lbGebruikers.TabIndex = 3;
            this.lbGebruikers.SelectedIndexChanged += new System.EventHandler(this.lbGebruikers_SelectedIndexChanged);
            // 
            // lblGebruikerId
            // 
            this.lblGebruikerId.AutoSize = true;
            this.lblGebruikerId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGebruikerId.Location = new System.Drawing.Point(164, 56);
            this.lblGebruikerId.Name = "lblGebruikerId";
            this.lblGebruikerId.Size = new System.Drawing.Size(91, 20);
            this.lblGebruikerId.TabIndex = 4;
            this.lblGebruikerId.Text = "Database ID";
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Location = new System.Drawing.Point(493, 288);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(135, 104);
            this.btnOpslaan.TabIndex = 5;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // txtGebruikerId
            // 
            this.txtGebruikerId.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGebruikerId.Location = new System.Drawing.Point(286, 26);
            this.txtGebruikerId.Name = "txtGebruikerId";
            this.txtGebruikerId.ReadOnly = true;
            this.txtGebruikerId.Size = new System.Drawing.Size(201, 52);
            this.txtGebruikerId.TabIndex = 6;
            // 
            // txtGebruikersnaam
            // 
            this.txtGebruikersnaam.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGebruikersnaam.Location = new System.Drawing.Point(286, 84);
            this.txtGebruikersnaam.Name = "txtGebruikersnaam";
            this.txtGebruikersnaam.Size = new System.Drawing.Size(201, 52);
            this.txtGebruikersnaam.TabIndex = 8;
            // 
            // lblPincode
            // 
            this.lblPincode.AutoSize = true;
            this.lblPincode.Location = new System.Drawing.Point(164, 171);
            this.lblPincode.Name = "lblPincode";
            this.lblPincode.Size = new System.Drawing.Size(62, 20);
            this.lblPincode.TabIndex = 7;
            this.lblPincode.Text = "Pincode";
            // 
            // lblGebruikersnaam
            // 
            this.lblGebruikersnaam.AutoSize = true;
            this.lblGebruikersnaam.Location = new System.Drawing.Point(164, 114);
            this.lblGebruikersnaam.Name = "lblGebruikersnaam";
            this.lblGebruikersnaam.Size = new System.Drawing.Size(115, 20);
            this.lblGebruikersnaam.TabIndex = 9;
            this.lblGebruikersnaam.Text = "gebruikersnaam";
            // 
            // txtVolledigeNaam
            // 
            this.txtVolledigeNaam.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtVolledigeNaam.Location = new System.Drawing.Point(286, 200);
            this.txtVolledigeNaam.Name = "txtVolledigeNaam";
            this.txtVolledigeNaam.Size = new System.Drawing.Size(201, 52);
            this.txtVolledigeNaam.TabIndex = 10;
            // 
            // lblVolledigenaam
            // 
            this.lblVolledigenaam.AutoSize = true;
            this.lblVolledigenaam.Location = new System.Drawing.Point(164, 229);
            this.lblVolledigenaam.Name = "lblVolledigenaam";
            this.lblVolledigenaam.Size = new System.Drawing.Size(113, 20);
            this.lblVolledigenaam.TabIndex = 7;
            this.lblVolledigenaam.Text = "Volledige naam";
            // 
            // txtPincode
            // 
            this.txtPincode.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPincode.Location = new System.Drawing.Point(286, 142);
            this.txtPincode.Mask = "00000";
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.PasswordChar = '*';
            this.txtPincode.Size = new System.Drawing.Size(201, 52);
            this.txtPincode.TabIndex = 11;
            this.txtPincode.ValidatingType = typeof(int);
            // 
            // chkKanInloggen
            // 
            this.chkKanInloggen.AutoSize = true;
            this.chkKanInloggen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkKanInloggen.Location = new System.Drawing.Point(183, 258);
            this.chkKanInloggen.Name = "chkKanInloggen";
            this.chkKanInloggen.Size = new System.Drawing.Size(119, 24);
            this.chkKanInloggen.TabIndex = 12;
            this.chkKanInloggen.Text = "Kan inloggen";
            this.chkKanInloggen.UseVisualStyleBackColor = true;
            // 
            // btnAfmelden
            // 
            this.btnAfmelden.Location = new System.Drawing.Point(14, 108);
            this.btnAfmelden.Name = "btnAfmelden";
            this.btnAfmelden.Size = new System.Drawing.Size(135, 91);
            this.btnAfmelden.TabIndex = 13;
            this.btnAfmelden.Text = "Afmelden";
            this.btnAfmelden.UseVisualStyleBackColor = true;
            this.btnAfmelden.Click += new System.EventHandler(this.btnAfmelden_Click);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(246, 371);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(31, 20);
            this.lblRol.TabIndex = 14;
            this.lblRol.Text = "Rol";
            // 
            // lbRollen
            // 
            this.lbRollen.FormattingEnabled = true;
            this.lbRollen.ItemHeight = 20;
            this.lbRollen.Location = new System.Drawing.Point(286, 288);
            this.lbRollen.Name = "lbRollen";
            this.lbRollen.Size = new System.Drawing.Size(201, 104);
            this.lbRollen.TabIndex = 15;
            // 
            // BeheerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1922, 589);
            this.Controls.Add(this.btnAfmelden);
            this.Controls.Add(this.btnTerug);
            this.Controls.Add(this.gbGebruikerBeheer);
            this.Controls.Add(this.btnAfsluiten);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "BeheerForm";
            this.Text = "BeheerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BeheerForm_FormClosed);
            this.Load += new System.EventHandler(this.BeheerForm_Load);
            this.gbGebruikerBeheer.ResumeLayout(false);
            this.gbGebruikerBeheer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAfsluiten;
        private System.Windows.Forms.GroupBox gbGebruikerBeheer;
        private System.Windows.Forms.Button btnTerug;
        private System.Windows.Forms.ListBox lbGebruikers;
        private System.Windows.Forms.Label lblGebruikerId;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.TextBox txtGebruikerId;
        private System.Windows.Forms.TextBox txtGebruikersnaam;
        private System.Windows.Forms.Label lblPincode;
        private System.Windows.Forms.Label lblGebruikersnaam;
        private System.Windows.Forms.TextBox txtVolledigeNaam;
        private System.Windows.Forms.Label lblVolledigenaam;
        private System.Windows.Forms.MaskedTextBox txtPincode;
        private System.Windows.Forms.CheckBox chkKanInloggen;
        private System.Windows.Forms.Button btnAfmelden;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ListBox lbRollen;
    }
}