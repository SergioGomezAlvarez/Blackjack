namespace Blackjackgithubtutorial
{
    using System;
    using System.Collections.Generic;
    public class Deck
    {
        private List<Card> cards;
        private Random random;


        public Deck()
        {
            cards = new List<Card>();
            random = new Random();

            InitializeDeck();
        }

        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "King", "Queen"};


            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    Card card = new Card(value, suit);
                    cards.Add(card);
                }
            }
        }

        public void ShuffleDeck()
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
        public void PrintDeck()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine("Value: " + card.GetValue() + ", Suit: " + card.GetSuit());
            }
        }
    }
}