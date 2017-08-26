namespace Diet.DataAccess.DataManagers
{
    using Diet.Business.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class FoodMasterDataManager
    {
        public DataTable GetFoodList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetFoodList");
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetFoodListWithID()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetFoodListWithID");
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetFoodUnitList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetFoodUnitList");
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetFoodMajorNutrients(string foodName, double foodQuantity, string foodUnit)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@foodName",foodName),
                    new SqlParameter("@foodQuantity",foodQuantity),
                    new SqlParameter("@foodUnit",foodUnit)
                };
                return DBOperate.GetDataTable("usp_GetFoodMajorNutrients", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
