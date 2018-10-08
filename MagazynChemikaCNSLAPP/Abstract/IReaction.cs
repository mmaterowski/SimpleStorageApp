using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface IReaction
	{
		void PerformReaction(IEnumerable<IGlassware> glassware);
	}
}