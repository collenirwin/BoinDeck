using System.Drawing;

namespace BoinDeckNS {

    /// <summary>
    /// Represents a playing card, with a corresponding image
    /// </summary>
    public class BoinCard {

        #region Vars

        public int value       { get; private set; }
        public string suit     { get; private set; }
        public string color    { get; private set; }
        public string faceName { get; private set; }
        public string fullName { get; private set; }
        public bool isFaceCard { get; private set; }
        public Image image     { get; private set; }

        #endregion

        #region Constructors & Related Methods

        public BoinCard(int value, string suit) {
            initProperties(value, suit);
        }

        public BoinCard(int value, string suit, Image image) {
            initProperties(value, suit);
            this.image = image;
        }

        public BoinCard(int value, string suit, string imagePath) {
            initProperties(value, suit);
            image = Image.FromFile("imagePath");
        }

        private void initProperties(int value, string suit) {
            this.value = value;
            this.suit  = suit;

            string suitLower = suit.ToLower();
<<<<<<< HEAD

            // if the suit is hearts or diamonds, the card color is red, otherwise it's black
            color = (suitLower == "hearts" || suitLower == "diamonds") ? "red" : "black";

            isFaceCard = value > 10;

            // check for a special name (face card)
=======
            // if the suit is hearts or diamonds, the card color is red, otherwise it's black
            color = (suitLower == "hearts" || suitLower == "diamonds") ? "red" : "black";

            isFaceCard = value > 10;

>>>>>>> origin/master
            if (value == 1) {
                faceName = "Ace";

            } else if (value == 11) {
                faceName = "Jack";

            } else if (value == 12) {
                faceName = "Queen";

            } else if (value == 13) {
                faceName = "King";

            } else {
                faceName = value.ToString();
            }

            // ex: King of Clubs
            fullName = faceName + " of " + suit;
        }

        #endregion
    }
}
