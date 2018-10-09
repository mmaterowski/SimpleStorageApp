using MagazynChemikaCNSLAPP.Abstract;
using System.Collections.Generic;
using System;
using System.Threading;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class PolishKit : IPolish
	{
		public void Polish(IGlassware pieceOfGlassware)
		{
			Console.WriteLine($"Polishing {pieceOfGlassware.ToString()}...");
			Thread.Sleep(300);
			Console.WriteLine($"{pieceOfGlassware.ToString()} is now clean and shiny!");
		}

		public void PolishAllItems(IEnumerable<IGlassware> glasswareCollection)
		{
			foreach (var pieceOfGlassware in glasswareCollection)
			{
				Polish(pieceOfGlassware);
			}
			Console.WriteLine();
			Console.WriteLine("All Your items are clean and shiny now !");
		}
	}
}
