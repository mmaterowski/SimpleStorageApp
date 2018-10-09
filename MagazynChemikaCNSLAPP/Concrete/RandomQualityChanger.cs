using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class RandomQualityChanger 
	{
		
		public void ChangeQuality(IGlassware glasswareObject)
		{
			Random rand = new Random();
			int randomValue = rand.Next(0, 100);
			if (glasswareObject.Quality > randomValue)
			{
				glasswareObject.Quality = randomValue;
			}
		}
	}
}
