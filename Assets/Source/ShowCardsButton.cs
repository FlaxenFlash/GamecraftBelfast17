using Assets.Source.Tools.UnityInterfaces;
using UnityEngine;
using UnityEngine.UI;

public class ShowCardsButton : MonoBehaviour, IEnable
{
	public GameObject CardRoot;

	public void ShowCards()
	{
		CardRoot.SetActive(true);
	}

	public void OnEnable()
	{
		GetComponent<Button>().interactable = true;
	}
}