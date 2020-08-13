using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame
{
    class BlackJackUI
    {
        Repository repo = new Repository();
        public void Run()
        {
            PlayGame();
            PlayGame();
            PlayGame();
            PlayGame();
            PlayGame();
        }

        public void PlayGame()
        {
            // Bet


            // Give Cards
            Console.Clear();
            repo.Shuffle();
            repo.Deal();
            Card dealerCard1 = repo._dealerHand[0];
            Card dealerCard2 = repo._dealerHand[1];
            Card playerCard1 = repo._playerHand[0];
            Card playerCard2 = repo._playerHand[1];
            Console.WriteLine(" _______     _______\n" + "|       |   |       |\n" + $"| {dealerCard1.Letter}{(dealerCard1.Letter == "10" ? "" : " ")}    |   | ///// |\n" + $"|   {dealerCard1.Symbol}   |   | ///// |\n" + $"|    {(dealerCard1.Letter == "10" ? "" : " ")}{dealerCard1.Letter} |   | ///// |\n" + $"|_______|   |_______|\n");
            Console.WriteLine($"The dealer is showing a {dealerCard1.Number} of {dealerCard1.Suit}\n");
            Console.WriteLine();
            // Create a display player card system

            Console.WriteLine($"You were dealt a {playerCard1.Number} of {playerCard1.Suit} {playerCard1.Letter}{playerCard1.Symbol} & a {playerCard2.Number} of {playerCard2.Suit} {playerCard2.Letter}{playerCard2.Symbol}");

            // Player Actions
            PlayerOptions();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            
            // Dealer Actions
            Console.WriteLine($"The dealer reveals his other card is a {dealerCard2.Number} of {dealerCard2.Suit}");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            repo.Dealer();
            Console.WriteLine($"Dealer has {repo.DealerTotal()}");
            DealerOutcomesPrint();
            Console.WriteLine();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));


            // Winner ? Dealer : Player
            repo.WinnerOutput();


            // Manage money

            // Loop

            // This is for testing only, take out in full release.
            Console.ReadLine();
        }

        public void DealerOutcomesPrint()
        {
            int playerTotal = repo.PlayerTotal();
            int total = repo.DealerTotal();
            if (total > 21) { Console.WriteLine("Dealer busts!"); }
            else if (total == 21) { Console.WriteLine("Dealer has Black Jack!"); }
            else { Console.WriteLine($"Dealer stands" + (playerTotal >= 22 ? " because you busted" : "!")); }
        }

        public void PlayerOptions()
        {
            bool playerContinue = true;
            while (playerContinue)
            {
                Console.WriteLine($"Your card total is: {repo.PlayerTotal()}");
                if (repo.PlayerTotal() > 21) { Console.WriteLine("You busted\n"); playerContinue = false; }
                else if (repo.PlayerTotal() == 21) { Console.WriteLine("Black Jack!\n"); playerContinue = false; }
                else {
                    Console.WriteLine("Would you like to [H]it or [S]tand?");
                    string input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "hit":
                        case "h":
                            repo.PlayerHit();
                            break;
                        case "stand":
                        case "s":
                            playerContinue = false;
                            break;
                    } 
                }
            }
        }
    }
}
