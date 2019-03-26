using System.Drawing;

namespace Coup
{
    public class AmbassadorCard : Card
    {
        public AmbassadorCard()
        {
            image = (Bitmap)Bitmap.FromFile("Ambassador.png");
        }
    }
}