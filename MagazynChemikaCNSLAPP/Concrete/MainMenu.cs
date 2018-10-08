using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using System;

namespace MagazynChemikaCNSLAPP
{
	class MainMenu
	{
		private int input;

		static MainMenu AppController = new MainMenu();

		public static void Run(Storage myStorage, ISupplier supplier)
		{
			while (true)
			{
				AppController.Welcome();
				switch (AppController.InputFromUser())
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
							int productID = InputNumber();
							var productDataString = listOfProducts[productID];

							var productDataTable = productDataString.Split(',');

							var productData = new ProductData(productDataTable[0], int.Parse(productDataTable[1]));

							//figure out where and how to assing product IDs
							var rand = new Random();
							var piece = new PieceOfGlassware
							{
								Name = productData.Name,
								Volume = productData.Volume,
								Price = 100M,
								ItemID = rand.Next(0, 1000)
							};

							myStorage.AddItem(piece);


						}
						break;
					case 3:
						{
							Console.WriteLine("This is list of Your products, type ID if You want to throw it out");
							myStorage.ShowStorage();
							Console.WriteLine("Type ID of item which you intent to throw out");
							int productId = InputNumber();
							myStorage.DeleteItem(productId);
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
			Console.WriteLine("Welcome to your chemistry's magazine!");
			Console.WriteLine("1.Check storage");
			Console.WriteLine("2.Add item");
			Console.WriteLine("3.Delete item");
			Console.WriteLine("4.Change item");
			Console.WriteLine("____________________________________");
		}

		public int InputFromUser()
		{
			if (GetValue())
			{
				return input;
			}
			else
				return -1;
		}

		private bool GetValue()
		{

			{
				try
				{
					input = Int16.Parse(Console.ReadLine());
					return true;
				}



				catch (System.FormatException)
				{
					Console.WriteLine("Value must be an integer!");
					return false;
				}


			}
		}

		private static int ItemChoice()
		{
			Console.WriteLine("What do you want to store?");
			Console.WriteLine("1. Beaker");
			Console.WriteLine("2. Flask");
			return InputNumber();
		}

		public static int InputNumber()
		{
			int temp;
			try
			{
				temp = (Int32.Parse(Console.ReadLine()));
				if (IsReal(temp))
					return temp;
				else throw new System.FormatException();
			}
			catch (System.FormatException)
			{
				return -1;
			}
		}

		private static bool IsReal(int temp)
		{
			if (temp >= 0)
			{
				return true;
			}
			else
				return false;
		}

	}
}
