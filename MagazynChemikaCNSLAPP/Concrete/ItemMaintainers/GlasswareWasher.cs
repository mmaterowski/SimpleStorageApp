using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Abstract.ItemMaintainers;
using System;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete.ItemMaintainers
{
	public class GlasswareWasher : IWash
	{
		public bool CheckIfAllItemsAreClean(IEnumerable<IGlassware> glasswareCollection)
		{
			foreach (var pieceOfGlassware in glasswareCollection)
			{
				if (!pieceOfGlassware.IsClean)
				{
					return false;
				}
			}
			return true;

		}

		public bool CheckIfItemIsClean(IGlassware pieceOfGlassware)
		{
			if (pieceOfGlassware.IsClean)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Wash(IGlassware glassware)
		{
			if (!glassware.IsClean)
			{
				Console.WriteLine($"I'm starting to wash Your {glassware.ToString()}");
				SimulateWashingProcess();
				Console.WriteLine($"Your item {glassware.ToString()} is clean");
				glassware.IsClean = true;
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
				Console.WriteLine(washingString);
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
