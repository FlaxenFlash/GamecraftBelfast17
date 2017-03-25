using System;
using UnityEngine;

namespace Assets.Source
{
	[CreateAssetMenu(menuName = "Faction")]
	public class Faction : ScriptableObject
	{
        [NonSerialized]
        public float Anger;
		public PolicyOpinion Opinions;
	}
}
