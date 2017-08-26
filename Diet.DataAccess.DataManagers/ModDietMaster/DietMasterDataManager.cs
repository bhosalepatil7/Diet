namespace Diet.DataAccess.DataManagers
{
    using Diet.Business.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DietMasterDataManager
    {
        public int ModifyDietMaster(DietMaster objDietMaster)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@Operation",objDietMaster.Operation),

                        //CustomerDetails

                        new SqlParameter("@CustomerID",objDietMaster.CustomerID),
                        new SqlParameter("@CustomerName",objDietMaster.CustomerName),
                        new SqlParameter("@MiddleName",objDietMaster.MiddleName),
                        new SqlParameter("@LastName",objDietMaster.LastName),
                        new SqlParameter("@CustomerAge",objDietMaster.CustomerAge),
                        new SqlParameter("@Gender",objDietMaster.Gender),
                        new SqlParameter("@DOB",objDietMaster.DOB),
                        new SqlParameter("@Address1",objDietMaster.Address1),
                        new SqlParameter("@Locality",objDietMaster.Locality),
                        new SqlParameter("@City",objDietMaster.City),
                        new SqlParameter("@State",objDietMaster.State),
                        new SqlParameter("@Country",objDietMaster.Country),
                        new SqlParameter("@Pincode",objDietMaster.PinCode),
                        new SqlParameter("@Profession",objDietMaster.Profession),
                        new SqlParameter("@ProfessionOthers",objDietMaster.ProfessionOthers),
                        new SqlParameter("@Email",objDietMaster.Email),
                        new SqlParameter("@Mobile",objDietMaster.Mobile),
                        new SqlParameter("@Landline",objDietMaster.Landline),
                        new SqlParameter("@PresentExercise",objDietMaster.PresentExercise),
                        new SqlParameter("@ExersizeActivity",objDietMaster.ExersizeActivity),
                        new SqlParameter("@CustomerDetailNotes",objDietMaster.CustomerDetailNotes),
                        new SqlParameter("@Session",objDietMaster.Session),
                        //Anthrpometrics

						new SqlParameter("@AnthropometricID",objDietMaster.AnthropometricID),

						new SqlParameter("@MeasuredWeight",objDietMaster.MeasuredWeight),

						new SqlParameter("@MeasuredHeight",objDietMaster.MeasuredHeight),

						new SqlParameter("@IdealBodyWeight",objDietMaster.IdealBodyWeight),

						new SqlParameter("@CalculatedBMI",objDietMaster.CalculatedBMI),

						new SqlParameter("@BMICategory",objDietMaster.BMICategory),

                        new SqlParameter("@BMIPer",objDietMaster.BMIPer),

                        new SqlParameter("@FatPer",objDietMaster.FatPer),

						new SqlParameter("@MeasuredWaist",objDietMaster.MeasuredWaist),

                        new SqlParameter("@MeasuredWrist",objDietMaster.MeasuredWrist),

						new SqlParameter("@WeightGainLossMonth",objDietMaster.WeightGainLossMonth),

						new SqlParameter("@WeightGainLossSixMonth",objDietMaster.WeightGainLossSixMonth),

						new SqlParameter("@WeightGainLossYear",objDietMaster.WeightGainLossYear),

						new SqlParameter("@NeckCircumference",objDietMaster.NeckCircumference),

						new SqlParameter("@MUAC",objDietMaster.MUAC),

						new SqlParameter("@BloodPressure",objDietMaster.BloodPressure),

                        new SqlParameter("@BodyFrame",objDietMaster.BodyFrame),

                        new SqlParameter("@ReasonGainLoss",objDietMaster.ReasonGainLoss),

                        new SqlParameter("@AnthrpometricsNotes",objDietMaster.AnthrpometricsNotes),
                        new SqlParameter("@MussleMass",objDietMaster.MussleMass),

                        new SqlParameter("@BoneMass",objDietMaster.BoneMass),

                        new SqlParameter("@BodyWater",objDietMaster.BodyWater),

                        new SqlParameter("@VisceralFat",objDietMaster.VisceralFat),
        //BioChemicalLabs

						new SqlParameter("@BioChemicalLabID",objDietMaster.BioChemicalLabID),

                        new SqlParameter("@TestDate",objDietMaster.TestDate),

						new SqlParameter("@FastingGlucose",objDietMaster.FastingGlucose),

					    new SqlParameter("@PP",objDietMaster.PP),

                        new SqlParameter("@HB",objDietMaster.HB),
                        
                        new SqlParameter("@Creatinine",objDietMaster.Creatinine),

						new SqlParameter("@Albumin",objDietMaster.Albumin),

						new SqlParameter("@HbA1C",objDietMaster.HbA1C),

						new SqlParameter("@AltSGPT",objDietMaster.AltSGPT),

						new SqlParameter("@AltSGOT",objDietMaster.AltSGOT),

						new SqlParameter("@Hematocrit",objDietMaster.Hematocrit),

						new SqlParameter("@Triglycerides",objDietMaster.Triglycerides),

						new SqlParameter("@TSH",objDietMaster.TSH),
                        
                        new SqlParameter("@HDL",objDietMaster.HDL),

                        new SqlParameter("@LDL",objDietMaster.LDL),

                        new SqlParameter("@UricAcid",objDietMaster.UricAcid),

                        new SqlParameter("@TotalCholesterol",objDietMaster.TotalCholesterol),

						new SqlParameter("@AlkalinePhosphatase",objDietMaster.AlkalinePhosphatase),

						new SqlParameter("@VitaminD3",objDietMaster.VitaminD3),

						new SqlParameter("@VitaminB12",objDietMaster.VitaminB12),

                        new SqlParameter("@BSL",objDietMaster.BSL),

                        new SqlParameter("@RBC",objDietMaster.RBC),

                        new SqlParameter("@Platelet",objDietMaster.Platelet),

						new SqlParameter("@OthersBioChemicalLabs",objDietMaster.OthersBioChemicalLabs),

                        new SqlParameter("@BioChemicalLabNotes",objDietMaster.BioChemicalLabNotes),

        //Comorbidity

						new SqlParameter("@ComorbidityID",objDietMaster.ComorbidityID),

						new SqlParameter("@Hypertension",objDietMaster.Hypertension),

						new SqlParameter("@Diabetes",objDietMaster.Diabetes),

						new SqlParameter("@CHF",objDietMaster.CHF),

						new SqlParameter("@Asthma",objDietMaster.Asthma),

						new SqlParameter("@IHD",objDietMaster.IHD),

						new SqlParameter("@Thyroid",objDietMaster.Thyroid),

                        new SqlParameter("@ThyroidType",objDietMaster.ThyroidType),

						new SqlParameter("@SleepApnea",objDietMaster.SleepApnea),

						new SqlParameter("@FunctionalStatus",objDietMaster.FunctionalStatus),

           				new SqlParameter("@ComorbidityOthers",objDietMaster.ComorbidityOthers),

                        new SqlParameter("@ComorbidityNotes",objDietMaster.ComorbidityNotes),

        //ChronicDiseases												

						new SqlParameter("@CardiacDisorders",objDietMaster.CardiacDisorders),

						new SqlParameter("@KidneyDisorders",objDietMaster.KidneyDisorders),

						new SqlParameter("@LeverDisorders",objDietMaster.LeverDisorders),						

						new SqlParameter("@FollowedParticularDietForProb",objDietMaster.FollowedParticularDietForProb),

        //DietAndLifeStyle

						new SqlParameter("@DietAndLifeStyleID",objDietMaster.DietAndLifeStyleID),

						new SqlParameter("@RegularExcercise",objDietMaster.RegularExcercise),

						new SqlParameter("@Smoking",objDietMaster.Smoking),

						new SqlParameter("@Alcohol",objDietMaster.Alcohol),

						new SqlParameter("@NoOfDrinks",objDietMaster.NoOfDrinks),

                       new SqlParameter("@FrequencyOfDrinks",objDietMaster.FrequencyOfDrinks),

                       new SqlParameter("@TypeOfDrink",objDietMaster.TypeOfDrink),
                        
                        new SqlParameter("@ExcersizeDetail",objDietMaster.ExcersizeDetail),

						new SqlParameter("@SleepHoursPerDay",objDietMaster.SleepHoursPerDay),

                        new SqlParameter("@ActivityFactor",objDietMaster.ActivityFactor),

						new SqlParameter("@DietLifeHistoryID",objDietMaster.DietLifeHistoryID),

                        new SqlParameter("@DietAndLifeStyleNotes",objDietMaster.DietAndLifeStyleNotes),
                        
                        new SqlParameter("@BMR",objDietMaster.BMR),                        

                        new SqlParameter("@Calorie",objDietMaster.Calorie),                        

                        new SqlParameter("@CarbhohydratesPercent",objDietMaster.CarbhohydratesPercent),                        

                        new SqlParameter("@FatPercent",objDietMaster.FatPercent),                        

                        new SqlParameter("@ProteinPercent",objDietMaster.ProteinPercent),  
                      
                         new SqlParameter("@Calorie1",objDietMaster.Calorie1),                        

                        new SqlParameter("@CarbhohydratesPercent1",objDietMaster.CarbhohydratesPercent1),                        

                        new SqlParameter("@FatPercent1",objDietMaster.FatPercent1),                        

                        new SqlParameter("@ProteinPercent1",objDietMaster.ProteinPercent1),  

                        new SqlParameter("@GrainsServings",objDietMaster.GrainsServings),                                                

                        new SqlParameter("@DalsServings",objDietMaster.DalsServings),                                                

                        new SqlParameter("@MilkServings",objDietMaster.MilkServings),                                                

                        new SqlParameter("@NonvegServings",objDietMaster.NonvegServings),      

                        new SqlParameter("@VegetablesServings",objDietMaster.VegetablesServings),      

                        new SqlParameter("@FruitsServings",objDietMaster.FruitsServings),      
                        
                        new SqlParameter("@SugarServings",objDietMaster.SugarServings),      

                        new SqlParameter("@FatServings",objDietMaster.FatServings),      
                        
                        new SqlParameter("@WaterServings",objDietMaster.WaterServings),   

                        new SqlParameter("@BiscuitServings",objDietMaster.BiscuitServings),   

                        new SqlParameter("@NonvegQuantity",objDietMaster.NonvegQuantity),      
                        
                        new SqlParameter("@NonvegTypes",objDietMaster.NonvegTypes),      

                        new SqlParameter("@NonvegValues",objDietMaster.NonvegValues),

        //DietHistory

						new SqlParameter("@DietHistoryID",objDietMaster.DietHistoryID),

						new SqlParameter("@DietType",objDietMaster.DietType),

                        new SqlParameter("@DietTypeDetails",objDietMaster.DietTypeDetails),

						new SqlParameter("@FreqOutFoodEat",objDietMaster.FreqOutFoodEat),

						new SqlParameter("@NoOfTypicalMealsInDay",objDietMaster.NoOfTypicalMealsInDay),

						new SqlParameter("@NoOfTypicalSnaxsInDay",objDietMaster.NoOfTypicalSnaxsInDay),

                        new SqlParameter("@NoOfTeaCoffeeInDay",objDietMaster.NoOfTeaCoffeeInDay),

                        new SqlParameter("@TeaCoffeeFrequency",objDietMaster.TeaCoffeeFrequency),
                        
                        new SqlParameter("@Caloricbeverages",objDietMaster.Caloricbeverages),

						new SqlParameter("@BreakfastEveryDay",objDietMaster.BreakfastEveryDay),

						new SqlParameter("@EatWhenBored",objDietMaster.EatWhenBored),

						new SqlParameter("@EatWhenStressed",objDietMaster.EatWhenStressed),

						new SqlParameter("@EatWhenWatchTV",objDietMaster.EatWhenWatchTV),

                        new SqlParameter("@Pregnant",objDietMaster.Pregnant),

                        new SqlParameter("@LactatingMother",objDietMaster.LactatingMother),

                        new SqlParameter("@BabyAge",objDietMaster.BabyAge),

						new SqlParameter("@TriedWeightLossDiet",objDietMaster.TriedWeightLossDiet),

						new SqlParameter("@WtLossGainSixMon",objDietMaster.WtLossGainSixMon),

        //Clinic Complaints

						new SqlParameter("@ClinicCompID",objDietMaster.ClinicCompID),

						new SqlParameter("@ClinicCompGastProbID",objDietMaster.ClinicCompGastProbID),

						//new SqlParameter("@ClinicCompChronDisID",objDietMaster.ClinicCompChronDisID),

						new SqlParameter("@ClinicCompMedicationID",objDietMaster.ClinicCompMedicationID),

  		//FatsAndOil

						new SqlParameter("@OilUseDetail",objDietMaster.OilUseDetail),

                        new SqlParameter("@SugarQuantityForMonth",objDietMaster.SugarQuantityForMonth),

						new SqlParameter("@OilQuantityForMonth",objDietMaster.OilQuantityForMonth),

						new SqlParameter("@NoOfMembersInFamily",objDietMaster.NoOfMembersInFamily),


                        new SqlParameter("@ClinicComplaintsNotes",objDietMaster.ClinicComplaintsNotes),

        //GastroIntenstinalProblems

						new SqlParameter("@GastProbID",objDietMaster.GastProbID),

						new SqlParameter("@Heartburn",objDietMaster.Heartburn),

						new SqlParameter("@Bloating",objDietMaster.Bloating),

						new SqlParameter("@Gas",objDietMaster.Gas),

						new SqlParameter("@Diarrhoea",objDietMaster.Diarrhoea),

						new SqlParameter("@Vomiting",objDietMaster.Vomiting),

						new SqlParameter("@Constipation",objDietMaster.Constipation),

						new SqlParameter("@LaxativeAntacide",objDietMaster.LaxativeAntacide),

						new SqlParameter("@HomeRemedy",objDietMaster.HomeRemedy),

          				new SqlParameter("@GastroOthers",objDietMaster.GastroOthers),

        

        //Medication

						new SqlParameter("@MedicationID",objDietMaster.MedicationID),

						new SqlParameter("@TakeVitaminSup",objDietMaster.TakeVitaminSup),

						new SqlParameter("@VitaminSupDet",objDietMaster.VitaminSupDet),

						new SqlParameter("@TakeMineralSup",objDietMaster.TakeMineralSup),

						new SqlParameter("@MineralSupDet",objDietMaster.MineralSupDet),

						new SqlParameter("@OralDrugDType",objDietMaster.OralDrugDType),

						new SqlParameter("@OralDrugDet",objDietMaster.OralDrugDet),

                        new SqlParameter("@MedicationOthers",objDietMaster.MedicationOthers),

        
        //RecallDiet

						new SqlParameter("@DietRecallID",objDietMaster.DietRecallID),

						new SqlParameter("@Meal1",objDietMaster.Meal1),

						new SqlParameter("@Meal2",objDietMaster.Meal2),

						new SqlParameter("@Meal3",objDietMaster.Meal3),

						new SqlParameter("@Meal4",objDietMaster.Meal4),

						new SqlParameter("@Meal5",objDietMaster.Meal5),

						new SqlParameter("@Meal6",objDietMaster.Meal6),

                        new SqlParameter("@RecallDietNotes",objDietMaster.RecallDietNotes),

                        new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_ModifyDietMaster", parameter);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to search for Patients
        /// </summary>
        /// <param name="searchText">string searchText</param>
        /// /// <param name="searchCriteria">string searchCriteria</param>
        /// <returns>DataTable</returns>
        public DataTable SearchPatients(string searchText, string searchCriteria, string session)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@searchText",searchText),
                    new SqlParameter("@searchCriteria",searchCriteria),
                    new SqlParameter("@Session",session)
                };
                return DBOperate.GetDataTable("csp_SearchPatients", parameter);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to fetch DietMaster Data
        /// </summary>
        /// <param name="customerID">int customerID</param>
        /// <returns>DataTable</returns>
        public DataSet GetDietMaster(int customerID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@customerID",customerID)
                };
                return DBOperate.GetDataSet("csp_GetDietMaster", parameter);
            }
            catch
            {
                throw;
            }
        }
        public DataSet GetDietMaster_History(int customerID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@customerID",customerID)
                };
                return DBOperate.GetDataSet("csp_GetDietMaster_History", parameter);
            }
            catch
            {
                throw;
            }
        }

        public int UpdateClientData(int customerID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@CustomerID",customerID),
                     new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_ModifyClientHistory", parameter);
            }
            catch
            {
                throw;
            }

        }
        public int AddHistory(int customerID, DateTime appDate)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@CustomerID",customerID),
                    new SqlParameter("@dt",appDate),
                     new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_AddClientHistory", parameter);
            }
            catch
            {
                throw;
            }

        }
    }
}
