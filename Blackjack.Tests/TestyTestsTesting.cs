using Blackjack_Mindfire_02;
using Blackjack_Mindfire_02.Participants;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Blackjack.Tests
{
	[TestFixture]
	public class TestyTestsTesting
	{
		[Test]
		public void DealerPickRandomDeckReturnsADeck()
		{
			// Arrange
			var dealer = new Dealer(amtDecks: 3);

			// Act
			var sut = dealer.PickRandomDeck();

			// Assert
			sut.Should().NotBeNullOrEmpty();
		}
		[Test]
		public void FiftySecondDealCardShouldReturnCard()
		{
			var dealer = new Dealer(1);

			for (int i = 0; i < 51; i++)
			{
				dealer.DealCard();
			}
			var sutLastCard = dealer.DealCard();

			sutLastCard.Should().NotBeNull();
		}
		[Test]
		public void FiftyThirdDealCardShouldThrowException()
		{
			var dealer = new Dealer(1);

			for (int i = 0; i < 52; i++)
			{
				dealer.DealCard();
			}
			Action sutAfter52ndCard = () => dealer.DealCard();

			sutAfter52ndCard.Should().Throw<Exception>();
		}
		[Test]
		public void InitialDealEveryoneHasTwoCards()
		{
			var dealer = new Dealer(1);
			var player1 = new Player("Player 1");
			var player2 = new Player("Player 2");
			var players = new List<Player>() { player1, player2 };

			dealer.InitialDeal(players);

			dealer.Hand.Count.Should().Be(2);
			player1.Hand.Count.Should().Be(2);
			player2.Hand.Count.Should().Be(2);
		}
		[Test]
		public void ResolveDealerRound_UnderSeventeen()
		{
			var dealer = new Dealer(1);
			dealer.Hand.Add(new Card(Card.Cards.Six));
			dealer.Hand.Add(new Card(Card.Cards.Ten));

			using (var monitoredSubject = dealer)
			{

			}
				dealer.ResolveUnderSeventeen();

			dealer.Should().Monitor<Dealer.Hit()>

			Action hit = () => dealer.Hit(dealer);
			hit.Should().
			
			//dealer.Should().
			
			//dealer.Hit(dealer).Should()
		}
	}
}
