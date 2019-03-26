using System.Drawing;

namespace Coup
{
    public class DukeCard : Card
    {
        public DukeCard()
        {
            image = (Bitmap)Bitmap.FromFile("Duke.png");
        }
    }
}