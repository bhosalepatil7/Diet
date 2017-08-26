using Diet.Business.Model.ModDietLifestyle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Diet.DataAccess.DataManagers.ModDietLifestyle
{
    public class DietLifestyleDataManager
    {
        public int ModifyDietLifestyle(DietLifestyle obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {

                        new SqlParameter("@CustomerID",obj.CustomerID),
                        
                        new SqlParameter("@DietAndLifeStyleID",obj.DietAndLifeStyleID),

						new SqlParameter("@RegularExcercise",obj.RegularExcercise),

						new SqlParameter("@Smoking",obj.Smoking),

						new SqlParameter("@Alcohol",obj.Alcohol),

						new SqlParameter("@NoOfDrinks",obj.NoOfDrinks),

                        new SqlParameter("@FrequencyOfDrinks",obj.FrequencyOfDrinks),

                        new SqlParameter("@TypeOfDrink",obj.TypeOfDrink),
                        
                        new SqlParameter("@ExcersizeDetail",obj.ExcersizeDetail),

						new SqlParameter("@SleepHoursPerDay",obj.SleepHoursPerDay),

                        new SqlParameter("@ActivityFactor",obj.ActivityFactor),

						new SqlParameter("@DietLifeHistoryID",obj.DietLifeHistoryID),

                        new SqlParameter("@DietAndLifeStyleNotes",obj.DietAndLifeStyleNotes),

                        new SqlParameter("@OilUseDetail",obj.OilUseDetail),

                        new SqlParameter("@SugarQuantityForMonth",obj.SugarQuantityForMonth),

                        new SqlParameter("@OilQuantityForMonth",obj.OilQuantityForMonth),                        

                        new SqlParameter("@NoOfMembersInFamily",obj.NoOfMembersInFamily),                        

                        new SqlParameter("@BMR",obj.BMR),                        

                        new SqlParameter("@Calorie",obj.Calorie),                        

                        new SqlParameter("@CarbhohydratesPercent",obj.CarbhohydratesPercent),                        

                        new SqlParameter("@FatPercent",obj.FatPercent),                        

                        new SqlParameter("@ProteinPercent",obj.ProteinPercent),                                                
                        
                         new SqlParameter("@Calorie1",obj.Calorie1),                        

                        new SqlParameter("@CarbhohydratesPercent1",obj.CarbhohydratesPercent1),                        

                        new SqlParameter("@FatPercent1",obj.FatPercent1),                        

                        new SqlParameter("@ProteinPercent1",obj.ProteinPercent1),                                                

                        new SqlParameter("@GrainsServings",obj.GrainsServings),                                                

                        new SqlParameter("@DalsServings",obj.DalsServings),                                                

                        new SqlParameter("@MilkServings",obj.MilkServings),                                                

                        new SqlParameter("@NonvegServings",obj.NonvegServings),      

                        new SqlParameter("@VegetablesServings",obj.VegetablesServings),      

                        new SqlParameter("@FruitsServings",obj.FruitsServings),      
                        
                        new SqlParameter("@SugarServings",obj.SugarServings),      

                        new SqlParameter("@FatServings",obj.FatServings),      
                        
                        new SqlParameter("@WaterServings",obj.WaterServings),      

                        new SqlParameter("@BiscuitServings",obj.BiscuitServings),   

                        new SqlParameter("@NonvegQuantity",obj.NonvegQuantity),      
                        
                        new SqlParameter("@NonvegTypes",obj.NonvegTypes),      

                        new SqlParameter("@NonvegValues",obj.NonvegValues),      
                        //DietHistory

						new SqlParameter("@DietHistoryID",obj.DietHistoryID),

						new SqlParameter("@DietType",obj.DietType),

                        new SqlParameter("@DietTypeDetails",obj.DietTypeDetails),

						new SqlParameter("@FreqOutFoodEat",obj.FreqOutFoodEat),

						new SqlParameter("@NoOfTypicalMealsInDay",obj.NoOfTypicalMealsInDay),

						new SqlParameter("@NoOfTypicalSnaxsInDay",obj.NoOfTypicalSnaxsInDay),

                        new SqlParameter("@NoOfTeaCoffeeInDay",obj.NoOfTeaCoffeeInDay),

                        new SqlParameter("@TeaCoffeeFrequency",obj.TeaCoffeeFrequency),
                        
                        new SqlParameter("@Caloricbeverages",obj.Caloricbeverages),

						new SqlParameter("@BreakfastEveryDay",obj.BreakfastEveryDay),

						new SqlParameter("@EatWhenBored",obj.EatWhenBored),

						new SqlParameter("@EatWhenStressed",obj.EatWhenStressed),

						new SqlParameter("@EatWhenWatchTV",obj.EatWhenWatchTV),

                        new SqlParameter("@Pregnant",obj.Pregnant),

                        new SqlParameter("@LactatingMother",obj.LactatingMother),

                        new SqlParameter("@BabyAge",obj.BabyAge),

						new SqlParameter("@TriedWeightLossDiet",obj.TriedWeightLossDiet),

						new SqlParameter("@WtLossGainSixMon",obj.WtLossGainSixMon),

                        new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_ModifyDietLifestyle", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
