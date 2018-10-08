using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using Ninject.Modules;

namespace MagazynChemikaCNSLAPP.Infrastructure
{
	public class Bindings : NinjectModule
	{
		public override void Load()
		{
			Bind<IGlassware>().To<LabGlass>();
			Bind<IWashable>().To<WashingMachine>();
			Bind<IConditionChanger>().To<ChangeConditionBasedOnQuality>();
			Bind<IChangeQuality>().To<RandomQualityChanger>();
			Bind<IUsable>().To<UseForReaction>();
			Bind<ILabWork>().To<RegularLabWork>();
		}
	}
}
