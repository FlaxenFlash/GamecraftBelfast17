using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source
{
	[CreateAssetMenu(menuName = "PolicyFunding")]
	public class PolicyFundingState : ScriptableObject
	{
		private List<FundingLevel> _outgoing;

		public FundingLevel TaxLevel;
		public FundingLevel WarFunding;
		public FundingLevel TortureFunding;
		public FundingLevel CastlesFunding;
		public FundingLevel CharityFunding;
		public FundingLevel BrothelFunding;
		public FundingLevel BarginsFunding;

		public List<FundingLevel> OutgoingFunds()
		{
			if (_outgoing == null || !_outgoing.Any()) PopulateOutgoings();

			return _outgoing;
		}

		private void PopulateOutgoings()
		{
			_outgoing = new List<FundingLevel>
			{
				WarFunding,
				TortureFunding,
				CastlesFunding,
				CharityFunding,
				BrothelFunding,
				BarginsFunding
			};
		}
	}
}