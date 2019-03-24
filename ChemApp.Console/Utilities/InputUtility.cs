using System;

namespace ChemApp.Console.Utilities
{
    public static class InputUtility
    {
        public static int GetInputFromUser()
        {
            string inputFromUser = System.Console.ReadLine();

            if (Int32.TryParse(inputFromUser, out int parsedNumber))
            {
                return parsedNumber;
            }
            else
            {
                System.Console.WriteLine("Please, type a valid input");
                return GetInputFromUser();
            }
        }
    }
}