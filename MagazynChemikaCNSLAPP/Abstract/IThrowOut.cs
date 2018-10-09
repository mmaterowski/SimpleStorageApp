using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface IThrowOut
	{
		void ThrowOutItem(IGlassware pieceOfGlassware);
		void ThrowOutBrokenItems(IEnumerable<IGlassware> glasswareCollection);
	}
}