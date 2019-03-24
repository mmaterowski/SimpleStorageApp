using ChemApp.Console.Utilities;
using ChemApp.Domain.Abstract;
using ChemApp.Domain.Abstract.ItemMaintainers;
using ChemApp.Domain.Concrete;
using ChemApp.Domain.Concrete.Laboratory;
using ChemApp.Domain.Infrastructure;
using Ninject;
using System;
using System.Linq;

namespace ChemApp.Console
{
    internal class MainMenu
    {
        private readonly IMaintainItem itemMaintainer;
        private readonly IQualityControl qualityControl;
        private readonly IChangeQuality qualityChanger;
        private readonly IConditionChanger conditionChanger;

        public MainMenu()
        {
            var kernel = new StandardKernel(new Bindings());
            this.itemMaintainer = kernel.Get<IMaintainItem>();
            this.qualityControl = kernel.Get<IQualityControl>();
            this.qualityChanger = kernel.Get<IChangeQuality>();
            this.conditionChanger = kernel.Get<IConditionChanger>();
        }

        public void Run(Storage myStorage, ISupplier supplier)
        {
            while (true)
            {
                Welcome();
                int input = InputUtility.GetInputFromUser();
                switch (input)
                {
                    case 1:
                        {
                            DisplayStorage(myStorage);
                            System.Console.ReadKey();
                        }
                        break;

                    case 2:
                        {
                            DisplayListOfProducts(myStorage);
                            BuyProduct(myStorage);
                            System.Console.ReadKey();
                        }
                        break;

                    case 3:
                        {
                            ///validation
                            DisplayStorage(myStorage);
                            ThrowOutProduct(myStorage);
                            System.Console.ReadLine();
                        }
                        break;

                    case 4:
                        {
                            var chemicalLaboratory = new ChemicalLaboratory(qualityControl, itemMaintainer, qualityChanger, conditionChanger);
                            System.Console.WriteLine("This is Your chemical laboratory, here You can:");
                            var labMenu = new LabMenu(chemicalLaboratory, myStorage);
                            labMenu.Run();
                        }
                        break;

                    default:
                        {
                            System.Console.WriteLine("Wrong choice!");
                            System.Console.ReadKey();
                            break;
                        }
                }
                System.Console.Clear();
            }
        }

        private void ThrowOutProduct(Storage myStorage)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Type ID of product You want to throw out");
            int itemID = InputUtility.GetInputFromUser();
            var result = myStorage.DeleteItem(itemID);
            System.Console.WriteLine(result);
        }

        private void DisplayListOfProducts(Storage myStorage)
        {
            System.Console.WriteLine("This is list of products from Your supplier:");
            System.Console.WriteLine();

            myStorage.ShowItemsThatCanBePurshed();
        }

        private void DisplayStorage(Storage myStorage)
        {
            System.Console.WriteLine("This is the list of products in Your storage:");
            System.Console.WriteLine();
            myStorage.ShowStorage();
        }

        private void BuyProduct(Storage myStorage)
        {
            System.Console.WriteLine("Please,type product ID to buy:");
            int productID = InputUtility.GetInputFromUser();
            var supplierProductList = myStorage.GetItemsThatCanBePurshed();

            if (productID < 0 || productID > supplierProductList.Count())
            {
                System.Console.WriteLine("There's no item with such ID, try again");
                return;
            }

            //figure out where and how to assing product IDs
            // change pricing so it makes sense
            var rand = new Random();
            var piece = new Glassware
            {
                Name = supplierProductList[productID].Name,
                Volume = supplierProductList[productID].Volume,
                Price = supplierProductList[productID].Price * ((decimal)rand.Next(95, 99) / 1000),
                ItemID = rand.Next(0, 1000),
                Condition = "New",
                Quality = 100,
                IsClean = true
            };

            myStorage.AddItem(piece);
            System.Console.WriteLine($"Item {piece.Name} was added!");
        }

        public void Welcome()
        {
            System.Console.WriteLine("Welcome to your magazine!");
            System.Console.WriteLine("1.Check storage");
            System.Console.WriteLine("2.Add item");
            System.Console.WriteLine("3.Delete item");
            System.Console.WriteLine("4.Enter laboratory");
            System.Console.WriteLine("____________________________________");
        }
    }
}