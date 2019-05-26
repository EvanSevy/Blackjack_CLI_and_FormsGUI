﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Mindfire_02.Participants;

namespace Blackjack_Mindfire_02
{
	public class Scorer
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
			BothDealerAndPlayerHave2CardsAnd21();
			DealerHave2CardsAnd21AndPlayersDont();
			PlayerHave2CardsAnd21AndDealerDoesnt();
			BothPlayerDealerSameValueAndNotAt2CardsAnd21();
			DealerMorePointsThanPlayerEitherTwoCardsOrLessThan21();
			PlayerMorePointsThanDealerEitherTwoCardsOrLessThan21();
		}
		public void BothDealerAndPlayerHave2CardsAnd21()
		{
			// if both dealer and the player have 2 cards and 21 then each get 1 point
			if (dealer.Hand.Count == 2 && dealer.Hand.HighestHand() == 21 &&
				players.Where(p => p.Hand.HighestHand() == 21).Where(p => p.Hand.Count == 2).Any())
			{
				List<Player> playersTwo21 = players.Where(p => p.Hand.HighestHand() == 21).Where(p => p.Hand.Count == 2).ToList<Player>();
				foreach (Player player in playersTwo21)
				{
					dealer.Points++;
					player.Points++;
				}
			}
		}
		public void DealerHave2CardsAnd21AndPlayersDont()
		{
			// If dealer has 2 cards and 21, and players do not have 2 and 21, then give him 2 points for each player he beats
			if (dealer.Hand.Count == 2 && dealer.Hand.HighestHand() == 21 &&
				players.Where(p => p.Hand.HighestHand() != 21 || p.Hand.Count > 2).Any())
			{
				List<Player> playersLess21 = players.Where(p => p.Hand.HighestHand() != 21 || p.Hand.Count > 2).ToList<Player>();
				foreach (Player player in playersLess21)
				{
					dealer.Points += 2;
				}
			}
		}
		public void PlayerHave2CardsAnd21AndDealerDoesnt()
		{
			// If player has 2 cards and 21, and dealer does not, then give the player 2 points
			if ((dealer.Hand.HighestHand() != 21 || dealer.Hand.Count > 2) &&
				players.Where(p => p.Hand.HighestHand() == 21 && p.Hand.Count == 2).Any())
			{
				List<Player> players21DealerLose = players.Where(p => p.Hand.HighestHand() == 21 && p.Hand.Count == 2).ToList<Player>();
				foreach (Player player in players21DealerLose)
				{
					player.Points += 2;
				}
			}
		}
		public void BothPlayerDealerSameValueAndNotAt2CardsAnd21()
		{
			// If the dealer and the player have the same value (and they are not both at 2 cards and 21), then the dealer gets 1 point
			if (!dealer.Hand.Bust && players.Where(p => p.Hand.HighestHand() == dealer.Hand.HighestHand() && (dealer.Hand.HighestHand() < 21) || dealer.Hand.Count > 2).Any())
			{
				List<Player> playersEqual = players.Where(p => p.Hand.HighestHand() == dealer.Hand.HighestHand() && !p.Hand.Bust && (p.Hand.Count > 2 || p.Hand.HighestHand() < 21)).ToList<Player>();
				foreach (Player player in playersEqual)
				{
					dealer.Points++;
				}
			}
		}
		public void DealerMorePointsThanPlayerEitherTwoCardsOrLessThan21()
		{
			// If the dealer has more points than another player (without busting) and has either more than 2 cards or less than 21 then he gets 1 point for each person he beats
			if (!dealer.Hand.Bust && players.Where(p => p.Hand.HighestHand() < dealer.Hand.HighestHand() && (dealer.Hand.HighestHand() < 21 || dealer.Hand.Count > 2)).Any())
			{
				List<Player> playersLost = players.Where(p => p.Hand.HighestHand() < dealer.Hand.HighestHand() && (dealer.Hand.HighestHand() < 21 || dealer.Hand.Count > 2)).ToList<Player>();
				foreach (Player player in playersLost)
				{
					dealer.Points++;
				}
			}
		}
		public void PlayerMorePointsThanDealerEitherTwoCardsOrLessThan21()
		{
			// If the player has more points than the dealer (without busting) and has either more than 2 cards or less than 21 then the player gets 1 point
			if (players.Where(p => p.Hand.HighestHand() > dealer.Hand.HighestHand() && (p.Hand.HighestHand() < 21 || p.Hand.Count > 2) && p.Hand.Bust != true).Any())
			{
				List<Player> playersWon = players.Where(p => p.Hand.HighestHand() > dealer.Hand.HighestHand() && (p.Hand.HighestHand() < 21 || p.Hand.Count > 2) && p.Hand.Bust != true).ToList<Player>();
				foreach (Player player in playersWon)
				{
					player.Points++;
				}
			}
		}
		public List<IParticipant> FindWinners()
		{
			List<IParticipant> winners = new List<IParticipant>();
			if (!dealer.Hand.Bust)
				winners.Add(dealer);
			foreach (Player player in players.Where(p => p.Hand.Bust != true))
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
