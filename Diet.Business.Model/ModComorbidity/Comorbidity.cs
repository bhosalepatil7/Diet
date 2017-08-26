
namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Comorbidity
    {
        public int Operation { set;  get; }  //write only property

        public int ComorbidityID { get; set; }

        public int CustomerID { get; set; }

        public string Hypertension { get; set; }

        public string Diabetes { get; set; }

        public string CHF { get; set; }

        public string Asthma { get; set; }

        public string IHD { get; set; }

        public string Thyroid { get; set; }

        public string ThyroidType { get; set; }

        public string SleepApnea { get; set; }

        public string FunctionalStatus { get; set; }

        public string ComorbidityOthers { get; set; }

        public string ComorbidityNotes { get; set; }


        public string CardiacDisorders { get; set; }

        public string KidneyDisorders { get; set; }

        public string LeverDisorders { get; set; }

        public string FollowedParticularDietForProb { get; set; }

    }
}
