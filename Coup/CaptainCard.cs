using System.Drawing;

namespace Coup
{
    public class CaptainCard : Card
    {
        public CaptainCard ()
        {
            image = (Bitmap)Bitmap.FromFile("Captain.png");
        }
    }
}