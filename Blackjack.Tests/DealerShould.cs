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
		Dealer dealer;
		[SetUp]
		public void Init()
		{
			dealer = new Dealer(1);
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
			dealer = new Dealer(amtDecks: 3);

			// Act
			var sut = dealer.PickRandomDeck();

			// Assert
			sut.Should().NotBeNullOrEmpty();
		}
		[Test]
		public void ReturnCard_When52ndCard_ON_DealCard()
		{

			for (int i = 0; i < 51; i++)
			{
				dealer.DealCard();
			}
			var sutLastCard = dealer.DealCard();

			sutLastCard.Should().NotBeNull();
		}
		//[Test]
		//public void ThrowException_WhenOver52Cards_ON_DealCard()
		//{
		//	var dealer = new Dealer(1);

		//	for (int i = 0; i < 52; i++)
		//	{
		//		dealer.DealCard();
		//	}
		//	Action sutAfter52ndCard = () => dealer.DealCard();

		//	sutAfter52ndCard.Should().Throw<Exception>();
		//}

		[Test]
		public void EveryoneHasTwoCards_ON_InitialDeal()
		{
			var player1 = new Player("Player 1");
			var player2 = new Player("Player 2");
			var players = new List<Player>() { player1, player2 };

			dealer.InitialDeal(players);


			dealer.Hand.Should().NotBeEquivalentTo(new List<Card>() { new Card(Card.Cards.BUST) });
			player1.Hand.Should().NotBeEquivalentTo(new List<Card>() { new Card(Card.Cards.BUST) });
			player2.Hand.Should().NotBeEquivalentTo(new List<Card>() { new Card(Card.Cards.BUST) });

			dealer.Hand.Bust.Should().BeFalse();
			player1.Hand.Bust.Should().BeFalse();
			player2.Hand.Bust.Should().BeFalse();

			dealer.Hand.Count.Should().Be(2);
			player1.Hand.Count.Should().Be(2);
			player2.Hand.Count.Should().Be(2);
		}
		[Test]
		public void HitCalled_WhenUnder17_ON_UnderSeventeen()
		{
			dealer.Hand.Add(new Card(Card.Cards.Six));
			dealer.Hand.Add(new Card(Card.Cards.Ten));

			dealer.ResolveUnderSeventeen();
			var handValue = dealer.Hand.HighestHand();

			Assert.That(handValue, Is.GreaterThan(16).Or.EqualTo(0));
		}
		[Test]
		public void HitCalled_WhenWithHighAce_ON_HighAceAndUnderEighteen()
		{
			dealer.Hand.Add(new Card(Card.Cards.Six));
			dealer.Hand.Add(new Card(Card.Cards.Ace));

			dealer.ResolveHighAceAndUnderEighteen();
			var handValue = dealer.Hand.HighestHand();

			Assert.That(handValue, Is.GreaterThan(17).Or.EqualTo(0));
		}
		[Test]
		public void HitNotCalled_WhenWithOutHighAce_ON_HighAceAndUnderEighteen()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Six));
			dealer.Hand.Add(new Card(Card.Cards.Ace));

			dealer.ResolveHighAceAndUnderEighteen();
			var handValue = dealer.Hand.HighestHand();

			handValue.Should().Be(17);
		}
		[Test]
		public void HitCalled_WhenUnderAnyPlayers_ON_ResolveUnderAnyPlayers()
		{
			dealer.Hand.Add(new Card(Card.Cards.Two));
			var player = new Player("PlayerOne") { Hand = new HandCards() { new Card(Card.Cards.Ten), new Card(Card.Cards.Queen) } };

			dealer.ResolveUnderAnyPlayers(new List<Player>() { player });
			var handValue = dealer.Hand.HighestHand();

			Assert.That(handValue, Is.GreaterThanOrEqualTo(20).Or.EqualTo(0));
		}
		[Test]
		public void HandBust_WhenHandAt21_ON_Hit()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ace));

			dealer.Hit(dealer);

			dealer.Hand.Should().BeEquivalentTo(new List<Card>() { new Card(Card.Cards.BUST) });
		}
		[Test]
		public void HandValid_WhenHandAt10_ON_Hit()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));

			dealer.Hit(dealer);
			var handValue = HighestHandHelper.HighestPossibleHand(dealer.Hand);

			Assert.That(handValue, Is.GreaterThan(10).And.LessThanOrEqualTo(21));
		}
	}
}
