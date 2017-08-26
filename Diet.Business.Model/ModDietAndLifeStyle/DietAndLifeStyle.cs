namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DietAndLifeStyle
    {
        public int Operation { set; private get; }  //write only property

        public int CustomerID { get; set; }

        public int DietAndLifeStyleID { get; set; }

        public string RegularExcercise { get; set; }

        public string Smoking { get; set; }

        public string Alcohol { get; set; }

        public string ExcersizeDetail { get; set; }

        public string SleepHoursPerDay { get; set; }

        public int DietLifeHistoryID { get; set; }

        public DateTime CreatedOn { get; set; }


    }
}
