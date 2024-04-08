using Blackjackgithubtutorial;
using System;

class Program
{
    static void Main(string[] args)
    {
        Deck deck = new Deck();

        Console.WriteLine("Het deck bevat de volgende kaarten:");
        deck.PrintDeck();
    }
}