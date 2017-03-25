using UnityEngine;

namespace Assets.Source
{
	[CreateAssetMenu(menuName = "Faction")]
	public class Faction : ScriptableObject
	{
		public float Anger;
		public PolicyOpinion Opinions;
	}
}
