namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };


        // Create a public int property Count that returns the Count value from the private collection _cards
        public int Count
        {
            get { return _cards.Count; }
        }

    // Create a private field _cards that is a List<Card>
    private List<Card> _cards;
    private List<Card> _testcards;

        // Create a public constructor that takes two parameter: a List<card> called cards and a boolean value called isEmptyDeck
        // If cards is not null and has elements in it, assign it to _cards and be done
        // If cards is null or empty:
        //     _cards should be initialized as an empty List<Card>
        //     InitializeDeck() should be called if and only if isEmptyDeck is false
        public Deck(List<Card> cards, bool isEmptyDeck = false)
    {
             _testcards = new List<Card>();
            InitializeTestDeck();
            if (cards != null)
            {
                _cards = cards;
            }
            if (cards == null || isEmptyDeck)
            {
                _cards = new List<Card>();
                if (!isEmptyDeck)
                {
                    InitializeDeck();
                }
            }
        }

        // Extra method that takes RankNames and converts them to numbers
        public int RankStringtoNames(string name)
        {
            if (name == "Ace")
            {
                return 1;
            }
            else if (name == "Jack")
            {
                return 11;
            }
            else if (name == "Queen")
            {
                return 12;
            }
            else if (name == "King")
            {
                return 13;
            }
            else
            {
                return int.Parse(name);
            }
        }

    // Create a private void method called InitializeDeck() which does the following:
    // Use RankNames and Suits in nested loops to generate all 52 combinations of rank and suit and add them to _cards
    private void InitializeDeck()
    {
        for (int i = 0; i < RankNames.Length; i++)
        {
            for (int j = 0; j < Suits.Length; j++)
            {
                Card c = new Card(Suits[j], RankStringtoNames(RankNames[i]));
                _cards.Add(c);
            }
        }
    }
        
    private void InitializeTestDeck()
    {
        for (int i = 0; i < RankNames.Length; i++)
        {
            for (int j = 0; j < Suits.Length; j++)
            {
                Card c = new Card(Suits[j], RankStringtoNames(RankNames[i]));
                _testcards.Add(c);
            }
        }
    }

    // Create a public void method called Shuffle() which shuffles (rearranges) the cards in _deck
    public void Shuffle() //IS Duplicating Cards
    {
        
        Random rand1 = new Random();
        Random rand2 = new Random();
        for (int i = 0; i < 100; i++)
        {
            int randomCard1 = rand1.Next(52);
            int randomCard2 = rand2.Next(52);
            while (randomCard2 == randomCard1 || (Math.Abs(randomCard1 - randomCard2) <= 5))
            {
                rand2 = new Random();
                randomCard2 = rand2.Next(52);
            }

            int randomRange = rand1.Next(5) + 1;
            if (randomCard1 + randomRange > 52) randomRange = 52 - randomCard1;
            if (randomCard2 + randomRange > 52) randomRange = 52 - randomCard2;


            List<Card> randomCollection1 = _cards.GetRange(randomCard1, randomRange);
            List<Card> randomCollection2 = _cards.GetRange(randomCard2, randomRange);

            _cards.InsertRange(randomCard2, randomCollection1);
            _cards.RemoveRange(randomCard2 + randomRange, randomRange);

            _cards.InsertRange(randomCard1, randomCollection2);
            _cards.RemoveRange(randomCard1 + randomRange, randomRange);

             
        
            
        }
        //spilts the deck in half and then shuffle halfs with each other

        for (int i = 0; i < 100; i++)
        {
            List<Card> firstHalf = _cards.GetRange(0, 26);
            List<Card> secondHalf = _cards.GetRange(26, 26);



            for (int j = 0; j < 26; j++)
            {
                _cards[2 * j + (i % 2 == 0 ? 0 : 1)] = firstHalf[j];
                _cards[2 * j + (i % 2 == 0 ? 1 : 0)] = secondHalf[j];
            }
        }

        // code to check for duplication error no longer in use but keeping just in case
        // List<bool> isCardsinDeck = new List<bool>();
        //     bool didShuffleMessupDeck = false;
        //     foreach (Card b in _testcards)
        //         {
        //             int countingTrue = 0;
        //             foreach (Card c in _cards)
        //             {
        //                 bool isCardinDeck = false;
        //                 if (b.ToString() == c.ToString()) isCardinDeck = true;
        //                 if (isCardinDeck) countingTrue += 1;
        //                 isCardsinDeck.Add(isCardinDeck);
        //             }
        //             if(countingTrue >= 2)
        //             {
        //                 didShuffleMessupDeck = true;
        //             }
        //         }
        //         Console.WriteLine($"does the shuffled deck have all the same cards in base deck?: {didShuffleMessupDeck}"); //check if two things equal

    }
        
    //Prints the the deck in the order it is given in
    public void PrintDeck()
    {
        
        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(_cards[i].ToString());
        }
    } 

        // Create a public method CardAtIndex which takes an int parameter for the index of a card and
        // returns the card at the index specified, or throws IndexOutOfRangeException if index is too large or too small
    public Card CardAtIndex(int index)
    {
        if (index > Count || index < 0)
            throw new IndexOutOfRangeException("You cant choose a card number lower than 0 or higher than 52 as their are only 52 cards in the deck");
        return _cards[index];
    }

        // Create a public method PullCardAtIndex which does exactly the same thing as CardAtIndex
        // with the additional feature that it _removes_ the card from the deck
    public Card PullCardAtIndex(int index)
    {
        if (index > Count || index < 0)
            throw new IndexOutOfRangeException("You cant choose a card number lowerthan 0 or higher than 51 as their are only 52 cards in the deck");
        Card PulledCard = CardAtIndex(index);
        _cards.Remove(_cards[index]);
        return PulledCard;
    }

        // Create a public method PullAllCards that returns a list of all of the cards in the deck
        // and removes them all from the deck, leaving it empty
    public List<Card> PullAllCards()
    {
        List<Card> AllCards = new List<Card>();
        AllCards.AddRange(_cards);
        _cards.Clear();
        return AllCards;
    } 

        // Create a public method PushCard that accepts a Card as a parameter and adds it to _deck
    public void PushCard(Card newCard)
    {
        _cards.Add(newCard);
    }

    // Create a public method PushCards that accepts a List<Card> as a parameter and adds the list to _cards
    // Be sure to use AddRange and not Add
    public void PushCards(List<Card> newCards)
    {
        _cards.AddRange(newCards);
    }

        // Create a public method Deal that accepts an integer representing the number of cards to deal
        // and then removes that many cards from the deck, returning them as a List<Card>
        // Be sure to check the size of _deck against the number of cards requested so you don't go out
        // of bounds
    public List<Card> Deal(int numDeal)
    {
        if (numDeal > Count)
            throw new IndexOutOfRangeException($"You can't deal {numDeal} card(s) There are only {Count} card(s) left in the deck");

        List<Card> cardDeal = _cards.GetRange(0, numDeal);
        _cards.RemoveRange(0, numDeal);
        return cardDeal;
    }
}
