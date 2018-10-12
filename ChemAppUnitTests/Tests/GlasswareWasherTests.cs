using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using MagazynChemikaCNSLAPP.Concrete.ItemMaintainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ChemAppUnitTests.Tests
{
	[TestClass]
	public class GlasswareWasherTests
	{
		private TestGlass cleanTestGlass1;
		private TestGlass cleanTestGlass2;
		private TestGlass dirtyTestGlass3;
		private TestGlass dirtyTestGlass4;
		private List<IGlassware> cleanGlasswareCollection;
		private List<IGlassware> dirtyGlasswareCollection;


		[TestInitialize]
		public void Initialize()
		{
			cleanTestGlass1 = new TestGlass() { IsClean = true };
			cleanTestGlass2 = new TestGlass() { IsClean = true };
			dirtyTestGlass3 = new TestGlass() { IsClean = false };
			dirtyTestGlass4 = new TestGlass() { IsClean = false };

			cleanGlasswareCollection = new List<IGlassware>() { cleanTestGlass1, cleanTestGlass2 };
			dirtyGlasswareCollection = new List<IGlassware>() { dirtyTestGlass3, dirtyTestGlass4, cleanTestGlass2 };


		}
		[TestMethod]
		public void Can_CheckIfItemIsClean()
		{
			//Arrange
			GlasswareWasher washer = new GlasswareWasher();

			//Act
			bool shouldBeClean = washer.CheckIfItemIsClean(cleanTestGlass1);
			bool shouldBeDirty = washer.CheckIfItemIsClean(dirtyTestGlass3);

			//Assert
			Assert.AreEqual(true, shouldBeClean);
			Assert.AreEqual(false, shouldBeDirty);

		}

		[TestMethod]
		public void Can_CheckIfCollectionIsClean()
		{
			//Arrange
			GlasswareWasher washer = new GlasswareWasher();

			//Act
			bool shouldBeClean = washer.CheckIfAllItemsAreClean(cleanGlasswareCollection);
			bool shouldBeDirty = washer.CheckIfAllItemsAreClean(dirtyGlasswareCollection);

			//Assert
			Assert.AreEqual(true, shouldBeClean);
			Assert.AreEqual(false, shouldBeDirty);
		}

		[TestMethod]
		public void Can_WashItem()
		{
			//Arrange
			GlasswareWasher washer = new GlasswareWasher();

			//Act
			washer.Wash(dirtyTestGlass3);

			//Assert
			Assert.AreEqual(true, dirtyTestGlass3.IsClean);
		}

		[TestMethod]
		public void Can_WashCollectionOfItems()
		{
			//Arrange 
			GlasswareWasher washer = new GlasswareWasher();

			//Act
			washer.Wash(dirtyGlasswareCollection);

			//Assert
			Assert.AreEqual(true, dirtyGlasswareCollection[0].IsClean);
			Assert.AreEqual(true, dirtyGlasswareCollection[1].IsClean);

		}
	}
}
