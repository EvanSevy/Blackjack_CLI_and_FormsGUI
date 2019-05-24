using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02
{
	public class Deck : IEnumerable<Card>
	{
		public List<Card> Cards { get; set; } = new List<Card>();
		public Deck()
		{
			Cards = new List<Card>(52);

			for (int i = 0; i < 4; i++)
			{
				for (int j = 1; j <= 13; j++)
				{
					Cards.Add(new Card((Card.Cards)j));
				}
			}
		}
		public void Shuffle()
		{
			List<Card> randomList = new List<Card>();

			Random r = new Random();
			int randomIndex = 0;
			while (Cards.Count > 0)
			{
				randomIndex = r.Next(0, Cards.Count); //Choose a random object in the list
				randomList.Add(Cards[randomIndex]); //add it to the new, random list
				Cards.RemoveAt(randomIndex); //remove to avoid duplicates
			}

			Cards = randomList;
		}
		public IEnumerator<Card> GetEnumerator()
		{
			return ((IEnumerable<Card>)Cards).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Card>)Cards).GetEnumerator();
		}
	}
}
