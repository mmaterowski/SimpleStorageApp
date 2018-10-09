using MagazynChemikaCNSLAPP.Abstract;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class PolishKit : IPolish
	{
		public void Polish(IGlassware pieceOfGlassware)
		{
			System.Console.WriteLine($"Polishing {pieceOfGlassware.ToString()}...");
			System.Threading.Thread.Sleep(300);
			System.Console.WriteLine($"{pieceOfGlassware.ToString()} is now clean and shiny!");
		}

		public void PolishAllItems(IEnumerable<IGlassware> glasswareCollection)
		{
			foreach (var pieceOfGlassware in glasswareCollection)
			{
				Polish(pieceOfGlassware);
			}
			System.Console.WriteLine();
			System.Console.WriteLine("All Your items are clean and shiny now !");
		}
	}
}
