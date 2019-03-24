using ChemApp.Domain.Abstract;
using System.Collections.Generic;
using System;
using System.Threading;
using ChemApp.Domain.Abstract.ItemMaintainers;

namespace ChemApp.Domain.Concrete.ItemMaintainers
{
	public class PolishingKit : IPolish
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
