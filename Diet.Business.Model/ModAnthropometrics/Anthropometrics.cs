namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Anthropometrics
    {
        public int Operation { set;  get; }  

        public int AnthropometricID { get; set; }

        public int CustomerID { get;set;}

        public double  MeasuredWeight { get; set; }

        public double MeasuredHeight { get; set; }

        public double IdealBodyWeight { get; set; }

        public double CalculatedBMI { get; set; }

        public string BMICategory { get; set; }

        public double BMIPer { get; set; }

        public double FatPer { get; set; }

        public double MeasuredWaist { get; set; }

        public double MeasuredWrist { get; set; }

        public double WeightGainLossMonth { get; set; }

        public double WeightGainLossSixMonth { get; set; }

        public double WeightGainLossYear { get; set; }

        public double NeckCircumference { get; set; }

        public double MUAC { get; set; }

        public string BloodPressure { get; set; }

        public string BodyFrame { get; set; }

        public string ReasonGainLoss { get; set; }

        public string AnthrpometricsNotes { get; set; }

        public double MussleMass { get; set; }

        public double BoneMass { get; set; }

        public double BodyWater { get; set; }

        public double VisceralFat { get; set; }    

    }
}
