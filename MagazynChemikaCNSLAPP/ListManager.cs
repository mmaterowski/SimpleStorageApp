using MagazynChemikaCNSLAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ListManager
{
	static List<Glassware> glass = new List<Glassware>();
	private static int id;

	public static void ShowStorage()
	{
		IsStorageEmpty();
		PrintStorage();
		SummarizeEquipment();
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
			Console.WriteLine("Name{0}, ID:{1}, Velocity: {2} ml, Price: {3}$", piece, piece.ThisItemID, piece.velocity, piece.price);
		}
	}

	private static void SummarizeEquipment()
	{
		Console.WriteLine("__________________________________________________________");
		Console.WriteLine("Total items:{0} \t Total value: {1:N2}$", Glassware.ItemCounter, Glassware.PriceOfAllGlassware);
	}

	public static void AddItem(int option)
	{
		if (option == 1)
			glass.Add(Beaker.AddBeaker());
		if (option == 2)
			glass.Add(Flask.AddFlask());
		else
		{
			Console.WriteLine("Wrong choice!");
		}

	}


	public static void DeleteItem()
	{
		id = WhichItem();
		GoThruList();

	}

	private static int WhichItem()
	{
		Console.WriteLine("Give ID of item which you intent to throw out");
		int id = Int32.Parse(Console.ReadLine());
		return id;
	}

	private static void GoThruList()
	{
		foreach (Glassware piece in glass)
		{
			if (piece.ThisItemID == id)
			{
				ConfirmDelete(piece);
				break;
			}


		}
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
		}

		}
	}

	
	