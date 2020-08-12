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
            repo.Shuffle();
            repo.Deal();
            Card dealerCard1 = repo._dealerHand[0];
            Card dealerCard2 = repo._dealerHand[1];
            Console.WriteLine($"The dealer is showing {dealerCard1.Number} of {dealerCard1.Suit}");
            Console.WriteLine($"But his secret card is {dealerCard2.Number} of {dealerCard2.Suit}");
            // Player Actions
            //while loop is repo._playerHand.total <= 21
            //repo.PlayerHit();
            // Dealer Actions
            repo.Dealer();
            // Winner ? Dealer : Player
            repo.WinnerOutput();
            // Manage money

            // Loop

        }

}
}
