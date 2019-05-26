using Blackjack_Mindfire_02;
using Blackjack_Mindfire_02.Participants;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Tests
{
	class ScorerShould
	{
		Dealer dealer;
		Player player1;
		[SetUp]
		public void Init()
		{
			dealer = new Dealer(1);
			player1 = new Player("Player1");
		}
		[TearDown]
		public void Cleanup()
		{
			dealer = null;
		}
		[Test]
		public void PlayerBeatsDealer_ON_FindWinners()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ace));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer );
			List<IParticipant> winners = new List<IParticipant>();

			scorer.ResolvePoints();
			winners = scorer.FindWinners();

			winners.Should().Contain(player1);
		}
		[Test]
		public void DealerBeatsPlayer_ON_FindWinners()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ace));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);
			List<IParticipant> winners = new List<IParticipant>();

			scorer.ResolvePoints();
			winners = scorer.FindWinners();

			winners.Should().Contain(dealer);
		}
		[Test]
		public void BothPlayerAndDealerWinWhenBoth21AtBeginning_ON_FindWinners()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ace));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ace));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);
			List<IParticipant> winners = new List<IParticipant>();

			scorer.ResolvePoints();
			winners = scorer.FindWinners();

			winners.Should().BeEquivalentTo(dealer, player1);
		}
		[Test]
		public void DealerWinsWhenBoth21AfterBeginning_ON_FindWinners()
		{
			dealer.Hand.Add(new Card(Card.Cards.Eight));
			dealer.Hand.Add(new Card(Card.Cards.Two));
			dealer.Hand.Add(new Card(Card.Cards.Ace));
			player1.Hand.Add(new Card(Card.Cards.Eight));
			player1.Hand.Add(new Card(Card.Cards.Two));
			player1.Hand.Add(new Card(Card.Cards.Ace));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);
			List<IParticipant> winners = new List<IParticipant>();

			scorer.ResolvePoints();
			winners = scorer.FindWinners();

			winners.Should().BeEquivalentTo(dealer);
		}
		// Individual ResolvePoints() functions
		[Test]
		public void OnePointEach_ON_BothDealerAndPlayerHave2CardsAnd21()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ace));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ace));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);

			scorer.BothDealerAndPlayerHave2CardsAnd21();

			dealer.Points.Should().Be(1);
			player1.Points.Should().Be(1);
		}
		[Test]
		public void TwoPointsEachPlayerDealerBeats_ON_DealerHave2CardsAnd21AndPlayersDont()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ace));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);

			scorer.DealerHave2CardsAnd21AndPlayersDont();

			dealer.Points.Should().Be(2);
			player1.Points.Should().Be(0);
		}
		[Test]
		public void PlayerTwoPointsWhenBeatDealerWith2CardsAnd21Points_ON_PlayerHave2CardsAnd21AndDealerDoesnt()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ace));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);

			scorer.PlayerHave2CardsAnd21AndDealerDoesnt();

			dealer.Points.Should().Be(0);
			player1.Points.Should().Be(2);
		}
		[Test]
		public void OnePointForDealerWhenWin_BY_BothPlayerDealerSameValueAndNotAt2Cards()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Five));
			dealer.Hand.Add(new Card(Card.Cards.Five));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Five));
			player1.Hand.Add(new Card(Card.Cards.Five));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);

			scorer.BothPlayerDealerSameValueAndNotAt2CardsAnd21();

			dealer.Points.Should().Be(1);
			player1.Points.Should().Be(0);
		}
		[Test]
		public void DealerGetsOnePointPerPlayer_21With3Cards_BY_DealerMorePointsThanPlayerEitherTwoCardsOrLessThan21()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Six));
			dealer.Hand.Add(new Card(Card.Cards.Five));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Five));
			player1.Hand.Add(new Card(Card.Cards.Five));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);

			scorer.DealerMorePointsThanPlayerEitherTwoCardsOrLessThan21();

			dealer.Points.Should().Be(1);
			player1.Points.Should().Be(0);
		}
		[Test]
		public void DealerGetsOnePointPerPlayer_20With2Cards_BY_DealerMorePointsThanPlayerEitherTwoCardsOrLessThan21()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Four));
			player1.Hand.Add(new Card(Card.Cards.Five));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);

			scorer.DealerMorePointsThanPlayerEitherTwoCardsOrLessThan21();

			dealer.Points.Should().Be(1);
			player1.Points.Should().Be(0);
		}
		[Test]
		public void PlayerGetsOnePoint_21With3Cards_BY_PlayerMorePointsThanDealerEitherTwoCardsOrLessThan21()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Five));
			dealer.Hand.Add(new Card(Card.Cards.Five));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Five));
			player1.Hand.Add(new Card(Card.Cards.Six));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);

			scorer.PlayerMorePointsThanDealerEitherTwoCardsOrLessThan21();

			dealer.Points.Should().Be(0);
			player1.Points.Should().Be(1);
		}
		[Test]
		public void PlayerGetsOnePoint_20With2Cards_BY_PlayerMorePointsThanDealerEitherTwoCardsOrLessThan21()
		{
			dealer.Hand.Add(new Card(Card.Cards.Ten));
			dealer.Hand.Add(new Card(Card.Cards.Four));
			dealer.Hand.Add(new Card(Card.Cards.Five));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			player1.Hand.Add(new Card(Card.Cards.Ten));
			Scorer scorer = new Scorer(new List<Player>() { player1 }, dealer);

			scorer.PlayerMorePointsThanDealerEitherTwoCardsOrLessThan21();

			dealer.Points.Should().Be(0);
			player1.Points.Should().Be(1);
		}
	}
}
