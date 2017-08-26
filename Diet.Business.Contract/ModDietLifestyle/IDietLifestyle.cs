using Diet.Business.Model.ModDietLifestyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diet.Business.Contract.ModDietLifestyle
{
    public interface IDietLifestyle
    {
        int ModifyDietLifestyle(DietLifestyle obj);
        
    }
}
