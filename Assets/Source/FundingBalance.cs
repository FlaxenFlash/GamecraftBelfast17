using Assets.Source.Messaging;
using Assets.Source.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source
{
	public class FundingBalance : BaseComponent
	{
		private int _income;
		public PolicyFundingState FundingState;
		public Text BalanceText;

		public void UpdateBalance()
		{
			_income = (int)FundingState.TaxLevel.CurrentValue;

			foreach (var fund in FundingState.OutgoingFunds())
			{
				_income -= (int)fund.CurrentValue;
			}

			BalanceText.text = (_income >= 0 ? "+" : "-") + Mathf.Abs(_income);
		}

		public void StageComplete()
		{
			if (_income < 0) return;
			MessagingCenter.BroadcastMessage(new FundingAssignedMessage{Income = _income});
		}
	}
}