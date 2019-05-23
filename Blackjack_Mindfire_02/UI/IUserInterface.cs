using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Mindfire_02.Participants;

namespace Blackjack_Mindfire_02.UI
{
    class IUserInterface
    {
        protected const int AMT_DECKS = 1;
        public Dealer dealer;
        public List<Player> players;
        public Scorer scorer;
        public IUserInterface()
        {
        }
        public void InitializeInterface(int amtPlayers)
        {
            players = new List<Player>();
            dealer = new Dealer(AMT_DECKS);
            for (int i = 0; i < amtPlayers; i++)
            {
                players.Add(new Player(($"'{i + 1}'").ToString()));
            }
            scorer = new Scorer(players, dealer);
        }
        public virtual void StartGame() { }
    }
}
