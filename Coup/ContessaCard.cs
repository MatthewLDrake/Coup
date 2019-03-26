using System.Drawing;

namespace Coup
{
    public class ContessaCard : Card
    {
        public ContessaCard()
        {
            image = (Bitmap)Bitmap.FromFile("Contessa.png");
        }
    }
}