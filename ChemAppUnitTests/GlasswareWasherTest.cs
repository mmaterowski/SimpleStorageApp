using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChemAppUnitTests
{

	class TestGlass : IGlassware
	{
		public string Name { get; set; }
		public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public float Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int Quality { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Condition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool IsClean { get; set; }

	}
	[TestClass]
	public class GlasswareWasherTest
	{
		GlasswareWasher washer;

		[TestInitialize]
		public void TestInitialize()
		{
			washer = new GlasswareWasher();
		}


		[TestMethod]
		public void Can_Wash_Item()
		{
			//Arrange 
			TestGlass testGlass = new TestGlass() { IsClean = false };

			//Act
			washer.Wash(testGlass);

			//Assert
			Assert.AreEqual(true, testGlass.IsClean);
		}

		[TestMethod]
		public void Can_Wash_All_Items()
		{
			//Arrange
			var testItem1 = new TestGlass { Name = "testPiece1", IsClean = false };
			var testItem2 = new TestGlass { Name = "testPiece2", IsClean = false };
			var testItem3 = new TestGlass { Name = "testPiece3", IsClean = false };

			var testCollection = new List<IGlassware>()
			{
				testItem1,testItem2,testItem3
			};

			//Act
			washer.Wash(testCollection);

			//Assert
			Assert.AreEqual(true, testItem1.IsClean);
			Assert.AreEqual(true, testItem2.IsClean);
			Assert.AreEqual(true, testItem3.IsClean);


		}

		[TestMethod]
		public void Can_CheckIfItemIsClean()
		{
			//Arrange
			TestGlass CleanTestGlass = new TestGlass() { IsClean = true };
			TestGlass DirtyTestGlass = new TestGlass() { IsClean = false };

			//Act
			bool isCleanGlassClean = washer.CheckIfItemIsClean(CleanTestGlass);
			bool isDirtyGlassClean = washer.CheckIfItemIsClean(DirtyTestGlass);


			//Assert
			Assert.IsTrue(isCleanGlassClean);
			Assert.IsFalse(isDirtyGlassClean);
		}

		[TestMethod]
		public void Can_CheckIfAllItemsAreClean()
		{
			//Arrange
			var testItem1 = new TestGlass { Name = "testPiece1", IsClean = false };
			var testItem2 = new TestGlass { Name = "testPiece2", IsClean = false };
			var testItem3 = new TestGlass { Name = "testPiece3", IsClean = false };
			var testItem4 = new TestGlass { Name = "testPiece4", IsClean = true };
			var testItem5 = new TestGlass { Name = "testPiece5", IsClean = true };



			var dirtyTestCollection = new List<IGlassware>() { testItem1, testItem2, testItem3 };
			var cleanTestCollection = new List<IGlassware>() { testItem4, testItem5 };
			var mixedTestCollection = new List<IGlassware>() { testItem1, testItem2, testItem3, testItem4, testItem5 };



			//Act
			bool dirtyCollectionReturnsFalse = washer.CheckIfAllItemsAreClean(dirtyTestCollection);
			bool cleanCollectionReturnsTrue = washer.CheckIfAllItemsAreClean(cleanTestCollection);
			bool mixedCollectionReturnsFalse = washer.CheckIfAllItemsAreClean(mixedTestCollection);

			//Assert
			Assert.IsTrue(cleanCollectionReturnsTrue);
			Assert.IsFalse(dirtyCollectionReturnsFalse);
			Assert.IsFalse(mixedCollectionReturnsFalse);


		}
	}
}
