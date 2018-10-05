namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface IQualityControl
	{
		void CheckQuality(Glassware glassObject);
		void ChangeQuality(Glassware glassObject);
	}
}
