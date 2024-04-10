using Blackjackgithubtutorial;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Casino Royale!");
        Console.WriteLine("Je bevindt je nu in een veilige test omgeving.");

        int numberOfPlayers = GetNumberOfPlayers();

        Console.WriteLine($"\nJe speelt tegen {numberOfPlayers} spelers");

        List<Player> players = CreatePlayers(numberOfPlayers);

        Console.WriteLine("\nDe namen van de spelers zijn:");
        foreach (var player in players)
        {
            Console.WriteLine(player.Name);
        }

        Deck deck = new Deck();

        Console.WriteLine("\nHet deck wordt geshuffled...");
        deck.ShuffleDeck();

        Console.WriteLine("\nHet deck is geshuffled");
    }

    static int GetNumberOfPlayers()
    {
        int numberOfPlayers;
        while (true)
        {
            Console.Write("Hoeveel spelers wil je tegen spelen? (1-4): ");
            if (int.TryParse(Console.ReadLine(), out numberOfPlayers) && numberOfPlayers >= 1 && numberOfPlayers <= 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Voer een getal tussen 1 en 4 in.");
            }
        }
        return numberOfPlayers;
    }

    static List<Player> CreatePlayers(int numberOfPlayers)
    {
        List<Player> players = new List<Player>();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            players.Add(new Player());
        }
        return players;
    }
}
