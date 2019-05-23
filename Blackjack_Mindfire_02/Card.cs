using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02
{
    class Card
    {
        public enum Cards { Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 10, Queen = 10, King = 10, BUST = 0 };

        public Card(Card.Cards card)
        {
            aCard = card;
        }

        public Cards aCard
        {
            get;
            set;
        }

        //public String DisplayCard()
        //{
        //    switch (aCard)
        //    {
        //        case Cards.Ace:
        //            {
        //                return "'A'";
        //            }
        //        case Cards.Two:
        //            {
        //                return "'2'";
        //            }
        //        case Cards.Three:
        //            {
        //                return "'3'";
        //            }
        //        case Cards.Four:
        //            {
        //                return "'4'";
        //            }
        //        case Cards.Five:
        //            {
        //                return "'5'";
        //            }
        //        case Cards.Six:
        //            {
        //                return "'6'";
        //            }
        //        case Cards.Seven:
        //            {
        //                return "'7'";
        //            }
        //        case Cards.Eight:
        //            {
        //                return "'8'";
        //            }
        //        case Cards.Nine:
        //            {
        //                return "'9'";
        //            }
        //        case Cards.Ten:
        //            {
        //                return "'10'";
        //            }
        //        case Cards.Jack:
        //            {
        //                return "'J'";
        //            }
        //        case Cards.Queen:
        //            {
        //                return "'Q'";
        //            }
        //        case Cards.King:
        //            {
        //                return "'K'";
        //            }
        //        case Cards.BUST:
        //            {
        //                return "'BUST'";
        //            }
        //    }
        //    return null;
        //}
        //public int CardValue()
        //{
        //    switch (aCard)
        //    {
        //        case Cards.Ace:
        //            {
        //                throw new DataMisalignedException("Ace should be handled programmatically");
        //            }
        //        case Cards.Two:
        //            {
        //                return 2;
        //            }
        //        case Cards.Three:
        //            {
        //                return 3;
        //            }
        //        case Cards.Four:
        //            {
        //                return 4;
        //            }
        //        case Cards.Five:
        //            {
        //                return 5;
        //            }
        //        case Cards.Six:
        //            {
        //                return 6;
        //            }
        //        case Cards.Seven:
        //            {
        //                return 7;
        //            }
        //        case Cards.Eight:
        //            {
        //                return 8;
        //            }
        //        case Cards.Nine:
        //            {
        //                return 9;
        //            }
        //        case Cards.Ten:
        //            {
        //                return 10;
        //            }
        //        case Cards.Jack:
        //            {
        //                return 10;
        //            }
        //        case Cards.Queen:
        //            {
        //                return 10;
        //            }
        //        case Cards.King:
        //            {
        //                return 10;
        //            }
        //        case Cards.BUST:
        //            {
        //                return 0;
        //            }
        //    }
        //    return -10000;
        //}
    }
}
