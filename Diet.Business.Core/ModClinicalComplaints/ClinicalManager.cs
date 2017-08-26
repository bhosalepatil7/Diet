namespace Diet.Business.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using Diet.Business.Contract;
    using Diet.Business.Model;
    using Diet.DataAccess.DataManagers;
    using Diet.Business.Contract.ModBioChemicalLab;
    using Diet.DataAccess.DataManagers.ModClinicalComplaints;
    using Diet.Business.Model.ModClinicalComplaints;

    [Export(typeof(IClinicalComplaints))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ClinicalManager : IClinicalComplaints
    {
        public int ModifyClinicalComplaints(ClinicalComplaints obj)
        {
            ClinicalDataManager obj1 = new ClinicalDataManager();

            try
            {
                return obj1.ModifyClinicalComplaints(obj);
            }
            catch
            {
                throw;
            }
        }
    }
}
