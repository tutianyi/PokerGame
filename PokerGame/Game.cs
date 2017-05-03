using System.Collections.Generic;

namespace PokerGame
{
    public class Game
    {
        public Game(Dealer dealer, IList<Player> players)
        {
            Dealer = dealer;
            Players = players;
        }

        public Dealer Dealer { get; private set; }
        public IList<Player> Players { get; private set; }
    }
}