using System;

namespace MagazynChemikaCNSLAPP
{
	class Flask : Glassware
	{
		public Flask(float price, int velocity)
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

		public static Flask AddFlask()
		{
			Console.WriteLine("Give velocity");
			int vel = MainMenu.InputNumber();
			if (vel > 0)
			{
				Flask obj = new Flask(vel * 0.2F, vel);
				Console.WriteLine("Flask of velocity {0} ml added. It costed {1}$.", obj.velocity, obj.price);
				return obj;
			}
			else
			{
				Console.WriteLine("The velocity must be a number greater than 0, try again");
				return AddFlask();
			}
		}


	}
}
