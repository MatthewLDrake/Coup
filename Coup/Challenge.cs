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
    public partial class Challenge : Form
    {
        private Card cardOne, cardTwo, selectedCard;
        private bool result;
        private string buttonName;
        public Challenge(string buttonName, string playerName, Card cardOne, Card cardTwo)
        {
            InitializeComponent();
            this.cardOne = cardOne;
            this.cardTwo = cardTwo;
            this.buttonName = buttonName;
            string cardName = "";
            switch(buttonName)
            {
                case "ambassadorButton":
                    cardName = "Ambassador";
                    break;
                case "assasainButton":
                    cardName = "Assasain";
                    break;
                case "captainButton":
                    cardName = "Captain";
                    break;
                case "contessaButton":
                    cardName = "Contessa";
                    break;
                case "dukeButton":
                    cardName = "Duke";
                    break;
                case "captainAmbassadorButton":
                    cardName = "Captain/Ambassador";
                    break;
            }

            if (cardOne.IsDead()) button1.Enabled = false;
            if (cardTwo.IsDead()) button2.Enabled = false;
            pictureBox1.Image = cardOne.GetImage(true);
            pictureBox2.Image = cardTwo.GetImage(true);

            label1.Text = playerName + " challenged your " + cardName + ". Either select that card, or select what card you will lose.";
        }
        public bool Result()
        {
            return result;
        }
        public Card GetCard()
        {
            return selectedCard;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (buttonName)
            {
                case "ambassadorButton":
                    result = cardOne is AmbassadorCard;
                    break;
                case "assasainButton":
                    result = cardOne is AssasainCard;
                    break;
                case "captainButton":
                    result = cardOne is CaptainCard;
                    break;
                case "contessaButton":
                    result = cardOne is ContessaCard;
                    break;
                case "dukeButton":
                    result = cardOne is DukeCard;
                    break;
                case "captainAmbassadorButton":
                    result = cardOne is CaptainCard || cardOne is AmbassadorCard;
                    break;
            }
            if (!result) cardOne.Kill();
            selectedCard = cardOne;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (buttonName)
            {
                case "ambassadorButton":
                    result = cardTwo is AmbassadorCard;
                    break;
                case "assasainButton":
                    result = cardTwo is AssasainCard;
                    break;
                case "captainButton":
                    result = cardTwo is CaptainCard;
                    break;
                case "contessaButton":
                    result = cardTwo is ContessaCard;
                    break;
                case "dukeButton":
                    result = cardTwo is DukeCard;
                    break;
                case "captainAmbassadorButton":
                    result = cardTwo is CaptainCard || cardTwo is AmbassadorCard;
                    break;
            }
            if (!result) cardTwo.Kill();
            selectedCard = cardOne;
            Close();
        }



    }
}
