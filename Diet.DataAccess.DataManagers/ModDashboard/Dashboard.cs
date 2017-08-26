namespace Diet.DataAccess.DataManagers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    public class Dashboard
    {
        public DataTable GetClientDetails(int ReportID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@ReportID",ReportID)
                };
                return DBOperate.GetDataTable("csp_GetDashboardData", parameter);
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetClientDetails(int ReportID, string Session)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@ReportID",ReportID),
                    new SqlParameter("@Session",Session)
                };
                return DBOperate.GetDataTable("csp_GetDashboardData", parameter);
            }
            catch
            {
                throw;
            }
        }
        public int UpdateDashoard(Int32 ID, string column,string session)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@ID",ID),
                    new SqlParameter("@column",column), 
                    new SqlParameter("@Session",session), 
                    new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("csp_UpdateDashboardData", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
