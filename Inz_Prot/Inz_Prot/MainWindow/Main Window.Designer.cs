namespace Inz_Prot.MainWindow
{
    partial class Main_Window
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
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.PanelUser = new System.Windows.Forms.Panel();
            this.labelUser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnStrServ = new System.Windows.Forms.Button();
            this.MainMenuPanel.SuspendLayout();
            this.PanelUser.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainMenuPanel.Controls.Add(this.btnStrServ);
            this.MainMenuPanel.Controls.Add(this.btnEmployees);
            this.MainMenuPanel.Location = new System.Drawing.Point(221, 102);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(298, 279);
            this.MainMenuPanel.TabIndex = 0;
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEmployees.Location = new System.Drawing.Point(14, 19);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(260, 42);
            this.btnEmployees.TabIndex = 0;
            this.btnEmployees.Text = "Pracownicy";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // PanelUser
            // 
            this.PanelUser.Controls.Add(this.labelUser);
            this.PanelUser.Location = new System.Drawing.Point(12, 12);
            this.PanelUser.Name = "PanelUser";
            this.PanelUser.Size = new System.Drawing.Size(194, 41);
            this.PanelUser.TabIndex = 1;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUser.Location = new System.Drawing.Point(3, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(51, 16);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChangePassword);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 100);
            this.panel1.TabIndex = 3;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChangePassword.Location = new System.Drawing.Point(12, 27);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(118, 61);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "Zmiana hasła";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsers.Location = new System.Drawing.Point(605, 27);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(142, 61);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Zarządzaj Użytkownikami Systemu";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnStrServ
            // 
            this.btnStrServ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStrServ.Location = new System.Drawing.Point(14, 81);
            this.btnStrServ.Name = "btnStrServ";
            this.btnStrServ.Size = new System.Drawing.Size(260, 42);
            this.btnStrServ.TabIndex = 1;
            this.btnStrServ.Text = "Magazyn / Usługi";
            this.btnStrServ.UseVisualStyleBackColor = true;
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelUser);
            this.Controls.Add(this.MainMenuPanel);
            this.MinimumSize = new System.Drawing.Size(775, 562);
            this.Name = "Main_Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Główne Okno";
            this.MainMenuPanel.ResumeLayout(false);
            this.PanelUser.ResumeLayout(false);
            this.PanelUser.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainMenuPanel;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Panel PanelUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnStrServ;
    }
}