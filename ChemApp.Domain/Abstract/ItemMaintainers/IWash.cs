using System.Collections.Generic;

namespace ChemApp.Domain.Abstract.ItemMaintainers
{
	public interface IWash
	{
		bool CheckIfItemIsClean(IGlassware pieceOfGlassware);
		bool CheckIfAllItemsAreClean(IEnumerable<IGlassware> glasswareCollection);
		void Wash(IGlassware pieceOfGlassware);
		void Wash(IEnumerable<IGlassware> glasswareCollection);
	}
}
