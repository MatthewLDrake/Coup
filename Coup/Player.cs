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
    public partial class Player : Form
    {
        private Card cardOne, cardTwo;
        private int coins, playerNum;
        private bool currentTurn;
        private MainGame game;
        public Player(int playerNum, MainGame game)
        {
            InitializeComponent();
            coins = 2;
            coinLabel.Text = "Coins: " + coins;
            currentTurn = false;
            this.playerNum = playerNum;
            this.game = game;
            tableLayoutPanel1.Visible = currentTurn;
            Text = "Player " + playerNum;
        }
        public void IsCurrentTurn()
        {
            currentTurn = true;
            tableLayoutPanel1.Visible = currentTurn;

            coupButton.Enabled = true;
            assasainButton.Enabled = true;

            if (coins < 7)
            {
                coupButton.Enabled = false;
                if (coins < 3)
                    assasainButton.Enabled = false;
            }
            

        }
        public void AddCards(List<Card> cards)
        {
            cardOne = cards[0];
            cardTwo = cards[1];
            UpdateCards();
        }
        private void UpdateCards()
        {
            pictureBox1.Image = cardOne.GetImage();
            pictureBox2.Image = cardTwo.GetImage();
        }
        public Bitmap GetImageOne()
        {
            return cardOne.GetImage();
        }
        public Bitmap GetImageTwo()
        {
            return cardTwo.GetImage();
        }
        public int GetCoins()
        {
            return coins;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            game.ButtonClicked(((Button)sender).Name);
            currentTurn = false;
            tableLayoutPanel1.Visible = currentTurn;
        }

        public void ChangeCoins(int newCoins)
        {
            coins += newCoins;
            coinLabel.Text = "Coins: " + coins;
        }
        public void ActionTaken(String action, int player, String playerName)
        {
            switch(action)
            {
                case "ambassadorButton":
                    break;
                case "assasainButton":
                    break;
                case "captainButton":
                    break;
                case "coupButton":
                    break;
                case "dukeButton":
                    DialogResult result = MessageBox.Show(playerName + " took duke money. Would you like to challenge the duke action?", "Income Button Pressed", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        game.NoActionTaken();
                    else
                        // TODO:
                        game.NoActionTaken();
                    break;
                case "foreignAidButton":
                    DialogResult result = MessageBox.Show(playerName + " took foreign aid. Would you like to block with a duke?", "Income Button Pressed", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        game.NoActionTaken();
                    else
                        // TODO:
                        game.NoActionTaken();

                    
                    break;
                case "incomeButton":
                    MessageBox.Show(playerName + " took their income.", "Income Button Pressed", MessageBoxButtons.OK);
                    game.NoActionTaken();
                    break;
            }
        }

    }
}
