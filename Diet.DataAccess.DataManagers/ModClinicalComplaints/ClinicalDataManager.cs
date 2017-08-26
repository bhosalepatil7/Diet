using Diet.Business.Model;
using Diet.Business.Model.ModClinicalComplaints;
using System.Data;
using System.Data.SqlClient;
namespace Diet.DataAccess.DataManagers.ModClinicalComplaints
{
    public class ClinicalDataManager
    {
        public int ModifyClinicalComplaints(ClinicalComplaints obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    //new SqlParameter("@ChronicDiseaseID",obj.ChronicDiseaseID),

                    new SqlParameter("@CustomerID",obj.CustomerID),

                    //new SqlParameter("@DiabetesChronDis",obj.DiabetesChronDis),

                    //new SqlParameter("@HypertensionChronDis",obj.HypertensionChronDis),

                    //new SqlParameter("@CardiacDisorders",obj.CardiacDisorders),

                    //new SqlParameter("@KidneyDisorders",obj.CardiacDisorders),

                    //new SqlParameter("@LeverDisorders",obj.LeverDisorders),

                    //new SqlParameter("@OtherChronicDiseases",obj.OtherChronicDiseases),

                    //new SqlParameter("@FollowedParticularDietForProb",obj.FollowedParticularDietForProb),

                    new SqlParameter("@GastProbID",obj.GastProbID),

                    new SqlParameter("@Heartburn",obj.Heartburn),

                    new SqlParameter("@Bloating",obj.Bloating),

                    new SqlParameter("@Gas",obj.Gas),

                    new SqlParameter("@Diarrhoea",obj.Diarrhoea),

                    new SqlParameter("@Vomiting",obj.Vomiting),

                    new SqlParameter("@Constipation",obj.Constipation),

                    new SqlParameter("@LaxativeAntacide",obj.LaxativeAntacide),

                    new SqlParameter("@HomeRemedy",obj.HomeRemedy),

                    new SqlParameter("@GastroOthers",obj.GastroOthers),

                    new SqlParameter("@MedicationID",obj.MedicationID),

                    new SqlParameter("@TakeVitaminSup",obj.TakeVitaminSup),

                    new SqlParameter("@VitaminSupDet",obj.VitaminSupDet),

                    new SqlParameter("@TakeMineralSup",obj.TakeMineralSup),

                    new SqlParameter("@MineralSupDet",obj.MineralSupDet),

                    new SqlParameter("@OralDrugDType",obj.OralDrugDType),

                    new SqlParameter("@OralDrugDet",obj.OralDrugDet),

                    new SqlParameter("@MedicationOthers",obj.MedicationOthers),

                    new SqlParameter("@ClinicCompID",obj.ClinicCompID),

                    new SqlParameter("@ClinicCompGastProbID",obj.ClinicCompGastProbID),

                    new SqlParameter("@ClinicCompChronDisID",obj.ClinicCompChronDisID),

                    new SqlParameter("@ClinicCompMedicationID",obj.ClinicCompMedicationID),                   

                    new SqlParameter("@ClinicComplaintsNotes",obj.ClinicComplaintsNotes),
    
                    new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_ModifyClinicalComplaints", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
