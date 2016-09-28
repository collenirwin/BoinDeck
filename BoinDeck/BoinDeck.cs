using System;
using System.Collections.Generic;
using System.Drawing;

namespace BoinDeckNS {
    public class BoinDeck {

        #region Vars

        public List<BoinCard> cards;
        public Image cardBack { get; set; }

        private bool _isShuffled = false;

        string[] _suits = { "Clubs", "Spades", "Hearts", "Diamonds" };

        private Random _ran = new Random();

        #endregion

        #region Constructors & Related Methods

        public BoinDeck(Image cardBack, bool shuffled = false, int numberOfDecks = 1) {
            this.cardBack = cardBack;
            initProperties(shuffled, numberOfDecks);
        }

        public BoinDeck(string cardBackPath, bool shuffled = false, int numberOfDecks = 1) {
            this.cardBack = Image.FromFile(cardBackPath);
            initProperties(shuffled, numberOfDecks);
        }

        public BoinDeck(bool shuffled = false, int numberOfDecks = 1) {
            this.cardBack = Properties.Resources.cardback; // Default cardback
            initProperties(shuffled, numberOfDecks);
        }

        private void initProperties(bool shuffled, int numberOfDecks) {
            this.cards = new List<BoinCard>();

            if (numberOfDecks > 0)
                this.addDecks(numberOfDecks, shuffled);
        }

        #endregion

        #region Deck Methods

        #region Misc

        /// <summary>
        /// Shuffles the deck, arranging its cards in random order
        /// </summary>
        public void shuffle() {
            List<BoinCard> tmpDeck = new List<BoinCard>(this.cards);
            this.cards.Clear();

            int total = tmpDeck.Count;
            for (int x = 0; x < total; x++) {
                int ranIndex = this._ran.Next(tmpDeck.Count);
                this.cards.Add(tmpDeck[ranIndex]);
                tmpDeck.RemoveAt(ranIndex);
            }

            this._isShuffled = true;
        }

        public void clearCards() {
            this.cards.Clear();
        }

        #endregion

        #region Adding

        /// <summary>
        /// Adds complete deck(s) of default BoinCards to the deck
        /// </summary>
        public void addDecks(int numberOfDecks, bool reshuffle = false) {
            for (int x = 0; x < this._suits.Length; x++) {
                for (int y = 1; y < 14; y++) {
                    this.cards.Add(new BoinCard(y, this._suits[x], 
                        (Image)Properties.Resources.ResourceManager.GetObject(
                        "_" +
                        y.ToString() + // Value
                        "_of_" + 
                        _suits[x].ToLower() // Suit
                        )));
                }
            }

            if (reshuffle)
                this.shuffle();
        }

        /// <summary>
        /// Adds a BoinCard to the deck
        /// </summary>
        public void addCard(BoinCard card, bool reshuffle = false) {
            this.cards.Add(card);

            if (reshuffle)
                this.shuffle();
        }

        /// <summary>
        /// Adds a random BoinCard to the deck
        /// </summary>
        public void addRandomCard(bool reshuffle = false) {
            this.cards.Add(new BoinCard(
                this._ran.Next(1, 14), 
                this._suits[this._ran.Next(4)]
                ));

            if (reshuffle)
                this.shuffle();
        }

        /// <summary>
        /// Adds an array of BoinCards to the deck
        /// </summary>
        public void addCards(BoinCard[] cards, bool reshuffle = false) {
            this.cards.AddRange(cards);

            if (reshuffle)
                this.shuffle();
        }

        /// <summary>
        /// Adds a list of BoinCards to the deck
        /// </summary>
        public void addCards(List<BoinCard> cards, bool reshuffle = false) {
            this.cards.AddRange(cards);

            if (reshuffle)
                this.shuffle();
        }

        #endregion

        #region Dealing

        /// <summary>
        /// Returns the BoinCard at the top of the deck and removes it
        /// </summary>
        public BoinCard dealCard() {
            BoinCard card = this.cards[0];
            this.cards.RemoveAt(0);

            return card;
        }

        /// <summary>
        /// Returns a BoinCard at a random position within the deck and removes it
        /// </summary>
        public BoinCard dealRandomCard() {
            int index = this._ran.Next(this.cards.Count);
            BoinCard card = this.cards[index];
            this.cards.RemoveAt(index);

            return card;
        }

        /// <summary>
        /// Returns an array of BoinCards from the top of the deck and removes them
        /// </summary>
        /// <param name="size">Size of the array returned</param>
        public BoinCard[] dealHandArray(int size) {
            BoinCard[] hand = new BoinCard[size];

            for (int x = 0; x < size; x++) {
                hand[x] = this.cards[0];
                this.cards.RemoveAt(0);
            }

            return hand;
        }

        /// <summary>
        /// Returns a list of BoinCards from the top of the deck and removes them
        /// </summary>
        /// <param name="size">Size of the list returned</param>
        public List<BoinCard> dealHandList(int size) {
            List<BoinCard> hand = new List<BoinCard>();

            for (int x = 0; x < size; x++) {
                hand.Add(this.cards[0]);
                this.cards.RemoveAt(0);
            }

            return hand;
        }

        #endregion

        #endregion

        #region Getters

        public bool isShuffled() {
            return this._isShuffled;
        }

        public int cardCount() {
            return this.cards.Count;
        }

        public bool hasCards() {
            return (this.cards.Count > 0);
        }

        #endregion

        #region Setters

        public void setCardBackPath(string path) {
            this.cardBack = Image.FromFile(path);
        }

        #endregion
    }
}
