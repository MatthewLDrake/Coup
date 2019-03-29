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
    public partial class KillCard : Form
    {
        private Card cardOne, cardTwo;
        public KillCard(Card cardOne, Card cardTwo)
        {
            InitializeComponent();
            pictureBox1.Image = cardOne.GetImage(true);
            pictureBox2.Image = cardTwo.GetImage(true);
            this.cardOne = cardOne;
            this.cardTwo = cardTwo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cardOne.Kill();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cardTwo.Kill();
            Close();
        }
    }
}
