namespace CoupServer
{
    partial class Server
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
            if (disposing && (components != null))
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
            this.ipLabels = new System.Windows.Forms.Label();
            this.playersLabel = new System.Windows.Forms.Label();
            this.endButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipLabels
            // 
            this.ipLabels.AutoSize = true;
            this.ipLabels.Location = new System.Drawing.Point(43, 48);
            this.ipLabels.Name = "ipLabels";
            this.ipLabels.Size = new System.Drawing.Size(23, 13);
            this.ipLabels.TabIndex = 0;
            this.ipLabels.Text = "IP: ";
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(43, 119);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(108, 13);
            this.playersLabel.TabIndex = 1;
            this.playersLabel.Text = "Players Connected: 0";
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(46, 194);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(75, 23);
            this.endButton.TabIndex = 2;
            this.endButton.Text = "End Game";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(46, 151);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 26);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start Server";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.ipLabels);
            this.Name = "Server";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabels;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button button1;
    }
}

