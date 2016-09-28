using System.Drawing;

namespace BoinDeckNS {
    public class BoinCard {

        #region Vars

        private int _value;
        private string _suit;
        private string _color;
        private bool _isFaceCard;
        private string _faceName;
        private string _fullName;
        private Image _image;

        #endregion

        #region Constructors & Related Methods

        public BoinCard(int value, string suit) {
            initProperties(value, suit);
        }

        public BoinCard(int value, string suit, Image image) {
            initProperties(value, suit);
            this._image = image;
        }

        public BoinCard(int value, string suit, string imagePath) {
            initProperties(value, suit);
            this._image = Image.FromFile("imagePath");
        }

        private void initProperties(int value, string suit) {
            this._value = value;
            this._suit = suit;

            this._color = (_suit.ToLower() == "hearts" || _suit.ToLower() == "diamonds") ? "red" : "black";
            this._isFaceCard = (value > 10) ? true : false;

            if (value == 1)
                this._faceName = "Ace";
            else if (value == 11)
                this._faceName = "Jack";
            else if (value == 12)
                this._faceName = "Queen";
            else if (value == 13)
                this._faceName = "King";
            else
                this._faceName = value.ToString();

            this._fullName = _faceName + " of " + _suit;
        }

        #endregion

        #region Getters

        public int getValue() {
            return this._value;
        }

        public string getSuit() {
            return this._suit;
        }

        public string getColor() {
            return this._color;
        }

        public bool isFaceCard() {
            return this._isFaceCard;
        }

        public string getFaceName() {
            return this._faceName;
        }

        public string getFullName() {
            return this._fullName;
        }

        public Image getImage() {
            return this._image;
        }

        #endregion

    }
}
