namespace Inz_Prot.Windows
{
    partial class CustomTableFrame
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgCustomTable = new System.Windows.Forms.DataGridView();
            this.btnAddCustomRow = new System.Windows.Forms.Button();
            this.btnEditRow = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnToCSV = new System.Windows.Forms.Button();
            this.csvSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnChangeTypeOfColumn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dgCustomTable);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(960, 405);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dgCustomTable
            // 
            this.dgCustomTable.AllowUserToAddRows = false;
            this.dgCustomTable.AllowUserToDeleteRows = false;
            this.dgCustomTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCustomTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgCustomTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgCustomTable.Location = new System.Drawing.Point(3, 3);
            this.dgCustomTable.Name = "dgCustomTable";
            this.dgCustomTable.Size = new System.Drawing.Size(957, 402);
            this.dgCustomTable.TabIndex = 0;
            // 
            // btnAddCustomRow
            // 
            this.btnAddCustomRow.Location = new System.Drawing.Point(6, 19);
            this.btnAddCustomRow.Name = "btnAddCustomRow";
            this.btnAddCustomRow.Size = new System.Drawing.Size(107, 43);
            this.btnAddCustomRow.TabIndex = 2;
            this.btnAddCustomRow.Text = "Dodaj wiersz";
            this.btnAddCustomRow.UseVisualStyleBackColor = true;
            this.btnAddCustomRow.Click += new System.EventHandler(this.btnAddCustomRow_Click);
            // 
            // btnEditRow
            // 
            this.btnEditRow.Location = new System.Drawing.Point(119, 19);
            this.btnEditRow.Name = "btnEditRow";
            this.btnEditRow.Size = new System.Drawing.Size(107, 43);
            this.btnEditRow.TabIndex = 3;
            this.btnEditRow.Text = "Edytuj Wiersz";
            this.btnEditRow.UseVisualStyleBackColor = true;
            this.btnEditRow.Click += new System.EventHandler(this.btnEditRow_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(232, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 43);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Usuń Wiersz";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnToCSV
            // 
            this.btnToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToCSV.Location = new System.Drawing.Point(562, 19);
            this.btnToCSV.Name = "btnToCSV";
            this.btnToCSV.Size = new System.Drawing.Size(120, 43);
            this.btnToCSV.TabIndex = 5;
            this.btnToCSV.Text = "Zapisz Wszystko Do pliku CSV";
            this.btnToCSV.UseVisualStyleBackColor = true;
            this.btnToCSV.Click += new System.EventHandler(this.btnToCSV_Click);
            // 
            // btnChangeTypeOfColumn
            // 
            this.btnChangeTypeOfColumn.Location = new System.Drawing.Point(6, 19);
            this.btnChangeTypeOfColumn.Name = "btnChangeTypeOfColumn";
            this.btnChangeTypeOfColumn.Size = new System.Drawing.Size(101, 36);
            this.btnChangeTypeOfColumn.TabIndex = 6;
            this.btnChangeTypeOfColumn.Text = "Zmień typ kolumny";
            this.btnChangeTypeOfColumn.UseVisualStyleBackColor = true;
            this.btnChangeTypeOfColumn.Click += new System.EventHandler(this.btnChangeTypeOfColumn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnAddCustomRow);
            this.groupBox1.Controls.Add(this.btnEditRow);
            this.groupBox1.Controls.Add(this.btnToCSV);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(15, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 84);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Narzędzia edycyjne wierszy";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChangeTypeOfColumn);
            this.groupBox2.Location = new System.Drawing.Point(645, 423);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 84);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Narzędzia edycyjne tabeli";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(349, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 43);
            this.button4.TabIndex = 5;
            this.button4.Text = "Zapisz Wszystko Do pliku CSV";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // CustomTableFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CustomTableFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomTableFrame";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomTableFrame_FormClosed);
            this.Load += new System.EventHandler(this.CustomTableFrame_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddCustomRow;
        private System.Windows.Forms.DataGridView dgCustomTable;
        private System.Windows.Forms.Button btnEditRow;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnToCSV;
        private System.Windows.Forms.SaveFileDialog csvSaveDialog;
        private System.Windows.Forms.Button btnChangeTypeOfColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}