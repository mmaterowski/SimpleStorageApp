namespace ChemApp.Console
{
    using ChemApp.Domain;
    using ChemApp.Domain.Abstract;
    using ChemApp.Domain.Concrete;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Storage : IStorage
    {
        private List<ProductData> productData;
        private List<IGlassware> storageItems;
        private readonly ISupplier supplier;

        public Storage(ISupplier supplier)
        {
            this.supplier = supplier;
            storageItems = new List<IGlassware>();
            productData = new List<ProductData>();
            ParseDataFromSupplier();
        }

        private void ParseDataFromSupplier()
        {
            var products = supplier.GetAvailableProducts();
            int iterator = 0;
            foreach (var product in products)
            {
                var productDataString = products[iterator];
                var productDataTable = productDataString.Split(',');
                var itemData = new ProductData(iterator, productDataTable[0], int.Parse(productDataTable[1]), decimal.Parse(productDataTable[2]));
                productData.Add(itemData);
                iterator++;
            }
        }

        public List<IGlassware> GetItems()
        {
            return storageItems;
        }

        public List<ProductData> GetItemsThatCanBePurshed()
        {
            return productData;
        }

        public void ShowItemsThatCanBePurshed()
        {
            for (int i = 0; i < productData.Count; i++)
            {
                Console.WriteLine($"{i}. Name: {productData[i].Name}, Volume: {productData[i].Volume}, Price: {productData[i].Price:N2}$");
            }
        }

        public void ShowStorage()
        {
            CheckIfStorageEmpty();
            PrintStorage();
            ShowTotalPriceOfItems();
        }

        private void CheckIfStorageEmpty()
        {
            if (storageItems.Count == 0)
            {
                Console.WriteLine("Storage is empty");
            }
        }

        private void PrintStorage()
        {
            for (int i = 0; i < storageItems.Count; i++)
            {
                Console.WriteLine($"{i}. Name: {storageItems[i].Name} ID: {storageItems[i].Id} Velocity: {storageItems[i].Volume}ml Price: {storageItems[i].Price:N2}$");
            }
        }

        public decimal GetTotalPriceOfItems()
        {
            var priceOfAllGlassware = storageItems.Sum(m => m.Price);
            return priceOfAllGlassware;
        }

        public void ShowTotalPriceOfItems()
        {
            var totalValue = GetTotalPriceOfItems();
            Console.WriteLine("__________________________________________________________");
            Console.WriteLine($"Total items: {storageItems.Count} \t Total Value: {totalValue:N2}");
        }

        public void AddItem(IGlassware piece)
        {
            storageItems.Add(piece);
        }

        public string DeleteItem(IGlassware item)
        {
            var productToDelete = storageItems.FirstOrDefault(i => i == item);
            if (productToDelete != null)
            {
                storageItems.Remove(productToDelete);
                return $"Item {productToDelete.ToString()} thrown out";
            }
            else
            {
                return "Sorry,there's no product with this ID in Your storage";
            }
        }

        public IGlassware GetItemById(Guid id)
        {
            return this.storageItems.FirstOrDefault(g => g.Id == id);
        }

        public IGlassware GetItemByIndex(int index)
        {
            return storageItems[index];
        }
    }
}