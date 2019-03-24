using System.Collections.Generic;

namespace ChemApp.Domain.Abstract
{
	public interface IReaction
	{
		void PerformReaction(IEnumerable<IGlassware> glassware);
	}
}