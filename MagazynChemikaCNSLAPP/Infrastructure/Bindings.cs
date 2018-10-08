using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using MagazynChemikaCNSLAPP.Concrete.Laboratory;
using Ninject.Modules;

namespace MagazynChemikaCNSLAPP.Infrastructure
{
	public class Bindings : NinjectModule
	{
		public override void Load()
		{
			Bind<IWash>().To<WashingMachine>();
			Bind<IConditionChanger>().To<ChangeConditionBasedOnQuality>();
			Bind<IQualityControl>().To<RandomQualityChanger>();
			Bind<IUsable>().To<UseForReaction>();
			Bind<ILaboratory>().To<ChemicalLaboratory>();
		}
	}
}
