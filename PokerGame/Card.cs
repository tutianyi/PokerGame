using System;
using System.Collections.Generic;

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
            return Dics[card1.Point] == Dics[card2.Point];
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        public static bool operator >=(Card card1, Card card2)
        {
            return Dics[card1.Point] >= Dics[card2.Point];
        }

        public static bool operator <=(Card card1, Card card2)
        {
            return Dics[card1.Point] <= Dics[card2.Point];
        }

        public static bool operator <(Card card1, Card card2)
        {
            return Dics[card1.Point] < Dics[card2.Point];
        }

        public static bool operator >(Card card1, Card card2)
        {
            return Dics[card1.Point] > Dics[card2.Point];
        }

        public static IDictionary<string, int> Dics =
            new Dictionary<string, int>()
                {
                    {"7", 77},
                    {"鬼", 60},
                    {"5", 55},
                    {"2", 42},
                    {"3", 33},
                    {"A", 21},
                    {"K", 13},
                    {"Q", 12},
                    {"J", 11},
                    {"10", 10},
                    {"9", 9},
                    {"8", 8},
                    {"6", 6},
                    {"4", 4},
                };
    }
}
