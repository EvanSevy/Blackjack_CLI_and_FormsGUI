using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02.Participants
{
    class Dealer : IParticipant
    {
        const string DEALER_NAME = "'Dealer'";
        List<Deck> decks = new List<Deck>();
        Deck currentDeck;

        public Dealer(int amtDecks) : base(DEALER_NAME)
        {
            // Include all the decks and shuffle them
            for (int i = 0; i < amtDecks; i++)
            {
                decks.Add(new Deck());
                decks[i].Shuffle();
            }

            // Pick a random deck
            Random r = new Random();
            currentDeck = decks[r.Next(0, amtDecks)];
        }

        public Card DealCard()
        {
            if (currentDeck.deck.Count <= 0)
            {
                throw new Exception("No More Cards to deal.");
            }
            Card dealtCard = currentDeck.deck[0];
            currentDeck.deck.RemoveAt(0);
            return dealtCard;
        }

        public void InitialDeal(List<Player> players)
        {
            Hit(this);
            Hit(this);
            foreach (Player player in players)
            {
                player.Hit(this);
                player.Hit(this);
            }
        }
        public void ResolveDealerRound(List<Player> players)
        {
            bool hasHighAce = false;
            while (ParticipantsHighestHand() < 17 && this.Bust != true)
            {
                Hit(this);
            }
            hasHighAce = HighestHandHelper.HasHighAce(Hand);
            if (hasHighAce)
            {
                while (ParticipantsHighestHand() < 18 && this.Bust != true)
                {
                    Hit(this);
                }
            }
            // As long as under the value of any of the players, then dealer keeps hitting.
            foreach (Player player in players)
            {
                while (this.ParticipantsHighestHand() < player.ParticipantsHighestHand() && this.Bust != true)
                {
                    Hit(this);
                }
            }
        }

    }
}
