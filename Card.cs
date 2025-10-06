namespace GameOfWar
{
    public class Card
    {

        // Create a string property Suit with a private setter
        private string _suit;
        public string Suit
        {
            get { return _suit; }
            set
            {
                _suit = value;
            }
        }

        // Create an int property Rank with a private setter - values should range from 0 for a face value of 2 to 12 for an Ace
        private int _rank;
        public int Rank
        {
            get { return _rank; }
            set
            {
                _rank = value;
            }
        }

        // Create a public constructor that takes suit and rank as arguments and assigns them to Suit and Rank
        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        // Overload the > operator to compare two cards by rank
        public static bool operator >(Card c1, Card c2)
        {
            return c1.Rank > c2.Rank;
        }

        // Overload the < operator to compare two cards by rank
        public static bool operator <(Card c1, Card c2)
        {
            return c1.Rank < c2.Rank;
        }

        // Create a public string method RankString that returns a string representation of this card's rank, 2-10 and Jack, Queen, King, Ace
        public string RankString()
        {
            return $"{this.Rank} of {this.Suit}";
        }

    }
}
