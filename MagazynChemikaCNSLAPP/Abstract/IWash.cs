using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface IWash
	{
		void Wash(IGlassware pieceOfGlassware);
		void Wash(IEnumerable<IGlassware> glasswareCollection);
	}
}
