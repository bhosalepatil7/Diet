using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Diet.DataAccess.DataManagers.ModHelper
{
    public class HelperMasterDataManager
    {
        public DataTable GetRegexForCountry(int country)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@countryId",country)                    
                };
                return DBOperate.GetDataTable("usp_GetCountryRegex", parameter);
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetCountryCode(int country)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@countryId",country)                    
                };
                return DBOperate.GetDataTable("usp_GetCountryCode", parameter);
            }
            catch
            {
                throw;
            }
        }
        public DataTable CheckAccess(string session)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@Session",session)                    
                };
                return DBOperate.GetDataTable("usp_CheckAccess", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
