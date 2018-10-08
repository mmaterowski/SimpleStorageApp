using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface IDispose
	{
		void ThrowOutBrokenItems(IEnumerable<IGlassware> listOfItems);
	}
}