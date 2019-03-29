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
    public partial class AmbassadorAction : Form
    {
        private int selectedBoxes;
        private List<Card> selected, notSelected;
        private Card cardOne, cardTwo, cardThree, cardFour;
        public AmbassadorAction(Card cardOne, Card cardTwo, Card cardThree, Card cardFour)
        {
            InitializeComponent();
            this.cardOne = cardOne;
            this.cardTwo = cardTwo;
            this.cardThree = cardThree;
            this.cardFour = cardFour;
            selectedBoxes = 0;
            if(cardOne.IsDead())
            {
                
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
                selectedBoxes++;
            }
            if(cardTwo.IsDead())
            {
                
                checkBox2.Checked = true;
                checkBox2.Enabled = false;
                selectedBoxes++;
            }
            pictureBox1.Image = cardOne.GetImage(true);
            pictureBox2.Image = cardTwo.GetImage(true);
            pictureBox3.Image = cardThree.GetImage(true);
            pictureBox4.Image = cardFour.GetImage(true);

            Confirm.Enabled = false;

        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            if (check.Checked) selectedBoxes++;
            else selectedBoxes--;

            if (selectedBoxes == 2) Confirm.Enabled = true;
            else Confirm.Enabled = false;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            selected = new List<Card>();
            notSelected = new List<Card>();
            if (checkBox1.Checked) selected.Add(cardOne);
            else notSelected.Add(cardOne);
            if (checkBox2.Checked) selected.Add(cardTwo);
            else notSelected.Add(cardTwo);
            if (checkBox3.Checked) selected.Add(cardThree);
            else notSelected.Add(cardThree);
            if (checkBox4.Checked) selected.Add(cardFour);
            else notSelected.Add(cardFour);
            Close();
        }
        public List<Card> GetSelected()
        {
            return selected;
        }
        public List<Card> GetNotSelected()
        {
            return notSelected;
        }

    }
}
