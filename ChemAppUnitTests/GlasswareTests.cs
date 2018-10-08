
using MagazynChemikaCNSLAPP;
using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using MagazynChemikaCNSLAPP.Concrete.Laboratory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChemAppUnitTests
{
	[TestClass]
	public class GlasswareTests
	{
		private class TestGlass : Glassware
		{
			private readonly IGlassware labGlass;
	/*		public TestGlass(IGlassware labGlassParam) : base(labGlassParam)
			{
				this.labGlass = labGlassParam;
			}*/
		}

		[TestMethod]
		public void Can_Wash_Glassware()
		{
			//Arrange
			IWash washingMachine = new WashingMachine();
			IConditionChanger conditionChanger = new ChangeConditionBasedOnQuality();

			IUsable useType = new UseForReaction();
			IQualityControl qualityChanger = new RandomQualityChanger();
			ILaboratory labWork = new ChemicalLaboratory(qualityChanger, useType);

				//	IGlassware labGlass = new LabGlass(conditionChanger, labWork, washingMachine);
				//	TestGlass glass = new TestGlass(labGlass)
				//	{
				//		IsClean = false
				//	};
				//Act
				//	glass.Wash(glass);

				//Assert
				//	Assert.AreEqual(true, glass.IsClean);

					}

				/*	[TestMethod]
					public void Quality_Of_Glassware_Can_Change()
					{
						//Arrange
						IWashable washingMachine = new WashingMachine();
						IConditionChanger conditionChanger = new ChangeConditionBasedOnQuality();

						IUsable useType = new UseForReaction();
						IChangeQuality qualityChanger = new RandomQualityChanger();
						ILaboratory labWork = new RegularLabWork(qualityChanger, useType);

						IGlassware labGlass = new LabGlass(conditionChanger, labWork, washingMachine);
						TestGlass glass = new TestGlass(labGlass);

						//Act
						glass.Use(glass);

						//Assert
						Assert.AreNotEqual(100, glass.Quality);*/
				//	}

				/*	[TestMethod]
					public void Condition_Of_Glassware_Can_Change()
					{
						//Arrange
						IWashable washingMachine = new WashingMachine();
						IConditionChanger conditionChanger = new ChangeConditionBasedOnQuality();

						IUsable useType = new UseForReaction();
						IChangeQuality qualityChanger = new RandomQualityChanger();
						ILaboratory labWork = new RegularLabWork(qualityChanger, useType);

					IGlassware labGlass = new LabGlass(conditionChanger, labWork, washingMachine);
					TestGlass glass = new TestGlass(labGlass)
						{
							Condition = "New",
							Quality = 50
						};

						//Act
						glass.ChangeCondition(glass);

						//Assert
						Assert.AreEqual("Damaged", glass.Condition);
					}*/
			}
		}

