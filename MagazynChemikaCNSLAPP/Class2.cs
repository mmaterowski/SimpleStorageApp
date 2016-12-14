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

		static MainMenu AppController = new MainMenu();

		public static void Run()
		{
			while (true)
			{
				AppController.Welcome();
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
					case 4:
						{
							Console.WriteLine(" \t $$ Pay one milion money to unlock this functionality $$");
							Console.ReadKey();
						}
						break;
					default:
							{
								Console.WriteLine("Wrong choice!");
								Console.ReadKey();
							break;
							}

						}
				Console.Clear();
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
				return input;
			}
			else
				return -1;
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

		private static int ItemChoice()
		{
			Console.WriteLine("What do you want to store?");
			Console.WriteLine("1. Beaker");
			Console.WriteLine("2. Flask");
			return InputNumber();
		}

		public static int InputNumber()
		{
			int temp;
			try
			{
				temp = (Int32.Parse(Console.ReadLine()));
				if (IsReal(temp))
					return temp;
				else throw new System.FormatException();
			}
			catch (System.FormatException)
			{
				return -1;
			}
		}

		private static bool IsReal(int temp)
		{
			if (temp >= 0)
			{
				return true;
			}
			else
				return false;
		}

	}
}
