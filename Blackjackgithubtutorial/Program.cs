using Blackjackgithubtutorial;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Casino Royale!");
        Console.WriteLine("Je bevindt je nu in een veilige test omgeving.");
        Console.WriteLine("Hoeveel spelers wil je tegen spelen?");

        Deck deck = new Deck();

        Console.WriteLine("Het originele deck bevat de volgende kaarten:");
        deck.PrintDeck();

        Console.WriteLine("\nHet deck wordt geshuffled...");
        deck.ShuffleDeck();

        Console.WriteLine("\nHet gesufflede deck bevat de volgende kaarten:");
        deck.PrintDeck();
    }
}
