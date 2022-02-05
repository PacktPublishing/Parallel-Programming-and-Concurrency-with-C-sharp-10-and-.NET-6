namespace WorkingWithTimers
{
    partial class TimerForm
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
            this.timerGroupBox = new System.Windows.Forms.GroupBox();
            this.stopTimerButton = new System.Windows.Forms.Button();
            this.startTimerButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stopThreadingTimerButton = new System.Windows.Forms.Button();
            this.startThreadingTimerButton = new System.Windows.Forms.Button();
            this.timerGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerGroupBox
            // 
            this.timerGroupBox.Controls.Add(this.stopTimerButton);
            this.timerGroupBox.Controls.Add(this.startTimerButton);
            this.timerGroupBox.Location = new System.Drawing.Point(35, 38);
            this.timerGroupBox.Name = "timerGroupBox";
            this.timerGroupBox.Size = new System.Drawing.Size(400, 308);
            this.timerGroupBox.TabIndex = 0;
            this.timerGroupBox.TabStop = false;
            this.timerGroupBox.Text = "Timer";
            // 
            // stopTimerButton
            // 
            this.stopTimerButton.Location = new System.Drawing.Point(116, 150);
            this.stopTimerButton.Name = "stopTimerButton";
            this.stopTimerButton.Size = new System.Drawing.Size(150, 46);
            this.stopTimerButton.TabIndex = 1;
            this.stopTimerButton.Text = "Stop Timer";
            this.stopTimerButton.UseVisualStyleBackColor = true;
            this.stopTimerButton.Click += new System.EventHandler(this.stopTimerButton_Click);
            // 
            // startTimerButton
            // 
            this.startTimerButton.Location = new System.Drawing.Point(116, 62);
            this.startTimerButton.Name = "startTimerButton";
            this.startTimerButton.Size = new System.Drawing.Size(150, 46);
            this.startTimerButton.TabIndex = 0;
            this.startTimerButton.Text = "Start Timer";
            this.startTimerButton.UseVisualStyleBackColor = true;
            this.startTimerButton.Click += new System.EventHandler(this.startTimerButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stopThreadingTimerButton);
            this.groupBox1.Controls.Add(this.startThreadingTimerButton);
            this.groupBox1.Location = new System.Drawing.Point(495, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 308);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timer";
            // 
            // stopThreadingTimerButton
            // 
            this.stopThreadingTimerButton.Location = new System.Drawing.Point(66, 150);
            this.stopThreadingTimerButton.Name = "stopThreadingTimerButton";
            this.stopThreadingTimerButton.Size = new System.Drawing.Size(280, 46);
            this.stopThreadingTimerButton.TabIndex = 1;
            this.stopThreadingTimerButton.Text = "Stop Threading Timer";
            this.stopThreadingTimerButton.UseVisualStyleBackColor = true;
            this.stopThreadingTimerButton.Click += new System.EventHandler(this.stopThreadingTimerButton_Click);
            // 
            // startThreadingTimerButton
            // 
            this.startThreadingTimerButton.Location = new System.Drawing.Point(66, 62);
            this.startThreadingTimerButton.Name = "startThreadingTimerButton";
            this.startThreadingTimerButton.Size = new System.Drawing.Size(280, 46);
            this.startThreadingTimerButton.TabIndex = 0;
            this.startThreadingTimerButton.Text = "Start Threading Timer";
            this.startThreadingTimerButton.UseVisualStyleBackColor = true;
            this.startThreadingTimerButton.Click += new System.EventHandler(this.startThreadingTimerButton_Click);
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.timerGroupBox);
            this.Name = "TimerForm";
            this.Text = "Working with Timers";
            this.timerGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox timerGroupBox;
        private GroupBox groupBox1;
        private Button stopTimerButton;
        private Button startTimerButton;
        private Button stopThreadingTimerButton;
        private Button startThreadingTimerButton;
    }
}