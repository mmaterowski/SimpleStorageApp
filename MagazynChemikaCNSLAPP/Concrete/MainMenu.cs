using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using System;

namespace MagazynChemikaCNSLAPP
{
	class MainMenu
	{
		public void Run(Storage myStorage, ISupplier supplier)
		{
			while (true)
			{
				Welcome();
				int input = GetInputFromUser();
				switch (input)
				{
					case 1:
						{
							myStorage.ShowStorage();
						}
						break;
					case 2:
						{
							var listOfProducts = supplier.GetAvailableProducts();
							Console.WriteLine("This is list of available items:");
							supplier.DisplayProductsList(listOfProducts);

							Console.WriteLine("Please,type product ID to buy:");
							int productID = GetInputFromUser();

							var productDataString = listOfProducts[productID];
							var productDataTable = productDataString.Split(',');
							var productData = new ProductData(productDataTable[0], int.Parse(productDataTable[1]));

							//figure out where and how to assing product IDs
							var rand = new Random();
							var piece = new Glassware
							{
								Name = productData.Name,
								Volume = productData.Volume,
								Price = 100M,
								ItemID = rand.Next(0, 1000)
							};

							myStorage.AddItem(piece);
							Console.WriteLine($"Item {piece.Name} was added!");
							Console.ReadKey();


						}
						break;
					case 3:
						{
							Console.WriteLine("This is list of Your products");
							Console.WriteLine();
							myStorage.ShowStorage();
							Console.WriteLine();
							Console.WriteLine("Type ID of product You want to throw out");
							int itemID = GetInputFromUser();
							myStorage.DeleteItem(itemID);
							Console.WriteLine($"Item with id: {itemID} was thrown out!");
							Console.ReadLine();
						}
						break;
					case 4:
						{

							Console.WriteLine("You may perform a reaction here.");
							Console.ReadKey();
						}
						break;
					default:
						{
							Console.WriteLine("Wrong choice!");
							Console.ReadKey();
							break;
						}

				}
				Console.Clear();
			}

		}



		public void Welcome()
		{
			Console.WriteLine("Welcome to your magazine!");
			Console.WriteLine("1.Check storage");
			Console.WriteLine("2.Add item");
			Console.WriteLine("3.Delete item");
			Console.WriteLine("4.Enter laboratory");
			Console.WriteLine("____________________________________");
		}




		private int GetInputFromUser()
		{
			string inputFromUser = Console.ReadLine();

			if (Int32.TryParse(inputFromUser, out int parsedNumber))
			{
				return parsedNumber;
			}
			else
			{
				Console.WriteLine("Please, type a valid input");
				return 0;
			}
		}


	}
}
