using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class RegularLabWork : ILabWork
	{
		private IChangeQuality stateChanger;
		private IUsable useStyle;

		public RegularLabWork(IChangeQuality stateChangerParam,IUsable useParam)
		{
			stateChanger = stateChangerParam;
			useStyle = useParam;
		}

		public void ChangeQuality(Glassware glasswareObject)
		{
			stateChanger.ChangeQuality(glasswareObject);
		}

		public void Use(Glassware glasswareObject)
		{
			if (glasswareObject.Quality < 20)
			{
				Console.WriteLine("You cannot use this piece, it's broken and have to be disposed");
			}
			else
			{
				Console.WriteLine("You've used this piece of glassware, now it's dirty");
				glasswareObject.IsClean = false;
				stateChanger.ChangeQuality(glasswareObject);
			}
		}
	}
}
