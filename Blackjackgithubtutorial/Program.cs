
namespace Blackjackgithubtutorial
{

    public class Program
    {
        public static void Main(string[] args)
        {
            // Print a request for message.
            Console.WriteLine("THIS IS CASINO ROYALE");

            Console.WriteLine("THIS IS BLACKJACK, WHAT CARD DO YOU WANT?: ");

            // Assign a new string variable. The value is the command we want to use.
            string message = "\n" + Console.ReadLine();

            // Print out the message we gave.
            Console.WriteLine("HERE IS THE CARD YOU CHOSE: " + "\n" + message);

        }
    }

}