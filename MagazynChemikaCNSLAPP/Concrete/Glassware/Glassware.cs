using MagazynChemikaCNSLAPP.Abstract;

namespace MagazynChemikaCNSLAPP
{
	public abstract class Glassware : IWashable, ILabWork
	{
		private IWashable washingMethod;
		private ILabWork typeOfLabWork;
		private IConditionChanger conditionChanger;

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
			get => _quality;
			set
			{
				if (this.Quality != value)
				{
					ChangeCondition(this);
					_quality = value;
				}
			}
		}
		public string Condition { get; set; }
		public bool IsClean { get; set; }

		public Glassware(IWashable washingMethodParam, ILabWork labWorkParam, IConditionChanger conditionChangerParam)
		{
			washingMethod = washingMethodParam;
			typeOfLabWork = labWorkParam;
			conditionChanger = conditionChangerParam;
			Quality = 100;
			IsClean = true;
		}

		public void Wash(Glassware glasswareObject)
		{
			washingMethod.Wash(glasswareObject);
		}


		public void Use(Glassware glasswareObject)
		{
			typeOfLabWork.Use(glasswareObject);
		}

		public void ChangeQuality(Glassware glasswareObject)
		{
			typeOfLabWork.ChangeQuality(glasswareObject);
		}

		//Add structur, extract interface
		public void ChangeCondition(Glassware glassware)
		{
			conditionChanger.ChangeCondition(glassware);
		}


	}






}
