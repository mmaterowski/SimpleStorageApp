using ChemApp.Domain.Abstract;
using ChemApp.Domain.Abstract.ItemMaintainers;
using System;
using System.Collections.Generic;

namespace ChemApp.Domain.Concrete.ItemMaintainers
{
	public class QualityBasedConditionChanger : IConditionChanger
	{

		public void ChangeCondition(IGlassware glassware)
		{
			Console.WriteLine();
			if (glassware.Quality == 100) { glassware.Condition = "New"; }
			else if (glassware.Quality > 75) { glassware.Condition = "Good"; }
			else if (glassware.Quality > 25)
			{
				glassware.Condition = "Damaged";
				Console.WriteLine($"Your {glassware.ToString()} is now damaged, but You can still use it");
			}
			else if (glassware.Quality <= 20)
			{
				glassware.Condition = "Broken";
				Console.WriteLine($"You've broken {glassware.ToString()} !");
			}
		}

		public void ChangeCondition(IEnumerable<IGlassware> glasswareCollection)
		{
			foreach (var pieceOfGlassware in glasswareCollection)
			{
				ChangeCondition(pieceOfGlassware);
			}
		}
	}
}
