using MagazynChemikaCNSLAPP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemAppUnitTests
{
	[TestClass]
	public class GlasswareTests
	{
		class TestGlass : Glassware
		{

		}

		[TestMethod]
		public void Can_Wash_Glassware()
		{
			//Arrange
			TestGlass glass = new TestGlass();
			glass.IsClean = false;

			//Act
			glass.Wash;

		}
	}
}
