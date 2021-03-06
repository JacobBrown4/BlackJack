﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame
{
    class BlackJackUI
    {
        private readonly Repository repo = new Repository();
        private readonly Deck deck = new Deck();
        bool playGame = true;
        int playerChips = 1000;
        int currentBet = 50;
        int currentMax = 200;
        bool doubleDown = false;
        bool aiMode = false;

        public void Run()
        {
            ToggleAIMode();
            while (playGame)
            {
                PlayGame();
                if (playerChips == 0)
                {
                    playGame = false; Console.WriteLine("You lost all your money. You get nothing! You loose. Good day, Sir!");
                    Console.ReadLine();
                }
            }
        }

        public void ToggleAIMode()
        {
            Console.WriteLine("Before we play would you like to play in AI mode?\n" +
                "In this mode the game will play itself but use the rules of play for most successful BlackJack run");
            Console.WriteLine("Press any key to continue, press 'y' to run on AI Mode");
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.Y:
                    aiMode = true;
                    break;
                default:
                    break;
            }
        }

        public void PlayGame()
        {
            // Bet
            Bet();

            // Give Cards

            if (deck._deck.Count < 8) repo.Shuffle();
            repo.Deal();


            Console.WriteLine();
            // Create a display player card system
            repo.DisplayCardsAfterDeal();

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
            Console.WriteLine($"\tYour current chip count is: {playerChips}");
            if (playerChips < 200) { currentMax = playerChips; }

            // Need a check that input in inbewteen our set minimum '1' and our currentMax variable
            // playerbet >= 1 && <= maxbetvar
            while (true)
            {
                Console.Write($"\tHow much would you like to bet, up to {currentMax}?: ");
                string playerBet = PlayerOrAIBet();
                int chipBet;
                if (int.TryParse(playerBet, out chipBet) && chipBet >= 1 && chipBet <= currentMax)
                {
                    currentBet = chipBet; return;
                }

                else
                {
                    Console.WriteLine($"\tPlease enter a bet between 1 and {currentMax}.");
                }
            }
        }

        public string PlayerOrAIBet()
        {
            if (aiMode == true)
            {
                if (playerChips > 1000)
                    return "200";
                else if (playerChips <= 1200 && playerChips >= 70)
                {
                    return Math.Round((double)playerChips/10).ToString();
                }
                else
                    return playerChips.ToString();
            }
            else
                return Console.ReadLine();
        }
        public void Payout()
        {
            int result = repo.WinnerOutput(); //(0 = player won, 1= dealer won, 2 = tie/push, 3 = double down)
            if (doubleDown == true)
            { currentBet *= 2;
                Console.WriteLine("You doubled down");
            }
            if (result == 0)
            {
                double payOutRaw = currentBet * 1;
                int payOut = (int)Math.Floor(payOutRaw);
                playerChips += payOut;
                Console.WriteLine($"You won ${payOut*2}! Your new chip count is {playerChips}.");
            }

            else if (result == 3)
            {
                double payOutRaw = currentBet * 1.5;
                int payOut = (int)Math.Floor(payOutRaw);
                playerChips += payOut;
                Console.WriteLine($"You won by Black Jack! You win ${payOut*2}! Your new chip count is {playerChips}.");
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
                if (repo.PlayerTotal() > 21) { Console.WriteLine("You busted\n"); System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1)); playerContinue = false; }
                else if (repo.PlayerTotal() == 21) { Console.WriteLine("Black Jack!\n"); System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2)); playerContinue = false; }
                else
                {
                    Console.WriteLine("\nWould you like to [H]it, [S]tand or [D]ouble Down?");
                    string input = PlayerOrAIPlay();
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

        public string PlayerOrAIPlay()
        {
            if (aiMode == true)
            {

                if (repo.SoftTotal() != 0 && repo.HardTotal() >= 11)
                {
                    if (repo.SoftTotal() == 10)
                    {
                        return "s";
                    }
                    else if (repo.SoftTotal() == 9)
                    {
                        if (repo._dealerHand[0].Value == 6)
                            return "d";
                        else
                            return "s";
                    }
                    else if (repo.SoftTotal() == 8)
                    {
                        if (repo._dealerHand[0].Value <= 6)
                            return "d";
                        else if (repo._dealerHand[0].Value <= 8)
                            return "s";
                        else
                            return "h";
                    }
                    else if (repo.SoftTotal() == 7)
                    {
                        if (repo._dealerHand[0].Value >= 3 && repo._dealerHand[0].Value <= 6)
                        {
                            return "d";
                        }
                        else
                            return "h";
                    }
                    else if (repo.SoftTotal() == 6)
                    {
                        if (repo._dealerHand[0].Value >= 4 && repo._dealerHand[0].Value <= 6)
                        {
                            return "d";
                        }
                        else
                            return "h";
                    }
                    else if (repo.SoftTotal() == 5)
                    {
                        if (repo._dealerHand[0].Value >= 4 && repo._dealerHand[0].Value <= 6)
                        {
                            return "d";
                        }
                        else
                            return "h";
                    }
                    else if (repo.SoftTotal() == 4)
                    {
                        if (repo._dealerHand[0].Value >= 5 && repo._dealerHand[0].Value <= 6)
                        {
                            return "d";
                        }
                        else
                            return "h";
                    }
                    else if (repo.SoftTotal() == 3)
                    {
                        if (repo._dealerHand[0].Value >= 5 && repo._dealerHand[0].Value <= 6)
                        {
                            return "d";
                        }
                        else
                            return "h";
                    }
                    else
                        return "h";

                }
                else
                {
                    if (repo.PlayerTotal() >= 17)
                    {
                        return "s";
                    }
                    else if (repo.PlayerTotal() <= 16 && repo.PlayerTotal() >= 13)
                    {
                        if (repo._dealerHand[0].Value <= 6)
                        {
                            return "s";
                        }
                        else return "h";
                    }
                    else if (repo.PlayerTotal() == 12)
                    {
                        if (repo._dealerHand[0].Value < 4 || repo._dealerHand[0].Value > 6)
                        {
                            return "h";
                        }
                        else return "s";
                    }
                    else if (repo.PlayerTotal() == 11)
                    {
                        return "d";
                    }
                    else if (repo.PlayerTotal() == 10)
                    {
                        if (repo._dealerHand[0].Value <= 9)
                        {
                            return "d";
                        }
                        else return "h";
                    }
                    else if (repo.PlayerTotal() == 9)
                    {
                        if (repo._dealerHand[0].Value <= 6 && repo._dealerHand[0].Value >= 3)
                        {
                            return "d";
                        }
                        else return "h";
                    }
                    else return "h";
                }
            }
            else
                return Console.ReadLine();
            // Hit
            // Stand
            // Double down
        }
    }
}
