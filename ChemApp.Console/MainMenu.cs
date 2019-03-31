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

        public void Run(IStorage storage, ISupplier supplier)
        {
            while (true)
            {
                Welcome();
                int userInput = InputUtility.GetInputFromUser();

                switch (userInput)
                {
                    case 1:
                        {
                            DisplayStorage(storage);
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        {
                            DisplayListOfProducts(storage);
                            ChooseProduct(storage);
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        {
                            ///validation
                            DisplayStorage(storage);
                            ThrowOutProduct(storage);
                            Console.ReadLine();
                        }
                        break;

                    case 4:
                        {
                            var laboratory = new ChemicalLaboratory(qualityControl, itemMaintainer, qualityChanger, conditionChanger);
                            Console.WriteLine("This is Your chemical laboratory, here You can:");
                            var labMenu = new LabMenu(laboratory, storage);
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
            Console.WriteLine("Type number of product You want to throw out");
            int choice = InputUtility.GetInputFromUser();
            var items = myStorage.GetItems();
            if (choice < 0 || choice > items.Count())
            {
                Console.WriteLine("There's no item with such number, try again");
                return;
            }
            else
            {
                var result = myStorage.DeleteItem(items[choice]);
                Console.WriteLine(result);
            }
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
            Console.WriteLine("Please,type number of product You want to buy:");
            int choice = InputUtility.GetInputFromUser();
            var supplierProductList = myStorage.GetItemsThatCanBePurshed();

            if (choice < 0 || choice > supplierProductList.Count())
            {
                Console.WriteLine("There's no item with such number, try again");
                return;
            }

            var rand = new Random();
            var piece = new Glassware
            {
                Name = supplierProductList[choice].Name,
                Volume = supplierProductList[choice].Volume,
                Price = supplierProductList[choice].Price,
                Id = Guid.NewGuid(),
                Condition = "New",
                Quality = 100,
                IsClean = true
            };

            myStorage.AddItem(piece);
            Console.WriteLine($"Item {piece.Name} was added!");
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