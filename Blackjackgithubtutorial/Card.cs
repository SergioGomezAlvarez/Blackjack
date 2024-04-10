namespace Blackjackgithubtutorial
{
    public class Card
    {
        private string value;
        private string suit;

        public Card(string value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public string GetValue()
        {
            return value;
        }

        public string GetSuit()
        {
            return suit;
        }
    }

}
