namespace Diet.Business.Contract
{
    using Diet.Business.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public interface IDietMaster
    {
        int ModifyDietMaster(DietMaster objDietMaster);

        DataTable SearchPatients(string searchText, string searchCriteria,string session);

        DataSet GetDietMaster(int customerID);

        DataSet GetDietMaster_History(int customerID);

        int UpdateClientData(int customerID);
    }
}
