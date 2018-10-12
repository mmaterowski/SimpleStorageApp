using MagazynChemikaCNSLAPP.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChemAppUnitTests
{
	[TestClass]
	public class QualityBasedConditionChangerTests
	{
		[TestMethod]
		public void Can_ChangeQuality()
		{
			//Arrange
			QualityBasedConditionChanger qualityChanger = new QualityBasedConditionChanger();
			var NewGlass = new TestGlass() { Quality = 100 };
			var GoodGlass = new TestGlass() { Quality = 80 };
			var DamagedGlass = new TestGlass() { Quality = 50 };
			var BrokenGlass = new TestGlass() { Quality = 20 };

			//Act
			qualityChanger.ChangeCondition(NewGlass);
			qualityChanger.ChangeCondition(GoodGlass);
			qualityChanger.ChangeCondition(DamagedGlass);
			qualityChanger.ChangeCondition(BrokenGlass);

			//Assert
			Assert.AreEqual("New", NewGlass.Condition);
			Assert.AreEqual("Good", GoodGlass.Condition);
			Assert.AreEqual("Damaged", DamagedGlass.Condition);
			Assert.AreEqual("Broken", BrokenGlass.Condition);
		}

	}
}
