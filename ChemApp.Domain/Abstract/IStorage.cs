using ChemApp.Domain.Abstract;
using ChemApp.Domain.Concrete;
using System;
using System.Collections.Generic;

namespace ChemApp.Domain
{
    public interface IStorage
    {
        void AddItem(IGlassware piece);

        string DeleteItem(IGlassware item);

        List<IGlassware> GetItems();

        List<ProductData> GetItemsThatCanBePurshed();

        IGlassware GetItemById(Guid id);

        IGlassware GetItemByIndex(int index);

        decimal GetTotalPriceOfItems();

        void ShowItemsThatCanBePurshed();

        void ShowStorage();

        void ShowTotalPriceOfItems();
    }
}