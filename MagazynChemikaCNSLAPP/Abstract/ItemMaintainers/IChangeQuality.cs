using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynChemikaCNSLAPP.Abstract.ItemMaintainers
{
	public interface IChangeQuality
	{
		void ChangeQuality(IGlassware glassware);
		void ChangeQuality(IEnumerable<IGlassware> glassware);
	}
}
