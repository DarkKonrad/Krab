namespace Inz_Prot
{
    partial class LoginForm
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtbLogin = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoginCredError = new System.Windows.Forms.Label();
            this.lblGeneratedLogin = new System.Windows.Forms.Label();
            this.btnDBConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLogin.Location = new System.Drawing.Point(229, 234);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(145, 42);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Zaloguj";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtbLogin
            // 
            this.txtbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtbLogin.Location = new System.Drawing.Point(229, 116);
            this.txtbLogin.Name = "txtbLogin";
            this.txtbLogin.Size = new System.Drawing.Size(145, 22);
            this.txtbLogin.TabIndex = 1;
            // 
            // txtbPassword
            // 
            this.txtbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtbPassword.Location = new System.Drawing.Point(229, 183);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.PasswordChar = '*';
            this.txtbPassword.Size = new System.Drawing.Size(145, 22);
            this.txtbPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(278, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(278, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasło";
            // 
            // lblLoginCredError
            // 
            this.lblLoginCredError.AutoSize = true;
            this.lblLoginCredError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLoginCredError.ForeColor = System.Drawing.Color.Red;
            this.lblLoginCredError.Location = new System.Drawing.Point(210, 310);
            this.lblLoginCredError.Name = "lblLoginCredError";
            this.lblLoginCredError.Size = new System.Drawing.Size(185, 20);
            this.lblLoginCredError.TabIndex = 5;
            this.lblLoginCredError.Text = "Błędny login lub hasło";
            this.lblLoginCredError.Visible = false;
            // 
            // lblGeneratedLogin
            // 
            this.lblGeneratedLogin.AutoSize = true;
            this.lblGeneratedLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGeneratedLogin.ForeColor = System.Drawing.Color.Black;
            this.lblGeneratedLogin.Location = new System.Drawing.Point(23, 22);
            this.lblGeneratedLogin.Name = "lblGeneratedLogin";
            this.lblGeneratedLogin.Size = new System.Drawing.Size(57, 20);
            this.lblGeneratedLogin.TabIndex = 6;
            this.lblGeneratedLogin.Text = "label3";
            this.lblGeneratedLogin.Visible = false;
            // 
            // btnDBConfig
            // 
            this.btnDBConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDBConfig.Location = new System.Drawing.Point(12, 337);
            this.btnDBConfig.Name = "btnDBConfig";
            this.btnDBConfig.Size = new System.Drawing.Size(145, 62);
            this.btnDBConfig.TabIndex = 7;
            this.btnDBConfig.Text = "Konfigurator Połączenia z Bazą Danych";
            this.btnDBConfig.UseVisualStyleBackColor = true;
            this.btnDBConfig.Click += new System.EventHandler(this.btnDBConfig_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(581, 411);
            this.Controls.Add(this.btnDBConfig);
            this.Controls.Add(this.lblGeneratedLogin);
            this.Controls.Add(this.lblLoginCredError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbPassword);
            this.Controls.Add(this.txtbLogin);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekran Logowania";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtbLogin;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLoginCredError;
        private System.Windows.Forms.Label lblGeneratedLogin;
        private System.Windows.Forms.Button btnDBConfig;
    }
}

