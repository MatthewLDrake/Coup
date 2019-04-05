using System.Drawing;

namespace Coup
{
    public class Card
    {
        protected Bitmap image;
        protected char letter;
        private static Bitmap cardFaceImage;
        private bool isDead;
        public Card()
        {
            isDead = false;
            if(cardFaceImage == null)
            {
                cardFaceImage = (Bitmap)Bitmap.FromFile("CardFace.png");
            }
        }
        public Bitmap GetImage(bool isAdmin = false)
        {
            if(!isAdmin && !isDead)
            {
                return cardFaceImage;
            }
            return image;
        }
        public bool IsDead()
        {
            return isDead;
        }
        public void Kill()
        {
            isDead = true;
        }
    }
}