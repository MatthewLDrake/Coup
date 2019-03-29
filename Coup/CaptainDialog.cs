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
    public partial class CaptainDialog : Form
    {
        public CaptainDialog(String playerName)
        {
            InitializeComponent();
            label1.Text = playerName + " used a captain card. Would you like to block with an ambassador/captain, challenge the captain or do nothing?";
        }

        private void contessaButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            Close();
        }

        private void assasainButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
            Close();
        }

        private void noActionButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            Close();
        }
    }
}
