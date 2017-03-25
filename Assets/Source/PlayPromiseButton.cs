using Assets.Source;
using Assets.Source.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class PlayPromiseButton : MonoBehaviour
{
	public Promise Promise;
	public Button FactionButton;
	public GameObject CardRoot;
	public Faction Faction;

	public void PlayPromise()
	{
		MessagingCenter.BroadcastMessage(new PlayedPromiseMessage{Promise = Promise, Faction = Faction});
		FactionButton.interactable = false;
		CardRoot.SetActive(false);
	}
}