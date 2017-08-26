using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diet.Business.Model.ModDietLifestyle
{
    public class DietLifestyle
    {
        public int Operation { set; private get; }  //write only property

        public int CustomerID { get; set; }

        public int DietAndLifeStyleID { get; set; }

        public string RegularExcercise { get; set; }

        public string Smoking { get; set; }

        public string Alcohol { get; set; }

        public int NoOfDrinks { get; set; }

        public string FrequencyOfDrinks { get; set; }

        public string TypeOfDrink { get; set; }

        public string ExcersizeDetail { get; set; }

        public string SleepHoursPerDay { get; set; }

        public string ActivityFactor { get; set; }

        public int DietLifeHistoryID { get; set; }

        public string DietAndLifeStyleNotes { get; set; }

        public double BMR { get; set; }

        public double Calorie { get; set; }

        public double CarbhohydratesPercent { get; set; }

        public double FatPercent { get; set; }

        public double ProteinPercent { get; set; }

        public double Calorie1 { get; set; }

        public double CarbhohydratesPercent1 { get; set; }

        public double FatPercent1 { get; set; }

        public double ProteinPercent1 { get; set; }

        public string GrainsServings { get; set; }

        public string DalsServings { get; set; }

        public string MilkServings { get; set; }

        public string NonvegServings { get; set; }

        public string VegetablesServings { get; set; }

        public string FruitsServings { get; set; }

        public string SugarServings { get; set; }

        public string FatServings { get; set; }

        public string WaterServings { get; set; }

        public string NonvegQuantity { get; set; }

        public string NonvegTypes { get; set; }

        public string NonvegValues { get; set; }

        public string BiscuitServings { get; set; }


        //DietHistory

        public int DietHistoryID { get; set; }

        public string DietType { get; set; }

        public string DietTypeDetails { get; set; }

        public string FreqOutFoodEat { get; set; }

        public int NoOfTypicalMealsInDay { get; set; }

        public int NoOfTypicalSnaxsInDay { get; set; }

        public string NoOfTeaCoffeeInDay { get; set; }

        public string TeaCoffeeFrequency { get; set; }
        public string Caloricbeverages { get; set; }

        public string BreakfastEveryDay { get; set; }

        public string EatWhenBored { get; set; }

        public string EatWhenStressed { get; set; }

        public string EatWhenWatchTV { get; set; }

        public string Pregnant { get; set; }

        public string LactatingMother { get; set; }

        public string BabyAge { get; set; }

        public string TriedWeightLossDiet { get; set; }

        public string WtLossGainSixMon { get; set; }

        public DateTime CreatedOn { get; set; }

        public string OilUseDetail { get; set; }

        public string SugarQuantityForMonth { get; set; }

        public string OilQuantityForMonth { get; set; }

        public int NoOfMembersInFamily { get; set; }
    }
}
