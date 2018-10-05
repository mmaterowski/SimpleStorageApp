using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class WashingMachine : IWashable
	{
		public void Wash(Glassware glassObject)
		{
			if (!glassObject.IsClean)
			{
				Console.WriteLine($"I'm starting to wash Your {glassObject.Name}");
				SimulateWashingProcess();
				glassObject.IsClean = true;
			}
			else
			{
				Console.WriteLine($"{glassObject.Name} is already clean!");
			}
		}

		private void SimulateWashingProcess()
		{
			string washingString = "";
			for (int i = 0; i < 3; i++)
			{
				washingString += ".";
				System.Threading.Thread.Sleep(100);
				if (washingString == "...")
				{
					i++;
					washingString = "";
				}

			}
		}
	}
}
