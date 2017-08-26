using Diet.Business.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Diet.DataAccess.DataManagers.ModComorbidity
{
    public class ComorbidityDataManager
    {
        public int ModifyComorbidity(Comorbidity objc)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@ComorbidityID",objc.ComorbidityID),
                        new SqlParameter("@CustomerID",objc.CustomerID),
                        new SqlParameter("@Hypertension",objc.Hypertension),
                        new SqlParameter("@Diabetes",objc.Diabetes),
                        new SqlParameter("@CHF",objc.CHF),
                        new SqlParameter("@Asthma",objc.Asthma),
                        new SqlParameter("@IHD",objc.IHD),
                        new SqlParameter("@Thyroid",objc.Thyroid),
                        new SqlParameter("@ThyroidType",objc.ThyroidType),
                        new SqlParameter("@SleepApnea",objc.SleepApnea),
                        new SqlParameter("@FunctionalStatus",objc.FunctionalStatus),
                        new SqlParameter("@ComorbidityOthers",objc.ComorbidityOthers),
                        new SqlParameter("@ComorbidityNotes",objc.ComorbidityNotes),                                     
                        new SqlParameter("@CardiacDisorders",objc.CardiacDisorders),
                        new SqlParameter("@KidneyDisorders",objc.CardiacDisorders),
                        new SqlParameter("@LeverDisorders",objc.LeverDisorders),                    
                        new SqlParameter("@FollowedParticularDietForProb",objc.FollowedParticularDietForProb),
                        new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_ModifyComorbidity", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
