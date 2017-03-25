using Assets.Source.Messaging;
using UnityEngine;

public class CompleteActionButton : MonoBehaviour
{
	public void Complete()
	{
		MessagingCenter.BroadcastMessage(new TaxesSetMessage());
	}

    public void CompletePromise()
    {
        MessagingCenter.BroadcastMessage(new PromiseSetMessage());
    }

    public void CompleteAppeasement()
    {
        MessagingCenter.BroadcastMessage(new AppeasementSetMessage());
    }
}