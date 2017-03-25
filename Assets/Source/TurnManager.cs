using Assets.Source.Tools;
using UnityEngine;

using Assets.Source.Messaging;
using System;
using System.Collections.Generic;

namespace Assets.Source
{
	public class TurnManager : BaseComponent, IReceivesMessages<TaxesSetMessage>, 
        IReceivesMessages<PromiseSetMessage>, IReceivesMessages<AppeasementSetMessage>,
        IReceivesMessages<PlayedPromiseMessage>
	{
		public GameObject PromiseUi;
		public GameObject ActionUi;
		public GameObject AppeasementUi;

        public List<Faction> factionList = new List<Faction>();
        private List<PlayedPromiseMessage> promisesList = new List<PlayedPromiseMessage>();

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

            foreach(Faction f in factionList)
            {
                foreach(PlayedPromiseMessage m in promisesList)
                {
                    if(f == m.Faction)
                    {
                        //if(m.Promise.WasProsmiseFulfilled())
                        //{
                            f.Anger += m.Promise.GetFundingChange();
                        //}
                    }
                }
            }
        }

        public void HandleMessage(PlayedPromiseMessage message)
        {
            promisesList.Add(message);
        }
    }
}