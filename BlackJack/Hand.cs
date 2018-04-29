using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Hand
    {
        public Hand()
        {
            cards = new List<Card>();
        }

        public List<Card> cards { get; set; }
        public int score => CardSum();

        // A hand always has a score
        // 1 or more aces are 1 or 11 depending on if they push the score over 21.
        // A hand with only 4 aces would be 11, 1, 1, 1
        private int CardSum()
        {
            var total = cards.Sum(x => x.value);

            if(total > 21)
            {
                var aces = cards.Where(x => x.name == "A");

                foreach (var ace in aces)
                {
                    total = 0;
                    ace.value = 1;
                    foreach (var card in cards)
                    {
                        total += card.value;
                    }

                    if (total <= 21) break;
                }
            }
            return total;
        }
    }
}
