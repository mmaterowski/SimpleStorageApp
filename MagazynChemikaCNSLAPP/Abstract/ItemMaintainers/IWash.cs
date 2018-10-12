﻿using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Abstract.ItemMaintainers
{
	public interface IWash
	{
		bool CheckIfItemIsClean(IGlassware pieceOfGlassware);
		bool CheckIfAllItemsAreClean(IEnumerable<IGlassware> glasswareCollection);
		void Wash(IGlassware pieceOfGlassware);
		void Wash(IEnumerable<IGlassware> glasswareCollection);
	}
}