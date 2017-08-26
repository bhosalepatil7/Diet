namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Medication
    {
        public int Operation { set; private get; }  //write only property

        public int MedicationID { get; set; }

        public string TakeVitaminSup { get; set; }

        public string VitaminSupDet { get; set; }

        public string TakeMineralSup { get; set; }

        public string MineralSupDet { get; set; }

        public string OralDrugDiabeteseDet { get; set; }

        public string OralDrugHypertensionDet { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
