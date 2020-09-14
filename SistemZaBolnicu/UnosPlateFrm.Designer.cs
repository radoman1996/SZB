namespace SistemZaBolnicu
{
    partial class UnosPlateFrm
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
            this.textBoxJMBGZaposlenog = new System.Windows.Forms.TextBox();
            this.btnSacuvajPlatu = new System.Windows.Forms.Button();
            this.textBoxPlata = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxJMBGZaposlenog
            // 
            this.textBoxJMBGZaposlenog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxJMBGZaposlenog.Location = new System.Drawing.Point(30, 53);
            this.textBoxJMBGZaposlenog.Name = "textBoxJMBGZaposlenog";
            this.textBoxJMBGZaposlenog.ReadOnly = true;
            this.textBoxJMBGZaposlenog.Size = new System.Drawing.Size(226, 24);
            this.textBoxJMBGZaposlenog.TabIndex = 0;
            // 
            // btnSacuvajPlatu
            // 
            this.btnSacuvajPlatu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvajPlatu.Location = new System.Drawing.Point(30, 124);
            this.btnSacuvajPlatu.Name = "btnSacuvajPlatu";
            this.btnSacuvajPlatu.Size = new System.Drawing.Size(226, 30);
            this.btnSacuvajPlatu.TabIndex = 1;
            this.btnSacuvajPlatu.Text = "Sačuvaj platu";
            this.btnSacuvajPlatu.UseVisualStyleBackColor = true;
            this.btnSacuvajPlatu.Click += new System.EventHandler(this.btnSacuvajPlatu_Click);
            // 
            // textBoxPlata
            // 
            this.textBoxPlata.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlata.Location = new System.Drawing.Point(30, 83);
            this.textBoxPlata.Name = "textBoxPlata";
            this.textBoxPlata.Size = new System.Drawing.Size(226, 24);
            this.textBoxPlata.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "Unesite platu zaposlenog";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // UnosPlateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 172);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPlata);
            this.Controls.Add(this.btnSacuvajPlatu);
            this.Controls.Add(this.textBoxJMBGZaposlenog);
            this.MaximumSize = new System.Drawing.Size(300, 211);
            this.MinimumSize = new System.Drawing.Size(300, 211);
            this.Name = "UnosPlateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unos plate";
            this.Load += new System.EventHandler(this.UnosPlateFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxJMBGZaposlenog;
        private System.Windows.Forms.Button btnSacuvajPlatu;
        private System.Windows.Forms.TextBox textBoxPlata;
        private System.Windows.Forms.Label label1;
    }
}