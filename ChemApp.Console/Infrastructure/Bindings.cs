using ChemApp.Domain.Abstract.ItemMaintainers;
using ChemApp.Domain.Concrete.ItemMaintainers;
using Ninject.Modules;

namespace ChemApp.Domain.Infrastructure
{
	public class Bindings : NinjectModule
	{
		public override void Load()
		{
			Bind<IWash>().To<GlasswareWasher>();
			Bind<IPolish>().To<PolishingKit>();
			Bind<IConditionChanger>().To<QualityBasedConditionChanger>();
			Bind<IChangeQuality>().To<RandomQualityChanger>();
            Bind<IQualityControl>().To<QualityControl>();
            Bind<IMaintainItem>().To<ItemMaintainer>();
		}
	}
}
