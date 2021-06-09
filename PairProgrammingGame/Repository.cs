using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            Console.Clear();
            deck._deck.Clear();
            _playerHand.Clear();
            _dealerHand.Clear();
            //Console.WriteLine("The deck is being shuffled");

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
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
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
            DisplayCardsAfterDeal();
            Console.WriteLine($"Hit! You were dealt a {newCard.Number} of {newCard.Suit}\n" + $"{newCard.Letter}{newCard.Symbol}");
            --currentDeckSize;
        }

        public void DealerHit()
        {
            Card newCard = GetRandomCard();
            deck._deck.Remove(newCard.Index);
            _dealerHand.Add(newCard);
            DisplayCardsAfterPlayerGoes();
            Console.WriteLine($"Dealer hit! dealt a {newCard.Number} of {newCard.Suit} giving him {DealerTotal()}");
            --currentDeckSize;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
        }
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

        public int SoftTotal()
        {
            int playerTotal = 0;
            bool hasAce = false;
            foreach (Card card in _playerHand)
            {
                if (card.Number == "Ace")
                { hasAce = true; }
            }
            if (hasAce == true)
            {
                foreach (Card card in _playerHand)
                {
                    playerTotal += card.Value;
                }
                int softTotal = playerTotal + 10;
                if (softTotal > 21) { return 0; }
                else if (softTotal > playerTotal) { return softTotal; }
                else { return 0; }

            }
            else
            { return 0; }
        }

        public int HardTotal()
        {
            int playerTotal = 0;
            foreach (Card card in _playerHand)
            {
                playerTotal += card.Value;
            }
            return playerTotal;
        }
        public void DisplayCardsAfterDeal()
        {
            Console.Clear();
            Card dealerCard1 = _dealerHand[0];
            Card dealerCard2 = _dealerHand[1];
            Card playerCard1 = _playerHand[0];
            Card playerCard2 = _playerHand[1];


            Console.WriteLine(
                "\t┌───────┐   ┌───────┐\n" +
               $"\t│ {_dealerHand[0].Letter}{(_dealerHand[0].Letter == "10" ? "" : " ")}    │   │░░░░░░░│\n" +
                "\t│       │   │░░░░░░░│\n" +
               $"\t│   {_dealerHand[0].Symbol}   │   │░░░░░░░│\n" +
                "\t│       │   │░░░░░░░│\n" +
               $"\t│    {(_dealerHand[0].Letter == "10" ? "" : " ")}{_dealerHand[0].Letter} │   │░░░░░░░│\n" +
               $"\t└───────┘   └───────┘\n");
            Console.WriteLine($"The dealer is showing a {_dealerHand[0].Number} of {_dealerHand[0].Suit}\n");

            Console.WriteLine(
           $"\t┌───────┐   ┌───────┐{(_playerHand.Count >= 3 ? "   ┌───────┐" : "")}{(_playerHand.Count >= 4 ? "   ┌───────┐" : "")}{(_playerHand.Count >= 5 ? "   ┌───────┐" : "")}\n" +
           $"\t│ {_playerHand[0].Letter}{(_playerHand[0].Letter == "10" ? "" : " ")}    │   │ {_playerHand[1].Letter}{(_playerHand[1].Letter == "10" ? "" : " ")}    │{(_playerHand.Count >= 3 ? $"   │ {_playerHand[2].Letter}{(_playerHand[2].Letter == "10" ? "" : " ")}    │" : "")}{(_playerHand.Count >= 4 ? $"   │ {_playerHand[3].Letter}{(_playerHand[3].Letter == "10" ? "" : " ")}    │" : "")}{(_playerHand.Count >= 5 ? $"   │ {_playerHand[4].Letter}{(_playerHand[4].Letter == "10" ? "" : " ")}    │" : "")}\n" +
           $"\t│       │   │       │{(_playerHand.Count >= 3 ? "   │       │" : "")}{(_playerHand.Count >= 4 ? "   │       │" : "")}{(_playerHand.Count >= 5 ? "   │       │" : "")}\n" +
           $"\t│   {_playerHand[0].Symbol}   │   │   {_playerHand[0].Symbol}   │{(_playerHand.Count >= 3 ? $"   │   {_playerHand[2].Symbol}   │" : "")}{(_playerHand.Count >= 4 ? $"   │   {_playerHand[3].Symbol}   │" : "")}{(_playerHand.Count >= 5 ? $"   │   {_playerHand[4].Symbol}   │" : "")}\n" +
           $"\t│       │   │       │{(_playerHand.Count >= 3 ? "   │       │" : "")}{(_playerHand.Count >= 4 ? "   │       │" : "")}{(_playerHand.Count >= 5 ? "   │       │" : "")}\n" +
           $"\t│     {_playerHand[0].Letter}{(_playerHand[0].Letter == "10" ? "" : " ")}│   │     {_playerHand[1].Letter}{(_playerHand[1].Letter == "10" ? "" : " ")}│{(_playerHand.Count >= 3 ? $"   │     {_playerHand[2].Letter}{(_playerHand[2].Letter == "10" ? "" : " ")}│" : "")}{(_playerHand.Count >= 4 ? $"   │     {_playerHand[3].Letter}{(_playerHand[3].Letter == "10" ? "" : " ")}│" : "")}{(_playerHand.Count >= 5 ? $"   │     {_playerHand[4].Letter}{(_playerHand[4].Letter == "10" ? "" : " ")}│" : "")}\n" +
           $"\t└───────┘   └───────┘{(_playerHand.Count >= 3 ? "   └───────┘" : "")}{(_playerHand.Count >= 4 ? "   └───────┘" : "")}{(_playerHand.Count >= 5 ? "   └───────┘" : "")}\n");

        }
        public void DisplayCardsAfterPlayerGoes()
        {
            Console.Clear();

            Console.WriteLine(
           $"\t┌───────┐   ┌───────┐{(_dealerHand.Count >= 3 ? "   ┌───────┐" : "")}{(_dealerHand.Count >= 4 ? "   ┌───────┐" : "")}{(_dealerHand.Count >= 5 ? "   ┌───────┐" : "")}\n" +
           $"\t│ {_dealerHand[0].Letter}{(_dealerHand[0].Letter == "10" ? "" : " ")}    │   │ {_dealerHand[1].Letter}{(_dealerHand[1].Letter == "10" ? "" : " ")}    │{(_dealerHand.Count >= 3 ? $"   │ {_dealerHand[2].Letter}{(_dealerHand[2].Letter == "10" ? "" : " ")}    │" : "")}{(_dealerHand.Count >= 4 ? $"   │ {_dealerHand[3].Letter}{(_dealerHand[3].Letter == "10" ? "" : " ")}    │" : "")}{(_dealerHand.Count >= 5 ? $"   │ {_dealerHand[4].Letter}{(_dealerHand[4].Letter == "10" ? "" : " ")}    │" : "")}\n" +
           $"\t│       │   │       │{(_dealerHand.Count >= 3 ? "   │       │" : "")}{(_dealerHand.Count >= 4 ? "   │       │" : "")}{(_dealerHand.Count >= 5 ? "   │       │" : "")}\n" +
           $"\t│   {_dealerHand[0].Symbol}   │   │   {_dealerHand[1].Symbol}   │{(_dealerHand.Count >= 3 ? $"   │   {_dealerHand[2].Symbol}   │" : "")}{(_dealerHand.Count >= 4 ? $"   │   {_dealerHand[3].Symbol}   │" : "")}{(_dealerHand.Count >= 5 ? $"   │   {_dealerHand[4].Symbol}   │" : "")}\n" +
           $"\t│       │   │       │{(_dealerHand.Count >= 3 ? "   │       │" : "")}{(_dealerHand.Count >= 4 ? "   │       │" : "")}{(_dealerHand.Count >= 5 ? "   │       │" : "")}\n" +
           $"\t│     {_dealerHand[0].Letter}{(_dealerHand[0].Letter == "10" ? "" : " ")}│   │     {_dealerHand[1].Letter}{(_dealerHand[1].Letter == "10" ? "" : " ")}│{(_dealerHand.Count >= 3 ? $"   │     {_dealerHand[2].Letter}{(_dealerHand[2].Letter == "10" ? "" : " ")}│" : "")}{(_dealerHand.Count >= 4 ? $"   │     {_dealerHand[3].Letter}{(_dealerHand[3].Letter == "10" ? "" : " ")}│" : "")}{(_dealerHand.Count >= 5 ? $"   │     {_dealerHand[4].Letter}{(_dealerHand[4].Letter == "10" ? "" : " ")}│" : "")}\n" +
           $"\t└───────┘   └───────┘{(_dealerHand.Count >= 3 ? "   └───────┘" : "")}{(_dealerHand.Count >= 4 ? "   └───────┘" : "")}{(_dealerHand.Count >= 5 ? "   └───────┘" : "")}\n");



            Console.WriteLine(
           $"\t┌───────┐   ┌───────┐{(_playerHand.Count >= 3 ? "   ┌───────┐" : "")}{(_playerHand.Count >= 4 ? "   ┌───────┐" : "")}{(_playerHand.Count >= 5 ? "   ┌───────┐" : "")}\n" +
           $"\t│ {_playerHand[0].Letter}{(_playerHand[0].Letter == "10" ? "" : " ")}    │   │ {_playerHand[1].Letter}{(_playerHand[1].Letter == "10" ? "" : " ")}    │{(_playerHand.Count >= 3 ? $"   │ {_playerHand[2].Letter}{(_playerHand[2].Letter == "10" ? "" : " ")}    │" : "")}{(_playerHand.Count >= 4 ? $"   │ {_playerHand[3].Letter}{(_playerHand[3].Letter == "10" ? "" : " ")}    │" : "")}{(_playerHand.Count >= 5 ? $"   │ {_playerHand[4].Letter}{(_playerHand[4].Letter == "10" ? "" : " ")}    │" : "")}\n" +
           $"\t│       │   │       │{(_playerHand.Count >= 3 ? "   │       │" : "")}{(_playerHand.Count >= 4 ? "   │       │" : "")}{(_playerHand.Count >= 5 ? "   │       │" : "")}\n" +
           $"\t│   {_playerHand[0].Symbol}   │   │   {_playerHand[1].Symbol}   │{(_playerHand.Count >= 3 ? $"   │   {_playerHand[2].Symbol}   │" : "")}{(_playerHand.Count >= 4 ? $"   │   {_playerHand[3].Symbol}   │" : "")}{(_playerHand.Count >= 5 ? $"   │   {_playerHand[4].Symbol}   │" : "")}\n" +
           $"\t│       │   │       │{(_playerHand.Count >= 3 ? "   │       │" : "")}{(_playerHand.Count >= 4 ? "   │       │" : "")}{(_playerHand.Count >= 5 ? "   │       │" : "")}\n" +
           $"\t│     {_playerHand[0].Letter}{(_playerHand[0].Letter == "10" ? "" : " ")}│   │     {_playerHand[1].Letter}{(_playerHand[1].Letter == "10" ? "" : " ")}│{(_playerHand.Count >= 3 ? $"   │     {_playerHand[2].Letter}{(_playerHand[2].Letter == "10" ? "" : " ")}│" : "")}{(_playerHand.Count >= 4 ? $"   │     {_playerHand[3].Letter}{(_playerHand[3].Letter == "10" ? "" : " ")}│" : "")}{(_playerHand.Count >= 5 ? $"   │     {_playerHand[4].Letter}{(_playerHand[4].Letter == "10" ? "" : " ")}│" : "")}\n" +
           $"\t└───────┘   └───────┘{(_playerHand.Count >= 3 ? "   └───────┘" : "")}{(_playerHand.Count >= 4 ? "   └───────┘" : "")}{(_playerHand.Count >= 5 ? "   └───────┘" : "")}\n");

            Console.Write(DisplayPlayerTotalSoftorHard());
            if (PlayerTotal() > 21)
            {
                Console.Write(". You busted\n");
            }
            else { Console.WriteLine(); }

           
        }
        public string DisplayPlayerTotalSoftorHard()
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
                if (softTotal > 21) { return $"Your hard total is {playerTotal}"; }
                else { return $"Your hard total is {playerTotal} and your soft total is {softTotal}"; }
            }

            else
            { return $"Your card total is {playerTotal}"; }
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

        // Auto Player AI


        public int WinnerOutput()
        {
            int playerTotal = PlayerTotal();
            int total = DealerTotal();
            if (playerTotal == 21 && _playerHand.Count == 2) { return 3; }
            else if (total > 21) { return 0; }
            else if (playerTotal > 21) { return 1; }
            else if (total > playerTotal) { return 1; }
            else if (playerTotal > total) { return 0; }
            else if (total == playerTotal) { return 2; }
            else { Console.WriteLine("Calculation error"); return 2; }

        }
    }
}
