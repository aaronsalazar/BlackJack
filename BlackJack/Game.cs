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

        // According to rules dealer deals one card to each player and then
        // themself and then a second card to each player and then themself.
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

        public void Stand(Hand dealerHand)
        {
            // When player stands the dealer must hit until his score is less than or equal to 17
            while(dealerHand.score < 17)
            {
                Hit(dealerHand);    
            }
        }

        // Just like in real life, take the next card off the top.
        public Card GetNextCard()
        {
            nextCard = deck.cards[index];
            index++;
            return nextCard;
        }

        // Not conclusive.  Next iteration I'll get more accurate.
        public bool? DeterminePlayerWinner(Hand hand)
        {
            var cardCnt = hand.cards.Count;

            // Start out with 21 - Win
            if (cardCnt == 2 && hand.score == 21)
                return true;
            // If I ever hit 21 - Win
            if (cardCnt > 2 && hand.score == 21)
                return true;
            // If I ever exceed 21 - Lose
            if (cardCnt > 2 && hand.score > 21)
                return false;

            return null;
        }
    }
}
