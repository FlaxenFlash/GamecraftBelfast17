using Assets.Source.Tools;
using Assets.Source.Tools.UnityInterfaces;
using UnityEngine.UI;

namespace Assets.Source
{
	public class FundingSlider : BaseComponent, IEnable
	{
		public Slider Slider;
		public FundingLevel FundingLevel;
		public FundingBalance Balance;

		public void OnEnable()
		{
			Slider.value = FundingLevel.GetNormalisedValue();
		}

		public void ValueUpdated(float value)
		{
			FundingLevel.SetValue(value);
			Balance.UpdateBalance();
		}
	}
}