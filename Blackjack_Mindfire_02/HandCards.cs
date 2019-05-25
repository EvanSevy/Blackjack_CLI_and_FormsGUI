using Blackjack_Mindfire_02.Participants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02
{
	// MIGHT INTEGRATE THIS LATER

	public class HandCards : IEnumerable<Card>
	{
		public List<Card> Hand { get; set; } = new List<Card>();
		public bool Bust { get; set; } = false;
		public void Add(Card newCard)
		{
			if (Bust == true) return;

			Hand.Add(newCard);
			if (HighestHand() > 21)
			{
				Bust = true;
				Hand.Clear();
				Hand.Add(new Card(Card.Cards.BUST));
			}
		}
		public int HighestHand()
		{
			return HighestPossibleHand();
		}
		public int HighestPossibleHand()
		{
			int amtAces = 0;
			int totalBeforeAces = 0;
			int grandTotal = 0;
			foreach (Card card in Hand)
			{
				if (card.aCard == Card.Cards.Ace)
				{
					amtAces++;
				}
			}
			foreach (Card card in Hand.Where(c => c.aCard != Card.Cards.Ace))
			{
				totalBeforeAces += (Int32)card.aCard;
				//totalBeforeAces += card.CardValue();
			}
			grandTotal = totalBeforeAces;
			while (amtAces > 0)
			{
				if (grandTotal + 11 > 21)
				{
					grandTotal += 1;
				}
				else
				{
					grandTotal += 11;
				}
				amtAces--;
			}
			return grandTotal;
		}
		public void Clear() { Hand.Clear(); }
		public int Count { get { return Hand.Count; } }
		public IEnumerator<Card> GetEnumerator()
		{
			return ((IEnumerable<Card>)Hand).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Card>)Hand).GetEnumerator();
		}
	}
}
