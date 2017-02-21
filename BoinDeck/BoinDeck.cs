using System;
using System.Collections.Generic;
using System.Drawing;

namespace BoinDeckNS {

    /// <summary>
    /// Represents a deck of BoinCards, with methods for adding, dealing, and shuffling
    /// </summary>
    public class BoinDeck {

        #region Vars

        public List<BoinCard> cards { get; private set; }
        public Image cardBack  { get; set; }
        public bool isShuffled { get; private set; }
        public bool hasCards {
            get {
                return cards.Count > 0;
            }
        }

        public int cardCount {
            get {
                return cards.Count;
            }
        }

        string[] _suits = { "Clubs", "Spades", "Hearts", "Diamonds" };

        private Random _ran = new Random();

        #endregion

        #region Constructors & Related Methods

        public BoinDeck(Image cardBack, bool shuffled = false, int numberOfDecks = 1) {
            this.cardBack = cardBack;
            initProperties(shuffled, numberOfDecks);
        }

        public BoinDeck(string cardBackPath, bool shuffled = false, int numberOfDecks = 1) {
            cardBack = Image.FromFile(cardBackPath);
            initProperties(shuffled, numberOfDecks);
        }

        public BoinDeck(bool shuffled = false, int numberOfDecks = 1) {
            cardBack = Properties.Resources.cardback; // Default cardback
            initProperties(shuffled, numberOfDecks);
        }

        private void initProperties(bool shuffled, int numberOfDecks) {
            cards = new List<BoinCard>();

            if (numberOfDecks > 0) {
                addDecks(numberOfDecks);
            }

            if (shuffled) {
                shuffle();
            }
        }

        #endregion

        #region Deck Methods

        #region Misc

        /// <summary>
        /// Shuffles the deck, arranging its cards in random order
        /// </summary>
        /// <remarks>Not an in-place shuffle</remarks>
        public void shuffle() {

            // copy the deck into tmpDeck
            List<BoinCard> tmpDeck = new List<BoinCard>(cards);
            cards.Clear();

            int total = tmpDeck.Count;
            for (int x = 0; x < total; x++) {

                // pick a random card from tmpDeck
                int ranIndex = _ran.Next(tmpDeck.Count);

                // add it into the main deck
                cards.Add(tmpDeck[ranIndex]);

                // remove it from tmpDeck
                tmpDeck.RemoveAt(ranIndex);
            }

            isShuffled = true;
        }

        public void clearCards() {
            cards.Clear();
        }

        #endregion

        #region Adding

        /// <summary>
        /// Adds complete deck(s) of default BoinCards to the deck
        /// </summary>
        public void addDecks(int numberOfDecks) {

            // foreach suit
            for (int x = 0; x < _suits.Length; x++) {

                // for each card in the suit
                for (int y = 1; y < 14; y++) {

                    // add that card to the deck
                    cards.Add(
                        new BoinCard(
                            y, // value
                            _suits[x], // suit

                            // corresponding image from Resources
                            (Image)Properties.Resources.ResourceManager.GetObject(
                                "_" +
                                y.ToString() + // Value
                                "_of_" + 
                                _suits[x].ToLower() // Suit
                            )
                        )
                    );
                }
            }
        }

        /// <summary>
        /// Adds a BoinCard to the deck
        /// </summary>
        public void addCard(BoinCard card) {
            cards.Add(card);
        }

        /// <summary>
        /// Adds a random BoinCard to the deck
        /// </summary>
        public void addRandomCard() {
            cards.Add(new BoinCard(
                _ran.Next(1, 14), 
                _suits[_ran.Next(4)]
            ));
        }

        /// <summary>
        /// Adds an array of BoinCards to the deck
        /// </summary>
        public void addCards(BoinCard[] cards) {
            this.cards.AddRange(cards);
        }

        /// <summary>
        /// Adds a list of BoinCards to the deck
        /// </summary>
        public void addCards(List<BoinCard> cards) {
            this.cards.AddRange(cards);
        }

        #endregion

        #region Dealing

        /// <summary>
        /// Returns the BoinCard at the top of the deck and removes it
        /// </summary>
        public BoinCard dealCard() {
            BoinCard card = cards[0];
            cards.RemoveAt(0);

            return card;
        }

        /// <summary>
        /// Returns a BoinCard at a random position within the deck and removes it
        /// </summary>
        public BoinCard dealRandomCard() {
            int index = _ran.Next(cards.Count);
            BoinCard card = cards[index];
            cards.RemoveAt(index);

            return card;
        }

        /// <summary>
        /// Returns an array of BoinCards from the top of the deck and removes them
        /// </summary>
        /// <param name="size">Size of the array returned</param>
        public BoinCard[] dealHandArray(int size) {
            BoinCard[] hand = new BoinCard[size];

            for (int x = 0; x < size; x++) {
                hand[x] = cards[0];
                cards.RemoveAt(0);
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
                hand.Add(cards[0]);
                cards.RemoveAt(0);
            }

            return hand;
        }

        #endregion

        #endregion
    }
}
