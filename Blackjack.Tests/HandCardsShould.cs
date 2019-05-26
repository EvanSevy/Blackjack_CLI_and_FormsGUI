using Blackjack_Mindfire_02;
using Blackjack_Mindfire_02.Participants;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Tests
{
	class HandCardsShould
	{
		[Test]
		public void LowAceResult_ON_HighestPossibleHand()
		{
			HandCards currentHand = new HandCards() {
				new Card(Card.Cards.Ten),
				new Card(Card.Cards.Nine),
				new Card(Card.Cards.Ace)
			};

			int highestHand = currentHand.HighestHand();

			highestHand.Should().Be(20);
		}
		[Test]
		public void HighAceResult_ON_HighestPossibleHand()
		{
			HandCards currentHand = new HandCards() {
				new Card(Card.Cards.Ten),
				new Card(Card.Cards.Ace)
			};

			int highestHand = currentHand.HighestHand();

			highestHand.Should().Be(21);
		}
		[Test]
		public void HaveHighAceResult_ON_HasHighAce()
		{
			HandCards currentHand = new HandCards {
				new Card(Card.Cards.Ten),
				new Card(Card.Cards.Ace)
			};

			bool hasHighAce = currentHand.HasHighAce();

			hasHighAce.Should().BeTrue();
		}
		[Test]
		public void HaveNoHighAceResult_ON_HasHighAce()
		{
			HandCards currentHand = new HandCards() {
				new Card(Card.Cards.Ten),
				new Card(Card.Cards.Nine),
				new Card(Card.Cards.Ace)
			};

			bool hasHighAce = currentHand.HasHighAce();

			hasHighAce.Should().BeFalse();
		}
	}
}
