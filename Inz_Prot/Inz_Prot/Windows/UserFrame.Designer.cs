namespace Inz_Prot.Windows
{
    partial class UserFrame
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
            if (disposing && ( components != null ))
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
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.dataGridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridPrivilages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.AllowUserToAddRows = false;
            this.dataGridUsers.AllowUserToDeleteRows = false;
            this.dataGridUsers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridName,
            this.dataGridSurname,
            this.dataGridLogin,
            this.dataGridPrivilages});
            this.dataGridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridUsers.Location = new System.Drawing.Point(0, 0);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.Size = new System.Drawing.Size(446, 457);
            this.dataGridUsers.TabIndex = 0;
            // 
            // dataGridName
            // 
            this.dataGridName.HeaderText = "Imię";
            this.dataGridName.Name = "dataGridName";
            this.dataGridName.ReadOnly = true;
            // 
            // dataGridSurname
            // 
            this.dataGridSurname.HeaderText = "Nazwisko";
            this.dataGridSurname.Name = "dataGridSurname";
            this.dataGridSurname.ReadOnly = true;
            // 
            // dataGridLogin
            // 
            this.dataGridLogin.HeaderText = "Login";
            this.dataGridLogin.Name = "dataGridLogin";
            this.dataGridLogin.ReadOnly = true;
            // 
            // dataGridPrivilages
            // 
            this.dataGridPrivilages.HeaderText = "Poziom Uprawnień";
            this.dataGridPrivilages.Name = "dataGridPrivilages";
            this.dataGridPrivilages.ReadOnly = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(3, 16);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(122, 35);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Dodaj Użytkownika";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(131, 16);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(129, 35);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Usuń Użytkownika";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Controls.Add(this.btnDeleteUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 107);
            this.panel1.TabIndex = 4;
            // 
            // UserFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridUsers);
            this.Name = "UserFrame";
            this.Text = "Spis Użytkowników";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserFrame_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridPrivilages;
    }
}