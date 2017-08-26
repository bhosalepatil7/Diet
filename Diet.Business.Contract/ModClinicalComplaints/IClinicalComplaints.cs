namespace Diet.Business.Contract
{
    using Diet.Business.Model;
    using Diet.Business.Model.ModClinicalComplaints;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public interface IClinicalComplaints
    {
        int ModifyClinicalComplaints(ClinicalComplaints obj);
    }
}
