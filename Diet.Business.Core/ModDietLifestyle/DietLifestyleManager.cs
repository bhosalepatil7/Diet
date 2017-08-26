using Diet.Business.Contract.ModDietLifestyle;
using Diet.Business.Model.ModDietLifestyle;
using Diet.DataAccess.DataManagers.ModDietLifestyle;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Diet.Business.Core.ModDietLifestyle
{

    [Export(typeof(IDietLifestyle))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class DietLifestyleManager : IDietLifestyle
    {
        public int ModifyDietLifestyle(DietLifestyle dobj)
        {
            DietLifestyleDataManager obj = new DietLifestyleDataManager();
            try
            {
                return obj.ModifyDietLifestyle(dobj);
            }
            catch
            {
                throw;
            }
        }
    }
}
