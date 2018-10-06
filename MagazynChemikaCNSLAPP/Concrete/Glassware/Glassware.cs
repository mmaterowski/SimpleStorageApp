using MagazynChemikaCNSLAPP.Abstract;
using MagazynChemikaCNSLAPP.Concrete;
using System;

namespace MagazynChemikaCNSLAPP
{
	public abstract class Glassware : IWashable, IUsable
	{
		private IWashable washingMethod;
		private IUsable labActivity;
		private IChangeItemState stateChangerType;


		//extract to other class
		public static decimal PriceOfAllGlassware;


		public static int ItemCounter = 0;
		private int _quality;
		public string Name { get; set; }
		public int ItemID { get; set; }
		public decimal Price { get; set; }
		public float Velocity { get; set; }
		public int Quality
		{
			get { return _quality; }
			set { _quality = value; }
		}

		private string _currentState;

		public string CurrentState
		{
			get { return _currentState; }
			private set { _currentState = value; }
		}

		private bool _isClean;

		public bool IsClean
		{
			get { return _isClean; }
			set { _isClean = value; }
		}

		public Glassware(IWashable washingMethod)
		{
			this.washingMethod = washingMethod;
			Quality = 100;
			IsClean = true;
		}

		public virtual void Wash(Glassware glasswareObject)
		{
			washingMethod.Wash(glasswareObject);
		}


		public virtual void Use(Glassware glasswareObject)
		{
			stateChangerType = new RandomStateChanger();
			RegularLabWork labWork = new RegularLabWork(stateChangerType);
			labWork.Change(glasswareObject);
		}

		//Add structur, extract interface
		public virtual void StateChanger()
		{
			if (Quality == 100) { CurrentState = "New"; }
			else if (Quality > 75) { CurrentState = "Good"; }
			else if (Quality > 25)
			{
				CurrentState = "Damaged";
				Console.WriteLine("Your beaker is now damaged, but You can still use it");
			}
			else if (Quality <= 20)
			{
				CurrentState = "ToTrash";
				Console.WriteLine("You broke this piece !");
			}

		}



	}






}
