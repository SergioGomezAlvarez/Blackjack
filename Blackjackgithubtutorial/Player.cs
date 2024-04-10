using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjackgithubtutorial
{
    public class Player
    {
        private static List<string> availableNames = new List<string> { "Niek", "Melvin", "Robert", "Erik", "Bart", "Patrick de Rozario", "Marco" };

        public string Name { get; private set; }
        public List<Hand> Hands { get; private set; }

        public Player()
        {
            Name = GenerateRandomName();
            Hands = new List<Hand>();
        }

        private string GenerateRandomName()
        {
            Random random = new Random();
            int index = random.Next(availableNames.Count);
            string name = availableNames[index];
            availableNames.RemoveAt(index);
            return name;
        }
    }
}
