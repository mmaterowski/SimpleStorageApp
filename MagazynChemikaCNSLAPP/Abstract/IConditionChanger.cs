using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface IConditionChanger
	{
		void ChangeCondition(IGlassware glassware);
		void ChangeCondition(IEnumerable<IGlassware> glasswareCollection);
	}
}
