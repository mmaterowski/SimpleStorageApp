﻿using ChemApp.Domain.Abstract;
using ChemApp.Domain.Abstract.ItemMaintainers;
using ChemApp.Domain.Concrete;
using ChemApp.Domain.Concrete.Laboratory;
using ChemApp.Domain.Infrastructure;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChemApp.Domain
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
							Console.WriteLine("This is Your storage:");
							Console.WriteLine();
							myStorage.ShowStorage();
							Console.ReadKey();
						}
						break;
					case 2:
						{
							Console.WriteLine("This is list of products from Your supplier:");
							Console.WriteLine();
							myStorage.ShowItemsThatCanBePurshed();

							Console.WriteLine("Please,type product ID to buy:");
							int productID = GetInputFromUser();
							var supplierProductList = myStorage.GetItemsThatCanBePurshed();

							if (productID < 0 || productID > supplierProductList.Count())
							{
								Console.WriteLine("There's no item with such ID, try again");
								Console.ReadLine();
								break;
							}



							//figure out where and how to assing product IDs
							// change pricing so it makes sense
							var rand = new Random();
							var piece = new Glassware
							{
								Name = supplierProductList[productID].Name,
								Volume = supplierProductList[productID].Volume,
								Price = supplierProductList[productID].Price * ((decimal)rand.Next(95, 99) / 1000),
								ItemID = rand.Next(0, 1000),
								Condition = "New",
								Quality = 100,
								IsClean = true
							};

							myStorage.AddItem(piece);
							Console.WriteLine($"Item {piece.Name} was added!");
							Console.ReadKey();


						}
						break;
					case 3:
						{
							///validation
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
							var kernel = new StandardKernel(new Bindings());
							var itemMaintainer = kernel.Get<IMaintainItem>();
							var qualityControl = kernel.Get<IQualityControl>();
							var qualityChanger = kernel.Get<IChangeQuality>();
							var conditionChanger = kernel.Get<IConditionChanger>();

							ChemicalLaboratory chemicalLaboratory = new ChemicalLaboratory(qualityControl, itemMaintainer, qualityChanger, conditionChanger);
							Console.WriteLine("This is Your chemical laboratory, here You can:");
							LabMenu(chemicalLaboratory, myStorage);
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

		private void LabMenu(ChemicalLaboratory chemLab, Storage myStorage)
		{
			while (true)
			{
				PrintLaboratory();
				int input = GetInputFromUser();

				switch (input)
				{
					case 1:
						Console.WriteLine("I'm attempting to perform a reaction");
						IEnumerable<IGlassware> listOfProducts = myStorage.GetItems();
						System.Threading.Thread.Sleep(500);
						chemLab.PerformReaction(listOfProducts);
						Console.ReadKey();
						break;
					case 2:
						Console.WriteLine("Type id of item to wash it");
						int itemID = GetInputFromUser();
						var foundItem = myStorage.GetItems().FirstOrDefault(i => i.ItemID == itemID);
						if (foundItem != null)
						{
							chemLab.WashItem(foundItem);
						}
						else
						{
							Console.WriteLine($"I didn't find item with ID {itemID}");
						}
						break;
					case 3:
						Console.WriteLine("I'm starting to wash all dirty items in Your storage");
						chemLab.WashDirtyItems(myStorage.GetItems());
						break;
					case 4:
						Console.WriteLine("Type id of item to polish:");
						itemID = GetInputFromUser();
						foundItem = myStorage.GetItems().FirstOrDefault(i => i.ItemID == itemID);
						if (foundItem != null)
						{
							chemLab.PolishItem(foundItem);
						}
						else
						{
							Console.WriteLine($"I didn't find item with ID {itemID}");
						}
						break;
					case 5:
						Console.WriteLine("I'm polishing all items in Your lab");
						chemLab.PolishAllItems(myStorage.GetItems());
						break;
					case 6:
						//code
						break;
					default:
						Console.WriteLine("Wrong choice");
						break;
				}
				Console.Clear();
			}
		}

		private void PrintLaboratory()
		{
			Console.WriteLine("1. Perform a reaction");
			Console.WriteLine("2. Wash an item");
			Console.WriteLine("3. Wash all items");
			Console.WriteLine("4. Polish an item");
			Console.WriteLine("5. Polish all items");
			Console.WriteLine("6. Go back to storage");
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
				return GetInputFromUser();
			}
		}


	}
}