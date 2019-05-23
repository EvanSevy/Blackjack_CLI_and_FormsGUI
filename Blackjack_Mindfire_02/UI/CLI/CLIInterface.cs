using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Mindfire_02.Participants;

namespace Blackjack_Mindfire_02.UI.CLI
{
    class CLIInterface : IUserInterface
    {
        const int AMT_PLAYERS = 4;
        public override void StartGame()
        {
            while (PlayAgain())
            {
                InitializeInterface(AMT_PLAYERS);
                Console.WriteLine("Here's the initial deal: ");
                dealer.InitialDeal(players);

                //Console.WriteLine("***********************");
                //Console.Write("Card String: ");
                //Console.WriteLine(dealer.Hand[0].aCard.ToString());
                //Console.Write("Card Value: ");
                //Console.WriteLine((Int32)dealer.Hand[0].aCard);
                //Console.WriteLine("***********************");


                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine($"Player #{players[i].PlayerName}s hand: ");
                    Console.WriteLine($"{players[i].DisplayHand()} -> [TOTAL: {players[i].ParticipantsHighestHand()}]");
                }
                Console.WriteLine("Dealers hand: ");
                // start at 1 to skip the dealers hidden card
                Console.Write("'X'"); // Dealers hidden card display
                for (int i = 1; i < dealer.Hand.Count; i++)
                {

                    Console.Write(dealer.Hand[i].aCard.ToString());
                    //Console.Write(dealer.Hand[i].DisplayCard());
                }
                Console.WriteLine();
                // Players keep choosing 'Hit' or 'Hold' until every player is either holding or busted
                while (players.Where(p => p.Hold == false && p.Bust == false).Any())
                {
                    foreach (Player player in players.Where(p => p.Hold == false && p.Bust == false))
                    {
                        Console.WriteLine($"Player #{player.PlayerName} has the following hand: {player.DisplayHand()} -> [TOTAL: {player.ParticipantsHighestHand()}]");
                        bool notValidInput = true;
                        String hitOrHold = "";
                        while (notValidInput)
                        {
                            Console.WriteLine($"Player #{player.PlayerName}, would you like to Hit ('Hit') or Hold ('Hold')?");
                            hitOrHold = Console.ReadLine().ToLower();
                            if ((hitOrHold.Equals("hit") || hitOrHold.Equals("hold")))
                                notValidInput = false;
                        }
                        if (hitOrHold.Equals("hit"))
                            player.Hit(dealer);
                        else
                            player.Hold = true;
                        Console.WriteLine($"Player #{player.PlayerName} now has the following hand: {player.DisplayHand()} -> [TOTAL: {player.ParticipantsHighestHand()}]");
                    }
                }
                Console.WriteLine("Dealer now takes their turn.");
                dealer.ResolveDealerRound(players);
                Console.WriteLine("Dealer has the following hand: ");
                Console.WriteLine($"{dealer.DisplayHand()} ->  [TOTAL: {dealer.ParticipantsHighestHand()}]");
                Console.WriteLine("Resolving all participants points...");
                scorer.ResolvePoints();
                Console.WriteLine($"Dealer got {dealer.Points} points.");
                foreach (Player player in players)
                {
                    Console.WriteLine($"Player {player.PlayerName}, got {player.Points} points.");
                }
                List<IParticipant> winners = scorer.FindWinners();
                Console.WriteLine("The winners are: ");
                foreach (IParticipant participant in winners)
                {
                    Console.WriteLine($"Player {participant.PlayerName}");
                }
            }
        }
        bool PlayAgain()
        {
            bool notValidInput = true;
            String yesOrNo = "";
            bool playAgain = false;
            Console.WriteLine("**********************************************************");
            while (notValidInput)
            {
                Console.WriteLine("Ready to play BlackJack! (Y/N)");
                yesOrNo = Console.ReadLine().ToLower();
                if (yesOrNo.Equals("y") || yesOrNo.Equals("n"))
                {
                    notValidInput = false;
                }
            }
            if (yesOrNo.Equals("y"))
                playAgain = true;
            else
                playAgain = false;
            return playAgain;
        }
    }
}
