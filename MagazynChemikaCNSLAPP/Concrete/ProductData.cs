namespace MagazynChemikaCNSLAPP.Concrete
{
	public struct ProductData
	{
		public int Volume { get; set; }
		public string Name { get; set; }

		public ProductData(string name, int volume)
		{
			Name = name;
			Volume = volume;
		}
	}
}
