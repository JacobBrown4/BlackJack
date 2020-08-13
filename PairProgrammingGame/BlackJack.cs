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
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            
            // 8/13 To Do's:
          /* 
           * Actually keep track wins somehwere
           * Have an actual UI
           * Make a method in UI that can tell if you have a soft or hard total
           * 
           * Print player card method
           * If we got time add betting, better display
           * if we have time after double down
           */

            bjUI.Run();
            Console.ReadLine();
        }
    }
}
