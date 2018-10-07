using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class LabGlass : IGlassware
	{
		private IConditionChanger conditionChanger;
		private IWashable washingMethod;
		private ILabWork labWork;

		public LabGlass(IConditionChanger conditionChangerParam,ILabWork labWorkParam,IWashable washingMethodParam)
		{
			conditionChanger = conditionChangerParam;
			labWork = labWorkParam;
			washingMethod = washingMethodParam;
		}
		public void ChangeCondition(Glassware glassware)
		{
			conditionChanger.ChangeCondition(glassware);
		}

		public void ChangeQuality(Glassware glasswareObject)
		{
			labWork.ChangeQuality(glasswareObject);
		}

		public void Use(Glassware glasswareObject)
		{
			labWork.Use(glasswareObject);
		}

		public void Wash(Glassware glasswareObject)
		{
			washingMethod.Wash(glasswareObject);
		}
	}
}
