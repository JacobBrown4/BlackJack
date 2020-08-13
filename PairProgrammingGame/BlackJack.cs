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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bjUI.Run();
        }
    }
}
