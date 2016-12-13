using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynChemikaCNSLAPP
{
    class MainMenu
    {
        private int input;
		private static int choice;
		static MainMenu AppController = new MainMenu();
	
		public static void Run()
		{
			switch (AppController.InputFromUser())
			{
				case 1:
					{
						ListManager.ShowStorage();
					}
					break;
				case 2:
					{
						ListManager.AddItem(ItemChoice()); 
					}
					break;
				case 3:
					{
						ListManager.DeleteItem();
					}
					break;
					//case 4:
					//	{
					//		ChangeItem();
					//	}
					//	break;

			}
		}


		public void Welcome()
        {
            Console.WriteLine("Welcome to your chemistry's magazine!");
            Console.WriteLine("1.Check storage");
            Console.WriteLine("2.Add item");
            Console.WriteLine("3.Delete item");
            Console.WriteLine("4.Change item");
            Console.WriteLine("____________________________________");
        }

        public int InputFromUser()
        {
            if (GetValue())
            {
                CheckValue(input);
            }
            return input;
        }

        private bool GetValue()
        {

            {
                try
                {
                    input = Int16.Parse(Console.ReadLine());
                    return true;
                }



                catch (System.FormatException)
                {
                    Console.WriteLine("Value must be an integer!");
                    return false;
                }


            }
        }

        private void CheckValue(int ValueToCheck)
        {
            ValueToCheck = this.input;
            if (ValueToCheck < 1 || ValueToCheck > 4)
            {
                Console.WriteLine("Wrong choice");
            }

        }

       

        private static int ItemChoice()
        {
            Console.WriteLine("What do you want to store?");
            Console.WriteLine("1. Beaker");
            Console.WriteLine("2. Flask");
            return (Int32.Parse(Console.ReadLine()));
    
        }

 

    

       

        //public void Choice(int choice)
        //{
        //    switch (choice)
        //    {
        //        case 1:
        //            { CheckStorage(); }
        //            break;
        //        case 2:
        //            { AddItem(); }
        //            break;
        //        case 3:
        //            { DeleteItem(); }
        //            break;
        //        case 4:
        //            { ChangeItem(); }
        //            break;

        //    }


    //}
}
}
