using System;
using System.Collections.Generic;

namespace BlackJack
{
    /*
     * Aaron Salazar's Black Jack game
     * 
     * It still needs a lot of work but the basic game play is there.
     * This is about 4 hours of work.
     */

    class MainClass
    {
        public static void Main(string[] args)
        {
            // Game setup
            // A game has a dealer, players and a shuffled deck
            // The dealer and all players have a hand
            var dealer = new Dealer()
            {
                name = "Dealer",
                hands = new List<Hand>() { new Hand() }
            };

            var players = new List<Player>()
            {
                new Player(){ name = "Player", hands = new List<Hand>()
                    { new Hand() }
                }
            };

            var game = new Game(players, dealer, 1);

            // Deal from top of deck to all players
            game.Deal();

            // Show the cards and current scores
            ShowCurrentGameState(game, false);

            // Wait for user input
            ConsoleKeyInfo userKey;
            do
            {
                userKey = Console.ReadKey(true);

                // Hit
                if(userKey.Key == ConsoleKey.H)
                {
                    game.Hit(players[0].hands[0]);
                    ShowCurrentGameState(game, false);
                }
                // Stand
                else if(userKey.Key == ConsoleKey.S)
                {
                    game.Stand(dealer.hands[0]);
                    RevealDealerCards(dealer);
                    ShowCurrentGameState(game, true);
                    Environment.Exit(0);
                }
            } while (userKey.Key != ConsoleKey.Escape);
        }

        // Prints out the current hands, score and key commands
        public static void ShowCurrentGameState(Game game, bool reveal)
        {
            ShowDealer(game.dealer, reveal);
            ShowPlayers(game.players);
            ShowOptions();
            IsWinner(game);

        }

        public static void RevealDealerCards(Dealer dealer)
        {
            foreach (var card in dealer.hands[0].cards)
            {
                card.isHidden = false;
            }
        }

        public static void ShowDealer(Dealer dealer, bool reveal)
        {
            Console.Write("Dealer: ");
            foreach (var hand in dealer.hands)
            {
                foreach (var card in hand.cards)
                {
                    if(card.isHidden)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write(card.name + " ");   
                    }
                }
                if (reveal)
                {
                    Console.Write("(" + dealer.hands[0].score + ")");
                }
            }
        }

        public static void ShowPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.Write("\n" + player.name + ": ");
                foreach (var hand in player.hands)
                {
                    foreach (var card in hand.cards)
                    {
                        Console.Write(card.name + " ");
                    }
                    Console.Write("(" + hand.score + ")");
                }
            }
        }

        public static void ShowOptions()
        {
            Console.WriteLine("\n\n-- [h]: hit, [s]: stand --");
        }

        // Determines what to print when a winner is considered.
        public static void IsWinner(Game game)
        {
            var playerWins = game.DeterminePlayerWinner(game.players[0].hands[0]);
            var dealerWins = game.DeterminePlayerWinner(game.dealer.hands[0]);

            if (playerWins != null)
            {
                if (playerWins.Value)
                {
                    Console.WriteLine("\nYou win!");
                }
                else
                {
                    Console.WriteLine("\nYou lose.");
                }
            }
            if(dealerWins != null)
            {
                if (dealerWins.Value)
                {
                    Console.WriteLine("\nYou lose.");
                }
                else
                {
                    Console.WriteLine("\nYou win!");
                }
            }
        }
    }
}
