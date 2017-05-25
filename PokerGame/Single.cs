using System.Collections.Generic;

namespace PokerGame
{
    public class Single : CardGroup
    {
        public Single(Card newCard) : base(new List<Card>(), newCard)
        {
            Rank = 1;
        }

        public override CardGroup UpRank(Card card)
        {
            return new Double(Cards, card);
        }
    }
}