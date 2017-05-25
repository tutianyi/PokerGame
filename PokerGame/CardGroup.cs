using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    public abstract class CardGroup
    {
        public virtual IList<Card> Cards { get; set; }
        public virtual int Rank { get; protected set; }

        protected CardGroup()
        {
            Cards = new List<Card>();
        }

        protected CardGroup(IList<Card> cards, Card newCard)
        {
            Cards = new List<Card>();
            foreach (var card in cards)
                Cards.Add(card);
            Cards.Add(newCard);
        }

        public static bool operator >=(CardGroup first, CardGroup second)
        {
            if (first.GetType().Equals(second.GetType()))
                return first.Cards[0] >= second.Cards[0];
            return first.Rank > second.Rank;
        }

        public static bool operator <=(CardGroup first, CardGroup second)
        {
            throw new InvalidOperationException("不支持该操作");
        }

        public abstract CardGroup UpRank(Card card);

        public static CardGroup Null()
        {
            return new Null();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in Cards)
                sb.Append(card).Append(" ");
            return sb.ToString();
        }
    }
}