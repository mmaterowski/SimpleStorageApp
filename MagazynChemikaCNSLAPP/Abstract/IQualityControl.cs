namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface IQualityControl : IConditionChanger,IDispose
	{
		void ChangeQuality(IGlassware glassware);
	}
}