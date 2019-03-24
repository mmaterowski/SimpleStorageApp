using ChemApp.Domain.Abstract;
using ChemApp.Domain.Abstract.ItemMaintainers;
using System;
using System.Collections.Generic;

namespace ChemApp.Domain.Concrete.ItemMaintainers
{
	public class QualityControl : IQualityControl
	{
		public bool QualityControlFailed { get; set; } = false;

		public void CheckQuality(IGlassware pieceOfGlassware)
		{
			Console.WriteLine($"{pieceOfGlassware.ToString()} is {pieceOfGlassware.Condition} !");
			if (pieceOfGlassware.Quality <= 20)
			{
				QualityControlFailed = true;
			}

		}

		public void CheckQuality(IEnumerable<IGlassware> glasswareCollection)
		{
			Console.WriteLine("I'm performing quality control.");
			Console.WriteLine();
			QualityControlFailed = false;
			foreach (var pieceOfGlassware in glasswareCollection)
			{
				CheckQuality(pieceOfGlassware);
			}
			Console.WriteLine();
		}
	}
}
