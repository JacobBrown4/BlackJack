using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame
{
    public class Deck
    {
        public Dictionary<int, Card> _deck = new Dictionary<int, Card>();
    }
    public class Card
    {
        public Card(string number, int value, Suit suit,int index)
        {
            Number = number;
            Value = value;
            Suit = suit;
            Index = index;
        }
        public string Number { get; set; }
        public int Value { get; set; }
        public Suit Suit { get; set; }
        public int Index { get; set; }
        public string Symbol
        {
            get
            {
                switch (Suit) {
                    case Suit.Spades:
                        return "\u2660";
                    case Suit.Hearts:
                        return "\u2665";
                    case Suit.Clubs:
                        return "\u2663";
                    case Suit.Diamonds:
                        return "\u2666";
                    default:
                        return "\u2663";
                }
            }
        }
        public string Letter
        {
            get
            {
                if (Number == "Ace")
                    return "A";
                else if (Number == "King")
                    return "K";
                else if (Number == "Queen")
                    return "Q";
                else if (Number == "Jack")
                    return "J";
                else
                    return Convert.ToString(Value);                    
            }
        }
    }
    public enum Suit
    {
        Spades,
        Clubs,
        Hearts,
        Diamonds
    }
}
