using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class RandomQualityChanger : IQualityControl
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
