using System.Collections.Generic;

namespace PokerGame
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Hands = new List<Card>();
        }

        public string Name { get; private set; }
        public IList<Card> Hands { get; private set; }
    }
}