using System;
using System.Collections.Generic;

namespace PokerGame
{
    public class BigBomb : CardGroup
    {
        public BigBomb(IList<Card> cards, Card newCard)
            : base(cards, newCard)
        {
            Rank = 4;
        }

        public override CardGroup UpRank(Card card)
        {
            throw new InvalidOperationException("不能再升级");
        }
    }
}