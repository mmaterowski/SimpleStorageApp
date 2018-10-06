using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP
{
	public abstract class Glassware : IWashable
	{
		private IWashable washingMethod;

		//extract to other class
		public static decimal PriceOfAllGlassware;


		public static int ItemCounter = 0;

		public string Name { get; set; }
		public int ItemID { get; set; }
		public decimal Price { get; set; }
		public float Velocity { get; set; }
		public int Quality { get; set; }
		public string CurrentState { get; set; }
		public bool IsClean { get; set; }

		public Glassware(IWashable washingMethod)
		{
			this.washingMethod = washingMethod;
		}


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
			if (obj.Quality < 20)
			{
				Console.WriteLine("You cannot use this piece, it's broken and have to be disposed");
			}
			else
			{
				Console.WriteLine("You've used this piece of glassware, now it's dirty");
				IsClean = false;

				int temp = obj.UsingGlassware.Next(100);
				if (temp < obj.Quality)
				{
					obj.Quality = temp;
					StateChanger(obj);
				}




			}
		}

		protected virtual void StateChanger(Glassware obj)
		{
			if (obj.Quality == 100) { obj.CurrentState = "New"; }
			else if (obj.Quality > 75) { obj.CurrentState = "Good"; }
			else if (obj.Quality > 25)
			{
				obj.CurrentState = "Damaged";
				Console.WriteLine("Your beaker is now damaged, but You can still use it");
			}
			else if (obj.Quality <= 20)
			{
				obj.CurrentState = "ToTrash";
				Console.WriteLine("You broke this piece !");
			}

		}



	}






}
