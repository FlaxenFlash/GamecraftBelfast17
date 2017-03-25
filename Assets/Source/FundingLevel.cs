using UnityEngine;
using System;

namespace Assets.Source
{
	[CreateAssetMenu(menuName = "FundingLevel")]
	public class FundingLevel : ScriptableObject
	{
		public float MaxValue = 100;
        [NonSerialized]
		public float CurrentValue;

		public float GetNormalisedValue()
		{
			return CurrentValue/MaxValue;
		}

		public void SetValue(float value)
		{
			CurrentValue = MaxValue*value;
		}
	}
}