using Assets.Source;
using Assets.Source.Tools.UnityInterfaces;
using UnityEngine;
using UnityEngine.UI;

public class ShowAppeasementCardsButton : MonoBehaviour, IEnable
{
	public static Faction CurrentFaction;

	public Faction Faction;
	public GameObject CardRoot;

	public void ShowCards()
	{
		CurrentFaction = Faction;
		CardRoot.SetActive(true);
		GetComponent<Button>().interactable = false;
	}

	public void OnEnable()
	{
		GetComponent<Button>().interactable = true;
	}
}