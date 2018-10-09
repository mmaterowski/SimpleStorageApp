using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using Ninject.Modules;

namespace MagazynChemikaCNSLAPP.Infrastructure
{
	public class Bindings : NinjectModule
	{
		public override void Load()
		{
			Bind<IWash>().To<GlasswareWasher>();
			Bind<IPolish>().To<PolishKit>();
			Bind<IThrowOut>().To<ChemicalDisposer>();
			Bind<IConditionChanger>().To<QualityBasedConditionChanger>();
			Bind<IChangeQuality>().To<RandomQualityChanger>();
			Bind<IMaintainItem>().To<ItemMaintainer>();


		}
	}
}
