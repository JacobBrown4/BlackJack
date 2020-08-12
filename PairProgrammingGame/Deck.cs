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

        //List<TKey> keyList = new List<>(_deck);

        //private List<Deck> _deck = new List<Deck>();
        // Dictionary, random number pull, remove, Casey said "utilize hash set" foreach random number
        //_deck.remove(cardDrawn);

        // Jacob thought process
        // So in a randomized dictionary we still have to randomize the indexes and match that up with items/objects
        // Then still manage to pull a card and move it into the player's hand and the dealers hand
        // Thinking it'd be better to make a straight forward dictionary of 1-52 cards and use a random number generator to pull a random index
        // So instead of randomizing the list and pullng out. We can pull a random card from a straight deck, .remove that card from the dictionary
        // Use a variable to say give me a random number between 0 and deckSize where every time we pull a card we --deckSize
        // That way the playerhand<> list will be a tally and we can display all card objects within that list. Same for dealer.
        // We can even utilize the same deck for multiple hands by keeping it and emptying the player and dealer lists until like the deckSize variable
        // is less than 7 or something. Cw shuffling.
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
        public char Symbol
        {
            get
            {
                switch (Suit) {
                    case Suit.Spades:
                        return '\u2663';
                    case Suit.Hearts:
                        return '\u2663';
                    case Suit.Clubs:
                        return '\u2663';
                    case Suit.Diamonds:
                        return '\u2663';
                    default:
                        return '\u2663';
                }
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
    //public enum suit
    //{♠,♥,♣,♦}
}
