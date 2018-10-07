using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class RandomQualityChanger : IChangeQuality
	{
		public void ChangeQuality(Glassware glasswareObject)
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
