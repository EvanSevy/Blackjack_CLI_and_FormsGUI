using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02.Participants
{
	public class Dealer : IParticipant
	{
		const string DEALER_NAME = "'Dealer'";
		GameDecks Decks;
		Deck CurrentDeck;

		public Dealer(int amtDecks) : base(DEALER_NAME)
		{
			Decks = new GameDecks(amtDecks);
			CurrentDeck = PickRandomDeck();
		}
		public Deck PickRandomDeck()
		{
			Random r = new Random();
			return Decks.Decks[r.Next(0, Decks.Decks.Count)];
		}
		public virtual Card DealCard()
		{
			if (CurrentDeck.Cards.Count <= 0)
			{
				throw new Exception("No More Cards to deal.");
			}
			Card dealtCard = CurrentDeck.Cards[0];
			CurrentDeck.Cards.RemoveAt(0);
			return dealtCard;
		}

		public void InitialDeal(List<Player> players)
		{
			Hit(this);
			Hit(this);
			foreach (Player player in players)
			{
				player.Hit(this);
				player.Hit(this);
			}
		}
		public void ResolveDealerRound(List<Player> players)
		{
			ResolveUnderSeventeen();
			ResolveHighAceAndUnderEighteen();
			ResolveUnderAnyPlayers(players);
		}
		public void ResolveUnderSeventeen()
		{
			while (Hand.HighestHand() < 17 && Hand.Bust != true)
			{
				Hit(this);
			}
		}
		public void ResolveHighAceAndUnderEighteen()
		{
			bool hasHighAce = Hand.HasHighAce();
			if (hasHighAce)
			{
				while (Hand.HighestHand() < 18 && Hand.Bust != true)
				{
					Hit(this);
				}
			}
		}
		public void ResolveUnderAnyPlayers(List<Player> players)
		{
			// As long as under the value of any of the players, then dealer keeps hitting.
			foreach (Player player in players)
			{
				while (Hand.HighestHand() < player.Hand.HighestHand() && Hand.Bust != true)
				{
					Hit(this);
				}
			}
		}
	}
}
