using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemApp.Domain.Abstract.ItemMaintainers
{
	public interface IPolish
	{
		void Polish(IGlassware pieceOfGlassware);
		void PolishAllItems(IEnumerable<IGlassware> glasswareCollection);
	}
}
