
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
			public TestGlass(IWashable washingMethod, ILabWork labWork, IConditionChanger conditionChanger) : base(washingMethod, labWork, conditionChanger)
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
			IConditionChanger conditionChanger = new ChangeConditionBasedOnQuality();

			IUsable useType = new RegularItemUse();
			IChangeQuality qualityChanger = new RandomQualityChanger();
			ILabWork labWork = new RegularLabWork(qualityChanger, useType);
			TestGlass glass = new TestGlass(washingMachine, labWork, conditionChanger);

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
			IConditionChanger conditionChanger = new ChangeConditionBasedOnQuality();

			IUsable useType = new RegularItemUse();
			IChangeQuality qualityChanger = new RandomQualityChanger();
			ILabWork labWork = new RegularLabWork(qualityChanger, useType);
			TestGlass glass = new TestGlass(washingMachine, labWork, conditionChanger);

			//Act
			glass.Use(glass);

			//Assert
			Assert.AreNotEqual(100, glass.Quality);
		}

		[TestMethod]
		public void Condition_Of_Glassware_Can_Change()
		{
			//Arrange
			IWashable washingMachine = new WashingMachine();
			IConditionChanger conditionChanger = new ChangeConditionBasedOnQuality();

			IUsable useType = new RegularItemUse();
			IChangeQuality qualityChanger = new RandomQualityChanger();
			ILabWork labWork = new RegularLabWork(qualityChanger, useType);
			TestGlass testGlass = new TestGlass(washingMachine, labWork, conditionChanger);

			//Act
			testGlass.Condition = "New";
			testGlass.Quality = 50;
			testGlass.ChangeCondition(testGlass);

			//Assert
			Assert.AreEqual("Damaged", testGlass.Condition);
		}
	}
}

