using MagazynChemikaCNSLAPP.Abstract;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class Glassware : IGlassware
	{
		public string Name { get; set; }
		public int ItemID { get; set; }
		public decimal Price { get; set; }
		public float Volume { get; set; }
		public int Quality { get; set; }
		public string Condition { get; set; }
		public bool IsClean { get; set; }

		override public string ToString()
		{
			return $"{this.Name} ({this.Volume}ml)";
		}
	}
}
