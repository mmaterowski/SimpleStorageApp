using ChemApp.Domain.Abstract;
using ChemApp.Domain.Abstract.ItemMaintainers;
using System.Collections.Generic;

namespace ChemApp.Domain.Concrete.Laboratory
{
    public class ChemicalLaboratory : ILaboratory
    {
        private readonly IQualityControl qualityControl;
        private readonly IMaintainItem maintainer;
        private readonly IChangeQuality qualityChanger;
        private readonly IConditionChanger conditionChanger;

        public ChemicalLaboratory(IQualityControl qualityControlParam, IMaintainItem maintainParam, IChangeQuality qualityChangerParam, IConditionChanger conditionChangerParam)
        {
            qualityControl = qualityControlParam;
            maintainer = maintainParam;
            qualityChanger = qualityChangerParam;
            conditionChanger = conditionChangerParam;
        }

        public void PerformReaction(IEnumerable<IGlassware> glasswareCollection)
        {
            qualityControl.CheckQuality(glasswareCollection);
            bool allItemsAreClean = maintainer.CheckIfAllItemsAreClean(glasswareCollection);
            if (!qualityControl.QualityControlFailed && allItemsAreClean)
            {
                qualityChanger.ChangeQuality(glasswareCollection);
                conditionChanger.ChangeCondition(glasswareCollection);

                System.Console.WriteLine("Reaction performed. You gain xxx money.");
            }
            else
            {
                System.Console.WriteLine("You can't perform reaction, some of Your items are broken or dirty!");
                System.Console.WriteLine("Please, buy new ones and clean dirty ones, before attempting to perform a reaction");
            }
        }

        public void WashItem(IGlassware pieceOfGlassware)
        {
            maintainer.Wash(pieceOfGlassware);
        }

        public void WashItems(IEnumerable<IGlassware> glasswareCollection)
        {
            maintainer.Wash(glasswareCollection);
        }

        public void PolishItem(IGlassware pieceOfGlassware)
        {
            maintainer.Polish(pieceOfGlassware);
        }

        public void PolishItems(IEnumerable<IGlassware> glasswareCollection)
        {
            maintainer.PolishAllItems(glasswareCollection);
        }
    }
}