using System;

namespace PokerGame
{
    public class Card
    {
        public Card(string color, string point)
        {
            Color = color;
            Point = point;
        }

        public string Color { get; private set; }
        public string Point { get; private set; }

        public override string ToString()
        {
            return Color + Point;
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is Card))
                throw new ArgumentException("只能与扑克牌对象进行比较");

            var card = obj as Card;
            return this.Color == card.Color && this.Point == card.Point;
        }

        public static bool operator ==(Card card1, Card card2)
        {
            return card1.Equals(card2);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
    }
}
