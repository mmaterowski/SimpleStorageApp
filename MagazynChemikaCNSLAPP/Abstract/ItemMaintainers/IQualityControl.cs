using System.Collections.Generic;

namespace MagazynChemikaCNSLAPP.Abstract.ItemMaintainers
{
	public interface IQualityControl 
	{
		bool QualityControlFailed { get; set; }
		void CheckQuality(IGlassware glassware);
		void CheckQuality(IEnumerable<IGlassware> glassware);
		
	}
}