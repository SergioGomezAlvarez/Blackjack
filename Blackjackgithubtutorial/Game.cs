using Blackjackgithubtutorial;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

public class Game
{
    private Deck deck;
    private List<Player> players;
    int score = 10;

    public Game(int numberOfPlayers, List<Player> initialPlayers)
    {
        players = initialPlayers;
        deck = new Deck();
        Console.WriteLine("\nHet deck wordt geshuffled...");
        deck.ShuffleDeck();
        Console.WriteLine("\nHet deck is geshuffled");
    }
    public Deck GetDeck()
    {
        return deck;
    }
    public void DealCardsToPlayers()
    {
        int numberOfCardsPerPlayer = 0;
        while (numberOfCardsPerPlayer != 2)
        {
            Console.Write("Hoeveel kaarten wil je uitdelen aan elke speler?: ");
            if (!int.TryParse(Console.ReadLine(), out numberOfCardsPerPlayer) || numberOfCardsPerPlayer != 2)
            {

                score--;
                Console.WriteLine("POINT DEDUCTION. Je score is nu: " + score);
                Console.WriteLine("Je hebt niet het juiste aantal kaarten uitgedeeld. Probeer het opnieuw.");
            }
        }

        foreach (var player in players)
        {
            for (int i = 0; i < numberOfCardsPerPlayer; i++)
            {
                Card card = deck.DrawCard();
                player.Hands[0].Cards.Add(card);
            }
        }

        Console.WriteLine($"\nElke speler heeft {numberOfCardsPerPlayer} kaarten ontvangen.");

        foreach (var player in players)
        {
            Console.WriteLine($"Kaarten van speler {player.Name}:");
            foreach (var card in player.Hands[0].Cards)
            {
                Console.WriteLine($"   {card.GetValue()} van {card.GetSuit()}");
            }
        }
    }

    public bool WantToDealCardsToSelf()
    {
        while (true)
        {
            Console.Write("Wil je kaarten aan jezelf uitdelen? (ja/nee): ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "ja" || answer == "yes")
            {
                return true;
            }
            else if (answer == "nee" || answer == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Voer 'ja' of 'nee' in.");
            }
        }
    }

    public void DealCardsToSelf(Player player)
    {
        int numberOfCardsToDeal = 0;
        while (numberOfCardsToDeal != 2)
        {
            Console.Write($"Hoeveel kaarten wil {player.Name} aan zichzelf uitdelen? (moet 2 zijn): ");
            if (!int.TryParse(Console.ReadLine(), out numberOfCardsToDeal) || numberOfCardsToDeal != 2)
            {
                Console.WriteLine("Ongeldige invoer. Het aantal kaarten moet 2 zijn.");
            }
        }

        for (int i = 0; i < numberOfCardsToDeal; i++)
        {
            Card card = deck.DrawCard();
            player.Hands[0].Cards.Add(card);
        }

        Console.WriteLine($"Kaarten zijn aan {player.Name} uitgedeeld.");
    }



}