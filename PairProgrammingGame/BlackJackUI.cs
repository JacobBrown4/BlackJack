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
        bool playGame = true;
        int playerChips = 1000;
        int currentBet = 50;
        int currentMax = 200;
        bool doubleDown = false;

        public void Run()
        {
            while (playGame)
            {
                PlayGame();
                if (playerChips == 0)
                {
                    playGame = false; Console.WriteLine("You lost all your money. You loose.");
                    Console.ReadLine();
                }
            }
        }

        public void PlayGame()
        {
            // Bet
            Bet();

            // Give Cards
            Console.Clear();
            repo.Shuffle();
            repo.Deal();

            
            Console.WriteLine();
            // Create a display player card system
            repo.DisplayCards();
            
            // Player Actions
            PlayerOptions();
            Console.WriteLine($"The dealer reveals a {repo._dealerHand[1].Number} of {repo._dealerHand[1].Suit}\n");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));


            // Dealer Actions
            repo.DisplayCardsAfterPlayerGoes();
            Card dealerCard2 = repo._dealerHand[1];
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            repo.Dealer();
            Console.WriteLine($"Dealer has {repo.DealerTotal()}");
            DealerOutcomesPrint();
            Console.WriteLine();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            // Manage money
            Payout();
            // Loop

            // Play again state
            Console.WriteLine("Press enter to contine or [E]xit");
            string endGameInput = Console.ReadLine();
            switch (endGameInput.ToLower())
            {
                case "e":
                case "exit":
                    playGame = false;
                    return;
                default:
                    break;
            }
        }

        public void Bet() // This is for the actual betting process, bet calculations in the repository. 
        {
            // What we need: Players current total. Player bet total. Player's success or failure. Calculation happens and player's money is updated here.
            Console.Clear();

            Console.WriteLine("\n" +
 "    ▀█████████▄   ▄█          ▄████████  ▄████████    ▄█   ▄█▄           ▄█    ▄████████  ▄████████    ▄█   ▄█▄ \n" +
 "      ███    ███ ███         ███    ███ ███    ███   ███ ▄███▀          ███   ███    ███ ███    ███   ███ ▄███▀ \n" +
 "      ███    ███ ███         ███    ███ ███    █▀    ███▐██▀            ███   ███    ███ ███    █▀    ███▐██▀   \n" +
 "     ▄███▄▄▄██▀  ███         ███    ███ ███         ▄█████▀             ███   ███    ███ ███         ▄█████▀    \n" +
 "    ▀▀███▀▀▀██▄  ███       ▀███████████ ███        ▀▀█████▄             ███ ▀███████████ ███        ▀▀█████▄    \n" +
 "      ███    ██▄ ███         ███    ███ ███    █▄    ███▐██▄            ███   ███    ███ ███    █▄    ███▐██▄   \n" +
 "      ███    ███ ███▌    ▄   ███    ███ ███    ███   ███ ▀███▄          ███   ███    ███ ███    ███   ███ ▀███▄ \n" +
 "    ▄█████████▀  █████▄▄██   ███    █▀  ████████▀    ███   ▀█▀      █▄ ▄███   ███    █▀  ████████▀    ███   ▀█▀ \n" +
 "                 ▀                                   ▀              ▀▀▀▀▀▀                            ▀         ");
            Console.WriteLine($"Your current chip count is: {playerChips}");
            if (playerChips < 200) { currentMax = playerChips; }

            // Need a check that input in inbewteen our set minimum '1' and our currentMax variable
            // playerbet >= 1 && <= maxbetvar
            while (true)
            {
            Console.Write($"How much would you like to bet, up to {currentMax}?: ");
            var playerBet = Int32.Parse(Console.ReadLine());
                if (playerBet >= 1 && playerBet <= currentMax)
                {
                    currentBet = playerBet; return;
                }

                else
                {
                    Console.WriteLine($"Again, please enter a bet between 1 and {currentMax}.");
                }
            }
        }
        public void Payout()
        {
            int result = repo.WinnerOutput(); //(0 = player won, 1= dealer won, 2 = tie/push)
            if (doubleDown == true)
            { currentBet *= 2; }
            if (result == 0)
            {
                double payOutRaw = currentBet * 2;
                int payOut = (int)Math.Floor(payOutRaw);
                playerChips += payOut;
                Console.WriteLine($"You won ${payOut}! Your new chip count is {playerChips}.");
            }

            else if (result == 3)
            {
                double payOutRaw = currentBet * 1.5;
                int payOut = (int)Math.Floor(payOutRaw);
                playerChips += payOut;
                Console.WriteLine($"You won by Black Jack! You win ${payOut}! Your new chip count is {playerChips}.");
            }
            else if (result == 1)
            {
                playerChips -= currentBet;
                Console.WriteLine($"Dealers wins. You lost ${currentBet}. Your current chip count is {playerChips}.");
            }

            else if (result == 2)
            {
                Console.WriteLine($"Push! You tied. Your bet is returned. Your current chip count is {playerChips}.");
            }
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
                Console.WriteLine(repo.DisplayPlayerTotalSoftorHard());
                if (repo.PlayerTotal() > 21) { Console.WriteLine("You busted\n"); playerContinue = false; }
                else if (repo.PlayerTotal() == 21) { Console.WriteLine("Black Jack!\n"); playerContinue = false; }
                else
                {
                    Console.WriteLine("Would you like to [H]it, [S]tand or [D]ouble Down?");
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
                        case "d":
                        case "dd":
                        case "double":
                        case "double down":
                            repo.PlayerHit();
                            playerContinue = false;
                            doubleDown = true;
                            break;
                    }
                }
            }
        }
    }
}
