using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame
{
    class Repository
    {
        Deck deck = new Deck();
        Random random = new Random();
        public List<Card> _playerHand = new List<Card>();
        public List<Card> _dealerHand = new List<Card>();
        int currentDeckSize = 51;

        public void Shuffle()
        {
            deck._deck.Clear();
            _playerHand.Clear();
            _dealerHand.Clear();

            // Re-add the cards to the deck
            deck._deck.Add(0, new Card("Ace", 1, Suit.Spades, 0));
            deck._deck.Add(1, new Card("Two", 2, Suit.Spades, 1));
            deck._deck.Add(2, new Card("Three", 3, Suit.Spades, 2));
            deck._deck.Add(3, new Card("Four", 4, Suit.Spades, 3));
            deck._deck.Add(4, new Card("Five", 5, Suit.Spades, 4));
            deck._deck.Add(5, new Card("Six", 6, Suit.Spades, 5));
            deck._deck.Add(6, new Card("Seven", 7, Suit.Spades, 6));
            deck._deck.Add(7, new Card("Eight", 8, Suit.Spades, 7));
            deck._deck.Add(8, new Card("Nine", 9, Suit.Spades, 8));
            deck._deck.Add(9, new Card("Ten", 10, Suit.Spades, 9));
            deck._deck.Add(10, new Card("Jack", 10, Suit.Spades, 10));
            deck._deck.Add(11, new Card("Queen", 10, Suit.Spades, 11));
            deck._deck.Add(12, new Card("King", 10, Suit.Spades, 12));
            deck._deck.Add(13, new Card("Ace", 1, Suit.Clubs, 13));
            deck._deck.Add(14, new Card("Two", 2, Suit.Clubs, 14));
            deck._deck.Add(15, new Card("Three", 3, Suit.Clubs, 15));
            deck._deck.Add(16, new Card("Four", 4, Suit.Clubs, 16));
            deck._deck.Add(17, new Card("Five", 5, Suit.Clubs, 17));
            deck._deck.Add(18, new Card("Six", 6, Suit.Clubs, 18));
            deck._deck.Add(19, new Card("Seven", 7, Suit.Clubs, 19));
            deck._deck.Add(20, new Card("Eight", 8, Suit.Clubs, 20));
            deck._deck.Add(21, new Card("Nine", 9, Suit.Clubs, 21));
            deck._deck.Add(22, new Card("Ten", 10, Suit.Clubs, 22));
            deck._deck.Add(23, new Card("Jack", 10, Suit.Clubs, 23));
            deck._deck.Add(24, new Card("Queen", 10, Suit.Clubs, 24));
            deck._deck.Add(25, new Card("King", 10, Suit.Clubs, 25));
            deck._deck.Add(26, new Card("Ace", 1, Suit.Hearts, 26));
            deck._deck.Add(27, new Card("Two", 2, Suit.Hearts, 27));
            deck._deck.Add(28, new Card("Three", 3, Suit.Hearts, 28));
            deck._deck.Add(29, new Card("Four", 4, Suit.Hearts, 29));
            deck._deck.Add(30, new Card("Five", 5, Suit.Hearts, 30));
            deck._deck.Add(31, new Card("Six", 6, Suit.Hearts, 31));
            deck._deck.Add(32, new Card("Seven", 7, Suit.Hearts, 32));
            deck._deck.Add(33, new Card("Eight", 8, Suit.Hearts, 33));
            deck._deck.Add(34, new Card("Nine", 9, Suit.Hearts, 34));
            deck._deck.Add(35, new Card("Ten", 10, Suit.Hearts, 35));
            deck._deck.Add(36, new Card("Jack", 10, Suit.Hearts, 36));
            deck._deck.Add(37, new Card("Queen", 10, Suit.Hearts, 37));
            deck._deck.Add(38, new Card("King", 10, Suit.Hearts, 38));
            deck._deck.Add(39, new Card("Ace", 1, Suit.Diamonds, 39));
            deck._deck.Add(40, new Card("Two", 2, Suit.Diamonds, 40));
            deck._deck.Add(41, new Card("Three", 3, Suit.Diamonds, 41));
            deck._deck.Add(42, new Card("Four", 4, Suit.Diamonds, 42));
            deck._deck.Add(43, new Card("Five", 5, Suit.Diamonds, 43));
            deck._deck.Add(44, new Card("Six", 6, Suit.Diamonds, 44));
            deck._deck.Add(45, new Card("Seven", 7, Suit.Diamonds, 45));
            deck._deck.Add(46, new Card("Eight", 8, Suit.Diamonds, 46));
            deck._deck.Add(47, new Card("Nine", 9, Suit.Diamonds, 47));
            deck._deck.Add(48, new Card("Ten", 10, Suit.Diamonds, 48));
            deck._deck.Add(49, new Card("Jack", 10, Suit.Diamonds, 49));
            deck._deck.Add(50, new Card("Queen", 10, Suit.Diamonds, 50));
            deck._deck.Add(51, new Card("King", 10, Suit.Diamonds, 51));
            currentDeckSize = 51;
        }

        public Card GetRandomCard()
        {
            int min = 0;
            int max = currentDeckSize;
            int indexRandom = random.Next(min, max);
            return (Card)deck._deck.ElementAt(indexRandom).Value;
        }
        // Method for dealing
        public void Deal()
        {
            //Give player two cards
            for (int i = 0; i < 2; ++i)
            {
                Card newCard = GetRandomCard();
                deck._deck.Remove(newCard.Index);
                _playerHand.Add(newCard);
                --currentDeckSize;
            }
            //Give dealer two cards, only display second card
            // "Dealer is showing {card}"
            for (int i = 0; i != 2; ++i)
            {
                Card newCard = GetRandomCard();
                deck._deck.Remove(newCard.Index);
                _dealerHand.Add(newCard);
                --currentDeckSize;
            }
        }

        public void PlayerHit()
        {
            Card newCard = GetRandomCard();
            deck._deck.Remove(newCard.Index);
            _playerHand.Add(newCard);
            Console.WriteLine($"Hit! You were dealt a {newCard.Number} of {newCard.Suit}");
            --currentDeckSize;
        }

        public void DealerHit()
        {
            Card newCard = GetRandomCard();
            deck._deck.Remove(newCard.Index);
            _dealerHand.Add(newCard);
            Console.WriteLine($"Dealer hit! dealt a {newCard.Number} of {newCard.Suit}");
            --currentDeckSize;
        }

        // Method for Ace
        // Output two totals unless one is > 21;

        public int PlayerTotal()
        {
            int playerTotal = 0;
            bool hasAce = false;

            foreach (Card card in _playerHand)
            {
                if (card.Number == "Ace")
                { hasAce = true; }
            }
            foreach (Card card in _playerHand)
            {
                playerTotal += card.Value;
            }
            if (hasAce == true)
            {
                int softTotal = playerTotal + 10;
                if (softTotal > 21) { return playerTotal; }
                else if (softTotal > playerTotal) { return softTotal; }
                else { return playerTotal; }
            }

            else
            { return playerTotal; }
        }
        // It does total of all your cards assuming ace is one, a total of all your cards assuming Ace 11. Returns the closest to 21. 11 > 21 it's nah, don't use
        // but if the 1 value still under 21. others if both are over 21 > bust. Dealer would just do the same thing.
        public int DealerTotal()
        {
            int dealerTotal = 0;
            bool hasAce = false;

            foreach (Card card in _dealerHand)
            {
                if (card.Number == "Ace")
                { hasAce = true; }
            }
            foreach (Card card in _dealerHand)
            {
                dealerTotal += card.Value;
            }
            if (hasAce == true)
            {
                int softTotal = dealerTotal + 10;
                if (softTotal > 21) { return dealerTotal; }
                else if (softTotal > dealerTotal) { return softTotal; }
                else { return dealerTotal; }
            }

            else
            { return dealerTotal; }
        }

        // Double down can be down later
        // Method for keeping track of players money $1000
        //      Make bet
        //      Input bet upto 200 or money left
        //      Loose bet
        //      win bet payout 1.5x
        //      Outfor when out money


        // Method for dealer AI
        public void Dealer()
        {
            int playerTotal = PlayerTotal();
            int total = DealerTotal();
            while (total < 17)
            {
                if (playerTotal > 21) { break; }
                // Dealer looses if >= 22;
                else if (total > 21)
                { //dealer busts
                    break;
                }
                // Dealer stops if score is >= 21;
                else if (total >= 17 && total <= 21)
                {
                    break; //Dealer stands
                }
                // Dealer needs to 'hit' until score >= 17;
                else if (total < 17)
                {
                    DealerHit();
                    total = DealerTotal();
                }
            }
        }


        // Method for outcomes
        // Push (tie)
        // Dealer wins (run loose bet method)
        // Player wins (run multiply bet method)

        public void WinnerOutput()
        {
            int playerTotal = PlayerTotal();
            int total = DealerTotal();
            if (total > 21) { Console.WriteLine("Player Wins\n"); }
            else if (playerTotal > 21) { Console.WriteLine("Dealer wins!\n"); }
            else if (total > playerTotal) { Console.WriteLine("Dealer wins!\n"); }
            else if (playerTotal > total) { Console.WriteLine("You win!\n"); }
            else if (total == playerTotal) { Console.WriteLine("Push\n"); }

        }
    }
}
