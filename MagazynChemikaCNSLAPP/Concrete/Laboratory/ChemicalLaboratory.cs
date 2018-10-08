using MagazynChemikaCNSLAPP.Abstract;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete.Laboratory
{
	public class ChemicalLaboratory : ILaboratory
	{
		private IReaction typeOfReaction;
		private IQualityControl qualityControl;

		public ChemicalLaboratory(IReaction reactionParam, IQualityControl qualityControlParam)
		{
			typeOfReaction = reactionParam;
			qualityControl = qualityControlParam;
		}


		public void ChangeCondition(IGlassware glassware)
		{
			throw new System.NotImplementedException();
		}

		public void ChangeQuality(IGlassware glassware)
		{
			throw new System.NotImplementedException();
		}

		public void PerformReaction(IEnumerable<IGlassware> glassware)
		{
			throw new System.NotImplementedException();
		}

		public void ThrowOutBrokenItems(IEnumerable<IGlassware> listOfItems)
		{
			throw new System.NotImplementedException();
		}
	}
}
