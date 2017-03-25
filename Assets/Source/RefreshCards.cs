using System.Collections.Generic;
using Assets.Source.Tools.UnityInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source
{
	public class RefreshCards : MonoBehaviour, IEnable
	{
		public List<Button> Cards;
 
		public void OnEnable()
		{
			foreach (var card in Cards)
			{
				card.interactable = true;
			}
		}
	}
}