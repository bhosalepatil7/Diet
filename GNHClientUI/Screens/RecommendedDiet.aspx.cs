using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diet.Business.Model;
using Diet.Common;
using Diet.Business.Contract;
using System.Globalization;
using System.Text.RegularExpressions;
using Diet.DataAccess.DataManagers;
using Diet.Business.Core;

namespace GNHClientUI.Screens
{
    public partial class RecommendedDiet : System.Web.UI.Page
    {
        // FoodName And ID list
        DataTable dtFoodListWithID = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { BindData(); } 
        }

        protected void btnGenerateDietPlanReport_click(object sender, EventArgs e)
        {
            object filename = Server.MapPath("Diet-Plan-copy-1.docx");
            WebClient req = new WebClient();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + "test1.docx");
            byte[] data = req.DownloadData(filename.ToString());
            HttpContext.Current.Response.BinaryWrite(data);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();

        }

        private void BindData()
        {
            //Get Food Names with FoodID

            //BusinessHelper<IFoodMaster>.Use(FoodMasterManager =>
            //{
            //    dtFoodListWithID = FoodMasterManager.GetFoodListWithID();
            //});


            dtFoodListWithID = new FoodMasterManager().GetFoodListWithID();

            //Get Customer Recommended Diet Details
            int custID = Convert.ToInt32(Session["PatientID"]);

            DataTable dtRecommendedDietDetail = new DataTable();

            //BusinessHelper<IRecommendedDiet>.Use(RecommendedDietManager =>
            //{
            //    dtRecommendedDietDetail = RecommendedDietManager.GetRecommendedDietDetails(custID);
            //});

            dtRecommendedDietDetail = new RecommendedDietManager().GetRecommendedDietDetails(custID);

            List<RecommendedDietDetails> lstRecommendedDietDetails = new List<RecommendedDietDetails>();

            foreach (DataRow drRecommendedDiet in dtRecommendedDietDetail.Rows)
            {
                RecommendedDietDetails objRecommendedDietDetails = new RecommendedDietDetails();

                objRecommendedDietDetails.CustomerID = custID;
                objRecommendedDietDetails.VisitDate = Convert.ToDateTime(drRecommendedDiet["VisitDate"]);
                objRecommendedDietDetails.Notes = Convert.ToString(drRecommendedDiet["Notes"]);

                List<MealDetails> lstMealDetails = new List<MealDetails>();

                for (int mealID = 1; mealID <= 12; mealID++)
                {
                    string mealName = "Meal" + mealID;
                    string[] mealDetailSeperatingChars = { "@@" };
                    char[] mealFoodItemSeperatingChars = { '~' };
                    char[] mealFoodItemDetailSeperatingChars = { '|' };


                    string[] strMealDetails = Convert.ToString(drRecommendedDiet[mealName]).Split(mealDetailSeperatingChars, StringSplitOptions.None);

                    MealDetails objMealDetails = new MealDetails();

                    objMealDetails.MealName = mealName;
                    objMealDetails.Time = Convert.ToDateTime(strMealDetails[0]);
                    objMealDetails.Days = Convert.ToString(strMealDetails[1]);


                    List<MealFoodDetails> lstMealFoodDetails = new List<MealFoodDetails>();

                    string[] strMealFoodDetails = Convert.ToString(strMealDetails[2]).Split(mealFoodItemSeperatingChars, StringSplitOptions.RemoveEmptyEntries);

                    foreach (String strFoodItem in strMealFoodDetails)
                    {
                        MealFoodDetails objMealFoodDetails = new MealFoodDetails();
                        string[] strFoodItemDetail = strFoodItem.Split(mealFoodItemDetailSeperatingChars, StringSplitOptions.None);

                        var foodRows=dtFoodListWithID.Select("FoodID = " + Convert.ToInt16(strFoodItemDetail[0]));
                        string strFoodName=Convert.ToString(foodRows[0]["FoodName"]);

                        

                        objMealFoodDetails.ID = Convert.ToInt16(strFoodItemDetail[0]);  //Food ID
                        objMealFoodDetails.Name = strFoodName??string.Empty;
                        objMealFoodDetails.Qty = Convert.ToDouble(strFoodItemDetail[1]); //Food Quantity
                        objMealFoodDetails.Unit = Convert.ToString(strFoodItemDetail[2]); //Measure Unit
                        objMealFoodDetails.Remark = Convert.ToString(strFoodItemDetail[3]); //Food Remark
                        objMealFoodDetails.Energy = Convert.ToDouble(strFoodItemDetail[4]);
                        objMealFoodDetails.Protein = Convert.ToDouble(strFoodItemDetail[5]);
                        objMealFoodDetails.Fat = Convert.ToDouble(strFoodItemDetail[6]);
                        objMealFoodDetails.Fibre = Convert.ToDouble(strFoodItemDetail[7]);


                        lstMealFoodDetails.Add(objMealFoodDetails);
                    }

                    objMealDetails.MealFoodDetails = lstMealFoodDetails;
                    lstMealDetails.Add(objMealDetails);
                }
                objRecommendedDietDetails.MealDetails = lstMealDetails;
                lstRecommendedDietDetails.Add(objRecommendedDietDetails);
            }

            /// Generate HTML for saved Meals Data

            StringBuilder sbSingleRecommendedDietDetailsTemplate = new StringBuilder();



            sbSingleRecommendedDietDetailsTemplate.Append("<div class='form-group' {{ RecallDiet48Hour }}>");
            sbSingleRecommendedDietDetailsTemplate.Append("  <div class='days-block pull-left'>");
            sbSingleRecommendedDietDetailsTemplate.Append("      <table id='diet-table-{{ MealName }}' class='table table-striped'>");
            sbSingleRecommendedDietDetailsTemplate.Append("          <tbody>");
            sbSingleRecommendedDietDetailsTemplate.Append("              <tr>");
            sbSingleRecommendedDietDetailsTemplate.Append("                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                      <label class='label-block control-label text-left' for='txtTimePicker{{ MealName }}'>{{ MealName }}</label>");
            sbSingleRecommendedDietDetailsTemplate.Append("                          <div class='time-block'>");
            sbSingleRecommendedDietDetailsTemplate.Append("                              <div class='input-group bootstrap-timepicker'>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                  <input id='txtTimePicker{{ MealName }}' type='text' class='form-control' value='{{ MealTime }}' />");
            sbSingleRecommendedDietDetailsTemplate.Append("                                      <span class='input-group-addon'>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                          <i class='fa fa-clock-o bigger-110'></i>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                      </span>");
            sbSingleRecommendedDietDetailsTemplate.Append("                              </div>");
            sbSingleRecommendedDietDetailsTemplate.Append("                          </div>");
            sbSingleRecommendedDietDetailsTemplate.Append("                  </td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                      {{ MealDays }}");
            sbSingleRecommendedDietDetailsTemplate.Append("                      <div style='margin-top: 10px;'>");
            sbSingleRecommendedDietDetailsTemplate.Append("                          <table class='table table-bordered table-striped dataTable'>");
            sbSingleRecommendedDietDetailsTemplate.Append("                              <tr>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                      <input type='text' class='FoodItem scrollable typeahead' id='txtFoodItem{{ MealName }}' placeholder='Food' style='min-width: 175px; font-size: 16px;'></td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                      <input type='text' class='FoodQuantity scrollable' id='txtFoodQuantity{{ MealName }}' placeholder='Quantity'></td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                      <input type='text' class='FoodMeasure scrollable typeahead' id='txtFoodMeasure{{ MealName }}' placeholder='Measure' style='min-width: 175px; font-size: 16px;'></td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                      <input type='text' class='FoodRemark scrollable' id='txtFoodRemark{{ MealName }}' placeholder='Remark'></td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                                      <input name='add_button' type='button' id='add_button' value='Add' onclick='addFoodRow(&quot;{{ MealName }}&quot;)' class='btn btn-primary btn-sm' /></td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                              </tr>");
            sbSingleRecommendedDietDetailsTemplate.Append("                          </table>");
            sbSingleRecommendedDietDetailsTemplate.Append("                      </div>");
            sbSingleRecommendedDietDetailsTemplate.Append("                      {{ FoodTable }}");
            sbSingleRecommendedDietDetailsTemplate.Append("                  </td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                      <input type='button' id='btnSave{{ MealName }}' class='btn btn-primary btn-sm' value='Save' onclick='saveMeal(&quot;{{ MealName }}&quot;)'/>");
            sbSingleRecommendedDietDetailsTemplate.Append("                  </td>");
            sbSingleRecommendedDietDetailsTemplate.Append("              </tr>");
            sbSingleRecommendedDietDetailsTemplate.Append("          </tbody>");
            sbSingleRecommendedDietDetailsTemplate.Append("      </table>");
            sbSingleRecommendedDietDetailsTemplate.Append("  </div>");
            sbSingleRecommendedDietDetailsTemplate.Append("</div>");

            string[] RecallDiet48HourMeals = { "Meal7", "Meal8", "Meal9", "Meal10", "Meal11", "Meal12" };
            string roleRecallDiet48Hour;

            foreach (RecommendedDietDetails itemRecommendedDietDetails in lstRecommendedDietDetails)
            {
                StringBuilder sbRecommendedDietDetails = new StringBuilder();
                string mealName = "", mealTime = "", mealDays = "", foodTable = "";

                txtRecallDietNotes.Text = itemRecommendedDietDetails.Notes ?? string.Empty; //Bind Notes Data to textbox


                foreach (MealDetails itemMealDetails in itemRecommendedDietDetails.MealDetails)
                {
                    mealName = itemMealDetails.MealName;
                    mealTime = itemMealDetails.Time.ToString("HH:mm");
                    mealDays = GetDaysTemplateForMeal(mealName, itemMealDetails.Days);

                    if (RecallDiet48HourMeals.Contains(mealName))
                    {
                        roleRecallDiet48Hour = "role='RecallDiet48Hour'";
                    }
                    else
                    {
                        roleRecallDiet48Hour = string.Empty;
                    }

                    int rowCount=100;
                    StringBuilder sbFoodTableRows = new StringBuilder();
                    double[] foodNutrientsTotal = { 0, 0, 0, 0 };
                    foreach (MealFoodDetails itemMealFoodDetails in itemMealDetails.MealFoodDetails)
                    {
                        foodNutrientsTotal[0] += itemMealFoodDetails.Energy;
                        foodNutrientsTotal[1] += itemMealFoodDetails.Protein;
                        foodNutrientsTotal[2] += itemMealFoodDetails.Fat;
                        foodNutrientsTotal[3] += itemMealFoodDetails.Fibre;

                        sbFoodTableRows.Append(GetFoodTableRowTemplate(itemMealFoodDetails, rowCount));
                        rowCount++;
                    }

                    StringBuilder sbFoodTableTemplate = new StringBuilder();

                    sbFoodTableTemplate.Append("<div style='margin-top: 10px;'>");
                    sbFoodTableTemplate.Append("	<table id='tblFoodList{{ MealName }}' class='table table-bordered table-striped dataTable' {{ RecallDiet48Hour }}>");
                    sbFoodTableTemplate.Append("        <thead>");
                    sbFoodTableTemplate.Append("            <tr class='titleRow'>");
                    sbFoodTableTemplate.Append("                <th class='hidden'>FoodID</th>");
                    sbFoodTableTemplate.Append("                <th colspan='2'>Food</th>");
                    sbFoodTableTemplate.Append("                <th>Quantity</th>");
                    sbFoodTableTemplate.Append("                <th>Unit</th>");
                    sbFoodTableTemplate.Append("                <th>Remark</th>");
                    sbFoodTableTemplate.Append("                <th>Energy (kcal)</th>");
                    sbFoodTableTemplate.Append("                <th>Protein (g)</th>");
                    sbFoodTableTemplate.Append("                <th>Fat (g)</th>");
                    sbFoodTableTemplate.Append("                <th>Fibre (mcg)</th>");
                    sbFoodTableTemplate.Append("                <th>Action</th>");
                    sbFoodTableTemplate.Append("            </tr>");
                    sbFoodTableTemplate.Append("        </thead>");
                    sbFoodTableTemplate.Append("        <tbody>");

                    sbFoodTableTemplate.Append(sbFoodTableRows.ToString());

                    sbFoodTableTemplate.Append("        </tbody>");
                    sbFoodTableTemplate.Append("        <tfoot>");
                    sbFoodTableTemplate.Append("            <tr class='totalRow'>");
                    sbFoodTableTemplate.Append("                <td colspan='4'></td>");
                    sbFoodTableTemplate.Append("                <td>Total</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol'>" + foodNutrientsTotal[0] + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol'>" + foodNutrientsTotal[1] + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol'>" + foodNutrientsTotal[2] + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol'>" + foodNutrientsTotal[3] + "</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("            </tr>");
                    sbFoodTableTemplate.Append("        </tfoot>");
                    sbFoodTableTemplate.Append("    </table>");
                    sbFoodTableTemplate.Append("</div>");

                    foodTable = sbFoodTableTemplate.Replace("{{ MealName }}", mealName).ToString();
                    sbRecommendedDietDetails.Append(sbSingleRecommendedDietDetailsTemplate).Replace("{{ MealName }}", mealName).Replace("{{ MealTime }}", mealTime).Replace("{{ MealDays }}", mealDays).Replace("{{ FoodTable }}", foodTable).Replace("{{ RecallDiet48Hour }}", roleRecallDiet48Hour);
                }

                divRecommendedDietMeals.InnerHtml = sbRecommendedDietDetails.ToString();
                break; // Since for single visit
            }


        }

        public string GetDaysTemplateForMeal(string mealName, string delimitarSeperatedDays)
        {
            StringBuilder sbDaysTemplate = new StringBuilder();
            string setSelectedDay="checked";

            sbDaysTemplate.Append("<table>");
            sbDaysTemplate.Append("	<tbody>");
            sbDaysTemplate.Append("		<tr>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_0' type='checkbox' class='ace' value='Monday' " + (delimitarSeperatedDays.Contains('0')?setSelectedDay:string.Empty) + " >");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Monday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_1' type='checkbox' class='ace' value='Tuesday' " + (delimitarSeperatedDays.Contains('1') ? setSelectedDay : string.Empty) + " >");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Tuesday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_2' type='checkbox' class='ace' value='Wednesday' " + (delimitarSeperatedDays.Contains('2') ? setSelectedDay : string.Empty) + " >");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Wednesday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_3' type='checkbox' class='ace' value='Thursday' " + (delimitarSeperatedDays.Contains('3') ? setSelectedDay : string.Empty) + " >");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Thursday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_4' type='checkbox' class='ace' value='Friday' " + (delimitarSeperatedDays.Contains('4') ? setSelectedDay : string.Empty) + " >");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Friday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_5' type='checkbox' class='ace' value='Saturday' " + (delimitarSeperatedDays.Contains('5') ? setSelectedDay : string.Empty) + " >");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Saturday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_6' type='checkbox' class='ace' value='Sunday' " + (delimitarSeperatedDays.Contains('6') ? setSelectedDay : string.Empty) + " >");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Sunday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("		</tr>");
            sbDaysTemplate.Append("	</tbody>");
            sbDaysTemplate.Append("</table>");

            return sbDaysTemplate.Replace("{{ MealName }}", mealName).ToString();
        }

        public string GetFoodTableRowTemplate(MealFoodDetails mealFoodDetails,int itemCount)
        {
            StringBuilder sbFoodTableRow = new StringBuilder();
            
            sbFoodTableRow.Append("<tr id='tr" + itemCount + "'>");
            sbFoodTableRow.Append("	<td class='mealInput hidden'>" + mealFoodDetails.ID + "</td>");
            sbFoodTableRow.Append("	<td colspan='2'>" + mealFoodDetails.Name + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput'>" + mealFoodDetails.Qty + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput'>" + mealFoodDetails.Unit + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput'>" + mealFoodDetails.Remark + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Energy + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Protein + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Fat + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Fibre + "</td>");
            sbFoodTableRow.Append("	<td class='action'><input type='button'  id='" + itemCount + "' value='remove' onclick='removeFoodRow(&quot;{{ MealName }}&quot;,this)'></td>");
            sbFoodTableRow.Append("</tr>");
            return sbFoodTableRow.ToString();
        }
        

        [System.Web.Services.WebMethod]
        public static Object GetFoodData(string ClientID)
        {
            DataTable dtFoodList = new DataTable();

            //BusinessHelper<IFoodMaster>.Use(FoodMasterManager =>
            //{
            //    dtFoodList = FoodMasterManager.GetFoodList();
            //});

            dtFoodList = new FoodMasterManager().GetFoodList();

            DataTable dtFoodUnitList = new DataTable();

            //BusinessHelper<IFoodMaster>.Use(FoodMasterManager =>
            //{
            //    dtFoodUnitList = FoodMasterManager.GetFoodUnitList();
            //});
            dtFoodUnitList = new FoodMasterManager().GetFoodUnitList();

            string[] foods = dtFoodList.Rows[0][0].ToString().Split('~');
            string[] units = dtFoodUnitList.Rows[0][0].ToString().Split(',');
            FoodData objFoodData = new FoodData();
            objFoodData.foodNames = foods;
            objFoodData.foodUnits = units;
            return objFoodData;
            //return new Object();
        }

        [System.Web.Services.WebMethod]
        public static Object GetFoodNutrients(string FoodName, string foodQuantity, string foodUnit)
        {
            double foodQty = Convert.ToDouble(foodQuantity==string.Empty?"0":foodQuantity);
            DataTable dtFoodNutrients = new DataTable();

            BusinessHelper<IFoodMaster>.Use(FoodMasterManager =>
            {
                dtFoodNutrients = FoodMasterManager.GetFoodMajorNutrients(FoodName, foodQty, foodUnit);
            });

            FoodMajorNutrients objFoodNutrients = new FoodMajorNutrients();
            objFoodNutrients.foodID = dtFoodNutrients.Rows[0]["FoodID"].ToString();
            objFoodNutrients.foodName = dtFoodNutrients.Rows[0]["FoodName"].ToString();
            objFoodNutrients.energy = dtFoodNutrients.Rows[0]["Energy"].ToString();
            objFoodNutrients.protein = dtFoodNutrients.Rows[0]["Protein"].ToString();
            objFoodNutrients.fat = dtFoodNutrients.Rows[0]["Fat"].ToString();
            objFoodNutrients.fibre = dtFoodNutrients.Rows[0]["Fibre"].ToString();

            return objFoodNutrients;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static Object SaveRecommendedSingleMealDetails(string MealID, string MealDays, string MealData, string MealTime, string Notes)
        {

            int clientID = Convert.ToInt32(HttpContext.Current.Session["PatientID"]);
            //DateTime mealTime=Convert.ToDateTime(MealTime);
            DateTime mealTime = Convert.ToDateTime(MealTime.ToString());
            int rowsAffected;

            //BusinessHelper<IRecommendedDiet>.Use(RecommendedDietManager =>
            //{
            //    rowsAffected = RecommendedDietManager.SaveSingleMealDetails(clientID, MealID, MealDays, MealData, mealTime, Notes);
            //});
            rowsAffected = new RecommendedDietManager().SaveRecommendedSingleMealDetails(clientID, MealID, MealDays, MealData, mealTime, Notes);
            
            
            return new Object();
        }
    }
}