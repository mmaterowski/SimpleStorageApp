using MagazynChemikaCNSLAPP.Abstract;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class RegularLabWork : ILabWork
	{
		private IChangeQuality stateChanger;
		private IUsable useStyle;

		public RegularLabWork(IChangeQuality stateChangerParam, IUsable useParam)
		{
			stateChanger = stateChangerParam;
			useStyle = useParam;
		}

		public void ChangeQuality(Glassware glasswareObject)
		{
			stateChanger.ChangeQuality(glasswareObject);
		}

		public void Use(Glassware glasswareObject)
		{
			useStyle.Use(glasswareObject);
			ChangeQuality(glasswareObject);
		}
	}
}
