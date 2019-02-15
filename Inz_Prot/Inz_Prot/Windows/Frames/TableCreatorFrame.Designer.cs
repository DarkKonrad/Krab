namespace Inz_Prot.Windows
{
    partial class TableCreatorFrame
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoNamePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAcceptAllRows = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.InfoNamePanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.label3);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.InfoNamePanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(765, 100);
            this.topPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(235, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Krótki tekst - do 80 znaków\r\nOpis - do 2048 znaków";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwij swój zbiór danych.\r\nPrzykład: \"Magazyn\" lub \"Usługi\"";
            // 
            // InfoNamePanel
            // 
            this.InfoNamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.InfoNamePanel.Controls.Add(this.label2);
            this.InfoNamePanel.Controls.Add(this.txtTableName);
            this.InfoNamePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoNamePanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.InfoNamePanel.Location = new System.Drawing.Point(0, 54);
            this.InfoNamePanel.Name = "InfoNamePanel";
            this.InfoNamePanel.Size = new System.Drawing.Size(765, 46);
            this.InfoNamePanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(17, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nazwa Zbioru Danych";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(180, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(227, 20);
            this.txtTableName.TabIndex = 0;
            this.txtTableName.MouseEnter += new System.EventHandler(this.txtTableName_MouseEnter);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.flowLayoutPanel1);
            this.bottomPanel.Controls.Add(this.btnAcceptAllRows);
            this.bottomPanel.Controls.Add(this.btnDeleteRow);
            this.bottomPanel.Controls.Add(this.btnAddField);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 465);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(765, 78);
            this.bottomPanel.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblInfo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(238, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(336, 73);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(3, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(47, 15);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "label1";
            this.lblInfo.Visible = false;
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // btnAcceptAllRows
            // 
            this.btnAcceptAllRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptAllRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAcceptAllRows.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcceptAllRows.Location = new System.Drawing.Point(580, 6);
            this.btnAcceptAllRows.Name = "btnAcceptAllRows";
            this.btnAcceptAllRows.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAcceptAllRows.Size = new System.Drawing.Size(173, 50);
            this.btnAcceptAllRows.TabIndex = 2;
            this.btnAcceptAllRows.Text = "Zatwierdź";
            this.btnAcceptAllRows.UseVisualStyleBackColor = true;
            this.btnAcceptAllRows.Click += new System.EventHandler(this.btnAcceptAllRows_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRow.Location = new System.Drawing.Point(121, 6);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDeleteRow.Size = new System.Drawing.Size(111, 50);
            this.btnDeleteRow.TabIndex = 1;
            this.btnDeleteRow.Text = "Usuń Pole";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnAddField
            // 
            this.btnAddField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddField.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddField.Location = new System.Drawing.Point(4, 6);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(111, 50);
            this.btnAddField.TabIndex = 0;
            this.btnAddField.Text = "Dodaj Pole";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 100);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(765, 365);
            this.MainPanel.TabIndex = 2;
            // 
            // TableCreatorFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 543);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.HelpButton = true;
            this.Name = "TableCreatorFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stwórz nowy zbiór danych";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.InfoNamePanel.ResumeLayout(false);
            this.InfoNamePanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnAcceptAllRows;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel InfoNamePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
    }
}