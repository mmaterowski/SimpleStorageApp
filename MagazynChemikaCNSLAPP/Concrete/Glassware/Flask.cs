using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP
{
	public class Flask : Glassware
	{
		private IWashable washingMethod;

		public Flask(IWashable washingMethod) : base(washingMethod)
		{
		}

		public Flask(IWashable washingMethod, decimal price, int velocity) : base(washingMethod)
		{
			this.Price = price;
			this.Velocity = velocity;
			ItemID = ItemCounter++;
			PriceOfAllGlassware += price;
		}

		public override string ToString()
		{
			string temp = "Flask";
			return temp;
		}

		public static Flask AddFlask(IWashable washingMethod)
		{
			Console.WriteLine("Give velocity");
			int vel = MainMenu.InputNumber();
			if (vel > 0)
			{
				Flask obj = new Flask(washingMethod, (decimal)vel * 0.2M, vel);
				Console.WriteLine("Flask of velocity {0} ml added. It costed {1}$.", obj.Velocity, obj.Price);
				return obj;
			}
			else
			{
				Console.WriteLine("The velocity must be a number greater than 0, try again");
				return AddFlask(washingMethod);
			}
		}


	}
}
