
namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RecallDiet
    {
        public int Operation { set; private get; }  //write only property
        public int DietRecallID { get; set; }
        public int CustIDFK { get; set; }
        public DateTime MealTime1 { get; set; }
        public string FoodMeal1 { get; set; }
        public DateTime MealTime2 { get; set; }
        public string FoodMeal2 { get; set; }
        public DateTime MealTime3 { get; set; }
        public string FoodMeal3 { get; set; }
        public DateTime MealTime4 { get; set; }
        public string FoodMeal4 { get; set; }
        public DateTime MealTime5 { get; set; }
        public string FoodMeal5 { get; set; }
        public DateTime MealTime6 { get; set; }
        public string FoodMeal6 { get; set; }
        public DateTime MealTime7 { get; set; }
        public string FoodMeal7 { get; set; }
        public DateTime MealTime8 { get; set; }
        public string FoodMeal8 { get; set; }
        public DateTime MealTime9 { get; set; }
        public string FoodMeal9 { get; set; }
        public DateTime MealTime10 { get; set; }
        public string FoodMeal10 { get; set; }
        public DateTime MealTime11 { get; set; }
        public string FoodMeal11 { get; set; }
        public DateTime MealTime12 { get; set; }
        public string FoodMeal12 { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
