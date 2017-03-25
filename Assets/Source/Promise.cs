using UnityEngine;

namespace Assets.Source
{
	[CreateAssetMenu(menuName = "Promise")]
	public class Promise : ScriptableObject
	{
		private float _originalFundingLevel;

		public FundingLevel FundingLevel;
		public bool ShouldIncrease;

		public void MakePromise()
		{
			_originalFundingLevel = FundingLevel.CurrentValue;
		}

		public bool WasProsmiseFulfilled()
		{
			if (FundingLevel.CurrentValue == _originalFundingLevel) return false;
			return ShouldIncrease == (FundingLevel.CurrentValue > _originalFundingLevel);
		}

		public float GetFundingChange()
		{
			return FundingLevel.CurrentValue - _originalFundingLevel;
		}
	}
}