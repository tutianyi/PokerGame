using System;
using System.Collections;
using System.Collections.Generic;

namespace PokerGame
{
    public class PlayerCollection : IEnumerable<Player>
    {
        public IList<Player> Players { get; set; }
        public Player Next { get; set; }

        public PlayerCollection(params Player[] players)
        {
            Players = players;
            Next = Players[0];
        }

        public IEnumerator<Player> GetEnumerator()
        {
            int index = Players.IndexOf(Next);
            for(int i=index; i<index+Players.Count; i++)
            {
                Next = Players[(i + 1)%Players.Count];
                yield return Players[i%Players.Count];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}