using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Diet.Business.Model;
using Diet.Common;
using Diet.Business.Contract;

namespace GNHClientUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DietMaster objDietMaster = new DietMaster();
            objDietMaster.Operation = 1;
            objDietMaster.CustomerID = 0;


            int i = 0;
            BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            {
                i = DietMasterManager.ModifyDietMaster(objDietMaster);
            });

        }
    }
}