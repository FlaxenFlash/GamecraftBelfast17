using Assets.Source.Tools;
using UnityEngine;

using Assets.Source.Messaging;
using System;

namespace Assets.Source
{
	public class TurnManager : BaseComponent, IReceivesMessages<TaxesSetMessage>, IReceivesMessages<PromiseSetMessage>, IReceivesMessages<AppeasementSetMessage>
	{
		public GameObject PromiseUi;
		public GameObject ActionUi;
		public GameObject AppeasementUi;

        public void HandleMessage(PromiseSetMessage message)
        {
            PromiseUi.SetActive(false);
            ActionUi.SetActive(true);
            AppeasementUi.SetActive(false);
        }

        public void HandleMessage(TaxesSetMessage message)
        {
            PromiseUi.SetActive(false);
            ActionUi.SetActive(false);
            AppeasementUi.SetActive(true);
        }

        public void HandleMessage(AppeasementSetMessage message)
        {
            PromiseUi.SetActive(true);
            ActionUi.SetActive(false);
            AppeasementUi.SetActive(false);
        }
    }
}