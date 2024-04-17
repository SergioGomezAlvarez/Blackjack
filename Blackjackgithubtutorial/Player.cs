using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Blackjackgithubtutorial
{
    public class Player
    {
        private static List<string> availableNames = new List<string> { "Niek", "Melvin", "Robert", "Erik", "Bart", "Patrick de Rozario", "Marco" };

        public string Name { get; private set; }
        public List<Hand> Hands { get; private set; }
        private bool isDone; 


        public Player()
        {
            Name = GenerateRandomName();
            Hands = new List<Hand>();
            Hands.Add(new Hand());
        }


        private string GenerateRandomName()
        {
            if (availableNames.Count == 0)
            {
                ResetAvailableNames();
            }
            Random random = new Random();
            int index = random.Next(availableNames.Count);
            string name = availableNames[index];
            availableNames.RemoveAt(index);
            return name;
        }

        private void ResetAvailableNames()
        {
            availableNames = new List<string> { "Niek", "Melvin", "Robert", "Erik", "Bart", "Patrick de Rozario", "Marco" };
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
        public Player(string name)
        {
            Name = name;
            Hands = new List<Hand>();
            Hands.Add(new Hand());
        }

        public bool MakeDecision()
        {
            string decision = Console.ReadLine().ToLower();

            while (decision != "hit" && decision != "stand")
            {

            }

            if (decision == "stand")
            {
                isDone = true;
            }

            return decision == "hit";
        }


        public bool MakeRandomDecision()
        {
            Random random = new Random();
            bool hit = random.Next(2) == 0; 

            if (!hit)
            {
                isDone = true; 
            }

            return hit; 
        }


        
        public int CalculateTotalPoints()
        {
            int totalPoints = 0;
            foreach (var card in Hands[0].Cards)
            {
                totalPoints += CalculateCardValue(card);
            }
            // if more than 21 -> ace value naar 1 ipv 11
            return totalPoints;
        }

        private int CalculateCardValue(Card card)
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

        public void SetDone()
        {
            isDone = true;
        }

        public bool IsDone()
        {
            return isDone;
        }

    }
}
