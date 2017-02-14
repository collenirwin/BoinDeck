using System;
using System.Collections.Generic;
using System.Drawing;

namespace BoinDeckNS {
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
                addDecks(numberOfDecks, shuffled);
            }
        }

        #endregion

        #region Deck Methods

        #region Misc

        /// <summary>
        /// Shuffles the deck, arranging its cards in random order
        /// </summary>
        public void shuffle() {
            List<BoinCard> tmpDeck = new List<BoinCard>(cards);
            cards.Clear();

            int total = tmpDeck.Count;
            for (int x = 0; x < total; x++) {
                int ranIndex = _ran.Next(tmpDeck.Count);
                cards.Add(tmpDeck[ranIndex]);
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
        public void addDecks(int numberOfDecks, bool reshuffle = false) {
            for (int x = 0; x < _suits.Length; x++) {
                for (int y = 1; y < 14; y++) {
                    cards.Add(new BoinCard(y, _suits[x], 
                        (Image)Properties.Resources.ResourceManager.GetObject(
                        "_" +
                        y.ToString() + // Value
                        "_of_" + 
                        _suits[x].ToLower() // Suit
                    )));
                }
            }

            if (reshuffle) {
                shuffle();
            }
        }

        /// <summary>
        /// Adds a BoinCard to the deck
        /// </summary>
        public void addCard(BoinCard card, bool reshuffle = false) {
            cards.Add(card);

            if (reshuffle) {
                shuffle();
            }
        }

        /// <summary>
        /// Adds a random BoinCard to the deck
        /// </summary>
        public void addRandomCard(bool reshuffle = false) {
            cards.Add(new BoinCard(
                _ran.Next(1, 14), 
                _suits[_ran.Next(4)]
                ));

            if (reshuffle) {
                shuffle();
            }
        }

        /// <summary>
        /// Adds an array of BoinCards to the deck
        /// </summary>
        public void addCards(BoinCard[] cards, bool reshuffle = false) {
            this.cards.AddRange(cards);

            if (reshuffle) {
                shuffle();
            }
        }

        /// <summary>
        /// Adds a list of BoinCards to the deck
        /// </summary>
        public void addCards(List<BoinCard> cards, bool reshuffle = false) {
            this.cards.AddRange(cards);

            if (reshuffle) {
                shuffle();
            }
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
