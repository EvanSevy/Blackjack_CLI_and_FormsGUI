using Blackjack_Mindfire_02;
using Blackjack_Mindfire_02.Participants;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Tests
{
	class IParticipantShould
	{
		[Test]
		public void LowAceResult_ON_HighestPossibleHand()
		{
			List<Card> currentHand = new List<Card>() {
				new Card(Card.Cards.Ten),
				new Card(Card.Cards.Nine),
				new Card(Card.Cards.Ace)
			};

			int highestHand = HighestHandHelper.HighestPossibleHand(currentHand);

			highestHand.Should().Be(20);
		}
		[Test]
		public void HighAceResult_ON_HighestPossibleHand()
		{
			List<Card> currentHand = new List<Card>() {
				new Card(Card.Cards.Ten),
				new Card(Card.Cards.Ace)
			};

			int highestHand = HighestHandHelper.HighestPossibleHand(currentHand);

			highestHand.Should().Be(21);
		}
		[Test]
		public void HaveHighAceResult_ON_HasHighAce()
		{
			List<Card> currentHand = new List<Card>() {
				new Card(Card.Cards.Ten),
				new Card(Card.Cards.Ace)
			};

			bool hasHighAce = HighestHandHelper.HasHighAce(currentHand);

			hasHighAce.Should().BeTrue();
		}
		[Test]
		public void NotHaveHighAceResult_ON_HasHighAce()
		{
			List<Card> currentHand = new List<Card>() {
				new Card(Card.Cards.Ten),
				new Card(Card.Cards.Nine),
				new Card(Card.Cards.Ace)
			};

			bool hasHighAce = HighestHandHelper.HasHighAce(currentHand);

			hasHighAce.Should().BeFalse();
		}
	}
}
