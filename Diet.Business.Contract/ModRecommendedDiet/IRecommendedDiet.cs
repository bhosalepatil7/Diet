
namespace Diet.Business.Contract
{
    using Diet.Business.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public interface IRecommendedDiet
    {
        int SaveRecommendedSingleMealDetails(int CustID, string MealID, string MealDays, string MealData, DateTime MealTime, string Notes);
        DataTable GetRecommendedDietDetails(int CustID);
        DataTable GetRecommendedDietDetailsHistory(int CustID,string date);
    }
}
