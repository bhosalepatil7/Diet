using Diet.DataAccess.DataManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using System.Text;

namespace Diet.Business.Core.ModDashboard
{
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class DashboardManager
    {
        Dashboard obj = new Dashboard();

        public DataTable GetClientDetails(int reportid)
        {
            try
            {
                return obj.GetClientDetails(reportid);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetClientDetails(int reportid, string session)
        {
            try
            {
                return obj.GetClientDetails(reportid, session);
            }
            catch
            {
                throw;
            }
        }
        public int UpdateDashoard(Int32 ID, string column, string session)
        {
            try
            {
                return obj.UpdateDashoard(ID, column, session);
            }
            catch
            {
                throw;
            }
        }
    }
}
