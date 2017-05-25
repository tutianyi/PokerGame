using System.Collections.Generic;

namespace PokerGame
{
    public class Null : CardGroup
    {
        public Null()
        {
            Rank = 0;
        }

        public override CardGroup UpRank(Card card)
        {
            return new Single(card);
        }
    }
}