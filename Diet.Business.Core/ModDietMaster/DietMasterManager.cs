namespace Diet.Business.Core.ModDietMaster
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

    [Export(typeof(IDietMaster))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class DietMasterManager : IDietMaster
    {
        DietMasterDataManager objDietMasterDataManager = new DietMasterDataManager();

        public int ModifyDietMaster(DietMaster objDietMaster)
        {
            try
            {
                return objDietMasterDataManager.ModifyDietMaster(objDietMaster);
            }
            catch
            {
                throw;
            }
        }

        public DataTable SearchPatients(string searchText, string searchCriteria,string session)
        {
            try
            {
                return objDietMasterDataManager.SearchPatients(searchText, searchCriteria,session);
            }
            catch
            {
                throw;
            }
        }


        public DataSet GetDietMaster(int customerID)
        {
            try
            {
                return objDietMasterDataManager.GetDietMaster(customerID);
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetDietMaster_History(int customerID)
        {
            try
            {
                return objDietMasterDataManager.GetDietMaster_History(customerID);
            }
            catch
            {
                throw;
            }
        }

        public int UpdateClientData(int customerID)
        {
            try
            {
                return objDietMasterDataManager.UpdateClientData(customerID);
            }
            catch
            {
                throw;
            }
        }
    }
}
