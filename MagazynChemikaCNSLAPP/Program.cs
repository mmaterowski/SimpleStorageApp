using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using Ninject;
using System.Reflection;

namespace MagazynChemikaCNSLAPP
{
	class Program
	{
		static void Main(string[] args)
		{

			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());
			var labGlass = kernel.Get<IGlassware>();
			var supplier = new SupplyingCompany();
			var myStorage = new Storage(supplier);
			MainMenu.Run(myStorage, supplier);
		}

	}
}




