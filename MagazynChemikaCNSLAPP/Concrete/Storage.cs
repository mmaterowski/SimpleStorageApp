﻿using MagazynChemikaCNSLAPP.Abstract;
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

	public List<Glassware> GetItems()
	{
		return storageItems;
	}
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
			Console.WriteLine($"Name: {piece.Name} ID: {piece.ItemID} Velocity: {piece.Volume}ml Price: {piece.Price:N2}$");
		}
	}

	private void SummarizeEquipment()
	{
		var priceOfAllGlassware = storageItems.Sum(m => m.Price);
		Console.WriteLine("__________________________________________________________");
		Console.WriteLine($"Total items: {storageItems.Count} \t Total Value: {priceOfAllGlassware:N2}");
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

}


