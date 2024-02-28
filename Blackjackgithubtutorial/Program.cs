using System;

namespace Blackjackgithubtutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Print een verzoek voor een bericht.
            Console.WriteLine("DIT IS CASINO ROYALE");
            Console.WriteLine("Je bevindt je nu in een veilige omgeving waar je kunt oefenen." + "\n");

            int spelers;  // Declareer spelers buiten de if-blokken zodat het beschikbaar is in het hele scope.

            do
            {
                Console.WriteLine("Hoeveel mensen wil je tegen spelen?");

                // Lees de invoer als een string.
                string input = Console.ReadLine();

                // Probeer de ingevoerde waarde om te zetten naar een getal (int).
                if (int.TryParse(input, out spelers))
                {
                    if (spelers >= 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ongeldige invoer. Het aantal spelers mag niet gelijk zijn aan of groter zijn dan 7.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Dit is het aantal spelers dat speelt: " + spelers);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Set foreground color to red
                    Console.WriteLine("Ongeldige invoer. Voer een geldig getal in.");
                    Console.ResetColor(); // Reset color to default
                }

            } while (spelers >= 5);  // Herhaal de invoerprompt totdat een geldige waarde is ingevoerd.

            // Voeg hier de rest van je code toe na het verkrijgen van een geldige invoer.
        }
    }
}
