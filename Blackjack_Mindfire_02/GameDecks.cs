using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02
{
	public class GameDecks : IEnumerable<Deck>
	{
		public List<Deck> Decks { get; set; } = new List<Deck>();
		public GameDecks(int amtDecks)
		{
			for (int i = 0; i < amtDecks; i++)
			{
				Decks.Add(new Deck());
				Decks[i].Shuffle();
			}
		}
		public IEnumerator<Deck> GetEnumerator()
		{
			return ((IEnumerable<Deck>)Decks).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Deck>)Decks).GetEnumerator();
		}
	}
}
