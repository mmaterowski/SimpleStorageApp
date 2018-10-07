using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class UseForReaction : IUsable
	{
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
			}
		}
	}
}
