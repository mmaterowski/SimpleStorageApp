using MagazynChemikaCNSLAPP.Abstract;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class ItemMaintainer : IMaintainItem
	{
		private IPolish polisher;
		private IWash washer;

		public ItemMaintainer(IPolish polisherParam, IWash washerParam)
		{
			polisher = polisherParam;
			washer = washerParam;

		}
		public bool CheckIfAllItemsAreClean(IEnumerable<IGlassware> glasswareCollection)
		{
			return washer.CheckIfAllItemsAreClean(glasswareCollection);
		}

		public bool CheckIfItemIsClean(IGlassware pieceOfGlassware)
		{
			return washer.CheckIfItemIsClean(pieceOfGlassware);
		}

		public void Wash(IGlassware pieceOfGlassware)
		{
			washer.Wash(pieceOfGlassware);
		}

		public void Wash(IEnumerable<IGlassware> glasswareCollection)
		{
			washer.Wash(glasswareCollection);
		}

		public void Polish(IGlassware pieceOfGlassware)
		{
			polisher.Polish(pieceOfGlassware);
		}

		public void PolishAllItems(IEnumerable<IGlassware> glasswareCollection)
		{
			polisher.PolishAllItems(glasswareCollection);
		}
	}

}
