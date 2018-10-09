using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemAppUnitTests
{
	public class TestGlass : IGlassware
	{
		public string Name { get; set; }
		public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public float Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int Quality { get; set; }
		public string Condition { get; set; }
		public bool IsClean { get; set; }

	}
}
