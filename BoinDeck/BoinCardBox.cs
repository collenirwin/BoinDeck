using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BoinDeckNS {
    [ToolboxItem(true)]
    public partial class BoinCardBox : PictureBox {

        #region Vars

        public Image cardBack { get; set; }
        public BoinCard card  { get; set; }

        #endregion

        #region Constructor

        public BoinCardBox() {
            InitializeComponent();

            // set dimensions to card dimensions
            Width  = 87;
            Height = 125;

            // set and show cardback
            cardBack = Properties.Resources.cardback;
            Image    = cardBack;
            SizeMode = PictureBoxSizeMode.Zoom;
        }

        #endregion
    }
}
