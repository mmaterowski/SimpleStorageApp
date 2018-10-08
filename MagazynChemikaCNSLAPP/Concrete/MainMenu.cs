using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using System;

namespace MagazynChemikaCNSLAPP
{
	class MainMenu
	{
		private int input;



		public void Run(Storage myStorage, ISupplier supplier)
		{
			while (true)
			{
				Welcome();
				GetInputFromUser();
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
							GetInputFromUser();
							int productID = input;
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
							Console.WriteLine("This is list of Your products, type ID if You want to throw it out");
							myStorage.ShowStorage();
							GetInputFromUser();
							myStorage.DeleteItem(input);
							Console.WriteLine($"Item with {input} was thrown out!");
							Console.ReadLine();
						}
						break;
					case 4:
						{
							Console.WriteLine(" \t $$ Pay one milion money to unlock this functionality $$");
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
			Console.WriteLine("4.Use item");
			Console.WriteLine("____________________________________");
		}




		private void GetInputFromUser()
		{
			string inputFromUser = Console.ReadLine();
			if (Int32.TryParse(inputFromUser, out input))
			{
				input = Int32.Parse(inputFromUser);
			}
			else
			{
				Console.WriteLine("Please, type a valid input");
			}
		}


	}
}
