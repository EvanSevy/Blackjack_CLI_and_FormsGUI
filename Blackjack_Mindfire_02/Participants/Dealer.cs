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
		public Card DealCard()
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
			while (ParticipantsHighestHand() < 17 && this.Bust != true)
			{
				Hit(this);
			}
		}
		public void ResolveHighAceAndUnderEighteen()
		{
			bool hasHighAce = HighestHandHelper.HasHighAce(Hand);
			if (hasHighAce)
			{
				while (ParticipantsHighestHand() < 18 && this.Bust != true)
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
				while (this.ParticipantsHighestHand() < player.ParticipantsHighestHand() && this.Bust != true)
				{
					Hit(this);
				}
			}
		}
	}
}
