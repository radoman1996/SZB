namespace SistemZaBolnicu
{
    partial class IzborZaposlenogFrm
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
            this.btnIzborDoktor = new System.Windows.Forms.Button();
            this.btnIzborMedSestra = new System.Windows.Forms.Button();
            this.btnIzborVozac = new System.Windows.Forms.Button();
            this.btnIzborIzlaz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIzborDoktor
            // 
            this.btnIzborDoktor.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzborDoktor.Location = new System.Drawing.Point(41, 8);
            this.btnIzborDoktor.Name = "btnIzborDoktor";
            this.btnIzborDoktor.Size = new System.Drawing.Size(200, 30);
            this.btnIzborDoktor.TabIndex = 0;
            this.btnIzborDoktor.Text = "Doktor";
            this.btnIzborDoktor.UseVisualStyleBackColor = true;
            this.btnIzborDoktor.Click += new System.EventHandler(this.btnIzborDoktor_Click);
            // 
            // btnIzborMedSestra
            // 
            this.btnIzborMedSestra.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzborMedSestra.Location = new System.Drawing.Point(41, 42);
            this.btnIzborMedSestra.Name = "btnIzborMedSestra";
            this.btnIzborMedSestra.Size = new System.Drawing.Size(200, 30);
            this.btnIzborMedSestra.TabIndex = 1;
            this.btnIzborMedSestra.Text = "Medicinska sestra";
            this.btnIzborMedSestra.UseVisualStyleBackColor = true;
            this.btnIzborMedSestra.Click += new System.EventHandler(this.btnIzborMedSestra_Click);
            // 
            // btnIzborVozac
            // 
            this.btnIzborVozac.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzborVozac.Location = new System.Drawing.Point(41, 76);
            this.btnIzborVozac.Name = "btnIzborVozac";
            this.btnIzborVozac.Size = new System.Drawing.Size(200, 30);
            this.btnIzborVozac.TabIndex = 2;
            this.btnIzborVozac.Text = "Vozač";
            this.btnIzborVozac.UseVisualStyleBackColor = true;
            this.btnIzborVozac.Click += new System.EventHandler(this.btnIzborVozac_Click);
            // 
            // btnIzborIzlaz
            // 
            this.btnIzborIzlaz.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzborIzlaz.Location = new System.Drawing.Point(41, 152);
            this.btnIzborIzlaz.Name = "btnIzborIzlaz";
            this.btnIzborIzlaz.Size = new System.Drawing.Size(200, 30);
            this.btnIzborIzlaz.TabIndex = 3;
            this.btnIzborIzlaz.Text = "Izlaz";
            this.btnIzborIzlaz.UseVisualStyleBackColor = true;
            this.btnIzborIzlaz.Click += new System.EventHandler(this.btnIzborIzlaz_Click);
            // 
            // IzborZaposlenogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(283, 191);
            this.Controls.Add(this.btnIzborIzlaz);
            this.Controls.Add(this.btnIzborVozac);
            this.Controls.Add(this.btnIzborMedSestra);
            this.Controls.Add(this.btnIzborDoktor);
            this.MaximumSize = new System.Drawing.Size(299, 230);
            this.MinimumSize = new System.Drawing.Size(299, 230);
            this.Name = "IzborZaposlenogFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Izbor zaposlenog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIzborDoktor;
        private System.Windows.Forms.Button btnIzborMedSestra;
        private System.Windows.Forms.Button btnIzborVozac;
        private System.Windows.Forms.Button btnIzborIzlaz;
    }
}