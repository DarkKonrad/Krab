namespace Inz_Prot.Windows.DialogBoxes
{
    partial class ChooseJuxapositionDialog
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.listBoxJux = new System.Windows.Forms.ListBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnAddJuxA = new System.Windows.Forms.Button();
            this.btnDeleteJuxA = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.listBoxJux);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(382, 355);
            this.MainPanel.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.btnDeleteJuxA);
            this.bottomPanel.Controls.Add(this.btnAddJuxA);
            this.bottomPanel.Controls.Add(this.btnChoose);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 255);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(382, 100);
            this.bottomPanel.TabIndex = 1;
            // 
            // listBoxJux
            // 
            this.listBoxJux.FormattingEnabled = true;
            this.listBoxJux.Location = new System.Drawing.Point(37, 24);
            this.listBoxJux.Name = "listBoxJux";
            this.listBoxJux.Size = new System.Drawing.Size(316, 225);
            this.listBoxJux.TabIndex = 0;
            // 
            // btnChoose
            // 
            this.btnChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChoose.Location = new System.Drawing.Point(37, 29);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(101, 42);
            this.btnChoose.TabIndex = 0;
            this.btnChoose.Text = "Wybierz";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnAddJuxA
            // 
            this.btnAddJuxA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddJuxA.Location = new System.Drawing.Point(144, 29);
            this.btnAddJuxA.Name = "btnAddJuxA";
            this.btnAddJuxA.Size = new System.Drawing.Size(101, 42);
            this.btnAddJuxA.TabIndex = 1;
            this.btnAddJuxA.Text = "Dodaj";
            this.btnAddJuxA.UseVisualStyleBackColor = true;
            // 
            // btnDeleteJuxA
            // 
            this.btnDeleteJuxA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteJuxA.Location = new System.Drawing.Point(251, 29);
            this.btnDeleteJuxA.Name = "btnDeleteJuxA";
            this.btnDeleteJuxA.Size = new System.Drawing.Size(102, 42);
            this.btnDeleteJuxA.TabIndex = 2;
            this.btnDeleteJuxA.Text = "Usuń";
            this.btnDeleteJuxA.UseVisualStyleBackColor = true;
            // 
            // ChooseJuxapositionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 355);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.MainPanel);
            this.MaximumSize = new System.Drawing.Size(398, 394);
            this.MinimumSize = new System.Drawing.Size(398, 394);
            this.Name = "ChooseJuxapositionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybierz Zestawienie";
            this.MainPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ListBox listBoxJux;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button btnDeleteJuxA;
        private System.Windows.Forms.Button btnAddJuxA;
        private System.Windows.Forms.Button btnChoose;
    }
}