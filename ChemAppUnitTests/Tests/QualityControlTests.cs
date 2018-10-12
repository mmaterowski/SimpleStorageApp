using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Abstract.ItemMaintainers;
using MagazynChemikaCNSLAPP.Concrete;
using MagazynChemikaCNSLAPP.Concrete.ItemMaintainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace ChemAppUnitTests.Tests
{
	[TestClass]
	public class QualityControlTests
	{
		[TestMethod]
		public void Can_Check_Quality()
		{
			//Arrange
			IConditionChanger changer = new QualityBasedConditionChanger();
			var qualityController = new QualityControl();
			TestGlass goodQualityGlass = new TestGlass() { Quality = 100, Condition = "New" };
			TestGlass brokenGlass = new TestGlass() { Quality = 15, Condition = "Broken" };
			List<TestGlass> listOfGlassware = new List<TestGlass>() { goodQualityGlass, brokenGlass };

			//Act
			qualityController.CheckQuality(goodQualityGlass);
			//Assert
			Assert.IsFalse(qualityController.QualityControlFailed);

			//Act
			qualityController.CheckQuality(brokenGlass);
			//Assert
			Assert.IsTrue(qualityController.QualityControlFailed);

			//Act
			qualityController.CheckQuality(listOfGlassware);
			//Assert
			Assert.IsTrue(qualityController.QualityControlFailed);

		}
	}
}
