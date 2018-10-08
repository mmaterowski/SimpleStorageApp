using MagazynChemikaCNSLAPP.Abstract;

namespace MagazynChemikaCNSLAPP
{
	public class Glassware : IGlassware
	{
		private IGlassware labGlassware;
		//extract to other class
		
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
				if (Quality != value)
				{
					ChangeCondition(this);
					_quality = value;
				}
			}
		}
		public string Condition { get; set; }
		public bool IsClean { get; set; }

		public Glassware(IGlassware labGlassware)
		{
			this.labGlassware = labGlassware;
			Quality = 100;
			IsClean = true;
		}

		public void Wash(Glassware glasswareObject)
		{
			labGlassware.Wash(glasswareObject);
		}


		public void Use(Glassware glasswareObject)
		{
			labGlassware.Use(glasswareObject);
		}

		public void ChangeQuality(Glassware glasswareObject)
		{
			labGlassware.ChangeQuality(glasswareObject);
		}

		public void ChangeCondition(Glassware glassware)
		{
			labGlassware.ChangeCondition(glassware);
		}


	}






}
