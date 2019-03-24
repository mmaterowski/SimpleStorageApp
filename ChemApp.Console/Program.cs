using ChemApp.Domain.Concrete;
using Ninject;
using System.Reflection;

namespace ChemApp.Domain
{
	class Program
	{
		static void Main(string[] args)
		{

			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());
			var supplier = new SupplyingCompany();
			var myStorage = new Storage(supplier);
			MainMenu main = new MainMenu();
			main.Run(myStorage, supplier);
		}

	}
}




