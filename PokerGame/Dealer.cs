using System;

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
            cards = new Card[Count];
            
            cards[0] = new Card("王", "大");
            cards[1] = new Card("王", "小");
            for(int i=0;i<numbers.Length;i++)
            {
                cards[numbers.Length * 0 + i + 2] = new Card("黑桃", numbers[i]);
                cards[numbers.Length * 1 + i + 2] = new Card("红桃", numbers[i]);
                cards[numbers.Length * 2 + i + 2] = new Card("梅花", numbers[i]);
                cards[numbers.Length * 3 + i + 2] = new Card("方块", numbers[i]);
            }

            index = 0;
        }

        private Card[] cards;

        private int index;

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
            return cards[index++];
        }
    }
}
