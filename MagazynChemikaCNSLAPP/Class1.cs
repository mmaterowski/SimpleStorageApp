using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynChemikaCNSLAPP
{
    abstract class Glassware
    {
        public float price;
        public static float PriceOfAllGlassware;
        public int velocity;
        public static int ItemCounter= 0;
        public int ThisItemID;
        protected bool IsClean;
        public string CurrentState;
        protected int quality = 100;

      
        Random UsingGlassware = new Random();

        protected virtual void Wash(Glassware obj)
        {
            if (obj.IsClean)
            {
                Console.WriteLine("It's already clean!");
                IsClean = false;
            }
            else
            {
                Console.WriteLine("The {0} is clean now",obj);
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
            else if (obj.quality >75) { obj.CurrentState = "Good"; }
            else if (obj.quality >25)
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
