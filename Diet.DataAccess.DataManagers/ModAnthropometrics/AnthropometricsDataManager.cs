namespace Diet.DataAccess.DataManagers
{
    using Diet.Business.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AnthropometricsDataManager
    {
        public int ModifyAnthropometrics(Anthropometrics objAnthropometrics)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@Operation",objAnthropometrics.Operation),
                        new SqlParameter("@AnthropometricID",objAnthropometrics.AnthropometricID),
                        new SqlParameter("@CustomerID",objAnthropometrics.CustomerID),
                        new SqlParameter("@MeasuredWeight",objAnthropometrics.MeasuredWeight),
                        new SqlParameter("@MeasuredHeight",objAnthropometrics.MeasuredHeight),
                        new SqlParameter("@IdealBodyWeight",objAnthropometrics.IdealBodyWeight),
                        new SqlParameter("@CalculatedBMI",objAnthropometrics.CalculatedBMI),
                        new SqlParameter("@BMICategory",objAnthropometrics.BMICategory),
                        new SqlParameter("@BMIPer",objAnthropometrics.BMIPer),
                        new SqlParameter("@FatPer",objAnthropometrics.FatPer),
                        new SqlParameter("@MeasuredWaist",objAnthropometrics.MeasuredWaist),
                        new SqlParameter("@MeasuredWrist",objAnthropometrics.MeasuredWrist),
                        new SqlParameter("@WeightGainLossMonth",objAnthropometrics.WeightGainLossMonth),
                        new SqlParameter("@WeightGainLossSixMonth",objAnthropometrics.WeightGainLossSixMonth),
                        new SqlParameter("@WeightGainLossYear",objAnthropometrics.WeightGainLossYear),
                        new SqlParameter("@NeckCircumference",objAnthropometrics.NeckCircumference),
                        new SqlParameter("@MUAC",objAnthropometrics.MUAC),
                        new SqlParameter("@BloodPressure",objAnthropometrics.BloodPressure),
                        new SqlParameter("@BodyFrame",objAnthropometrics.BodyFrame),
                        new SqlParameter("@ReasonGainLoss",objAnthropometrics.ReasonGainLoss),
                        new SqlParameter("@AnthrpometricsNotes",objAnthropometrics.AnthrpometricsNotes),
                        new SqlParameter("@MussleMass",objAnthropometrics.MussleMass),
                        new SqlParameter("@BoneMass",objAnthropometrics.BoneMass),
                        new SqlParameter("@BodyWater",objAnthropometrics.BodyWater),
                        new SqlParameter("@VisceralFat",objAnthropometrics.VisceralFat),
                        new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_ModifyAnthropometrics", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
