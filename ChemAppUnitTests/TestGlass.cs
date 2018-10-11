using MagazynChemikaCNSLAPP.Abstract;

namespace ChemAppUnitTests
{
	public class TestGlass : IGlassware
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public float Volume { get; set; }
		public int Quality { get; set; }
		public string Condition { get; set; }
		public bool IsClean { get; set; }
		public int ItemID { get; set; }
	}
}
