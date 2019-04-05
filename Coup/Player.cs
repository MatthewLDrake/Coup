using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private string playerName;
        private PlayerGameView view;
        private int deadCards;

        private string selectedButton;
        public Player(int playerNum, MainGame game, string playerName)
        {
            InitializeComponent();
            this.playerName = playerName;
            coins = 2;
            coinLabel.Text = "Coins: " + coins;
            currentTurn = false;
            this.playerNum = playerNum;
            this.game = game;
            tableLayoutPanel1.Visible = currentTurn;
            Text = playerName;
            
            deadCards = 0;
        }
        public void SetUpGameView()
        {
            view = new PlayerGameView(playerNum, game);
            view.Show();
        }
        public bool Eliminated()
        {
            return deadCards >= 2;
        }
        public string GetName()
        {
            return playerName;
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
            pictureBox1.Image = cardOne.GetImage(true);
            pictureBox2.Image = cardTwo.GetImage(true);
        }
        public Bitmap GetImageOne(bool isAdmin = false)
        {
            return cardOne.GetImage(isAdmin);
        }
        public Bitmap GetImageTwo(bool isAdmin = false)
        {
            return cardTwo.GetImage(isAdmin);
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
        public void KillCard()
        {
            if(deadCards == 1)
            {
                DialogResult result = MessageBox.Show("You've been eliminated", "Elimination", MessageBoxButtons.OK);
                if (cardOne.IsDead()) cardTwo.Kill();
                else cardOne.Kill();
            }
            else
            {
                KillCard kill = new KillCard(cardOne, cardTwo);
                kill.ShowDialog();
            }
            deadCards++;
        }
        public List<Card> AmbassadorAction(Card firstAlt, Card secondAlt)
        {
            AmbassadorAction action = new AmbassadorAction(cardOne, cardTwo, firstAlt, secondAlt);
            action.ShowDialog();
            List<Card> selected = action.GetSelected();
            cardOne = selected[0];
            cardTwo = selected[1];
            UpdateCards();
            return action.GetNotSelected();
        }

        public void ActionTaken(String action, int player, String playerName, String targetName)
        {
            switch(action)
            {
                case "ambassadorButton":
                    DialogResult result = MessageBox.Show(playerName + " used an ambassador card. Would you like to challenge the ambassador action?", "Ambassador Used", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        game.NoActionTaken();
                    else
                        game.Challenge(this);
                    break;
                case "assasainButton":
                    if (player == playerNum)
                    {
                        AssasainDialog dialog = new AssasainDialog(playerName);
                        result = dialog.ShowDialog();
                        if(result == DialogResult.None)
                        {
                            game.NoActionTaken();
                        }
                        else if(result == DialogResult.Abort)
                        {
                            game.Block(playerNum);
                        }
                        else
                        {
                            game.Challenge(this);
                        }
                    }
                    else
                    {
                        result = MessageBox.Show(playerName + " used an assasain card on " + targetName + ". Would you like to challenge the assasain action?", "Assasain Used", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                            game.NoActionTaken();
                        else
                            // TODO:
                            game.Challenge(this);
                    }
                    break;
                case "captainButton":
                    if (player == playerNum)
                    {
                        CaptainDialog dialog = new CaptainDialog(playerName);
                        result = dialog.ShowDialog();
                        if (result == DialogResult.None)
                        {
                            game.NoActionTaken();
                        }
                        else if (result == DialogResult.Abort)
                        {
                            game.Block(playerNum);
                        }
                        else
                        {
                            game.Challenge(this);
                        }
                    }
                    else
                    {
                        result = MessageBox.Show(playerName + " used a captain card on " + targetName + ". Would you like to challenge the captain action?", "Captain Used", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                            game.NoActionTaken();
                        else
                            game.Challenge(this);
                    }
                    break;
                case "coupButton":
                    if(player == playerNum)
                    {
                        KillCard();
                    }
                    else
                    {
                        MessageBox.Show(playerName + " performed a coup on " + targetName, "Coup Occurred", MessageBoxButtons.OK);                        
                    }
                    game.NoActionTaken();
                    break;
                case "dukeButton":
                    result = MessageBox.Show(playerName + " took duke money. Would you like to challenge the duke action?", "Duke Used", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        game.NoActionTaken();
                    else
                        game.Challenge(this);
                    break;
                case "foreignAidButton":
                    result = MessageBox.Show(playerName + " took foreign aid. Would you like to block with a duke?", "Foreign Aid Pressed", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        game.NoActionTaken();
                    else
                        game.Block(playerNum);

                    
                    break;
                case "incomeButton":
                    MessageBox.Show(playerName + " took their income.", "Income Button Pressed", MessageBoxButtons.OK);
                    game.NoActionTaken();
                    break;
            }
        }
        public void ActionBlocked(String action, int player, String playerName, String targetName)
        {
            switch (action)
            {
                case "contessaButton":
                    DialogResult result = MessageBox.Show(playerName + " blocked the assasain ", "Assasain Used", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        game.NoActionTaken();
                    else
                        game.Challenge(this);
                    
                    break;
                case "captainAmbassadorButton":
                    
                    result = MessageBox.Show(playerName + " blocked the captain. Would you like to challenge the block?", "Captain Blocked", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        game.NoActionTaken();
                    else
                        game.Challenge(this);
                    
                    break;
                case "dukeButton":
                    result = MessageBox.Show(playerName + " blocked the foreign aid. Would you like to challenge their duke?", "Foreign Aid Blocked", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        game.NoActionTaken();
                    else
                        game.Challenge(this);

                    break;
            }
        }
        public void PlayerSelected(int player)
        {
            game.ButtonClicked(selectedButton, player);
            
        }
        private void targettedPlayerClick(object sender, EventArgs e)
        {            
            view.ShowButtons();
            view.Visible = true;
            currentTurn = false;
            tableLayoutPanel1.Visible = currentTurn;

            selectedButton = ((Button)sender).Name;
        }
        public void UpdateView()
        {
            view.UpdateView();
        }
        public void AlreadyChallenged(String playerName)
        {
            MessageBox.Show(playerName + " was already challenged.", "Already Challenged", MessageBoxButtons.OK);
        }
        private Card challengedCard;
        public bool Challenge(string buttonName, string playerName)
        {
            Challenge challenge = new Challenge(buttonName, playerName, cardOne, cardTwo);
            challenge.ShowDialog();

            challengedCard = challenge.GetCard();
            return challenge.Result();
        }

        public Card GetChallengedCard()
        {
            if(challengedCard.Equals(cardOne))
                cardOne = null;
            else
                cardTwo = null;
            return challengedCard;
        }
        public void AddNewCard(Card newCard)
        {
            if (cardOne == null)
                cardOne = newCard;
            else
                cardTwo = newCard;

            UpdateCards();
        }
    }
}
