using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_BRM_002 : PenTemplate //flamewaker
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
			return 0;
		}
	}
}
