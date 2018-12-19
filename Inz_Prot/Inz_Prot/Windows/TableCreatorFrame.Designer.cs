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
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.btnAddField = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(765, 100);
            this.topPanel.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.btnAddField);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 443);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(765, 100);
            this.bottomPanel.TabIndex = 1;
            // 
            // btnAddField
            // 
            this.btnAddField.Location = new System.Drawing.Point(12, 19);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(103, 50);
            this.btnAddField.TabIndex = 0;
            this.btnAddField.Text = "Dodaj Pole";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 100);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(765, 343);
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
            this.Name = "TableCreatorFrame";
            this.Text = "TableCreatorForm";
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button btnAddField;
    }
}