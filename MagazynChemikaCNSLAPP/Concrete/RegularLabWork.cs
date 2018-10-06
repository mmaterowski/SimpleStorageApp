using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class RegularLabWork : IChangeItemState
	{
		private IChangeItemState stateChanger;

		public RegularLabWork(IChangeItemState stateChangerParam)
		{
			stateChanger = stateChangerParam;
		}

		public void Change(Glassware glasswareObject)
		{
			UseGlassware(glasswareObject);
			stateChanger.Change(glasswareObject);
		}

		private void UseGlassware(Glassware glasswareObject)
		{
			if (glasswareObject.Quality < 20)
			{
				Console.WriteLine("You cannot use this piece, it's broken and have to be disposed");
			}
			else
			{
				Console.WriteLine("You've used this piece of glassware, now it's dirty");
				glasswareObject.IsClean = false;
				stateChanger.Change(glasswareObject);
			}
		}
	}
}
