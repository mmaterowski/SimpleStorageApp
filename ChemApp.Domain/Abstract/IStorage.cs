using ChemApp.Domain.Abstract;
using ChemApp.Domain.Concrete;
using System.Collections.Generic;

namespace ChemApp.Domain
{
    public interface IStorage
    {
        int ProductID { get; set; }

        void AddItem(IGlassware piece);

        string DeleteItem(int itemID);

        List<IGlassware> GetItems();

        List<ProductData> GetItemsThatCanBePurshed();

        IGlassware GetItemById(int id);

        decimal GetTotalPriceOfItems();

        void ShowItemsThatCanBePurshed();

        void ShowStorage();

        void ShowTotalPriceOfItems();
    }
}