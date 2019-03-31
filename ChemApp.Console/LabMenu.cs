namespace ChemApp.Console
{
    using ChemApp.Console.Infrastructure;
    using ChemApp.Console.Utilities;
    using ChemApp.Domain;
    using ChemApp.Domain.Abstract;
    using ChemApp.Infrastructure.Exceptions;
    using System;
    using System.Linq;

    internal class LabMenu
    {
        private readonly ILaboratory chemLaboratory;
        private readonly IStorage myStorage;
        private bool ExitLaboratory;

        public LabMenu(ILaboratory chemLaboratory, IStorage myStorage)
        {
            this.chemLaboratory = chemLaboratory;
            this.myStorage = myStorage;
        }

        public void Run()
        {
            while (true)
            {
                ExitLaboratory = false;
                PrintLaboratory();
                int input = InputUtility.GetInputFromUser();

                switch (input)
                {
                    case 1:
                        Console.WriteLine("I'm attempting to perform a reaction");
                        var listOfProducts = myStorage.GetItems();
                        System.Threading.Thread.Sleep(500);
                        chemLaboratory.PerformReaction(listOfProducts);
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("Type id of item to wash it");
                        int choice = InputUtility.GetInputFromUser();
                        var foundItem = myStorage.GetItemByIndex(choice);
                        if (foundItem != null)
                        {
                            chemLaboratory.WashItem(foundItem);
                        }
                        else
                        {
                            var ex = new ItemNotFoundException(choice.ToString());
                            DefaultLogger.Instance.Error("Item not found");
                            DefaultLogger.Instance.Error(ex.ToString());
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("I'm starting to wash all dirty items in Your storage");
                        chemLaboratory.WashItems(myStorage.GetItems().Where(i => i.IsClean = false));
                        break;

                    case 4:
                        Console.WriteLine("Type id of item to polish:");
                        choice = InputUtility.GetInputFromUser();
                        foundItem = myStorage.GetItemByIndex(choice);
                        if (foundItem != null)
                        {
                            chemLaboratory.PolishItem(foundItem);
                        }
                        else
                        {
                            var ex = new ItemNotFoundException(choice.ToString());
                            DefaultLogger.Instance.Error("Item not found");
                            DefaultLogger.Instance.Error(ex.ToString());
                        }
                        break;

                    case 5:
                        Console.WriteLine("I'm polishing all items in Your lab");
                        chemLaboratory.PolishItems(myStorage.GetItems());
                        break;

                    case 6:
                        //code
                        ExitLaboratory = true;
                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
                if (ExitLaboratory)
                {
                    break;
                }
                Console.Clear();
            }
        }

        private void PrintLaboratory()
        {
            Console.WriteLine("1. Perform a reaction");
            Console.WriteLine("2. Wash an item");
            Console.WriteLine("3. Wash all items");
            Console.WriteLine("4. Polish an item");
            Console.WriteLine("5. Polish all items");
            Console.WriteLine("6. Go back to storage");
        }
    }
}