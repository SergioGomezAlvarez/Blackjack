using System;
using System.Collections.Generic;

namespace Blackjackgithubtutorial
{
    public class Dealer : Player
    {
        public Dealer() : base("Dealer")
        {
        }

        public void ShowCards()
        {
            Console.WriteLine($"Kaarten van speler {Name}:");
            foreach (var card in Hands[0].Cards)
            {
                if (card.IsFaceUp)
                {
                    Console.WriteLine($"   {card.GetValue()} van {card.GetSuit()}");
                }
                else
                {
                    string value = card.GetValue();
                    Console.WriteLine($"Gesloten kaart");
                }
            }
        }
        public void DealCardsToSelf(Deck deck)
        {
            int numberOfCardsToDeal = 2;
            for (int i = 0; i < numberOfCardsToDeal; i++)
            {
                Card card = deck.DrawCard();
                card.IsFaceUp = (i == 0) ? false : true;
                Hands[0].Cards.Add(card);
            }

            Console.WriteLine("Kaarten zijn aan de dealer uitgedeeld.");
        }

        public bool ShouldHit()
        {
            int totalPoints = CalculateTotalPoints();

            return totalPoints < 17;
        }

        public int CalculateTotalPoints()
        {
            int totalPoints = 0;
            foreach (var card in Hands[0].Cards)
            {
                totalPoints += CalculateCardValue(card);
            }
            return totalPoints;
        }
        public int CalculateCardValue(Card card)
        {
            string value = card.GetValue();
            switch (value)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    return int.Parse(value);
                case "10":
                case "Jack":
                case "Queen":
                case "King":
                    return 10;
                case "Ace":

                    return 11;
                default:
                    return 0;
            }
        }
    }
}