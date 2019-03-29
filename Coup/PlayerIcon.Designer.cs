namespace Coup
{
    partial class PlayerIcon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.playerOneImageTwo = new System.Windows.Forms.PictureBox();
            this.playerOneLabel = new System.Windows.Forms.Label();
            this.playerOneImageOne = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerOneImageTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerOneImageOne)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.playerOneImageTwo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.playerOneLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.playerOneImageOne, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(237, 160);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // playerOneImageTwo
            // 
            this.playerOneImageTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneImageTwo.Location = new System.Drawing.Point(121, 35);
            this.playerOneImageTwo.Name = "playerOneImageTwo";
            this.playerOneImageTwo.Size = new System.Drawing.Size(113, 122);
            this.playerOneImageTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerOneImageTwo.TabIndex = 3;
            this.playerOneImageTwo.TabStop = false;
            // 
            // playerOneLabel
            // 
            this.playerOneLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.playerOneLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.playerOneLabel, 2);
            this.playerOneLabel.Location = new System.Drawing.Point(96, 0);
            this.playerOneLabel.Name = "playerOneLabel";
            this.playerOneLabel.Size = new System.Drawing.Size(45, 13);
            this.playerOneLabel.TabIndex = 0;
            this.playerOneLabel.Text = "Player 1";
            // 
            // playerOneImageOne
            // 
            this.playerOneImageOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneImageOne.Location = new System.Drawing.Point(3, 35);
            this.playerOneImageOne.Name = "playerOneImageOne";
            this.playerOneImageOne.Size = new System.Drawing.Size(112, 122);
            this.playerOneImageOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerOneImageOne.TabIndex = 2;
            this.playerOneImageOne.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coins: ";
            // 
            // PlayerIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlayerIcon";
            this.Size = new System.Drawing.Size(237, 196);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerOneImageTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerOneImageOne)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox playerOneImageTwo;
        private System.Windows.Forms.Label playerOneLabel;
        private System.Windows.Forms.PictureBox playerOneImageOne;
        private System.Windows.Forms.Label label1;
    }
}
