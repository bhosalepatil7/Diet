
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

    [Export(typeof(IRecallDiet))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class RecallDietManager : IRecallDiet
    {
        RecallDietDataManager objRecallDietDataManager = new RecallDietDataManager();

        public int SaveSingleMealDetails(int CustID, string MealID, string MealDays, string MealData, DateTime MealTime, string Notes)
        {
            try
            {
                return objRecallDietDataManager.SaveSingleMealDetails(CustID, MealID, MealDays, MealData, MealTime, Notes);
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
                return objRecallDietDataManager.GetRecallDietDetails(CustID);
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
                return objRecallDietDataManager.GetRecallDietDetailsHistory(CustID, date);
            }
            catch
            {
                throw;
            }
        }

    }
}
