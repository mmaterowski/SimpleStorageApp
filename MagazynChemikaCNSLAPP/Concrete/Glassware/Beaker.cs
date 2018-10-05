using System;

namespace MagazynChemikaCNSLAPP
{
	class Beaker : Glassware
	{
		public Beaker(float price, int velocity)
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
			string temp = "Beaker";
			return temp;
		}

		public static Beaker AddBeaker()
		{
			Console.WriteLine("Give velocity");
			int vel = MainMenu.InputNumber();
			if (vel > 0)
			{
				Beaker obj = new Beaker(vel * 0.12F, vel);
				Console.WriteLine("Beaker of velocity {0} ml added. It costed {1}$.", obj.velocity, obj.price);
				return obj;
			}
			else
			{
				Console.WriteLine("The velocity must be a number greater than 0, try again");
				return AddBeaker();
			}
		}



	}
}
