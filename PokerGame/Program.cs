using System;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            dealer.Shuffle();

            for(int i=0;i<Dealer.Count;i++)
            {
                Console.Write(dealer.Deal());
                Console.Write('\t');
            }
            
            Console.Read();
        }
    }
}
