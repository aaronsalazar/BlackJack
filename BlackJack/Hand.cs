using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Hand
    {
        public Hand()
        {

        }

        public List<Card> cards { get; set; }
        public int score => cardSum();

        private int cardSum()
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
