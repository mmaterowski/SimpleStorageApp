using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class GlasswareWasher : IWash
	{
		public void Wash(IGlassware glassware)
		{
			if (!glassware.IsClean)
			{
				Console.WriteLine($"I'm starting to wash Your {glassware.ToString()}");
				SimulateWashingProcess();
				glassware.IsClean = true;
			}
			else
			{
				Console.WriteLine($"{glassware.ToString()} is already clean!");
			}
		}

		public void Wash(IEnumerable<IGlassware> glasswareCollection)
		{
			foreach (var pieceOfGlassware in glasswareCollection)
			{
				Wash(pieceOfGlassware);
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
