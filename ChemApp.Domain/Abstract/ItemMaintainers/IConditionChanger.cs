using System.Collections.Generic;

namespace ChemApp.Domain.Abstract.ItemMaintainers
{
	public interface IConditionChanger
	{
		void ChangeCondition(IGlassware glassware);
		void ChangeCondition(IEnumerable<IGlassware> glasswareCollection);
	}
}
