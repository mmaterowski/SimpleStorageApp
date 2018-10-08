using MagazynChemikaCNSLAPP.Abstract;
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

			MainMenu.Run(labGlass);
		}

	}
}




