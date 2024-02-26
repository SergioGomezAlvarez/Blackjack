
namespace Blackjackgithubtutorial
{

    public class Program
    {
        public static void Main(string[] args)
        {
            // Print a request for message.
            Console.WriteLine("Give a message: ");

            // Assign a new string variable. The value is the command we want to use.
            string message = "\n" + Console.ReadLine();

            // Print out the message we gave.
            Console.WriteLine("This is it: " + "\n" + message);
        }
    }

}