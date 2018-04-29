using System;
using System.Collections.Generic;

namespace BlackJack
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var players = new List<Player>();
            var aaron = new Player();
            aaron.name = "Aaron";
            var h = new Hand();
            aaron.hands.Add(h);
            players.Add(aaron);
            var game = new Game(players, 1);

            game.deal();

            //showState(players);

            //game.hit(players[0].hands[0]);
            //game.hit(players[0].hands[0]);

            showState(players);
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
                        Console.WriteLine("Card name: " + card.name);
                    }
                }
            }
        }

    }
}
