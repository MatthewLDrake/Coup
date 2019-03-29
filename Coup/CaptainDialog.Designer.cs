namespace Coup
{
    partial class CaptainDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.noActionButton = new System.Windows.Forms.Button();
            this.assasainButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contessaButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.noActionButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.assasainButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.contessaButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 89);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // noActionButton
            // 
            this.noActionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noActionButton.Location = new System.Drawing.Point(191, 34);
            this.noActionButton.Name = "noActionButton";
            this.noActionButton.Size = new System.Drawing.Size(90, 52);
            this.noActionButton.TabIndex = 3;
            this.noActionButton.Text = "No Action";
            this.noActionButton.UseVisualStyleBackColor = true;
            this.noActionButton.Click += new System.EventHandler(this.noActionButton_Click);
            // 
            // assasainButton
            // 
            this.assasainButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assasainButton.Location = new System.Drawing.Point(97, 34);
            this.assasainButton.Name = "assasainButton";
            this.assasainButton.Size = new System.Drawing.Size(88, 52);
            this.assasainButton.TabIndex = 2;
            this.assasainButton.Text = "Challenge Captain";
            this.assasainButton.UseVisualStyleBackColor = true;
            this.assasainButton.Click += new System.EventHandler(this.assasainButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contessaButton
            // 
            this.contessaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contessaButton.Location = new System.Drawing.Point(3, 34);
            this.contessaButton.Name = "contessaButton";
            this.contessaButton.Size = new System.Drawing.Size(88, 52);
            this.contessaButton.TabIndex = 1;
            this.contessaButton.Text = "Block with Captain/ Ambassador";
            this.contessaButton.UseVisualStyleBackColor = true;
            this.contessaButton.Click += new System.EventHandler(this.contessaButton_Click);
            // 
            // CaptainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CaptainDialog";
            this.Text = "CaptainDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button noActionButton;
        private System.Windows.Forms.Button assasainButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button contessaButton;
    }
}