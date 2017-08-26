
namespace Diet.Business.Contract
{
    using Diet.Business.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public interface IRecallDiet
    {
        int SaveSingleMealDetails(int CustID, string MealID, string MealDays, string MealData, DateTime MealTime, string Notes);
        DataTable GetRecallDietDetails(int CustID);

        DataTable GetRecallDietDetailsHistory(int CustID,string date);
    }
}
