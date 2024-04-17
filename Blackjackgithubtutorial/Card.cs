namespace Blackjackgithubtutorial
{
    public class Card
    {
        private string value;
        private string suit;
        private bool isFaceUp;

        public bool IsFaceUp
        {
            get { return isFaceUp; }
            set { isFaceUp = value; }
        }
        public Card(string value, string suit)
        {
            this.value = value;
            this.suit = suit;
            this.isFaceUp = true; 

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
