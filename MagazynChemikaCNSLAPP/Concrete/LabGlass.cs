using MagazynChemikaCNSLAPP.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynChemikaCNSLAPP.Concrete
{
	public class LabGlass 
	{
		private IConditionChanger conditionChanger;
		private IWash washingMethod;
		private ILaboratory labWork;

		public LabGlass(IConditionChanger conditionChangerParam,ILaboratory labWorkParam,IWash washingMethodParam)
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
