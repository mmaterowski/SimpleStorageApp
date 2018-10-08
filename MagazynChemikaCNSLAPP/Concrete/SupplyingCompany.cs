using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class SupplyingCompany : ISupplier
	{


		private string[] availableVolumes = new string[] { "50", "100", "150", "200", "250", "500" };
		private string[] availableEquipment = new string[]
		{
				"Conical flask",
				"Volumetric flask",
				"Round-bottom flask",
				"Filter funnel",
				"Graduated cylinder",
				"Test tube",
				"Beaker"
		};


		public string[] GetAvailableProducts()
		{
			var capacity = (availableVolumes.Length) * (availableEquipment.Length);
			string[] listOfProducts = new string[capacity];
			int iterator = 0;
			for (int i = 0; i < availableEquipment.Length; i++)
			{
				for (int j = 0; j < availableVolumes.Length; j++)
				{
					listOfProducts[iterator] = availableEquipment[i] + "," + availableVolumes[j];
					iterator++;

				}
			}

			return listOfProducts;
		}

		public void DisplayProductsList(string[] listOfProducts)
		{
			for (int i = 0; i < listOfProducts.Length; i++)
			{
				Console.WriteLine($"ProductID: {i}, Name: {listOfProducts[i]}");
			}
		}

	}
}



