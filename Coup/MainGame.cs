﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Coup
{
    public partial class MainGame : Form
    {
        private static List<Card> cards;
        public static List<Player> players;
        private static List<PlayerIcon> icons;
        public static Random rng = new Random();
        private int responses;
        private int currentTurn = 0;
        private bool wasChallenged, wasBlocked;
        private Player challengingPlayer;
        private Socket socket;
        private int playerNum;
        public MainGame()
        {
            InitializeComponent();
            Hide();
            ConnectToServer serv = new ConnectToServer();
            serv.ShowDialog();

            socket = serv.GetSocket();

            if (socket == null)
                Close();

            playerNum = serv.GetNumber();

            CreateDeck();

            Show();

        }
        private void CreateDeck()
        {
           
            players = new List<Player>();
            icons = new List<PlayerIcon>
            {
                playerIcon1,
                playerIcon2,
                playerIcon3,
                playerIcon4,
                playerIcon5,
                playerIcon6
            };
            if(playerNum == 1)
            {
                cards = new List<Card>
                {
                    new DukeCard(),
                    new DukeCard(),
                    new DukeCard(),
                    new AssasainCard(),
                    new AssasainCard(),
                    new AssasainCard(),
                    new ContessaCard(),
                    new ContessaCard(),
                    new ContessaCard(),
                    new AmbassadorCard(),
                    new AmbassadorCard(),
                    new AmbassadorCard(),
                    new CaptainCard(),
                    new CaptainCard(),
                    new CaptainCard()
                };

                cards = Shuffle(cards);

                String str = "";
                foreach(Card card in cards)
                {
                    Type type = card.GetType();
                    if (card is DukeCard)                    
                        str += "D";                    
                    else if(card is AssasainCard)
                        str += "A";
                    else if (card is AmbassadorCard)
                        str += "M";
                    else if (card is CaptainCard)
                        str += "C";
                    else if (card is ContessaCard)
                        str += "S";
                }

                socket.Send(Encoding.UTF8.GetBytes(str));
            }
            else
            {
                byte[] buff = new byte[1024];
                socket.Receive(buff);

                string s = System.Text.Encoding.UTF8.GetString(buff, 0, buff.Length);

                cards = new List<Card>();

                foreach(Char c in s)
                {
                    switch(c)
                    {
                        case 'D':
                            cards.Add(new DukeCard());
                            break;
                        case 'A':
                            cards.Add(new AssasainCard());
                            break;
                        case 'M':
                            cards.Add(new AmbassadorCard());
                            break;
                        case 'C':
                            cards.Add(new CaptainCard());
                            break;
                        case 'S':
                            cards.Add(new ContessaCard());
                            break;
                    }
                }


            }

            
            players.Add(new Player(0, this, "Player 1"));
            players.Add(new Player(1, this, "Player 2"));
            players.Add(new Player(2, this, "Player 3"));
            players.Add(new Player(3, this, "Player 4"));
            players.Add(new Player(4, this, "Player 5"));
            players.Add(new Player(5, this, "Player 6"));

            for(int i =0; i < 6; i++)
            {
                Player temp = players[i];
                List<Card> firstTwoCards = new List<Card>
                {
                    cards[0],
                    cards[1]
                };
                temp.AddCards(firstTwoCards);
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                if(i == playerNum - 1)temp.Show();

                icons[i].SetPlayerNum(i + 1);
                icons[i].SetImageOne(temp.GetImageOne(true));
                icons[i].SetImageTwo(temp.GetImageTwo(true));
                icons[i].SetMoney(temp.GetCoins());
                if (i == currentTurn) temp.IsCurrentTurn();
            }
            players[playerNum - 1].SetUpGameView();
            if (playerNum != 1) Hide();
            UpdateCards();
        }
        private void UpdateCards()
        {
            pictureBox1.Image = cards[0].GetImage(true);
            pictureBox2.Image = cards[1].GetImage(true);
            pictureBox3.Image = cards[2].GetImage(true);
        }
        private String buttonName;
        private int targettedPlayer;
        /*public void ButtonClicked(String buttonName, int player = -1)
        {
            this.buttonName = buttonName;
            targettedPlayer = player;
            responses = 0; 
            for(int i = 0; i < players.Count; i++)
            {
                if (i == currentTurn) continue;
                players[i].ActionTaken(buttonName, player,players[currentTurn].GetName(), player == -1 ? "" : players[player].GetName());
            }
        }*/

        public void ButtonClicked(String buttonName, int player = -1)
        {
            byte[] buffer = new byte[64];
            String valueToSend = buttonName + ';' + player;

            socket.Send(buffer);
        }

        private bool block;
        private void BlockAction()
        {
            responses = 0;
            if (wasChallenged)
            {
                bool challengeResult = players[targettedPlayer].Challenge(buttonName, challengingPlayer.GetName());
                if (challengeResult)
                {
                    // Challenge not successful, challenging player loses a card
                    Card returningCard = players[targettedPlayer].GetChallengedCard();
                    cards.Add(returningCard);
                    cards = Shuffle(cards);
                    players[targettedPlayer].AddNewCard(cards[0]);
                    cards.RemoveAt(0);
                    challengingPlayer.KillCard();

                }
                else
                {
                    DoAction(buttonName, currentTurn, targettedPlayer);
                    // Tell all players challenge was successful
                }
            }
            block = false;
            currentTurn = (currentTurn + 1) % players.Count;
            wasChallenged = false;
            wasBlocked = false;
            players[currentTurn].IsCurrentTurn();
            

            foreach (Player p in players)
            {
                p.UpdateView();
            }

            if (currentTurn != playerNum - 1) ReceiveNextAction();

        }
        private void ReceiveNextAction()
        {
            byte[] buffer = new byte[64];
            socket.Receive(buffer);

            string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            string[] theParams = s.Split(';');

            int player = int.Parse(theParams[1]);

            players[playerNum - 1].ActionTaken(theParams[0], player, players[currentTurn].GetName(), player == -1 ? "" : players[player].GetName());
        }
        private void Actions()
        {
            responses = 0;
            if (wasBlocked)
            {
                wasChallenged = false;
                block = true;
                string name = "";
                
                switch (buttonName)
                {
                    case "assasainButton":
                        name = "contessaButton";
                        break;
                    case "captainButton":
                        name = "captainAmbassadorButton";
                        break;
                    case "foreignAidButton":
                        name = "dukeButton";
                        break;

                }
                for (int i = 0; i < players.Count; i++)
                {
                    if (i == targettedPlayer) continue;
                    players[i].ActionBlocked(name, targettedPlayer, players[targettedPlayer].GetName(), players[currentTurn].GetName());

                }
               
            }
            else if (wasChallenged)
            {
                bool challengeResult = players[currentTurn].Challenge(buttonName, challengingPlayer.GetName());
                if (challengeResult)
                {
                    // Challenge not successful, challenging player loses a card
                    challengingPlayer.KillCard();
                    Card returningCard = players[currentTurn].GetChallengedCard();
                    cards.Add(returningCard);
                    cards = Shuffle(cards);
                    players[currentTurn].AddNewCard(cards[0]);
                    cards.RemoveAt(0);
                    DoAction(buttonName, currentTurn, targettedPlayer);
                }
                else
                {
                    // Tell all players challenge was successful
                }
                currentTurn = (currentTurn + 1) % players.Count;
                wasChallenged = false;
                wasBlocked = false;
                players[currentTurn].IsCurrentTurn();
                if (currentTurn != playerNum - 1) ReceiveNextAction();
                foreach (Player p in players)
                {
                    p.UpdateView();
                }
            }
            else
            {
                DoAction(buttonName, currentTurn, targettedPlayer);
                currentTurn = (currentTurn + 1) % players.Count;
                wasChallenged = false;
                wasBlocked = false;
                players[currentTurn].IsCurrentTurn();
                if (currentTurn != playerNum - 1) ReceiveNextAction();
                foreach (Player p in players)
                {
                    p.UpdateView();
                }

            }

            
        }
        private void DoAction(string buttonName, int currentTurn, int player)
        {
            switch (buttonName)
            {
                case "ambassadorButton":
                    cards = Shuffle(cards);
                    List<Card> temp = players[currentTurn].AmbassadorAction(cards[0], cards[1]);
                    cards.RemoveAt(0);
                    cards.RemoveAt(0);
                    cards.AddRange(temp);
                    icons[currentTurn].SetImageOne(players[currentTurn].GetImageOne(true));
                    icons[currentTurn].SetImageTwo(players[currentTurn].GetImageTwo(true));
                    UpdateCards();
                    break;
                case "assasainButton":
                    players[player].KillCard();
                    break;
                case "captainButton":
                    players[currentTurn].ChangeCoins(2);
                    players[player].ChangeCoins(-2);
                    icons[currentTurn].SetMoney(players[currentTurn].GetCoins());
                    icons[player].SetMoney(players[player].GetCoins());
                    break;
                case "coupButton":
                    // already taken care of in action taken, nothing to do
                    break;
                case "dukeButton":
                    players[currentTurn].ChangeCoins(3);
                    icons[currentTurn].SetMoney(players[currentTurn].GetCoins());
                    break;
                case "foreignAidButton":
                    players[currentTurn].ChangeCoins(2);
                    icons[currentTurn].SetMoney(players[currentTurn].GetCoins());
                    break;
                case "incomeButton":
                    players[currentTurn].ChangeCoins(1);
                    icons[currentTurn].SetMoney(players[currentTurn].GetCoins());
                    break;
            }
        }
        public void NoActionTaken()
        {
            responses++;
            if (responses == players.Count - 1 && block) BlockAction();
            else if (responses == players.Count - 1) Actions();
        }

        public static List<T> Shuffle<T>( List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
        
        public void Challenge(Player p)
        {
            if (wasChallenged) p.AlreadyChallenged(players[currentTurn].GetName());
            else challengingPlayer = p;
            wasChallenged = true;
            responses++;
            if (responses == players.Count - 1 && block) BlockAction();
            else if (responses == players.Count - 1) Actions();
        }
        public void Block(int playerNum)
        {
            wasBlocked = true;
            responses++;
            if (responses == players.Count - 1 && block) BlockAction();
            else if (responses == players.Count - 1) Actions();
        }
    }
}
