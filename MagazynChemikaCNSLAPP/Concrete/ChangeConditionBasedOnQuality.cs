using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class ChangeConditionBasedOnQuality : IConditionChanger
	{
		public void ChangeCondition(IGlassware glassware)
		{
			if (glassware.Quality == 100) { glassware.Condition = "New"; }
			else if (glassware.Quality > 75) { glassware.Condition = "Good"; }
			else if (glassware.Quality > 25)
			{
				glassware.Condition = "Damaged";
				Console.WriteLine("Your beaker is now damaged, but You can still use it");
			}
			else if (glassware.Quality <= 20)
			{
				glassware.Condition = "ToTrash";
				Console.WriteLine("You broke this piece !");
			}
		}
	}
}
