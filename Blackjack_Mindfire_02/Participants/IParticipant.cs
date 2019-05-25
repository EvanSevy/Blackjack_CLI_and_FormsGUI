using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02.Participants
{
    public abstract class IParticipant
    {
        public string PlayerName { get; set; }
        public IParticipant(string playerName)
        {
            PlayerName = playerName;
        }
        public HandCards Hand { get; set; } = new HandCards();
        public int Points { get; set; }
        
		//public void Hit(Dealer dealer)
		//{
		//	if (Bust != true)
		//	{
		//		Hand.Add(dealer.DealCard());
		//		if (ParticipantsHighestHand() > 21)
		//			Bust = true;
		//	}
		//	if (Bust == true)
		//	{
		//		Hand.Clear();
		//		Hand.Add(new Card(Card.Cards.BUST));
		//	}
		//}
		public void Hit(Dealer dealer)
		{
			Hand.Add(dealer.DealCard());
		}
        public String DisplayHand()
        {
			return String.Join(", ", Hand);
        }
        public override string ToString()
        {
            return PlayerName;
        }
    }
}
