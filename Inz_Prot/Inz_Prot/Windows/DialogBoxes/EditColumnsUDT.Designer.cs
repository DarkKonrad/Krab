namespace Inz_Prot.Windows.DialogBoxes
{
    partial class EditColumnsUDT
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.radioDecr = new System.Windows.Forms.RadioButton();
            this.radioShortText = new System.Windows.Forms.RadioButton();
            this.radioData = new System.Windows.Forms.RadioButton();
            this.radioInt = new System.Windows.Forms.RadioButton();
            this.radiofloat = new System.Windows.Forms.RadioButton();
            this.txtColName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboColumnName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.radiofloat);
            this.mainPanel.Controls.Add(this.radioInt);
            this.mainPanel.Controls.Add(this.radioData);
            this.mainPanel.Controls.Add(this.radioShortText);
            this.mainPanel.Controls.Add(this.radioDecr);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(285, 228);
            this.mainPanel.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BottomPanel.Controls.Add(this.label3);
            this.BottomPanel.Controls.Add(this.label2);
            this.BottomPanel.Controls.Add(this.comboColumnName);
            this.BottomPanel.Controls.Add(this.btnCancel);
            this.BottomPanel.Controls.Add(this.btnAccept);
            this.BottomPanel.Controls.Add(this.label1);
            this.BottomPanel.Controls.Add(this.txtColName);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 81);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(285, 147);
            this.BottomPanel.TabIndex = 1;
            // 
            // radioDecr
            // 
            this.radioDecr.AutoSize = true;
            this.radioDecr.Location = new System.Drawing.Point(11, 11);
            this.radioDecr.Name = "radioDecr";
            this.radioDecr.Size = new System.Drawing.Size(46, 17);
            this.radioDecr.TabIndex = 0;
            this.radioDecr.TabStop = true;
            this.radioDecr.Text = "Opis";
            this.radioDecr.UseVisualStyleBackColor = true;
            // 
            // radioShortText
            // 
            this.radioShortText.AutoSize = true;
            this.radioShortText.Location = new System.Drawing.Point(124, 11);
            this.radioShortText.Name = "radioShortText";
            this.radioShortText.Size = new System.Drawing.Size(78, 17);
            this.radioShortText.TabIndex = 1;
            this.radioShortText.TabStop = true;
            this.radioShortText.Text = "Krótki tekst";
            this.radioShortText.UseVisualStyleBackColor = true;
            // 
            // radioData
            // 
            this.radioData.AutoSize = true;
            this.radioData.Location = new System.Drawing.Point(11, 57);
            this.radioData.Name = "radioData";
            this.radioData.Size = new System.Drawing.Size(48, 17);
            this.radioData.TabIndex = 2;
            this.radioData.TabStop = true;
            this.radioData.Text = "Data";
            this.radioData.UseVisualStyleBackColor = true;
            // 
            // radioInt
            // 
            this.radioInt.AutoSize = true;
            this.radioInt.Location = new System.Drawing.Point(11, 34);
            this.radioInt.Name = "radioInt";
            this.radioInt.Size = new System.Drawing.Size(107, 17);
            this.radioInt.TabIndex = 3;
            this.radioInt.TabStop = true;
            this.radioInt.Text = "Liczba Całkowita";
            this.radioInt.UseVisualStyleBackColor = true;
            // 
            // radiofloat
            // 
            this.radiofloat.AutoSize = true;
            this.radiofloat.Location = new System.Drawing.Point(124, 34);
            this.radiofloat.Name = "radiofloat";
            this.radiofloat.Size = new System.Drawing.Size(160, 17);
            this.radiofloat.TabIndex = 4;
            this.radiofloat.TabStop = true;
            this.radiofloat.Text = "Liczba Zmiennoprzecinkowa";
            this.radiofloat.UseVisualStyleBackColor = true;
            // 
            // txtColName
            // 
            this.txtColName.Location = new System.Drawing.Point(124, 43);
            this.txtColName.Name = "txtColName";
            this.txtColName.Size = new System.Drawing.Size(153, 20);
            this.txtColName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nowa nazwa";
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(3, 102);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(89, 32);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(188, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // comboColumnName
            // 
            this.comboColumnName.FormattingEnabled = true;
            this.comboColumnName.Location = new System.Drawing.Point(124, 3);
            this.comboColumnName.Name = "comboColumnName";
            this.comboColumnName.Size = new System.Drawing.Size(156, 21);
            this.comboColumnName.TabIndex = 4;
            this.comboColumnName.SelectedIndexChanged += new System.EventHandler(this.comboColumnName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kolumna";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "(Opcjonalne)";
            // 
            // EditColumnsUDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 228);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.mainPanel);
            this.Name = "EditColumnsUDT";
            this.Text = "EditColumnsUDT";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.RadioButton radiofloat;
        private System.Windows.Forms.RadioButton radioInt;
        private System.Windows.Forms.RadioButton radioData;
        private System.Windows.Forms.RadioButton radioShortText;
        private System.Windows.Forms.RadioButton radioDecr;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboColumnName;
    }
}