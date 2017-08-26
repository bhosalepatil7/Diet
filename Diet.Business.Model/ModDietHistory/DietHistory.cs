
namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DietHistory
    {
        public int Operation { set; private get; }  //write only property

        public int DietHistoryID { get; set; }

        public string DietType { get; set; }

        public string FreqOutFoodEat { get; set; }

        public int NoOfTypicalMealsInDay { get; set; }

        public int NoOfTypicalSnaxsInDay { get; set; }

        public string Caloricbeverages { get; set; }

        public string BreakfastEveryDay { get; set; }

        public string EatWhenBored { get; set; }

        public string EatWhenStressed { get; set; }

        public string EatWhenWatchTV { get; set; }

        public string TriedWeightLossDiet { get; set; }

        public string WtLossGainSixMon { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
