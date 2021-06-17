
namespace FancyCashRegister.Forms
{
    partial class RapportageForm
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
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTot = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBestandsnaam = new System.Windows.Forms.TextBox();
            this.btnRapportAanmaken = new System.Windows.Forms.Button();
            this.btnKiesBestand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(138, 49);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 23);
            this.dtStart.TabIndex = 0;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datum van";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum tot";
            // 
            // dtTot
            // 
            this.dtTot.Location = new System.Drawing.Point(465, 48);
            this.dtTot.Name = "dtTot";
            this.dtTot.Size = new System.Drawing.Size(200, 23);
            this.dtTot.TabIndex = 3;
            this.dtTot.ValueChanged += new System.EventHandler(this.dtTot_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "bestandsnaam";
            // 
            // txtBestandsnaam
            // 
            this.txtBestandsnaam.Location = new System.Drawing.Point(138, 110);
            this.txtBestandsnaam.Name = "txtBestandsnaam";
            this.txtBestandsnaam.Size = new System.Drawing.Size(100, 23);
            this.txtBestandsnaam.TabIndex = 6;
            // 
            // btnRapportAanmaken
            // 
            this.btnRapportAanmaken.Location = new System.Drawing.Point(375, 110);
            this.btnRapportAanmaken.Name = "btnRapportAanmaken";
            this.btnRapportAanmaken.Size = new System.Drawing.Size(75, 23);
            this.btnRapportAanmaken.TabIndex = 7;
            this.btnRapportAanmaken.Text = "Aanmaken";
            this.btnRapportAanmaken.UseVisualStyleBackColor = true;
            this.btnRapportAanmaken.Click += new System.EventHandler(this.btnRapportAanmaken_Click);
            // 
            // btnKiesBestand
            // 
            this.btnKiesBestand.Location = new System.Drawing.Point(270, 119);
            this.btnKiesBestand.Name = "btnKiesBestand";
            this.btnKiesBestand.Size = new System.Drawing.Size(75, 23);
            this.btnKiesBestand.TabIndex = 8;
            this.btnKiesBestand.Text = "kies bestand";
            this.btnKiesBestand.UseVisualStyleBackColor = true;
            this.btnKiesBestand.Click += new System.EventHandler(this.btnKiesBestand_Click);
            // 
            // RapportageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKiesBestand);
            this.Controls.Add(this.btnRapportAanmaken);
            this.Controls.Add(this.txtBestandsnaam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtTot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtStart);
            this.Name = "RapportageForm";
            this.Text = "RapportageForm";
            this.Load += new System.EventHandler(this.RapportageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBestandsnaam;
        private System.Windows.Forms.Button btnRapportAanmaken;
        private System.Windows.Forms.Button btnKiesBestand;
    }
}