using System;

namespace MagazynChemikaCNSLAPP
{
	public abstract class Glassware
	{
		public string Name { get; set; }
		public float price;
		public static float PriceOfAllGlassware;
		public int velocity;
		public static int ItemCounter = 0;
		public int ThisItemID;
		public bool IsClean;
		public string CurrentState;
		protected int quality = 100;


		Random UsingGlassware = new Random();

		public virtual void Wash(Glassware obj)
		{
			if (obj.IsClean)
			{
				Console.WriteLine("It's already clean!");
				IsClean = false;
			}
			else
			{
				Console.WriteLine("The {0} is clean now", obj);
				IsClean = true;
			}
		}

		protected virtual void Use(Glassware obj)
		{
			if (obj.quality < 20)
			{
				Console.WriteLine("You cannot use this piece, it's broken and have to be disposed");
			}
			else
			{
				Console.WriteLine("You've used this piece of glassware, now it's dirty");
				IsClean = false;

				int temp = obj.UsingGlassware.Next(100);
				if (temp < obj.quality)
				{
					obj.quality = temp;
					StateChanger(obj);
				}




			}
		}

		protected virtual void StateChanger(Glassware obj)
		{
			if (obj.quality == 100) { obj.CurrentState = "New"; }
			else if (obj.quality > 75) { obj.CurrentState = "Good"; }
			else if (obj.quality > 25)
			{
				obj.CurrentState = "Damaged";
				Console.WriteLine("Your beaker is now damaged, but You can still use it");
			}
			else if (obj.quality <= 20)
			{
				obj.CurrentState = "ToTrash";
				Console.WriteLine("You broke this piece !");
			}

		}



	}






}
