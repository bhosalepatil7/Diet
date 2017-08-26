using Diet.Business.Contract.ModComorbidity;
using Diet.Business.Model;
using Diet.DataAccess.DataManagers.ModComorbidity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Diet.Business.Core.ModComorbidity
{
    [Export(typeof(IComorbidity))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ComorbidityManager :IComorbidity
    {
        public int ModifyComorbidity(Comorbidity objcomor)
        {
            ComorbidityDataManager obj = new ComorbidityDataManager();

            try
            {
                return obj.ModifyComorbidity(objcomor);
            }
            catch
            {
                throw;
            }
        }
    }
}
