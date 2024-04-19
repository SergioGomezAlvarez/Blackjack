using Blackjackgithubtutorial;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int score = 10;

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

        Game game = new Game(numberOfPlayers, players);
        game.DealCardsToPlayers();

        Dealer dealer = new Dealer();
        Deck deck = game.GetDeck();

        bool dealToSelf = game.WantToDealCardsToSelf();

        if (dealToSelf)
        {
            dealer.DealCardsToSelf(deck);
            dealer.ShowCards();
        }

        bool allPlayersDone = false;

        while (!allPlayersDone)
        {
            allPlayersDone = true;

            foreach (var player in players)
            {
                if (!player.IsDone())
                {
                    Console.WriteLine($"\n{player.Name}, het is jouw beurt.");
                    Thread.Sleep(2000);

                    bool hit = player.MakeRandomDecision();


                    while (hit)
                    {
                        Card card = deck.DrawCard();
                        player.Hands[0].Cards.Add(card);
                        player.ShowCards(); 

                        int totalPoints = player.CalculateTotalPoints();
                        if (totalPoints > 21)
                        {
                            Console.WriteLine("Bust! Einde van de ronde voor deze speler.");
                            player.SetDone();
                            break;
                        }
                        else if (totalPoints == 21)
                        {
                            Console.WriteLine("21 behaald! Einde van de ronde voor deze speler.");
                            player.SetDone();
                            break;
                        }
                        hit = player.MakeRandomDecision();
                    }
                    

                    if (!hit)
                    {
                        Console.WriteLine("Heeft gestand.");
                    }


                        if (!player.IsDone())
                    {
                        allPlayersDone = false;
                        break;
                    }
                }
            }

            if (allPlayersDone)
            {
                Console.WriteLine("\nDealer's turn:");

                dealer.Hands[0].Cards[0].IsFaceUp = true;
                dealer.ShowCards();

                int dealerTotalPoints = dealer.CalculateTotalPoints();


                string decision = "";

                while (decision.ToLower() != "stand")
                {
                    Console.Write("Wil de dealer hitten (hit) of standen (stand)? ");
                    decision = Console.ReadLine();

                    while (decision.ToLower() != "stand" && decision.ToLower() != "hit")
                    {
                        Console.WriteLine("Ongeldige keuze. Kies 'hit' om te hitten of 'stand' om te standen.");
                        Console.Write("Wil de dealer hitten (hit) of standen (stand)? ");
                        decision = Console.ReadLine();
                    }

                    if (decision.ToLower() == "hit")
                    {
                        if (dealer.CalculateTotalPoints() <= 16)
                        {
                            Card card = deck.DrawCard();
                            dealer.Hands[0].Cards.Add(card);
                            dealer.ShowCards();
                        }
                        else
                        {
                            Console.WriteLine("Niet de goede keuze");
                            score--;
                            Console.WriteLine("POINT DEDUCTION. Je score is nu: " + score);
                        }
                    }

                    if (decision.ToLower() == "stand")
                    {
                        if (dealer.CalculateTotalPoints() >= 17)
                        {
                            Console.WriteLine("Je hebt voor stand gekozen");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Niet de goede keuze");
                            score--;
                            Console.WriteLine("POINT DEDUCTION. Je score is nu: " + score);
                        }
                    }

                    if (decision.ToLower() == "stand")
                    {
                        if (dealer.CalculateTotalPoints() == 21)
                        {
                            Console.WriteLine("Je hebt 21 punten! het spel is voorbij!");
                            return;
                        }
                    }

                    if (dealer.CalculateTotalPoints() >= 21)
                    {
                        Console.WriteLine("Het spel is voorbij!");
                        return;
                    }

                }
            }
        }


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
                Console.WriteLine("Niet mogelijk. Probeer het opnieuw.");
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
