using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        public Game(List<Player> _players, Dealer _dealer, int? numberOfDecks)
        {
            index = 0;
            players = _players;
            dealer = _dealer;
            deck = new Deck(numberOfDecks ?? 1);
        }

        public List<Player> players { get; set; }
        public Dealer dealer { get; set; }
        public Deck deck { get; set; }
        private int index { get; set; }
        private Card nextCard { get; set; }

        public void Deal()
        {
            foreach (var player in players)
            {
                var cardsDealt = 0;
                while (cardsDealt < 2)
                {
                    foreach (var hand in player.hands)
                    {
                        hand.cards.Add(GetNextCard());
                    }
                    foreach (var hand in dealer.hands)
                    {
                        var next = GetNextCard();
                        if (cardsDealt == 1)
                            next.isHidden = false;
                        hand.cards.Add(nextCard);
                    }
                    cardsDealt++;
                }
            }
        }

        public void Hit(Hand hand)
        {
            hand.cards.Add(GetNextCard());
        }

        public Card GetNextCard()
        {
            nextCard = deck.cards[index];
            index++;
            return nextCard;
        }
    }
}
