using System.Collections.Generic;

namespace ChemApp.Domain.Abstract
{
    public interface ILaboratory : IReaction
    {
        void WashItem(IGlassware pieceOfGlassware);

        void WashDirtyItems(IEnumerable<IGlassware> glasswareCollection);

        void PolishItem(IGlassware pieceOfGlassware);

        void PolishAllItems(IEnumerable<IGlassware> glasswareCollection);
    }
}