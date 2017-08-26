namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DietMaster
    {
        public int Operation { get; set; }

        //---------------------------------------------------------------

        //Customer Details
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int CustomerAge { get; set; }

        public int Gender { get; set; }

        public DateTime DOB { get; set; }

        public string Address1 { get; set; }

        public string Locality { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PinCode { get; set; }

        public string Profession { get; set; }

        public string ProfessionOthers { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Landline { get; set; }

        public string PresentExercise { get; set; }

        public string ExersizeActivity { get; set; }

        public string CustomerDetailNotes { get; set; }

        public string Session { get; set; }

        //Anthrpometrics

        public int AnthropometricID { get; set; }

        public double MeasuredWeight { get; set; }

        public double MeasuredHeight { get; set; }

        public double IdealBodyWeight { get; set; }

        public double CalculatedBMI { get; set; }

        public string BMICategory { get; set; }

        public double BMIPer { get; set; }

        public double FatPer { get; set; }

        public double MeasuredWaist { get; set; }

        public double WeightGainLossMonth { get; set; }

        public double WeightGainLossSixMonth { get; set; }

        public double WeightGainLossYear { get; set; }

        public double NeckCircumference { get; set; }

        public double MeasuredWrist { get; set; }

        public double MUAC { get; set; }

        public string BloodPressure { get; set; }

        public string BodyFrame { get; set; }

        public string ReasonGainLoss { get; set; }

        public string AnthrpometricsNotes { get; set; }

        public double MussleMass { get; set; }

        public double BoneMass { get; set; }

        public double BodyWater { get; set; }

        public double VisceralFat { get; set; }

        //BioChemicalLabs

        public int BioChemicalLabID { get; set; }

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

        //Comorbidity

        public int ComorbidityID { get; set; }

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


        //ChronicDiseases              

        public string CardiacDisorders { get; set; }

        public string KidneyDisorders { get; set; }

        public string LeverDisorders { get; set; }

        public string FollowedParticularDietForProb { get; set; }


        //DietAndLifeStyle

        public int DietAndLifeStyleID { get; set; }

        public string RegularExcercise { get; set; }

        public string Smoking { get; set; }

        public string Alcohol { get; set; }

        public int NoOfDrinks { get; set; }

        public string FrequencyOfDrinks { get; set; }

        public string TypeOfDrink { get; set; }

        public string ExcersizeDetail { get; set; }

        public string SleepHoursPerDay { get; set; }

        public double BMR { get; set; }

        public double Calorie { get; set; }

        public double CarbhohydratesPercent { get; set; }

        public double FatPercent { get; set; }

        public double ProteinPercent { get; set; }


        public double Calorie1 { get; set; }

        public double CarbhohydratesPercent1 { get; set; }

        public double FatPercent1 { get; set; }

        public double ProteinPercent1 { get; set; }

        public string ActivityFactor { get; set; }

        public string GrainsServings { get; set; }

        public string DalsServings { get; set; }

        public string MilkServings { get; set; }

        public string NonvegServings { get; set; }

        public string VegetablesServings { get; set; }

        public string FruitsServings { get; set; }

        public string SugarServings { get; set; }

        public string FatServings { get; set; }

        public string WaterServings { get; set; }

        public string BiscuitServings { get; set; }

        public string NonvegQuantity { get; set; }


        public string NonvegTypes { get; set; }

        public string NonvegValues { get; set; }


        public int DietLifeHistoryID { get; set; }

        public string DietAndLifeStyleNotes { get; set; }

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

        //Clinic Complaints

        public int ClinicCompID { get; set; }

        public int ClinicCompGastProbID { get; set; }

        public int ClinicCompChronDisID { get; set; }

        public int ClinicCompMedicationID { get; set; }

        public string OilUseDetail { get; set; }

        public string OilQuantityForMonth { get; set; }

        public string SugarQuantityForMonth { get; set; }

        public int NoOfMembersInFamily { get; set; }


        public string ClinicComplaintsNotes { get; set; }

        //GastroIntenstinalProblems

        public int GastProbID { get; set; }

        public string Heartburn { get; set; }

        public string Bloating { get; set; }

        public string Gas { get; set; }

        public string Diarrhoea { get; set; }

        public string Vomiting { get; set; }

        public string Constipation { get; set; }

        public string LaxativeAntacide { get; set; }

        public string HomeRemedy { get; set; }

        public string GastroOthers { get; set; }

        //Medication

        public int MedicationID { get; set; }

        public string TakeVitaminSup { get; set; }

        public string VitaminSupDet { get; set; }

        public string TakeMineralSup { get; set; }

        public string MineralSupDet { get; set; }

        public string OralDrugDType { get; set; }

        public string OralDrugDet { get; set; }

        public string MedicationOthers { get; set; }


        //RecallDiet

        public int DietRecallID { get; set; }

        public DateTime Meal1 { get; set; }

        public DateTime Meal2 { get; set; }

        public DateTime Meal3 { get; set; }

        public DateTime Meal4 { get; set; }

        public DateTime Meal5 { get; set; }

        public DateTime Meal6 { get; set; }

        public string RecallDietNotes { get; set; }

        //--------------------------------------------------------
        public DateTime CreatedOn { get; set; }
    }
}
