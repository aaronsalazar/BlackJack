using System;
using System.Collections.Generic;

namespace BlackJack
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var dealer = new Dealer()
            {
                name = "Dealer",
                hands = new List<Hand>() { new Hand() }
            };

            var players = new List<Player>()
            {
                new Player(){ name = "Aaron", hands = new List<Hand>()
                    { new Hand() }
                }
            };

            var game = new Game(players, dealer, 1);

            game.Deal();

            showDealer(dealer);
            showState(players);
        }

        public static void showDealer(Dealer dealer)
        {
            Console.WriteLine("Dealer");
            foreach (var hand in dealer.hands)
            {
                foreach (var card in hand.cards)
                {
                    if(card.isHidden)
                    {
                        Console.WriteLine("Card: hidden");
                    }
                    else
                    {
                        Console.WriteLine("Card: " + card.name);   
                    }
                }
            }
        }

        public static void showState(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine("player: " + player.name);
                foreach (var hand in player.hands)
                {
                    Console.WriteLine("Score: " + hand.score);
                    foreach (var card in hand.cards)
                    {
                        Console.WriteLine("Card: " + card.name);
                    }
                }
            }
        }

    }
}
