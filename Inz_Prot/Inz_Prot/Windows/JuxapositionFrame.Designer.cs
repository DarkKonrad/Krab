namespace Inz_Prot.Windows
{
    partial class JuxapositionFrame
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
            this.dgJuxaposition = new System.Windows.Forms.DataGridView();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveToCSV = new System.Windows.Forms.Button();
            this.btnChooseJuxA = new System.Windows.Forms.Button();
            this.btnAddJux = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgJuxaposition)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgJuxaposition
            // 
            this.dgJuxaposition.AllowUserToAddRows = false;
            this.dgJuxaposition.AllowUserToDeleteRows = false;
            this.dgJuxaposition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgJuxaposition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJuxaposition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgJuxaposition.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgJuxaposition.Location = new System.Drawing.Point(0, 0);
            this.dgJuxaposition.Name = "dgJuxaposition";
            this.dgJuxaposition.Size = new System.Drawing.Size(800, 450);
            this.dgJuxaposition.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.dgJuxaposition);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.groupBox2);
            this.bottomPanel.Controls.Add(this.groupBox1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 349);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(800, 101);
            this.bottomPanel.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSaveToCSV);
            this.groupBox2.Controls.Add(this.btnChooseJuxA);
            this.groupBox2.Controls.Add(this.btnAddJux);
            this.groupBox2.Location = new System.Drawing.Point(447, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 57);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zestawienia";
            // 
            // btnSaveToCSV
            // 
            this.btnSaveToCSV.Location = new System.Drawing.Point(230, 19);
            this.btnSaveToCSV.Name = "btnSaveToCSV";
            this.btnSaveToCSV.Size = new System.Drawing.Size(106, 32);
            this.btnSaveToCSV.TabIndex = 3;
            this.btnSaveToCSV.Text = "Zapisz Do CSV";
            this.btnSaveToCSV.UseVisualStyleBackColor = true;
            this.btnSaveToCSV.Click += new System.EventHandler(this.btnSaveToCSV_Click);
            // 
            // btnChooseJuxA
            // 
            this.btnChooseJuxA.Location = new System.Drawing.Point(118, 19);
            this.btnChooseJuxA.Name = "btnChooseJuxA";
            this.btnChooseJuxA.Size = new System.Drawing.Size(106, 32);
            this.btnChooseJuxA.TabIndex = 2;
            this.btnChooseJuxA.Text = "Wybierz lub usuń";
            this.btnChooseJuxA.UseVisualStyleBackColor = true;
            this.btnChooseJuxA.Click += new System.EventHandler(this.btnChooseJuxA_Click_1);
            // 
            // btnAddJux
            // 
            this.btnAddJux.Location = new System.Drawing.Point(6, 19);
            this.btnAddJux.Name = "btnAddJux";
            this.btnAddJux.Size = new System.Drawing.Size(106, 32);
            this.btnAddJux.TabIndex = 0;
            this.btnAddJux.Text = "Dodaj zestawienie";
            this.btnAddJux.UseVisualStyleBackColor = true;
            this.btnAddJux.Click += new System.EventHandler(this.btnAddJux_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Narzędzia edycji komórek ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(230, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 32);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 32);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edytuj";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // JuxapositionFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "JuxapositionFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JuxapositionFrame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JuxapositionFrame_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgJuxaposition)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgJuxaposition;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChooseJuxA;
        private System.Windows.Forms.Button btnAddJux;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSaveToCSV;
    }
}