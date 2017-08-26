
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

    [Export(typeof(IRecommendedDiet))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class RecommendedDietManager : IRecommendedDiet
    {
        RecommendedDietDataManager objRecommendedDietDataManager = new RecommendedDietDataManager();

        public int SaveRecommendedSingleMealDetails(int CustID, string MealID, string MealDays, string MealData, DateTime MealTime, string Notes)
        {
            try
            {
                return objRecommendedDietDataManager.SaveRecommendedSingleMealDetails(CustID, MealID, MealDays, MealData, MealTime, Notes);
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
                return objRecommendedDietDataManager.GetRecommendedDietDetails(CustID);
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
                return objRecommendedDietDataManager.GetRecommendedDietDetailsHistory(CustID, date);
            }
            catch
            {
                throw;
            }
        }
    }
}
