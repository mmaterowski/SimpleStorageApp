using MagazynChemikaCNSLAPP.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ChemAppUnitTests
{
	public class FakeSupplier : ISupplier
	{
		public void DisplayProductsList(string[] listOfProducts)
		{
			//do nothing
		}

		public string[] GetAvailableProducts()
		{
			string[] data = new string[]
			{
				"product,250,10",
				"otherproduct,500,50",
				"product2,240,20"
			};

			return data;
		}
	}

	[TestClass]
	public class StorageTests
	{
		private FakeSupplier fakeSupplier;
		private Storage storage;
		private IGlassware glass;

		[TestInitialize]
		public void Initialize()
		{
			fakeSupplier = new FakeSupplier();
			storage = new Storage(fakeSupplier);
			glass = new TestGlass() { ItemID = 0 };
		}

		[TestMethod]
		public void Can_Add_Product()
		{
			//Act
			storage.AddItem(glass);
			var listOfProducts = storage.GetItems();

			//Assert
			Assert.AreEqual(1, listOfProducts.Count);
		}

		[TestMethod]
		public void Can_Delete_Product()
		{
			//Arrange
			storage.AddItem(glass);

			//Act
			storage.DeleteItem(0);
			var listOfProducts = storage.GetItems();


			//Assert
			Assert.AreEqual(0, listOfProducts.Count);
		}

		[TestMethod]
		public void Can_SumValueOfAllProducts()
		{
			//Arrange
			var testItem1 = new TestGlass { Name = "testPiece1", Price = 20M };
			var testItem2 = new TestGlass { Name = "testPiece2", Price = 10M };
			var testItem3 = new TestGlass { Name = "testPiece3", Price = 10M };

			storage.AddItem(testItem1);
			storage.AddItem(testItem2);
			storage.AddItem(testItem3);


			//Act
			var totalSum = storage.GetTotalPriceOfItems();

			//Assert
			Assert.AreEqual(40M, totalSum);

		}

		[TestMethod]
		public void Can_GetListOfStorageItems()
		{
			//Arrange
			var testGlass1 = new TestGlass();
			var testGlass2 = new TestGlass();
			var testList = new List<IGlassware>()
			{
				testGlass1,testGlass2
			};
			storage.AddItem(testGlass1);
			storage.AddItem(testGlass2);

			//Act
			var storageGlassware = storage.GetItems();

			//Assert
			Assert.AreEqual(testList[0], storageGlassware[0]);
			Assert.AreEqual(testList[1], storageGlassware[1]);

		}
	}
}
