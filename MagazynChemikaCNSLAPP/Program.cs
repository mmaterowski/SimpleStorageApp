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
			IUsable labActivity = new UseForReaction();
			ILabWork labWork = new RegularLabWork(qualityChanger, labActivity);

			IGlassware labGlass = new LabGlass(conditionChanger,labWork, washMachine);
			MainMenu.Run(labGlass);
		}

	}
}




