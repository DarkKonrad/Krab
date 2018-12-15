namespace Inz_Prot.Windows
{
    partial class EmployeeFrame
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridEmployee = new System.Windows.Forms.DataGridView();
            this.OrdinalNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emplName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emplSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emplBirthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pesel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emplAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emplHireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emplExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emplPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmployee)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridEmployee
            // 
            this.dataGridEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEmployee.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridEmployee.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdinalNumber,
            this.emplName,
            this.emplSurname,
            this.emplBirthDay,
            this.Pesel,
            this.emplAddress,
            this.emplHireDate,
            this.emplExpirationDate,
            this.emplPosition});
            this.dataGridEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEmployee.Location = new System.Drawing.Point(0, 0);
            this.dataGridEmployee.Name = "dataGridEmployee";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridEmployee.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridEmployee.Size = new System.Drawing.Size(1144, 594);
            this.dataGridEmployee.TabIndex = 0;
            // 
            // OrdinalNumber
            // 
            this.OrdinalNumber.FillWeight = 22.84264F;
            this.OrdinalNumber.HeaderText = "L.P";
            this.OrdinalNumber.Name = "OrdinalNumber";
            this.OrdinalNumber.ReadOnly = true;
            // 
            // emplName
            // 
            this.emplName.FillWeight = 109.6447F;
            this.emplName.HeaderText = "Imię";
            this.emplName.Name = "emplName";
            this.emplName.ReadOnly = true;
            // 
            // emplSurname
            // 
            this.emplSurname.FillWeight = 109.6447F;
            this.emplSurname.HeaderText = "Nazwisko";
            this.emplSurname.Name = "emplSurname";
            // 
            // emplBirthDay
            // 
            this.emplBirthDay.FillWeight = 109.6447F;
            this.emplBirthDay.HeaderText = "Data Urodzin";
            this.emplBirthDay.Name = "emplBirthDay";
            this.emplBirthDay.ReadOnly = true;
            // 
            // Pesel
            // 
            this.Pesel.FillWeight = 109.6447F;
            this.Pesel.HeaderText = "PESEL";
            this.Pesel.Name = "Pesel";
            this.Pesel.ReadOnly = true;
            // 
            // emplAddress
            // 
            this.emplAddress.FillWeight = 109.6447F;
            this.emplAddress.HeaderText = "Adres";
            this.emplAddress.Name = "emplAddress";
            this.emplAddress.ReadOnly = true;
            // 
            // emplHireDate
            // 
            this.emplHireDate.FillWeight = 109.6447F;
            this.emplHireDate.HeaderText = "Data Zatrudnienia";
            this.emplHireDate.Name = "emplHireDate";
            this.emplHireDate.ReadOnly = true;
            // 
            // emplExpirationDate
            // 
            this.emplExpirationDate.FillWeight = 109.6447F;
            this.emplExpirationDate.HeaderText = "Data Końca Zatrudnienia";
            this.emplExpirationDate.Name = "emplExpirationDate";
            this.emplExpirationDate.ReadOnly = true;
            // 
            // emplPosition
            // 
            this.emplPosition.FillWeight = 109.6447F;
            this.emplPosition.HeaderText = "Stanowisko";
            this.emplPosition.Name = "emplPosition";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnDeleteEmployee);
            this.groupBox1.Controls.Add(this.btnAddEmployee);
            this.groupBox1.Controls.Add(this.btnEditEmployee);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Narzędzia Edycji Pracowników";
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(332, 19);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(157, 40);
            this.btnDeleteEmployee.TabIndex = 5;
            this.btnDeleteEmployee.Text = "Usuń Pracownika";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(6, 19);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(157, 40);
            this.btnAddEmployee.TabIndex = 3;
            this.btnAddEmployee.Text = "Dodaj Pracownika";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(169, 19);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(157, 40);
            this.btnEditEmployee.TabIndex = 4;
            this.btnEditEmployee.Text = "Edytuj Pracownika";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(979, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Wyjdź";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 438);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 156);
            this.panel1.TabIndex = 3;
            // 
            // EmployeeFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 594);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridEmployee);
            this.MinimumSize = new System.Drawing.Size(1160, 633);
            this.Name = "EmployeeFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeFrame";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeFrame_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmployee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridEmployee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdinalNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn emplName;
        private System.Windows.Forms.DataGridViewTextBoxColumn emplSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn emplBirthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pesel;
        private System.Windows.Forms.DataGridViewTextBoxColumn emplAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn emplHireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn emplExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn emplPosition;
    }
}