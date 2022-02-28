namespace WinFormsInvoke
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
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.btnRunInBackground = new System.Windows.Forms.Button();
            this.btnRunOnMainThread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(29, 26);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.ReadOnly = true;
            this.usernameTextBox.Size = new System.Drawing.Size(340, 39);
            this.usernameTextBox.TabIndex = 0;
            // 
            // btnRunInBackground
            // 
            this.btnRunInBackground.Location = new System.Drawing.Point(33, 90);
            this.btnRunInBackground.Name = "btnRunInBackground";
            this.btnRunInBackground.Size = new System.Drawing.Size(252, 46);
            this.btnRunInBackground.TabIndex = 1;
            this.btnRunInBackground.Text = "Run in Background";
            this.btnRunInBackground.UseVisualStyleBackColor = true;
            this.btnRunInBackground.Click += new System.EventHandler(this.btnRunInBackground_Click);
            // 
            // btnRunOnMainThread
            // 
            this.btnRunOnMainThread.Location = new System.Drawing.Point(339, 92);
            this.btnRunOnMainThread.Name = "btnRunOnMainThread";
            this.btnRunOnMainThread.Size = new System.Drawing.Size(244, 46);
            this.btnRunOnMainThread.TabIndex = 2;
            this.btnRunOnMainThread.Text = "Run on Main Thread";
            this.btnRunOnMainThread.UseVisualStyleBackColor = true;
            this.btnRunOnMainThread.Click += new System.EventHandler(this.btnRunOnMainThread_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRunOnMainThread);
            this.Controls.Add(this.btnRunInBackground);
            this.Controls.Add(this.usernameTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox usernameTextBox;
        private Button btnRunInBackground;
        private Button btnRunOnMainThread;
    }
}