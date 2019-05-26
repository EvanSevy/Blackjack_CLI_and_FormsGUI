using Blackjack_Mindfire_02;
using Blackjack_Mindfire_02.Participants;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Blackjack.Tests
{
	public class DealerShould
	{
		Mock<Dealer> dealer;
		[SetUp]
		public void Init()
		{
			dealer = new Mock<Dealer>(MockBehavior.Loose, 1);
		}
		[TearDown]
		public void Cleanup()
		{
			dealer = null;
		}

		[Test]
		public void ReturnsDeck_ON_DealerPickRandomDeck()
		{
			// Arrange
			Dealer dealer = new Dealer(amtDecks: 3);

			// Act
			var sut = dealer.PickRandomDeck();

			// Assert
			sut.Should().NotBeNullOrEmpty();
		}
		[Test]
		public void ReturnCard_When52ndCard_ON_DealCard()
		{
			Dealer dealer = new Dealer(1);
			var temp = new Card(Card.Cards.Ace);
			for (int i = 0; i < 51; i++)
			{
				temp = dealer.DealCard();
			}
			var sutLastCard = dealer.DealCard();

			sutLastCard.Should().NotBeNull();
		}
		[Test]
		public void ThrowException_WhenOver52Cards_ON_DealCard()
		{
			dealer.CallBase = true;
			for (int i = 0; i < 52; i++)
			{
				dealer.Object.DealCard();
			}
			Action sutAfter52ndCard = () => dealer.Object.DealCard();

			sutAfter52ndCard.Should().Throw<Exception>();
		}
		[Test]
		public void EveryoneHasTwoCards_ON_InitialDeal()
		{
			dealer.CallBase = true;
			var player1 = new Player("Player 1");
			var player2 = new Player("Player 2");
			var players = new List<Player>() { player1, player2 };

			dealer.Object.InitialDeal(players);

			dealer.Object.Hand.Count.Should().Be(2);
			player1.Hand.Count.Should().Be(2);
			player2.Hand.Count.Should().Be(2);
		}
		[Test]
		public void HitResultToBust_WhenUnder17_ON_UnderSeventeen()
		{
			dealer.Object.Hand.Add(new Card(Card.Cards.Six));
			dealer.Object.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Setup(d => d.DealCard()).Returns(new Card(Card.Cards.Ten));

			dealer.Object.ResolveUnderSeventeen();
			var handValue = dealer.Object.Hand.HighestHand();

			handValue.Should().Be(0);
		}
		[Test]
		public void HitCalled_WhenWithHighAce_ON_HighAceAndUnderEighteen()
		{
			dealer.Object.Hand.Add(new Card(Card.Cards.Six));
			dealer.Object.Hand.Add(new Card(Card.Cards.Ace));
			dealer.Setup(d => d.DealCard()).Returns(new Card(Card.Cards.Three));

			dealer.Object.ResolveHighAceAndUnderEighteen();
			var handValue = dealer.Object.Hand.HighestHand();

			handValue.Should().Be(20);
		}
		[Test]
		public void HitNotCalled_WhenWithOutHighAce_ON_HighAceAndUnderEighteen()
		{
			dealer.Object.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Object.Hand.Add(new Card(Card.Cards.Six));
			dealer.Object.Hand.Add(new Card(Card.Cards.Ace));

			dealer.Object.ResolveHighAceAndUnderEighteen();
			var handValue = dealer.Object.Hand.HighestHand();

			handValue.Should().Be(17);
		}
		[Test]
		public void HitCalled_WhenUnderAnyPlayers_ON_ResolveUnderAnyPlayers()
		{
			dealer.Object.Hand.Add(new Card(Card.Cards.Two));
			dealer.Setup(d => d.DealCard()).Returns(new Card(Card.Cards.Five));
			var player = new Player("PlayerOne") { Hand = new HandCards() { new Card(Card.Cards.Nine), new Card(Card.Cards.Two) } };

			dealer.Object.ResolveUnderAnyPlayers(new List<Player>() { player });
			var handValue = dealer.Object.Hand.HighestHand();

			handValue.Should().Be(12);
		}
		[Test]
		public void HandBust_WhenHandAt21_ON_Hit()
		{
			Mock<IParticipant> participant = new Mock<IParticipant>("Some Player");
			participant.Object.Hand.Add(new Card(Card.Cards.Ten));
			participant.Object.Hand.Add(new Card(Card.Cards.Ten));
			participant.Object.Hand.Add(new Card(Card.Cards.Ace));

			participant.Object.Hit(new Dealer(1));

			participant.Object.Hand.Should().BeEquivalentTo(new List<Card>() { new Card(Card.Cards.BUST) });
		}
		[Test]
		public void HandValid_WhenHandAt10_ON_Hit()
		{
			dealer.Setup(d => d.DealCard()).Returns(new Card(Card.Cards.Ten));
			dealer.Object.Hand.Add(new Card(Card.Cards.Ten));

			dealer.Object.Hit(dealer.Object);
			var handValue = dealer.Object.Hand.HighestHand();

			handValue.Should().Be(20);
		}
	}
}
