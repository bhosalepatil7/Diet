using Diet.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diet.Business.Contract.ModComorbidity
{
    public interface IComorbidity
    {
        int ModifyComorbidity(Comorbidity objcomor);
    }
}
