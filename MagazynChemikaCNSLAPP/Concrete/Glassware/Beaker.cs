using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP
{
	class Beaker : Glassware
	{
		public Beaker(IWashable washingMethod,ILabWork labWork,IConditionChanger conditionChanger, decimal price, float velocity) : base(washingMethod,labWork,conditionChanger)
		{
			this.Price = price;
			this.Velocity = velocity;
			ItemID = ItemCounter++;
			PriceOfAllGlassware += price;
		}

		public override string ToString()
		{
			string temp = "Beaker";
			return temp;
		}

		public static Beaker AddBeaker(IWashable washingMethod,ILabWork labWork,IConditionChanger conditionChanger)
		{
			Console.WriteLine("Give velocity");
			float vel = MainMenu.InputNumber();
			if (vel > 0)
			{
				Beaker obj = new Beaker(washingMethod,labWork,conditionChanger, (((decimal)vel * 0.12M)), vel);
				Console.WriteLine("Beaker of velocity {0} ml added. It costed {1}$.", obj.Velocity, obj.Price);
				return obj;
			}
			else
			{
				Console.WriteLine("The velocity must be a number greater than 0, try again");
				return AddBeaker(washingMethod,labWork,conditionChanger);
			}
		}



	}
}
