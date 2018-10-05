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

		public Flask(IWashable washingMethod, float price, int velocity) : base(washingMethod)
		{
			this.price = price;
			this.velocity = velocity;
			ThisItemID = ItemCounter++;
			quality = 100;
			CurrentState = "New";
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
				Flask obj = new Flask(washingMethod, vel * 0.2F, vel);
				Console.WriteLine("Flask of velocity {0} ml added. It costed {1}$.", obj.velocity, obj.price);
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
