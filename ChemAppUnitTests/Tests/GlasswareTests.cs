using MagazynChemikaCNSLAPP.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChemAppUnitTests.Tests
{
	[TestClass]
	public class GlasswareTests
	{
		[TestMethod]
		public void Valid_ToString_Override()
		{
			//Arrange
			Glassware testGlass = new Glassware() { Name = "Beaker", Volume = 100 };

			//Act
			string glassDescription = testGlass.ToString();

			//Assert
			Assert.AreEqual("Beaker (100ml)", glassDescription);
		}
	}
}
