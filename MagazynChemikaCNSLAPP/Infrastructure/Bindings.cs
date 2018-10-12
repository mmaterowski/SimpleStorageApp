using MagazynChemikaCNSLAPP.Abstract.ItemMaintainers;
using MagazynChemikaCNSLAPP.Concrete.ItemMaintainers;
using Ninject.Modules;

namespace MagazynChemikaCNSLAPP.Infrastructure
{
	public class Bindings : NinjectModule
	{
		public override void Load()
		{
			Bind<IWash>().To<GlasswareWasher>();
			Bind<IPolish>().To<PolishingKit>();
			Bind<IConditionChanger>().To<QualityBasedConditionChanger>();
			Bind<IChangeQuality>().To<RandomQualityChanger>();
			Bind<IMaintainItem>().To<ItemMaintainer>();
		}
	}
}
