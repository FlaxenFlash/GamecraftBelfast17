using Assets.Source.Messaging;
using UnityEngine;

public class CompleteActionButton : MonoBehaviour
{
	public void Complete()
	{
		MessagingCenter.BroadcastMessage(new TaxesSetMessage());
	}
}