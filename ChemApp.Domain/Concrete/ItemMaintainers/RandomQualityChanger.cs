using ChemApp.Domain.Abstract;
using ChemApp.Domain.Abstract.ItemMaintainers;
using System;
using System.Collections.Generic;

namespace ChemApp.Domain.Concrete.ItemMaintainers
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
