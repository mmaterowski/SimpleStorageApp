using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class RandomQualityChanger : IChangeQuality
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

		public void ChangeQuality(IEnumerable<IGlassware> glassware)
		{
			foreach (var pieceOfGlassware in glassware)
			{
				ChangeQuality(pieceOfGlassware);
			}
		}
	}
}
