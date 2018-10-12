using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Abstract.ItemMaintainers
{
	public interface IConditionChanger
	{
		void ChangeCondition(IGlassware glassware);
		void ChangeCondition(IEnumerable<IGlassware> glasswareCollection);
	}
}
