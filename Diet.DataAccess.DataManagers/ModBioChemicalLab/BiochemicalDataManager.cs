namespace Diet.DataAccess.DataManagers
{
    using Diet.Business.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class BiochemicalDataManager
    {
        public int ModifyBiochemical(BioChemicalLab objBio)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@BioChemicalLabID",objBio.BioChemicalLabID),  
	                    new SqlParameter("@CustomerID",objBio.CustomerID),  
                        new SqlParameter("@TestDate",objBio.TestDate),  	
                        new SqlParameter("@FastingGlucose",objBio.FastingGlucose),  	 	
                        new SqlParameter("@PP",objBio.PP),  	 	
                        new SqlParameter("@HB",objBio.HB),  			
                        new SqlParameter("@Creatinine",objBio.Creatinine),  	 		
                        new SqlParameter("@Albumin",objBio.Albumin),  	 			
                        new SqlParameter("@HbA1C",objBio.HbA1C),  	 			
                        new SqlParameter("@AltSGPT",objBio.AltSGPT),  	 	
                        new SqlParameter("@AltSGOT",objBio.AltSGOT),  	 	
                        new SqlParameter("@Hematocrit",objBio.Hematocrit),  	 	
                        new SqlParameter("@Triglycerides",objBio.Triglycerides),  	 	
                        new SqlParameter("@TSH",objBio.TSH),  	 	
                        new SqlParameter("@HDL",objBio.HDL),  	 	
                        new SqlParameter("@LDL",objBio.LDL),  	
                        new SqlParameter("@UricAcid",objBio.UricAcid),  	 	
                        new SqlParameter("@TotalCholesterol",objBio.TotalCholesterol),  	 	
                        new SqlParameter("@AlkalinePhosphatase",objBio.AlkalinePhosphatase),  	 	
                        new SqlParameter("@VitaminD3",objBio.VitaminD3),  	 	
                        new SqlParameter("@VitaminB12",objBio.VitaminB12),  	 	
                        new SqlParameter("@BSL",objBio.BSL),  	 	
                        new SqlParameter("@RBC",objBio.RBC),  	 	
                        new SqlParameter("@Platelet",objBio.Platelet),  	  	
                        new SqlParameter("@OthersBioChemicalLabs",objBio.OthersBioChemicalLabs),  	
                        new SqlParameter("@BioChemicalLabNotes",objBio.BioChemicalLabNotes),  	
                        new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_ModifyBioChemicalLabs", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
