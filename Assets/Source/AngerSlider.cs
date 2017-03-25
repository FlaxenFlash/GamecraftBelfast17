using Assets.Source.Messaging;
using Assets.Source.Tools;
using Assets.Source.Tools.UnityInterfaces;
using UnityEngine.UI;

namespace Assets.Source
{
	public class AngerSlider : BaseComponent, IEnable, IReceivesMessages<UpdateSliderMessage>
	{
		public Slider Slider;
		public Faction Faction;

		public void OnEnable()
		{
			Slider.value = Faction.Anger;
		}

		public void HandleMessage(UpdateSliderMessage message)
		{
			Slider.value = Faction.Anger;
		}
	}
}