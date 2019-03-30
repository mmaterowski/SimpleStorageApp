namespace ChemApp.Console
{
    using ChemApp.Console.Utilities;
    using ChemApp.Domain;
    using ChemApp.Domain.Abstract;
    using ChemApp.Domain.Abstract.ItemMaintainers;
    using ChemApp.Domain.Concrete;
    using ChemApp.Domain.Concrete.Laboratory;
    using ChemApp.Domain.Infrastructure;
    using Ninject;
    using System;
    using System.Linq;

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

        public void Run(IStorage myStorage, ISupplier supplier)
        {
            while (true)
            {
                Welcome();
                int userInput = InputUtility.GetInputFromUser();

                switch (userInput)
                {
                    case 1:
                        {
                            DisplayStorage(myStorage);
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        {
                            DisplayListOfProducts(myStorage);
                            ChooseProduct(myStorage);
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        {
                            ///validation
                            DisplayStorage(myStorage);
                            ThrowOutProduct(myStorage);
                            Console.ReadLine();
                        }
                        break;

                    case 4:
                        {
                            var chemicalLaboratory = new ChemicalLaboratory(qualityControl, itemMaintainer, qualityChanger, conditionChanger);
                            Console.WriteLine("This is Your chemical laboratory, here You can:");
                            var labMenu = new LabMenu(chemicalLaboratory, myStorage);
                            labMenu.Run();
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

        private void ThrowOutProduct(IStorage myStorage)
        {
            Console.WriteLine();
            Console.WriteLine("Type ID of product You want to throw out");
            int itemID = InputUtility.GetInputFromUser();
            var result = myStorage.DeleteItem(itemID);
            Console.WriteLine(result);
        }

        private void DisplayListOfProducts(IStorage myStorage)
        {
            Console.WriteLine("This is list of products from Your supplier:");
            Console.WriteLine();

            myStorage.ShowItemsThatCanBePurshed();
        }

        private void DisplayStorage(IStorage myStorage)
        {
            Console.WriteLine("This is the list of products in Your storage:");
            Console.WriteLine();
            myStorage.ShowStorage();
        }

        private void ChooseProduct(IStorage myStorage)
        {
            Console.WriteLine("Please,type product ID to buy:");
            int productID = InputUtility.GetInputFromUser();
            var supplierProductList = myStorage.GetItemsThatCanBePurshed();

            if (productID < 0 || productID > supplierProductList.Count())
            {
                Console.WriteLine("There's no item with such ID, try again");
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
            Console.WriteLine("Welcome to your magazine!");
            Console.WriteLine("1.Check storage");
            Console.WriteLine("2.Add item");
            Console.WriteLine("3.Delete item");
            Console.WriteLine("4.Enter laboratory");
            Console.WriteLine("____________________________________");
        }
    }
}