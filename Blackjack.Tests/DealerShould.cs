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
		[Test]
		public void ReturnsDeckOn_DealerPickRandomDeck()
		{
			// Arrange
			var dealer = new Dealer(amtDecks: 3);

			// Act
			var sut = dealer.PickRandomDeck();

			// Assert
			sut.Should().NotBeNullOrEmpty();
		}
		[Test]
		public void ReturnCardOn_FiftySecondDealCard()
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
		public void ThrowExceptionOn_FiftyThirdDealCard()
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
		public void EveryoneHasTwoCardsOn_InitialDeal()
		{
			var dealer = new Dealer(1);
			var player1 = new Player("Player 1");
			var player2 = new Player("Player 2");
			var players = new List<Player>() { player1, player2 };

			dealer.InitialDeal(players);

			//dealer.Hand.Count.Should().Be(2);
			player1.Hand.Count.Should().Be(2);
			player2.Hand.Count.Should().Be(2);
		}
		[Test]
		public void HitCalledOn_ResolveDealerRound_UnderSeventeen()
		{
			var dealer = new Dealer(1);
			dealer.Hand.Add(new Card(Card.Cards.Six));
			dealer.Hand.Add(new Card(Card.Cards.Ten));

			dealer.ResolveUnderSeventeen();
			var handValue = dealer.ParticipantsHighestHand();

			Assert.That(handValue, Is.GreaterThan(16).Or.EqualTo(0));
		}
		[Test]
		public void HitCalled_WithHighAceOn_ResolveDealerRound_HighAceAndUnderEighteen()
		{
			var dealer = new Dealer(1);
			dealer.Hand.Add(new Card(Card.Cards.Six));
			dealer.Hand.Add(new Card(Card.Cards.Ace));

			dealer.ResolveHighAceAndUnderEighteen();
			var handValue = dealer.ParticipantsHighestHand();

			Assert.That(handValue, Is.GreaterThan(17).Or.EqualTo(0));
		}
		[Test]
		public void HitNotCalled_WithOutHighAceOn_ResolveDealerRound_HighAceAndUnderEighteen()
		{
			var dealer = new Dealer(1);
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Six));
			dealer.Hand.Add(new Card(Card.Cards.Ace));

			dealer.ResolveHighAceAndUnderEighteen();
			var handValue = dealer.ParticipantsHighestHand();

			handValue.Should().Be(17);
		}
		[Test]
		public void HitCalled_WhenUnderAnyPlayersOn_ResolveDealerRound_ResolveUnderAnyPlayers()
		{
			var dealer = new Dealer(1);
			dealer.Hand.Add(new Card(Card.Cards.Two));
			var player = new Player("PlayerOne") { Hand = new List<Card>() { new Card(Card.Cards.Ten), new Card(Card.Cards.Queen) } };

			dealer.ResolveUnderAnyPlayers(new List<Player>() { player });
			var handValue = dealer.ParticipantsHighestHand();

			Assert.That(handValue, Is.GreaterThanOrEqualTo(20).Or.EqualTo(0));
		}

	}
}
