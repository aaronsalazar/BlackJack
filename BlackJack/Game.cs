using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        public Game(List<Player> _players, int? numberOfDecks)
        {
            index = 0;
            players = _players;
            deck = new Deck(numberOfDecks ?? 1);
        }

        public List<Player> players { get; set; }
        public Deck deck { get; set; }
        private int index { get; set; }
        private Card nextCard { get; set; }

        public void deal()
        {
            foreach (var player in players)
            {
                foreach (var hand in player.hands)
                {
                    hand.cards = new List<Card>();
                    hand.cards.Add(getNextCard());
                    var showingCard = getNextCard();
                    showingCard.isHidden = false;
                    hand.cards.Add(showingCard);
                }
            }
        }

        public void hit(Hand hand)
        {
            hand.cards.Add(getNextCard());
        }

        public Card getNextCard()
        {
            nextCard = deck.cards[index];
            index++;
            return nextCard;
        }
    }
}
