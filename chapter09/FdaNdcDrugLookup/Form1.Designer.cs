namespace FdaNdcDrugLookup
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtNdc = new System.Windows.Forms.TextBox();
            this.lblNdc = new System.Windows.Forms.Label();
            this.btnLookup = new System.Windows.Forms.Button();
            this.txtDrugName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(150, 46);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtNdc
            // 
            this.txtNdc.Location = new System.Drawing.Point(12, 110);
            this.txtNdc.Name = "txtNdc";
            this.txtNdc.Size = new System.Drawing.Size(276, 39);
            this.txtNdc.TabIndex = 1;
            // 
            // lblNdc
            // 
            this.lblNdc.AutoSize = true;
            this.lblNdc.Location = new System.Drawing.Point(12, 75);
            this.lblNdc.Name = "lblNdc";
            this.lblNdc.Size = new System.Drawing.Size(132, 32);
            this.lblNdc.TabIndex = 2;
            this.lblNdc.Text = "NDC Code:";
            // 
            // btnLookup
            // 
            this.btnLookup.Enabled = false;
            this.btnLookup.Location = new System.Drawing.Point(294, 103);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(190, 46);
            this.btnLookup.TabIndex = 3;
            this.btnLookup.Text = "Lookup Drug";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // txtDrugName
            // 
            this.txtDrugName.Location = new System.Drawing.Point(12, 172);
            this.txtDrugName.Name = "txtDrugName";
            this.txtDrugName.ReadOnly = true;
            this.txtDrugName.Size = new System.Drawing.Size(1002, 39);
            this.txtDrugName.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 450);
            this.Controls.Add(this.txtDrugName);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.lblNdc);
            this.Controls.Add(this.txtNdc);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Lookup Drug by NDC Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLoad;
        private TextBox txtNdc;
        private Label lblNdc;
        private Button btnLookup;
        private TextBox txtDrugName;
    }
}