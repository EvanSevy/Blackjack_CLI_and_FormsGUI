//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Blackjack_Mindfire_02
//{
//	public class Deck
//	{

//		public List<Card> deck;

//		public Deck()
//		{

//			deck = new List<Card>(52);

//			//Card.Cards aCard = (Card.Cards)0;
//			//deck[0] = new Card((Card.Cards)0);

//			//Card.Cards theCard = ((Card.Cards[])(Enum.GetValues(typeof(Card.Cards))))[0];
//			//deck.Add(new Card(theCard));
//			//deck[1] = new Card(Card.Cards.BUST);

//			for (int i = 0; i < 4; i++)
//			{
//				for (int j = 1; j <= 13; j++)
//				{
//					deck.Add(new Card((Card.Cards)j));
//					//deck[(i + 1) * (j + 1) - 1] = new Card((Card.Cards)j);
//				}
//			}


//			//deck = new List<Card> { new Card(Card.Cards.Ace),
//			//                new Card(Card.Cards.Two),
//			//                new Card(Card.Cards.Three),
//			//                new Card(Card.Cards.Four),
//			//                new Card(Card.Cards.Five),
//			//                new Card(Card.Cards.Six),
//			//                new Card(Card.Cards.Seven),
//			//                new Card(Card.Cards.Eight),
//			//                new Card(Card.Cards.Nine),
//			//                new Card(Card.Cards.Ten),
//			//                new Card(Card.Cards.Jack),
//			//                new Card(Card.Cards.Queen),
//			//                new Card(Card.Cards.King),
//			//                new Card(Card.Cards.Ace),
//			//                new Card(Card.Cards.Two),
//			//                new Card(Card.Cards.Three),
//			//                new Card(Card.Cards.Four),
//			//                new Card(Card.Cards.Five),
//			//                new Card(Card.Cards.Six),
//			//                new Card(Card.Cards.Seven),
//			//                new Card(Card.Cards.Eight),
//			//                new Card(Card.Cards.Nine),
//			//                new Card(Card.Cards.Ten),
//			//                new Card(Card.Cards.Jack),
//			//                new Card(Card.Cards.Queen),
//			//                new Card(Card.Cards.King),
//			//                new Card(Card.Cards.Ace),
//			//                new Card(Card.Cards.Two),
//			//                new Card(Card.Cards.Three),
//			//                new Card(Card.Cards.Four),
//			//                new Card(Card.Cards.Five),
//			//                new Card(Card.Cards.Six),
//			//                new Card(Card.Cards.Seven),
//			//                new Card(Card.Cards.Eight),
//			//                new Card(Card.Cards.Nine),
//			//                new Card(Card.Cards.Ten),
//			//                new Card(Card.Cards.Jack),
//			//                new Card(Card.Cards.Queen),
//			//                new Card(Card.Cards.King),
//			//                new Card(Card.Cards.Ace),
//			//                new Card(Card.Cards.Two),
//			//                new Card(Card.Cards.Three),
//			//                new Card(Card.Cards.Four),
//			//                new Card(Card.Cards.Five),
//			//                new Card(Card.Cards.Six),
//			//                new Card(Card.Cards.Seven),
//			//                new Card(Card.Cards.Eight),
//			//                new Card(Card.Cards.Nine),
//			//                new Card(Card.Cards.Ten),
//			//                new Card(Card.Cards.Jack),
//			//                new Card(Card.Cards.Queen),
//			//                new Card(Card.Cards.King)
//			//                };
//		}

//		public void Shuffle()
//		{
//			List<Card> randomList = new List<Card>();


//			Random r = new Random();
//			int randomIndex = 0;
//			while (deck.Count > 0)
//			{
//				randomIndex = r.Next(0, deck.Count); //Choose a random object in the list
//				randomList.Add(deck[randomIndex]); //add it to the new, random list
//				deck.RemoveAt(randomIndex); //remove to avoid duplicates
//			}

//			deck = randomList;
//		}
//	}
//}
