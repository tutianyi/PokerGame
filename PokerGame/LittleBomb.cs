using System.Collections.Generic;

namespace PokerGame
{
    public class LittleBomb : CardGroup
    {
        public LittleBomb(IList<Card> cards, Card newCard) : base(cards, newCard)
        {
            Rank = 3;
        }

        public override CardGroup UpRank(Card card)
        {
            return new BigBomb(Cards, card);
        }
    }
}