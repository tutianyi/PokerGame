using System;
using System.Collections.Generic;

namespace PokerGame
{
    public class Dealer
    {
        public const int Count = 54;

        public Dealer()
        {
            string[] numbers = new string[]
                                   {
                                       "A","2","3","4",
                                       "5","6","7","8",
                                       "9","10","J","Q","K"
                                   };
            cards = new List<Card>();
            
            cards.Add(new Card("大", "鬼"));
            cards.Add(new Card("小", "鬼"));
            foreach (var number in numbers)
                cards.Add(new Card("黑桃", number));
            foreach (var number in numbers)
                cards.Add(new Card("红桃", number));
            foreach (var number in numbers)
                cards.Add(new Card("梅花", number));
            foreach (var number in numbers)
                cards.Add(new Card("方块", number));
        }

        private IList<Card> cards;

        public void Shuffle()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 100; i++)
            {
                Swap(r.Next(Count), r.Next(Count));
            }
        }

        private void Swap(int place1, int place2)
        {
            Card temp = cards[place1];
            cards[place1] = cards[place2];
            cards[place2] = temp;
        }

        public Card Deal()
        {
            var card = cards[0];
            cards.Remove(card);
            return card;
        }

        public int SurplusCount()
        {
            return cards.Count;
        }

        public bool Empty()
        {
            return cards.Count == 0;
        }
    }
}