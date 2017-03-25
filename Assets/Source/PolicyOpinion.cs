using System;
using UnityEngine;

namespace Assets.Source
{
	[Serializable]
	public class PolicyOpinion
	{
		[Range(-1, 1)]
		public float OpinionOnTax;
		[Range(-1, 1)]
		public float OpinionOnWar;
		[Range(-1, 1)]
		public float OpinionOnTorture;
		[Range(-1, 1)]
		public float OpinionOnCastles;
		[Range(-1, 1)]
		public float OpinionOnCharity;
		[Range(-1, 1)]
		public float OpinionOnBrothels;
		[Range(-1, 1)]
		public float OpinionOnBargins;
	}
}