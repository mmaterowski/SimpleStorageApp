using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynChemikaCNSLAPP.Concrete
{
	class ChemicalDisposer : IThrowOut
	{
		public void ThrowOutBrokenItems(IEnumerable<IGlassware> glasswareCollection)
		{
			throw new NotImplementedException();
		}

		public void ThrowOutItem(IGlassware pieceOfGlassware)
		{
			throw new NotImplementedException();
		}
	}
}
