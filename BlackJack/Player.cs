using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public Player(int numberOfHands = 1)
        {
            hands = new List<Hand>();
            while(numberOfHands > 1)
            {
                hands.Add(new Hand());
            }
        }

        public string name;
        public List<Hand> hands { get; set; }
    }
}
