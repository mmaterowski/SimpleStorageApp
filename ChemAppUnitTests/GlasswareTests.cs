
using MagazynChemikaCNSLAPP;
using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChemAppUnitTests
{
	[TestClass]
	public class GlasswareTests
	{
		private class TestGlass : Glassware
		{
			private IWashable washingMethod;
			public TestGlass(IWashable washingMethod) : base(washingMethod)
			{
				this.washingMethod = washingMethod;
			}

			public void Wash()
			{
				washingMethod.Wash(this);
			}
		}

		[TestMethod]
		public void Can_Wash_Glassware()
		{
			//Arrange
			IWashable washingMachine = new WashingMachine();
			TestGlass glass = new TestGlass(washingMachine);
			glass.IsClean = true;
			//Act
			glass.Wash();

			//Assert
			Assert.AreEqual(true, glass.IsClean);

		}

		[TestMethod]
		public void Quality_Of_Glassware_Can_Change()
		{
			//Arrange
			IWashable washingMachine = new WashingMachine();
			TestGlass glass = new TestGlass(washingMachine);

			//Act
			glass.Use(glass);

			//Assert
			Assert.AreNotEqual(100, glass.Quality);
		}
	}
}

