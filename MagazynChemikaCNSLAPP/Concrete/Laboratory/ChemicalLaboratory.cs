using MagazynChemikaCNSLAPP.Abstract;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete.Laboratory
{
	public class ChemicalLaboratory
	{

		private readonly IQualityControl qualityControl;
		private readonly IMaintainItem maintainer;

		public ChemicalLaboratory(IQualityControl qualityControlParam, IMaintainItem maintainParam)
		{
			qualityControl = qualityControlParam;
			maintainer = maintainParam;
		}

		public void PerformReaction(IEnumerable<IGlassware> glasswareCollection)
		{
			qualityControl.CheckQuality(glasswareCollection);
			bool allItemsAreClean = maintainer.CheckIfAllItemsAreClean(glasswareCollection);
			if (!qualityControl.QualityControlFailed && allItemsAreClean)
			{
				qualityControl.ChangeQuality(glasswareCollection);

				System.Console.WriteLine("Reaction performed. You gain xxx money.");
			}
			else
			{
				System.Console.WriteLine("You can't perform reaction, some of Your items are broken or dirty!");
				System.Console.WriteLine("Please, buy new ones and clean dirty ones, before attempting to perform a reaction");
			}
		}

		public void WashItem(IGlassware pieceOfGlassware)
		{
			maintainer.Wash(pieceOfGlassware);
		}
		public void WashDirtyItems(IEnumerable<IGlassware> glasswareCollection)
		{
			maintainer.Wash(glasswareCollection);
		}

		public void PolishItem(IGlassware pieceOfGlassware)
		{
			maintainer.Polish(pieceOfGlassware);
		}

		public void PolishAllItems(IEnumerable<IGlassware> glasswareCollection)
		{
			maintainer.PolishAllItems(glasswareCollection);
		}


	}
}
