﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02.Participants
{
    abstract class IParticipant
    {
        public String PlayerName { get; set; }
        public IParticipant(String playerName)
        {
            PlayerName = playerName;
        }
        public List<Card> Hand
        {
            get;
            set;
        } = new List<Card>();
        public int Points
        {
            get;
            set;
        }
        public bool Bust
        {
            get;
            set;
        } = false;
        public void Hit(Dealer dealer)
        {
            if (Bust != true)
            {
                Hand.Add(dealer.DealCard());
                if (ParticipantsHighestHand() > 21)
                    Bust = true;
            }
            if (Bust == true)
            {
                Hand.Clear();
                Hand.Add(new Card(Card.Cards.BUST));
            }
        }
        public int ParticipantsHighestHand()
        {
            return HighestHandHelper.HighestPossibleHand(Hand);
        }
        public String DisplayHand()
        {
            String display = "";
            foreach (Card card in Hand)
            {
                display += card.aCard.ToString();
                //display += card.DisplayCard();
            }
            return display;
        }
        public override string ToString()
        {
            return PlayerName;
        }
    }
}
