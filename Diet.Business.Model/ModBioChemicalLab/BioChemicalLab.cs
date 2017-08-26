
namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BioChemicalLab
    {
        public int Operation { set;  get; }  

        public int BioChemicalLabID { get; set; }

        public int CustomerID { get; set; }

        public DateTime TestDate { get; set; }

        public double FastingGlucose { get; set; }

        public double PP { get; set; }

        public double HB { get; set; }

        public double Creatinine { get; set; }

        public double Albumin { get; set; }

        public double HbA1C { get; set; }

        public double AltSGPT { get; set; }

        public double AltSGOT { get; set; }

        public double Hematocrit { get; set; }

        public double Triglycerides { get; set; }

        public double TSH { get; set; }

        public double HDL { get; set; }

        public double LDL { get; set; }

        public double UricAcid { get; set; }

        public double TotalCholesterol { get; set; }

        public double AlkalinePhosphatase { get; set; }

        public double VitaminD3 { get; set; }

        public double VitaminB12 { get; set; }

        public double BSL { get; set; }

        public double RBC { get; set; }

        public double Platelet { get; set; }

        public string OthersBioChemicalLabs { get; set; }

        public string BioChemicalLabNotes { get; set; }
    }
}
