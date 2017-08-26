namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ClinicComplaints
    {
        public int Operation { set; private get; }  //write only property

        public int CustomerID { get; set; }
        public int ClinicCompID { get; set; }

        public int ClinicCompGastProbID { get; set; }

        public int ClinicCompChronDisID { get; set; }

        public int ClinicCompMedicationID { get; set; }

        public int ClinicCompFatOilID { get; set; }
        
        public DateTime CreatedOn { get; set; }

    }
}
