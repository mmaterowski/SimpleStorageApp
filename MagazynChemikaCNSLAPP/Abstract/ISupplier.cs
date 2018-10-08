using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface ISupplier
	{
		string[] GetAvailableProducts();
		void DisplayProductsList(string[] listOfProducts);
	}
}
