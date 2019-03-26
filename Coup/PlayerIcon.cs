using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coup
{
    public partial class PlayerIcon : UserControl
    {
        public PlayerIcon()
        {
            InitializeComponent();
        }
        public void SetImageOne(Bitmap image)
        {
            playerOneImageOne.Image = image;
        }
        public void SetImageTwo(Bitmap image)
        {
            playerOneImageTwo.Image = image;
        }
        public void SetPlayerNum(int i)
        {
            playerOneLabel.Text = "Player " + i;
        }
        public void SetMoney(int coins)
        {
            label1.Text = "Coins: " + coins;
        }
    }
}
