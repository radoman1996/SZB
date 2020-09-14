namespace SistemZaBolnicu
{
    partial class Login
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
            this.textBoxPasswordLogin = new System.Windows.Forms.TextBox();
            this.comboBoxUsersLogin = new System.Windows.Forms.ComboBox();
            this.btnPrijaviSeLogin = new System.Windows.Forms.Button();
            this.btnOtkaziLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPasswordLogin
            // 
            this.textBoxPasswordLogin.AccessibleDescription = "";
            this.textBoxPasswordLogin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordLogin.Location = new System.Drawing.Point(106, 45);
            this.textBoxPasswordLogin.Name = "textBoxPasswordLogin";
            this.textBoxPasswordLogin.Size = new System.Drawing.Size(180, 22);
            this.textBoxPasswordLogin.TabIndex = 1;
            this.textBoxPasswordLogin.UseSystemPasswordChar = true;
            // 
            // comboBoxUsersLogin
            // 
            this.comboBoxUsersLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsersLogin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUsersLogin.FormattingEnabled = true;
            this.comboBoxUsersLogin.Location = new System.Drawing.Point(106, 16);
            this.comboBoxUsersLogin.Name = "comboBoxUsersLogin";
            this.comboBoxUsersLogin.Size = new System.Drawing.Size(180, 23);
            this.comboBoxUsersLogin.TabIndex = 2;
            // 
            // btnPrijaviSeLogin
            // 
            this.btnPrijaviSeLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrijaviSeLogin.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrijaviSeLogin.Location = new System.Drawing.Point(12, 73);
            this.btnPrijaviSeLogin.Name = "btnPrijaviSeLogin";
            this.btnPrijaviSeLogin.Size = new System.Drawing.Size(274, 23);
            this.btnPrijaviSeLogin.TabIndex = 3;
            this.btnPrijaviSeLogin.Text = "Prijavi se";
            this.btnPrijaviSeLogin.UseVisualStyleBackColor = true;
            this.btnPrijaviSeLogin.Click += new System.EventHandler(this.btnPrijaviSeLogin_Click);
            // 
            // btnOtkaziLogin
            // 
            this.btnOtkaziLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOtkaziLogin.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtkaziLogin.Location = new System.Drawing.Point(12, 102);
            this.btnOtkaziLogin.Name = "btnOtkaziLogin";
            this.btnOtkaziLogin.Size = new System.Drawing.Size(274, 23);
            this.btnOtkaziLogin.TabIndex = 4;
            this.btnOtkaziLogin.Text = "Otkaži";
            this.btnOtkaziLogin.UseVisualStyleBackColor = true;
            this.btnOtkaziLogin.Click += new System.EventHandler(this.btnOtkaziLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Izaberite nalog: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Unesite šifru: ";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(302, 137);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOtkaziLogin);
            this.Controls.Add(this.btnPrijaviSeLogin);
            this.Controls.Add(this.comboBoxUsersLogin);
            this.Controls.Add(this.textBoxPasswordLogin);
            this.MaximumSize = new System.Drawing.Size(318, 176);
            this.MinimumSize = new System.Drawing.Size(318, 176);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prijavi se";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxPasswordLogin;
        private System.Windows.Forms.ComboBox comboBoxUsersLogin;
        private System.Windows.Forms.Button btnPrijaviSeLogin;
        private System.Windows.Forms.Button btnOtkaziLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}