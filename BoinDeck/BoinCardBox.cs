using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BoinDeckNS {
    [ToolboxItem(true)]
    public partial class BoinCardBox : PictureBox {

        #region Vars

        private Image _cardBack;
        private BoinCard _card;

        #endregion

        #region Constructor

        public BoinCardBox() {
            InitializeComponent();

            this.Width = 87;
            this.Height = 125;

            this._cardBack = Properties.Resources.cardback;
            this.Image = this._cardBack;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }

        #endregion

        #region Getters

        public BoinCard getCard() {
            return this._card;
        }
        
        public Image getCardBack() {
            return this._cardBack;
        }

        #endregion

        #region Setters

        public void setCard(BoinCard card, bool showCardBack = false) {
            this._card = card;

            if (showCardBack)
                this.Image = this._cardBack;
            else
                this.Image = card.getImage();
        }

        public void setCardBack(Image cardBack, bool showCardBack = false) {
            this._cardBack = cardBack;

            if (showCardBack)
                this.Image = this._cardBack;
        }

        public void setCardBack(string cardBackPath, bool showCardBack = false) {
            this._cardBack = Image.FromFile(cardBackPath);

            if (showCardBack)
                this.Image = this._cardBack;
        }

        #endregion

    }
}
