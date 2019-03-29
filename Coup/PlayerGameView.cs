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
    public partial class PlayerGameView : Form
    {
        private int playerNum, selectedPlayer;
        private MainGame game;
        private List<PlayerIcon> icons;
        private List<Button> buttons;
        public PlayerGameView(int playerNum, MainGame game)
        {
            InitializeComponent();
            this.game = game;
            this.playerNum = playerNum;
            icons = new List<PlayerIcon>
            {
                playerIcon1,
                playerIcon2,
                playerIcon3,
                playerIcon4,
                playerIcon5,
                playerIcon6
            };
            buttons = new List<Button>
            {
                button1,
                button2, 
                button3,
                button4,
                button5,
                button6
            };
            foreach (Button b in buttons)
                b.Visible = false;
            UpdateView();

        }
        public void UpdateView()
        {
            for (int i = 0; i < 6; i++)
            {
                Player temp = MainGame.players[i];

                icons[i].SetPlayerNum(i + 1);
                icons[i].SetImageOne(temp.GetImageOne());
                icons[i].SetImageTwo(temp.GetImageTwo());
                icons[i].SetMoney(temp.GetCoins());
            }
        }
        public int GetPlayer()
        {
            return selectedPlayer;
        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            selectedPlayer = buttons.IndexOf((Button)sender);
            MainGame.players[playerNum].PlayerSelected(selectedPlayer);
            foreach (Button b in buttons) 
                b.Visible = false;
        }
        public void ShowButtons()
        {
            for(int i = 0; i < buttons.Count; i++)
            {
                if (i != playerNum) buttons[i].Visible = true;
            }
        }
    }
}
