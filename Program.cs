using GameOfWar;

// Create an instance of the GameState class
GameState game = new GameState();
// Shuffle CardDeck within your instance
game.CardDeck.Shuffle();
// Deal 26 cards each from CardDeck to your instance's PlayerDeck and ComputerDeck
game.PlayerDeck.PushCards(game.CardDeck.Deal(26));
game.ComputerDeck.PushCards(game.CardDeck.Deal(26));

// Create a function with the signature: static bool PlayCards(GameState state, int playerCardIndex)
// The function should:
//     Pull the card at playerCardIndex from state.PlayerDeck
//     Pull the card at index 0 from state.ComputerDeck
//     Compare the two cards
//         If the player card is higher, the player gets both cards along with any in state.TableDeck
//         If the computer card is higher, the computer gets both cards along with any in state.TableDeck
//         If the player and computer cards are the same, both cards go into state.TableDeck
//     Check whether either state.PlayerDeck or state.ComputerDeck are empty
//         If the computer deck is empty, the player wins and state.Winner should be set to "Computer"
//         If the player deck is empty, the computer wins and state.Winner should be set to "Player"
//     return true
static bool PlayCards(GameState state, int playerCardIndex)
{
    Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);
    if (playerCard > computerCard)
    {
        state.PlayerDeck.PushCard(playerCard);
        state.PlayerDeck.PushCard(computerCard);
        state.PlayerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    if (playerCard < computerCard)
    {
        state.ComputerDeck.PushCard(computerCard);
        state.ComputerDeck.PushCard(playerCard);
        state.ComputerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    if (playerCard == computerCard)
    {
        state.TableDeck.PushCard(playerCard);
        state.TableDeck.PushCard(computerCard);
    }
    if (state.ComputerDeck.Count == 0)
    {
        state.Winner = "Computer";
    }
    if (state.PlayerDeck.Count == 0)
    {
        state.Winner = "Player";
    }
    return true;
}

// Call Lib.RunGame(), passing two parameters: the state object you instantiated above and the name of your PlayCards function
Lib.RunGame(game, PlayCards);
namespace GameOfWar
{
    public class GameState
    {
        // Create a public Deck property called CardDeck
        public Deck CardDeck;

        // Create a public Deck property called PlayerDeck
        public Deck PlayerDeck;

        // Create a public Deck property called ComputerDeck
        public Deck ComputerDeck;

        // Create a public Deck property called TableDeck
        public Deck TableDeck;

        // Create a public string property called Winner
        public string Winner;


        // Create a public constructor that accepts no parameters. It should:
        //    Initialize Winner to be empty (not null)
        //    Initialize CardDeck to be a new, fresh deck of 52 cards
        //    Initialize PlayerDeck, ComputerDeck, and TableDeck to be empty Deck objects (no cards)

        public GameState()
        {
            Winner = "";
            CardDeck = new Deck(null);
            PlayerDeck = new Deck(null, true);
            ComputerDeck = new Deck(null, true);
            TableDeck = new Deck(null, true);
        }
    }
}
