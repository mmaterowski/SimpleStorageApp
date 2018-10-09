using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class QualityControl : IQualityControl
	{
		public bool QualityControlFailed { get; set; }

		private readonly IConditionChanger conditionChanger;

		public QualityControl(IConditionChanger conditionChangerParam)
		{
			conditionChanger = conditionChangerParam;
		}

		public void ChangeQuality(IGlassware pieceOfGlassware)
		{
			Random rand = new Random();
			int randomValue = rand.Next(0, 100);
			if (pieceOfGlassware.Quality > randomValue)
			{
				pieceOfGlassware.Quality = randomValue;
			}

			conditionChanger.ChangeCondition(pieceOfGlassware);
		}

		public void ChangeQuality(IEnumerable<IGlassware> glasswareCollection)
		{
			foreach (var pieceOfGlassware in glasswareCollection)
			{
				ChangeQuality(pieceOfGlassware);
			}
		}

		public void CheckQuality(IGlassware pieceOfGlassware)
		{
			Console.WriteLine($"{pieceOfGlassware.ToString()} is {pieceOfGlassware.Condition} !");
			if (pieceOfGlassware.Quality<=20)
			{
				QualityControlFailed = true;
			}
			else
			{
				QualityControlFailed = false;
			}
		}

		public void CheckQuality(IEnumerable<IGlassware> glasswareCollection)
		{
			foreach (var pieceOfGlassware in glasswareCollection)
			{
				CheckQuality(pieceOfGlassware);
			}
		}
	}
}
