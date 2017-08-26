using Diet.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diet.Business.Contract.ModBioChemicalLab
{
    public interface IBioChemicalLab
    {
        int ModifyBiochemical(BioChemicalLab objBio);
    }
}
