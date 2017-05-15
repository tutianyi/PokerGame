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
            Player playerA = new Player("A");
            Player playerB = new Player("B");

            Game game = new Game(dealer, playerA, playerB);
            game.Run();
            
            Console.ReadLine();
        }
    }
}