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
			if (!qualityControl.QualityControlFailed)
			{
				qualityControl.ChangeQuality(glasswareCollection);

				System.Console.WriteLine();
			}
			else
			{
				System.Console.WriteLine("You can't perform reaction, some of Your items are broken or dirty!");
				System.Console.WriteLine("Please, buy new ones and clean dirty ones, before attempting to perform a reaction");
			}
		}
	}
}
