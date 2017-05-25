using System.Collections.Generic;

namespace PokerGame
{
    public class Double : CardGroup
    {
        public Double(IList<Card> cards, Card newCard) : base(cards, newCard)
        {
            Rank = 1;
        }

        public override CardGroup UpRank(Card card)
        {
            return new LittleBomb(Cards, card);
        }
    }
}