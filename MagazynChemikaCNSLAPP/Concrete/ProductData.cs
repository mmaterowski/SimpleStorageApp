namespace MagazynChemikaCNSLAPP.Concrete
{
	public struct ProductData
	{
		public int Volume { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int SupplierID { get; set; }

		public ProductData(int supplierID, string name, int volume, decimal price)
		{
			Name = name;
			Volume = volume;
			Price = price;
			SupplierID = supplierID;
		}
	}
}
