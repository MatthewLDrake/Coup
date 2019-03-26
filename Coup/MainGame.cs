using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Coup
{
    public partial class MainGame : Form
    {
        private static List<Card> cards;
        private static List<Player> players;
        private static List<PlayerIcon> icons;
        public static Random rng = new Random();
        private Semaphore challengeSem;
        private int currentTurn = 0;
        private bool wasChallenged;
        public MainGame()
        {
            InitializeComponent();
            CreateDeck();
            
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

            for(int i =0; i < 6; i++)
            {
                Player temp = new Player(i, this);
                players.Add(temp);
                List<Card> firstTwoCards = new List<Card>
                {
                    cards[0],
                    cards[1]
                };
                temp.AddCards(firstTwoCards);
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                temp.Show();

                icons[i].SetPlayerNum(i + 1);
                icons[i].SetImageOne(temp.GetImageOne());
                icons[i].SetImageTwo(temp.GetImageTwo());
                icons[i].SetMoney(temp.GetCoins());
                if (i == currentTurn) temp.IsCurrentTurn();
            }
            pictureBox1.Image = cards[0].GetImage();
            pictureBox2.Image = cards[1].GetImage();
            pictureBox3.Image = cards[2].GetImage();
        }
        public void ButtonClicked(String buttonName, int player = -1)
        {
            challengeSem = new Semaphore(0,5);   
            for(int i = 0; i < players.Count; i++)
            {
                if (i == currentTurn) continue;
                players[i].ActionTaken(buttonName, player);
            }
            challengeSem.WaitOne();
            challengeSem.WaitOne();
            challengeSem.WaitOne();
            challengeSem.WaitOne();
            challengeSem.WaitOne();


            Console.WriteLine("Shouldn't happen until all players respond");



            
            if(wasChallenged)
            {

            }
            else
            {
                switch (buttonName)
                {
                    case "ambassadorButton":
                        break;
                    case "assasainButton":
                        break;
                    case "captainButton":
                        players[currentTurn].ChangeCoins(2);
                        players[player].ChangeCoins(-2);
                        break;
                    case "coupButton":
                        break;
                    case "dukeButton":
                        players[currentTurn].ChangeCoins(3);
                        break;
                    case "foreignAidButton":
                        players[currentTurn].ChangeCoins(2);
                        break;
                    case "incomeButton":
                        players[currentTurn].ChangeCoins(1);
                        break;
                }
            }

            currentTurn = (currentTurn + 1) % players.Count;

            players[currentTurn].IsCurrentTurn();

        }
        public void NoActionTaken()
        {
            challengeSem.Release();
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
    }
}
