using System.Collections.Generic;
using Assets.Source;
using Assets.Source.Messaging;
using Assets.Source.Messaging.Messages;
using Assets.Source.Tools;
using UnityEngine;
using UnityEngine.UI;

public class AppeaseButton : MonoBehaviour
{
	public float AppeaseValue;
	public List<Faction> Factions;
	public bool Steal;
	public bool Apologise;
	public GameObject CardRoot;

	public void Trigger()
	{
		GetComponent<Button>().interactable = false;
		CardRoot.SetActive(false);
		if (Apologise)
		{
			DoApologise();
			return;
		}
		ShowAppeasementCardsButton.CurrentFaction.Anger -= AppeaseValue;
		ShowAppeasementCardsButton.CurrentFaction.Anger = Mathf.Max(0, ShowAppeasementCardsButton.CurrentFaction.Anger);
		MessagingCenter.BroadcastMessage(new UpdateSliderMessage());

		if (!Steal) return;
		var faction = MathTools.ChooseRandomObject(Factions);
		faction.Anger += AppeaseValue;
		MessagingCenter.BroadcastMessage(new UpdateSliderMessage());
	}

	private void DoApologise()
	{
		foreach (var faction in Factions)
		{
			faction.Anger -= AppeaseValue;
			faction.Anger = Mathf.Max(0, ShowAppeasementCardsButton.CurrentFaction.Anger);
		}
		MessagingCenter.BroadcastMessage(new UpdateSliderMessage());
	}
}

public class UpdateSliderMessage : GameMessage
{
}