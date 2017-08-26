using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diet.DataAccess.DataManagers
{
    using Diet.Business.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class RecallDietDataManager
    {
        public int SaveSingleMealDetails(int CustID, string MealID, string MealDays,string MealData, DateTime MealTime, string Notes)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@CustID",CustID),
                    new SqlParameter("@MealID",MealID),
                    new SqlParameter("@MealDays",MealDays),
                    new SqlParameter("@MealData",MealData),
                    new SqlParameter("@MealTime",MealTime),
                    new SqlParameter("@Notes",Notes),
                };

                return DBOperate.ExecuteProcedureWithParameterReturnRowsAffected("usp_SaveSingleMealDetails", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetRecallDietDetails(int CustID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@CustID",CustID)
                };

                return DBOperate.GetDataTable("usp_GetRecallDietDetails", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetRecallDietDetailsHistory(int CustID, string date)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@CustID",CustID),
                    new SqlParameter("@date",date)
                };

                return DBOperate.GetDataTable("usp_GetRecallDietDetailsHistory", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
