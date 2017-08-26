namespace Diet.Business.Model.ModClinicalComplaints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ClinicalComplaints
    {
        public int Operation { set; private get; }  //write only property

        public int ClinicCompID { get; set; }

        public int CustomerID { get; set; }

        public int ClinicCompGastProbID { get; set; }

        public int ClinicCompChronDisID { get; set; }

        public int ClinicCompMedicationID { get; set; }      

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

        //ChronicDiseases

        //public int ChronicDiseaseID { get; set; }

        //public string DiabetesChronDis { get; set; }

        //public string HypertensionChronDis { get; set; }

        //public string CardiacDisorders { get; set; }

        //public string KidneyDisorders { get; set; }

        //public string LeverDisorders { get; set; }

        //public string OtherChronicDiseases { get; set; }

        //public string FollowedParticularDietForProb { get; set; }

        //Medication

        public int MedicationID { get; set; }

        public string TakeVitaminSup { get; set; }

        public string VitaminSupDet { get; set; }

        public string TakeMineralSup { get; set; }

        public string MineralSupDet { get; set; }

        public string OralDrugDType { get; set; }

        public string OralDrugDet { get; set; }

        public string MedicationOthers { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
