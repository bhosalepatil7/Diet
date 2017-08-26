
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

    [Export(typeof(IFoodMaster))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class FoodMasterManager : IFoodMaster
    {
        FoodMasterDataManager objFoodMasterDataManager = new FoodMasterDataManager();

        public DataTable GetFoodList()
        {

            try
            {
                return objFoodMasterDataManager.GetFoodList();
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetFoodListWithID()
        {
            try
            {
                return objFoodMasterDataManager.GetFoodListWithID();
            }
            catch
            {
                
                throw;
            }
            
        }

        public DataTable GetFoodUnitList()
        {

            try
            {
                return objFoodMasterDataManager.GetFoodUnitList();
            }
            catch
            {
                throw;
            }
        }


        public DataTable GetFoodMajorNutrients(string foodName, double foodQuantity, string foodUnit)
        {

            try
            {
                return objFoodMasterDataManager.GetFoodMajorNutrients(foodName, foodQuantity, foodUnit);
            }
            catch
            {
                throw;
            }
        }

    }
}
