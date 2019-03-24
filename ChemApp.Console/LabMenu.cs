using ChemApp.Console.Utilities;
using ChemApp.Domain;
using ChemApp.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ChemApp.Console
{
    internal class LabMenu
    {
        private readonly ILaboratory chemLaboratory;
        private readonly IStorage myStorage;

        public LabMenu(ILaboratory chemLaboratory, IStorage myStorage)
        {
            this.chemLaboratory = chemLaboratory;
            this.myStorage = myStorage;
        }

        public void Run()
        {
            while (true)
            {
                PrintLaboratory();
                int input = InputUtility.GetInputFromUser();

                switch (input)
                {
                    case 1:
                        System.Console.WriteLine("I'm attempting to perform a reaction");
                        IEnumerable<IGlassware> listOfProducts = myStorage.GetItems();
                        System.Threading.Thread.Sleep(500);
                        chemLaboratory.PerformReaction(listOfProducts);
                        System.Console.ReadKey();
                        break;

                    case 2:
                        System.Console.WriteLine("Type id of item to wash it");
                        int itemID = InputUtility.GetInputFromUser();
                        var foundItem = myStorage.GetItems().FirstOrDefault(i => i.ItemID == itemID);
                        if (foundItem != null)
                        {
                            chemLaboratory.WashItem(foundItem);
                        }
                        else
                        {
                            System.Console.WriteLine($"I didn't find item with ID {itemID}");
                        }
                        break;

                    case 3:
                        System.Console.WriteLine("I'm starting to wash all dirty items in Your storage");
                        chemLaboratory.WashDirtyItems(myStorage.GetItems());
                        break;

                    case 4:
                        System.Console.WriteLine("Type id of item to polish:");
                        itemID = InputUtility.GetInputFromUser();
                        foundItem = myStorage.GetItems().FirstOrDefault(i => i.ItemID == itemID);
                        if (foundItem != null)
                        {
                            chemLaboratory.PolishItem(foundItem);
                        }
                        else
                        {
                            System.Console.WriteLine($"I didn't find item with ID {itemID}");
                        }
                        break;

                    case 5:
                        System.Console.WriteLine("I'm polishing all items in Your lab");
                        chemLaboratory.PolishAllItems(myStorage.GetItems());
                        break;

                    case 6:
                        //code
                        break;

                    default:
                        System.Console.WriteLine("Wrong choice");
                        break;
                }
                System.Console.Clear();
            }
        }

        private void PrintLaboratory()
        {
            System.Console.WriteLine("1. Perform a reaction");
            System.Console.WriteLine("2. Wash an item");
            System.Console.WriteLine("3. Wash all items");
            System.Console.WriteLine("4. Polish an item");
            System.Console.WriteLine("5. Polish all items");
            System.Console.WriteLine("6. Go back to storage");
        }
    }
}