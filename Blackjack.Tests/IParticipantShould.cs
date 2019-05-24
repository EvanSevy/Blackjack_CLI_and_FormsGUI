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
		public void HandBustOn_HitWith21Hand()
		{
			var dealer = new Dealer(1);
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ace));

			dealer.Hit(dealer);

			dealer.Hand.Should().BeEquivalentTo(new List<Card>() { new Card(Card.Cards.BUST) });
		}
	}
}
