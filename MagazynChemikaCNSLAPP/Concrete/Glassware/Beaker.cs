using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP
{
	class Beaker : Glassware
	{
		private IGlassware labGlass;

		public Beaker(IGlassware labGlassParam, decimal price, float velocity) : base (labGlassParam)
		{
			labGlass = labGlassParam;
			this.Price = price;
			this.Velocity = velocity;
			ItemID = ItemCounter++;
		}

		public override string ToString()
		{
			string temp = "Beaker";
			return temp;
		}

		public Beaker AddBeaker()
		{
			Console.WriteLine("Give velocity");
			float vel = MainMenu.InputNumber();
			if (vel > 0)
			{
				Beaker beaker = new Beaker(labGlass, (((decimal)vel * 0.12M)), vel);
				Console.WriteLine("Beaker of velocity {0} ml added. It costed {1}$.", beaker.Velocity, beaker.Price);
				return beaker;
			}
			else
			{
				Console.WriteLine("The velocity must be a number greater than 0, try again");
				return AddBeaker();
			}
		}



	}
}
