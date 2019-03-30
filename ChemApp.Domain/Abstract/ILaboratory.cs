using System.Collections.Generic;

namespace ChemApp.Domain.Abstract
{
    public interface ILaboratory : IReaction
    {
        void WashItem(IGlassware pieceOfGlassware);

        void WashItems(IEnumerable<IGlassware> glasswareCollection);

        void PolishItem(IGlassware pieceOfGlassware);

        void PolishItems(IEnumerable<IGlassware> glasswareCollection);
    }
}