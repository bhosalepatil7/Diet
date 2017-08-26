
namespace Diet.DataAccess.DataManagers
{
    using Diet.Business.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class RecommendedDietDataManager
    {
        public int SaveRecommendedSingleMealDetails(int CustID, string MealID, string MealDays, string MealData, DateTime MealTime, string Notes)
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

                return DBOperate.ExecuteProcedureWithParameterReturnRowsAffected("usp_SaveRecommendedSingleMealDetails", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetRecommendedDietDetails(int CustID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@CustID",CustID)
                };

                return DBOperate.GetDataTable("usp_GetRecommendedDietDetails", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetRecommendedDietDetailsHistory(int CustID, string date)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@CustID",CustID),
                    new SqlParameter("@date",date)
                };

                return DBOperate.GetDataTable("usp_GetRecommendedDietDetailsHistory", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
