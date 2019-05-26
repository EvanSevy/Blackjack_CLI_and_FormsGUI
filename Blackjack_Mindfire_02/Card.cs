using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02
{
	public class Card
	{
		public enum Cards { Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, BUST = 0 };
		public Card(Cards card)
		{
			aCard = card;
		}
		public Cards aCard { get; set; }
		public override string ToString()
		{
			return aCard.ToString();
		}
	}
}
