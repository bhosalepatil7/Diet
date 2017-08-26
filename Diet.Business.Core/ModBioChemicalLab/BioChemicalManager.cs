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

    [Export(typeof(IBioChemicalLab))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class BioChemicalManager : IBioChemicalLab
    {
        public int ModifyBiochemical(BioChemicalLab objBio)
        {
            BiochemicalDataManager objBioDataManager = new BiochemicalDataManager();

            try
            {
                return objBioDataManager.ModifyBiochemical(objBio);
            }
            catch
            {
                throw;
            }
        }

    }
}
