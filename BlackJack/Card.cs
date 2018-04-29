using System;

namespace BlackJack
{
    public class Card
    {
        public Card(string _name, int _value)
        {
            name = _name;
            value = _value;
            isHidden = true;
        }

        public string name { get; set; }
        public int value { get; set; }
        public bool isHidden { get; set; }
    }
}
