using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Mindfire_02.Participants;

namespace Blackjack_Mindfire_02
{
    class Scorer
    {
        List<Player> players;
        Dealer dealer;

        public Scorer(List<Player> players, Dealer dealer)
        {
            this.players = players;
            this.dealer = dealer;
        }

        public void ResolvePoints()
        {
            // if both dealer and the player have 2 cards and 21 then each get 1 point
            if (dealer.Hand.Count == 2 && dealer.ParticipantsHighestHand() == 21 &&
                players.Where(p => p.ParticipantsHighestHand() == 21).Where(p => p.Hand.Count == 2).Any())
            {
                List<Player> playersTwo21 = players.Where(p => p.ParticipantsHighestHand() == 21).Where(p => p.Hand.Count == 2).ToList<Player>();
                foreach (Player player in playersTwo21)
                {
                    dealer.Points++;
                    player.Points++;
                }
            }
            // If dealer has 2 cards and 21, and players do not have 2 and 21, then give him 2 points for each player he beats
            if (dealer.Hand.Count == 2 && dealer.ParticipantsHighestHand() == 21 &&
                players.Where(p => p.ParticipantsHighestHand() != 21 || p.Hand.Count > 2).Any())
            {
                List<Player> playersLess21 = players.Where(p => p.ParticipantsHighestHand() != 21 || p.Hand.Count > 2).ToList<Player>();
                foreach (Player player in playersLess21)
                {
                    dealer.Points += 2;
                }
            }
            // If player has 2 cards and 21, and dealer does not, then give the player 2 points
            if ((dealer.ParticipantsHighestHand() != 21 || dealer.Hand.Count > 2) &&
                players.Where(p => p.ParticipantsHighestHand() == 21 && p.Hand.Count == 2).Any())
            {
                List<Player> players21DealerLose = players.Where(p => p.ParticipantsHighestHand() == 21 && p.Hand.Count == 2).ToList<Player>();
                foreach (Player player in players21DealerLose)
                {
                    player.Points += 2;
                }
            }
            // If the dealer and the player have the same value (and they are not both at 2 cards and 21), then the dealer gets 1 point
            if (!dealer.Bust && players.Where(p => p.ParticipantsHighestHand() == dealer.ParticipantsHighestHand() && (dealer.ParticipantsHighestHand() < 21) || dealer.Hand.Count > 2).Any())
            {
                List<Player> playersEqual = players.Where(p => p.ParticipantsHighestHand() == dealer.ParticipantsHighestHand() && !p.Bust && (p.Hand.Count > 2 || p.ParticipantsHighestHand() < 21)).ToList<Player>();
                foreach (Player player in playersEqual)
                {
                    dealer.Points++;
                }
            }

            // If the dealer has more points than another player (without busting) and has either more than 2 cards or less than 21 then he gets 1 point for each person he beats
            if (!dealer.Bust && players.Where(p => p.ParticipantsHighestHand() < dealer.ParticipantsHighestHand() && (dealer.ParticipantsHighestHand() < 21 || dealer.Hand.Count > 2)).Any())
            {
                List<Player> playersLost = players.Where(p => p.ParticipantsHighestHand() < dealer.ParticipantsHighestHand() && (dealer.ParticipantsHighestHand() < 21 || dealer.Hand.Count > 2)).ToList<Player>();
                foreach (Player player in playersLost)
                {
                    dealer.Points++;
                }
            }

            // If the player has more points than the dealer (without busting) and has either more than 2 cards or less than 21 then the player gets 1 point
            if (players.Where(p => p.ParticipantsHighestHand() > dealer.ParticipantsHighestHand() && (p.ParticipantsHighestHand() < 21 || p.Hand.Count > 2) && p.Bust != true).Any())
            {
                List<Player> playersWon = players.Where(p => p.ParticipantsHighestHand() > dealer.ParticipantsHighestHand() && (p.ParticipantsHighestHand() < 21 || p.Hand.Count > 2) && p.Bust != true).ToList<Player>();
                foreach (Player player in playersWon)
                {
                    player.Points++;
                }
            }
        }
        public List<IParticipant> FindWinners()
        {
            List<IParticipant> winners = new List<IParticipant>();
            if (!dealer.Bust)
                winners.Add(dealer);
            foreach (Player player in players.Where(p => p.Bust != true))
            {
                if (winners.Count == 0)
                    winners.Add(player);
                if (winners[0].Points < player.Points)
                {
                    winners.Clear();
                    winners.Add(player);
                }
                if (player.Points == winners[0].Points && player != winners[0])
                    winners.Add(player);
            }
            return winners;
        }
    }
}
