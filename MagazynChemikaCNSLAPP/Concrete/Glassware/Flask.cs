using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP
{
	public class Flask : Glassware
	{
		private IGlassware labGlass;
		public Flask(IGlassware labGlassParam, decimal price, int velocity) : base(labGlassParam)
		{
			labGlass = labGlassParam;
			this.Price = price;
			this.Velocity = velocity;
			ItemID = ItemCounter++;
			PriceOfAllGlassware += price;
		}

		public override string ToString()
		{
			return "Flask" + this.ItemID;
		}

		public Flask AddFlask()
		{
			Console.WriteLine("Give velocity");
			int vel = MainMenu.InputNumber();
			if (vel > 0)
			{
				Flask flask = new Flask(labGlass, (decimal)vel * 0.2M, vel);
				Console.WriteLine("Flask of velocity {0} ml added. It costed {1}$.", flask.Velocity, flask.Price);
				return flask;
			}
			else
			{
				Console.WriteLine("The velocity must be a number greater than 0, try again");
				return AddFlask();
			}
		}


	}
}
