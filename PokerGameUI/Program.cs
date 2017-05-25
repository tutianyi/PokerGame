using System;
using PokerGame;

namespace PokerGameUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            dealer.Shuffle();
            Player playerA = new Computer("电脑1");
            Player playerB = new Computer("电脑2");
            Player playerC = new Computer("电脑3");
            Player people = new People("玩家", Input, Output);

            Game game = new Game(dealer, playerA, playerB, playerC, people);
            game.Run();
            
            Console.ReadLine();
        }

        static int Input()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        static void Output(string hint)
        {
            Console.Write("\t");
            Console.WriteLine(hint);
        }
    }
}