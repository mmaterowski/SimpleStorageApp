using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

public class Storage
{
	private List<Glassware> storageItems;
	private readonly ISupplier supplyCompany;
	private int _productID;

	public int ProductID
	{
		get { return _productID; }
		set
		{
			_productID = value;
			_productID++;
		}
	}


	public Storage(ISupplier supplier)
	{
		supplyCompany = supplier;
		storageItems = new List<Glassware>();
	}
	public static decimal PriceOfAllGlassware { get; set; }

	public void ShowStorage()
	{
		CheckIfStorageEmpty();
		PrintStorage();
		SummarizeEquipment();
	}

	private void CheckIfStorageEmpty()
	{
		if (storageItems.Count == 0)
		{ Console.WriteLine("Storage is empty"); }
	}

	private void PrintStorage()
	{
		foreach (Glassware piece in storageItems)
		{
			Console.WriteLine($"Name: {piece.Name} ID: {piece.ItemID} Velocity: {piece.Volume}ml Price: {piece.Price}$");
		}
	}

	private void SummarizeEquipment()
	{
		Console.WriteLine("__________________________________________________________");
		Console.WriteLine($"Total items:{storageItems.Count} \t Total Value:{PriceOfAllGlassware}");
	}

	public void AddItem(Glassware piece)
	{
		storageItems.Add(piece);
	}





	public void DeleteItem(int itemID)
	{
		var productToDelete = storageItems.FirstOrDefault(p => p.ItemID == itemID);
		storageItems.Remove(productToDelete);


	}

	/*private static void GoThruList(int id)
	{
		foreach (Glassware piece in storageItems)
		{
			if (piece.ItemID == id)
			{
				ConfirmDelete(piece);
				return;
			}
		}
		Console.WriteLine("I didn't find piece of this ID");
	}

	private static void ThrowOutThisItem(Glassware piece)
	{
		storageItems.Remove(piece);
		Glassware.ItemCounter--;
		PriceOfAllGlassware -= piece.Price;
		Console.WriteLine("Item has been thrown out.");

	}*/

	/*private static void ConfirmDelete(Glassware piece)

	{
		Console.WriteLine("Do you want to throw out {0}, quality={1}? \n y/n?", piece.ToString(), piece.Condition);
		string choice = Console.ReadLine();
		if (choice == "y")
		{
			ThrowOutThisItem(piece);
		}


		else if (choice == "n")
			Console.WriteLine("Item of id: {0} wasn't deleted", piece.ItemID);

		else
		{
			Console.WriteLine("Wrong choice");
			ConfirmDelete(piece);
		}

	}*/
}


