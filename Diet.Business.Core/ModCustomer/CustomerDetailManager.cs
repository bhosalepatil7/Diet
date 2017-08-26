namespace Diet.Business.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using Diet.Business.Contract;
    using Diet.Business.Model;
    using Diet.DataAccess.DataManagers;


    [Export(typeof(ICustomerDetail))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class CustomerDetailManager : ICustomerDetail
    {
        CustomerDetailDataManager objCustomerDetailDataManager = new CustomerDetailDataManager();

        public int ModifyCustomerDetail(CustomerDetail objCustDetail)
        {
            try
            {
                return objCustomerDetailDataManager.ModifyCustomerDetail(objCustDetail);
            }
            catch
            {
                throw;
            }
        }

    }
}
