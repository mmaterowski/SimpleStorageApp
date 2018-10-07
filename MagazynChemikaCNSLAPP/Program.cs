using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;

namespace MagazynChemikaCNSLAPP
{
	class Program
	{
		static void Main(string[] args)
		{
			IWashable washMachine = new WashingMachine();
			IConditionChanger conditionChanger = new ChangeConditionBasedOnQuality();

			IChangeQuality qualityChanger = new RandomQualityChanger();
			IUsable labActivity = new RegularItemUse();
			ILabWork labWork = new RegularLabWork(qualityChanger, labActivity);
			MainMenu.Run(washMachine, labWork, conditionChanger);
		}

	}
}




