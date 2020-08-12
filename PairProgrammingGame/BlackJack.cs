using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame
{
    class BlackJack
    {
        static void Main(string[] args)
        {
            BlackJackUI bjUI = new BlackJackUI();
            Repository repo = new Repository();

            // 8/13 To Do's:
          /* Notices aces and calculate
           * Actually keep track wins somehwere
           * Loop the dealer logic
           * Have an actual UI
           * 
           * If we got time add betting, better display
           * if we have time after double down
           */

            bjUI.Run();

            repo.Shuffle();
            Card drawnCard = repo.GetRandomCard();
            Console.WriteLine($"{drawnCard.Number} of {drawnCard.Suit}{drawnCard.Symbol}");

            //Console.WriteLine($"You drew a {.Value} {.Suit}");
            Console.ReadLine();
            //bjUI.Run();

            /*Console.WriteLine("Give me a verb");
            string verb1 = Console.ReadLine();

            Console.WriteLine($"Here's your mad lib. You {verb1} the dog!");
            */
        }
    }
}
