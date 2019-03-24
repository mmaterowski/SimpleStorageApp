using ChemApp.Domain;
using ChemApp.Domain.Abstract;
using ChemApp.Domain.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace ChemApp.Console
{
    public class Storage : IStorage
    {
        private List<ProductData> productData;
        private List<IGlassware> storageItems;
        private readonly ISupplier supplier;
        private int _productID;

        public int ProductID
        {
            get { return _productID; }
            set
            {
                _productID = value;
                _productID++;
            }
        }

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
            foreach (var product in productData)
            {
                System.Console.WriteLine($"ID:{product.SupplierID}, Name: {product.Name}, Volume: {product.Volume}, Price: {product.Price:N2}$");
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
                System.Console.WriteLine("Storage is empty");
            }
        }

        private void PrintStorage()
        {
            foreach (Glassware piece in storageItems)
            {
                System.Console.WriteLine($"Name: {piece.Name} ID: {piece.ItemID} Velocity: {piece.Volume}ml Price: {piece.Price:N2}$");
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
            System.Console.WriteLine("__________________________________________________________");
            System.Console.WriteLine($"Total items: {storageItems.Count} \t Total Value: {totalValue:N2}");
        }

        public void AddItem(IGlassware piece)
        {
            storageItems.Add(piece);
        }

        public string DeleteItem(int itemID)
        {
            var productToDelete = storageItems.FirstOrDefault(i => i.ItemID == itemID);
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
    }
}