﻿using System;
using System.Collections.Generic;
using System.Linq;
using PokerGame;

namespace PokerGameUI
{
    public class Game
    {
        public Game(Dealer dealer, params Player[] players)
        {
            Dealer = dealer;
            Players = new PlayerCollection(players);
        }

        public Dealer Dealer { get; private set; }
        public PlayerCollection Players { get; private set; }

        public void Run()
        {
            while(!Dealer.Empty() || Players.Next.Hands.Count>0)
            {
                //摸牌阶段
                Console.WriteLine("============================================");
                Console.WriteLine("                  开始摸牌                  ");
                foreach (var player in Players)
                {
                    player.TouchCards(Dealer);
                    Console.WriteLine(player.ToString());
                }

                //出牌阶段
                Console.WriteLine("============================================");
                Console.WriteLine("                  出牌阶段                  ");
                CardGroup againstCard = CardGroup.Null();
                int passedCount = 0;
                do
                {
                    foreach(var player in Players)
                    {
                        var candidates = player.CandidateShowCards(againstCard);
                        if (candidates.Count > 0)
                        {
                            player.ShowCard(candidates[1]);
                            againstCard = candidates[1];
                            Console.WriteLine("{0}: {1}", player.Name, candidates[1]);
                            passedCount = 0;
                        }
                        else
                        {
                            passedCount++;
                        }
                        if (passedCount >= Players.Count() - 1)
                            break;
                    }
                } while (passedCount < Players.Count()-1);

                //结束阶段
                Console.WriteLine("============================================");
                Console.WriteLine("                  回合结束                  ");
                foreach (var player in Players)
                {
                    Console.WriteLine("{0}: {1}", player.Name, player.CardHeap.Count);
                }
                Console.WriteLine("============================================");
                Console.ReadLine();
            }

            Console.WriteLine("============================================");
            Console.WriteLine("                  游戏结束                  ");
            foreach (var player in Players)
            {
                Console.WriteLine("{0}: {1}", player.Name, player.CardHeap.Count);
            }
            Console.WriteLine("============================================");
        }
    }
}