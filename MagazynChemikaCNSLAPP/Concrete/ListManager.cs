using MagazynChemikaCNSLAPP;
using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;


class ListManager
{
	static List<Glassware> glass = new List<Glassware>();

	public static void ShowStorage()
	{
		IsStorageEmpty();
		PrintStorage();
		SummarizeEquipment();
		Console.ReadKey();
	}

	private static void IsStorageEmpty()
	{
		if (glass.Count == 0)
		{ Console.WriteLine("Storage is empty"); }
	}

	private static void PrintStorage()
	{
		foreach (Glassware piece in glass)
		{
			Console.WriteLine("Name: {0}, ID:{1}, Velocity: {2} ml, Price: {3}$", piece, piece.ThisItemID, piece.velocity, piece.price);
		}
	}

	private static void SummarizeEquipment()
	{
		Console.WriteLine("__________________________________________________________");
		Console.WriteLine("Total items:{0} \t Total value: {1:N2}$", Glassware.ItemCounter, Glassware.PriceOfAllGlassware);
	}

	public static void AddItem(int option,IWashable washingMethod)
	{
		if (option != 1 && option != 2)
		{
			Console.WriteLine("Wrong choice!");
		}
		else if (option == 1)
			glass.Add(Beaker.AddBeaker(washingMethod));
		else if (option == 2)
			glass.Add(Flask.AddFlask(washingMethod));

		Console.ReadKey();
	}


	public static void DeleteItem()
	{
		if (glass.Count == 0)
		{
			Console.WriteLine("The storage is empty");
		}
		else
		{
			Console.WriteLine("Give ID of item which you intent to throw out");
			int id = MainMenu.InputNumber();
			GoThruList(id);
		}
		Console.ReadLine();

	}

	private static void GoThruList(int id)
	{
		foreach (Glassware piece in glass)
		{
			if (piece.ThisItemID == id)
			{
				ConfirmDelete(piece);
				return;
			}
		}
		Console.WriteLine("I didn't find piece of this ID");
	}

	private static void ThrowOutThisItem(Glassware piece)
	{
		glass.Remove(piece);
		Glassware.ItemCounter--;
		Glassware.PriceOfAllGlassware = Glassware.PriceOfAllGlassware - piece.price;
		Console.WriteLine("Item has been thrown out.");

	}

	private static void ConfirmDelete(Glassware piece)

	{
		Console.WriteLine("Do you want to throw out {0}, quality={1}? \n y/n?", piece.ToString(), piece.CurrentState);
		string choice = Console.ReadLine();
		if (choice == "y")
		{
			ThrowOutThisItem(piece);
		}


		else if (choice == "n")
			Console.WriteLine("Item of id: {0} wasn't deleted", piece.ThisItemID);

		else
		{
			Console.WriteLine("Wrong choice");
			ConfirmDelete(piece);
		}

	}
}


