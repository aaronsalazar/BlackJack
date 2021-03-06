﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        // Build a stack of cards.
        // Suit doesn't matter so I've created a list of suit-less cards and for
        // each deck I insert 4 sets and then shuffle.
        public Deck(int numberOfDecks = 1)
        {
            cards = new List<Card>();
            var numberOfCardSuits = numberOfDecks * 4;
            var cardSuit = new List<Card> { new Card("A", 11), new Card("2", 2), new Card("3", 3), new Card("4", 4), new Card("5", 5), new Card("6", 6), new Card("7", 7), new Card("8", 8), new Card("9", 9), new Card("10", 10), new Card("J", 10), new Card("Q", 10), new Card("K", 10) };

            while (numberOfCardSuits != 0)
            {
                cards.AddRange(cardSuit);
                numberOfCardSuits--;
            }
            Shuffle();
        }

        public List<Card> cards { get; set; }

        // Copied from internet but modified for my use. It is a simple shuffle 
        // based on the Fisher–Yates shuffle which is not at a cryptographic 
        // level but good enough for this game.
        // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        public void Shuffle()
        {
            var randomNum = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = randomNum.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
