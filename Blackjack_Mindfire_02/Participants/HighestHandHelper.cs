using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02.Participants
{
    static class HighestHandHelper
    {
        //  Finds the highest possible hand value.  ie. when an Ace can be either '1' or '11'.
        static public int HighestPossibleHand(List<Card> currentHand)
        {
            int amtAces = 0;
            int totalBeforeAces = 0;
            int grandTotal = 0;
            foreach (Card card in currentHand)
            {
                if (card.aCard == Card.Cards.Ace)
                {
                    amtAces++;
                }
            }
            foreach (Card card in currentHand.Where(c => c.aCard != Card.Cards.Ace))
            {
                totalBeforeAces += (Int32)card.aCard;
                //totalBeforeAces += card.CardValue();
            }
            grandTotal = totalBeforeAces;
            while (amtAces > 0)
            {
                if (grandTotal + 11 > 21)
                {
                    grandTotal += 1;
                }
                else
                {
                    grandTotal += 11;
                }
                amtAces--;
            }
            return grandTotal;
        }
        // Used for the part of the spec that states that if the dealer has a 'high ace' in his hand...
        static public bool HasHighAce(List<Card> currentHand)
        {
            int amtAces = 0;
            int totalBeforeAces = 0;
            int grandTotal = 0;
            foreach (Card card in currentHand)
            {
                if (card.aCard == Card.Cards.Ace)
                {
                    amtAces++;
                }
            }
            if (amtAces == 0)
                return false;
            foreach (Card card in currentHand.Where(c => c.aCard != Card.Cards.Ace))
            {
                totalBeforeAces += (Int32)card.aCard;
                //totalBeforeAces += card.CardValue();
            }
            grandTotal = totalBeforeAces;
            while (amtAces > 0)
            {
                if (totalBeforeAces + 11 > 21)
                {
                    grandTotal += 1;
                }
                else
                {
                    // grandTotal += 11;
                    return true;
                }
                amtAces--;
            }
            return false;
        }
    }
}
