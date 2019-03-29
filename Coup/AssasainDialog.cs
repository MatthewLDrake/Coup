using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coup
{
    public partial class AssasainDialog : Form
    {
        public AssasainDialog(string playerName)
        {
            InitializeComponent();
            label1.Text = playerName + " used an assasain card. Would you like to block with a contessa, challenge the assasain or do nothing?";
        }

        private void noActionButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            Close();
        }

        private void assasainButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
            Close();
        }

        private void contessaButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            Close();
        }
    }
}
