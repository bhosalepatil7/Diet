namespace Diet.Business.Contract
{
    using Diet.Business.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public interface ICustomerDetail
    {
        int ModifyCustomerDetail(CustomerDetail objCustDetail);
    }
}
