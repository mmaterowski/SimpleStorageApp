using MagazynChemikaCNSLAPP.Abstract;
using System;

namespace MagazynChemikaCNSLAPP
{
	public abstract class Glassware : IWashable, ILabWork
	{
		private IWashable washingMethod;
	//	private IChangeQuality stateChangerType;
		private ILabWork typeOfLabWork;


		//extract to other class
		public static decimal PriceOfAllGlassware;


		public static int ItemCounter = 0;

		public string Name { get; set; }
		public int ItemID { get; set; }
		public decimal Price { get; set; }
		public float Velocity { get; set; }
		public int Quality { get; set; }
		public string Condition { get; private set; }
		public bool IsClean { get; set; }

		public Glassware(IWashable washingMethodParam, ILabWork labWorkParam)
		{
			washingMethod = washingMethodParam;
			typeOfLabWork = labWorkParam;
			Quality = 100;
			IsClean = true;
		}

		public virtual void Wash(Glassware glasswareObject)
		{
			washingMethod.Wash(glasswareObject);
		}


		public virtual void Use(Glassware glasswareObject)
		{
			typeOfLabWork.Use(glasswareObject);
		}

		public void ChangeQuality(Glassware glasswareObject)
		{
			typeOfLabWork.ChangeQuality(glasswareObject);
		}

		//Add structur, extract interface
		public virtual void ChangeCondition()
		{
			if (Quality == 100) { Condition = "New"; }
			else if (Quality > 75) { Condition = "Good"; }
			else if (Quality > 25)
			{
				Condition = "Damaged";
				Console.WriteLine("Your beaker is now damaged, but You can still use it");
			}
			else if (Quality <= 20)
			{
				Condition = "ToTrash";
				Console.WriteLine("You broke this piece !");
			}

		}


	}






}
