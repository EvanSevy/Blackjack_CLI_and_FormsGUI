using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_02.Participants
{
	public class Player : IParticipant
	{
		public Player(string playerName) : base(playerName)
		{
		}
		public bool Hold
		{
			get;
			set;
		} = false;
	}
}
