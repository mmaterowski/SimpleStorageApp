using MagazynChemikaCNSLAPP.Concrete;
using MagazynChemikaCNSLAPP.Concrete.ItemMaintainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChemAppUnitTests.Tests
{
	[TestClass]
	public class RandomQualityChangerTests
	{
		[TestMethod]
		public void Can_Change_Quality()
		{
			//Arrange
			TestGlass testGlass = new TestGlass { Quality = 100 };
			RandomQualityChanger qualityChanger = new RandomQualityChanger();

			//Act
			qualityChanger.ChangeQuality(testGlass);

			//Assert
			Assert.AreNotEqual(100, testGlass.Quality);

		}
	}
}
