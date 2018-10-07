using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP
{
	public class Flask : Glassware
	{
		public Flask(IWashable washingMethod,ILabWork labWork,IConditionChanger conditionChanger, decimal price, int velocity) : base(washingMethod,labWork,conditionChanger)
		{
			this.Price = price;
			this.Velocity = velocity;
			ItemID = ItemCounter++;
			PriceOfAllGlassware += price;
		}

		public override string ToString()
		{
			return "Flask" + this.ItemID;
		}

		public static Flask AddFlask(IWashable washingMethod,ILabWork labWork,IConditionChanger conditionChanger)
		{
			Console.WriteLine("Give velocity");
			int vel = MainMenu.InputNumber();
			if (vel > 0)
			{
				Flask obj = new Flask(washingMethod,labWork,conditionChanger, (decimal)vel * 0.2M, vel);
				Console.WriteLine("Flask of velocity {0} ml added. It costed {1}$.", obj.Velocity, obj.Price);
				return obj;
			}
			else
			{
				Console.WriteLine("The velocity must be a number greater than 0, try again");
				return AddFlask(washingMethod,labWork,conditionChanger);
			}
		}


	}
}
