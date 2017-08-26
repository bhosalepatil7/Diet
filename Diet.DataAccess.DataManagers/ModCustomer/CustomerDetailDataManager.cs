namespace Diet.DataAccess.DataManagers
{
    using Diet.Business.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CustomerDetailDataManager
    {
        public int ModifyCustomerDetail(CustomerDetail objCustDetail)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@Operation",objCustDetail.Operation),
                        new SqlParameter("@CustomerID",objCustDetail.CustomerID),
                        new SqlParameter("@CustomerName",objCustDetail.CustomerName),
                        new SqlParameter("@MiddleName ",objCustDetail.MiddleName),
                        new SqlParameter("@LastName",objCustDetail.LastName),
                        new SqlParameter("@CustomerAge",objCustDetail.CustomerAge),
                        new SqlParameter("@Gender",objCustDetail.Gender),
                        new SqlParameter("@DOB",objCustDetail.DOB),
                        new SqlParameter("@Address1",objCustDetail.Address1),
                        new SqlParameter("@Locality",objCustDetail.Locality),
                        new SqlParameter("@City",objCustDetail.City),
                        new SqlParameter("@State",objCustDetail.State),
                        new SqlParameter("@Country",objCustDetail.Country),
                        new SqlParameter("@Pincode",objCustDetail.Pincode),
                        new SqlParameter("@Profession",objCustDetail.Profession),
                        new SqlParameter("@ProfessionOthers",objCustDetail.ProfessionOthers),
                        new SqlParameter("@Email",objCustDetail.Email),
                        new SqlParameter("@Mobile",objCustDetail.Mobile),
                        new SqlParameter("@Landline",objCustDetail.Landline),
                        new SqlParameter("@PresentExercise",objCustDetail.PresentExercise),
                        new SqlParameter("@ExersizeActivity",objCustDetail.ExersizeActivity),
                        new SqlParameter("@CustomerDetailNotes",objCustDetail.CustomerDetailNotes),
                        new SqlParameter("@Session",objCustDetail.Session),
                        new SqlParameter("@ReturnVal",SqlDbType.Int)
                };
                return DBOperate.ExecuteProcedure("usp_ModifyCustomerDetail", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
