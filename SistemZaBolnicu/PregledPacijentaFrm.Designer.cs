namespace SistemZaBolnicu
{
    partial class PregledPacijentaFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.textBoxImeRoditelja = new System.Windows.Forms.TextBox();
            this.textBoxPrezime = new System.Windows.Forms.TextBox();
            this.textBoxJMBG = new System.Windows.Forms.TextBox();
            this.textBoxOpisProblema = new System.Windows.Forms.TextBox();
            this.dateTimePickerDatumRodjenja = new System.Windows.Forms.DateTimePicker();
            this.btnZavrsipregled = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ime roditelja: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prezime: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "JMBG: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Opis pregleda: ";
            // 
            // textBoxIme
            // 
            this.textBoxIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIme.Location = new System.Drawing.Point(153, 33);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.ReadOnly = true;
            this.textBoxIme.Size = new System.Drawing.Size(188, 22);
            this.textBoxIme.TabIndex = 5;
            // 
            // textBoxImeRoditelja
            // 
            this.textBoxImeRoditelja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImeRoditelja.Location = new System.Drawing.Point(153, 61);
            this.textBoxImeRoditelja.Name = "textBoxImeRoditelja";
            this.textBoxImeRoditelja.ReadOnly = true;
            this.textBoxImeRoditelja.Size = new System.Drawing.Size(188, 22);
            this.textBoxImeRoditelja.TabIndex = 6;
            // 
            // textBoxPrezime
            // 
            this.textBoxPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrezime.Location = new System.Drawing.Point(153, 89);
            this.textBoxPrezime.Name = "textBoxPrezime";
            this.textBoxPrezime.ReadOnly = true;
            this.textBoxPrezime.Size = new System.Drawing.Size(188, 22);
            this.textBoxPrezime.TabIndex = 7;
            // 
            // textBoxJMBG
            // 
            this.textBoxJMBG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxJMBG.Location = new System.Drawing.Point(153, 117);
            this.textBoxJMBG.Name = "textBoxJMBG";
            this.textBoxJMBG.ReadOnly = true;
            this.textBoxJMBG.Size = new System.Drawing.Size(188, 22);
            this.textBoxJMBG.TabIndex = 8;
            // 
            // textBoxOpisProblema
            // 
            this.textBoxOpisProblema.Location = new System.Drawing.Point(49, 207);
            this.textBoxOpisProblema.Multiline = true;
            this.textBoxOpisProblema.Name = "textBoxOpisProblema";
            this.textBoxOpisProblema.Size = new System.Drawing.Size(292, 99);
            this.textBoxOpisProblema.TabIndex = 9;
            // 
            // dateTimePickerDatumRodjenja
            // 
            this.dateTimePickerDatumRodjenja.Enabled = false;
            this.dateTimePickerDatumRodjenja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDatumRodjenja.Location = new System.Drawing.Point(49, 145);
            this.dateTimePickerDatumRodjenja.Name = "dateTimePickerDatumRodjenja";
            this.dateTimePickerDatumRodjenja.Size = new System.Drawing.Size(292, 22);
            this.dateTimePickerDatumRodjenja.TabIndex = 10;
            // 
            // btnZavrsipregled
            // 
            this.btnZavrsipregled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZavrsipregled.Location = new System.Drawing.Point(49, 322);
            this.btnZavrsipregled.Name = "btnZavrsipregled";
            this.btnZavrsipregled.Size = new System.Drawing.Size(292, 26);
            this.btnZavrsipregled.TabIndex = 11;
            this.btnZavrsipregled.Text = "Sačuvaj pregled";
            this.btnZavrsipregled.UseVisualStyleBackColor = true;
            this.btnZavrsipregled.Click += new System.EventHandler(this.btnZavrsipregled_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(49, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(292, 26);
            this.button1.TabIndex = 12;
            this.button1.Text = "Izlaz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PregledPacijentaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(396, 388);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnZavrsipregled);
            this.Controls.Add(this.dateTimePickerDatumRodjenja);
            this.Controls.Add(this.textBoxOpisProblema);
            this.Controls.Add(this.textBoxJMBG);
            this.Controls.Add(this.textBoxPrezime);
            this.Controls.Add(this.textBoxImeRoditelja);
            this.Controls.Add(this.textBoxIme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(412, 427);
            this.MinimumSize = new System.Drawing.Size(412, 427);
            this.Name = "PregledPacijentaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pregled pacijenta";
            this.Load += new System.EventHandler(this.PregledPacijentaFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.TextBox textBoxImeRoditelja;
        private System.Windows.Forms.TextBox textBoxPrezime;
        private System.Windows.Forms.TextBox textBoxJMBG;
        private System.Windows.Forms.TextBox textBoxOpisProblema;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumRodjenja;
        private System.Windows.Forms.Button btnZavrsipregled;
        private System.Windows.Forms.Button button1;
    }
}