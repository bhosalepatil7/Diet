﻿using System;
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

namespace GNHClientUI
{
    public partial class DietHelper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            double foodQty = Convert.ToDouble(foodQuantity == string.Empty ? "0" : foodQuantity);
            DataTable dtFoodNutrients = new DataTable();

            //BusinessHelper<IFoodMaster>.Use(FoodMasterManager =>
            //{
            //dtFoodNutrients = FoodMasterManager.GetFoodMajorNutrients(FoodName, foodQty, foodUnit);

            dtFoodNutrients = new FoodMasterManager().GetFoodMajorNutrients(FoodName, foodQty, foodUnit);
            //});

            FoodMajorNutrients objFoodNutrients = new FoodMajorNutrients();

            if (dtFoodNutrients.Rows.Count > 0)
            {
                objFoodNutrients.foodID = dtFoodNutrients.Rows[0]["FoodID"].ToString();
                objFoodNutrients.foodName = dtFoodNutrients.Rows[0]["FoodName"].ToString();
                objFoodNutrients.energy = dtFoodNutrients.Rows[0]["Energy"].ToString();
                objFoodNutrients.protein = dtFoodNutrients.Rows[0]["Protein"].ToString();
                objFoodNutrients.fat = dtFoodNutrients.Rows[0]["Fat"].ToString();
                objFoodNutrients.fibre = dtFoodNutrients.Rows[0]["Fibre"].ToString();
                objFoodNutrients.carbs = dtFoodNutrients.Rows[0]["Carbs"].ToString();
            }
            else
            {
                objFoodNutrients.foodID = "-1"; //Food doesn't exist
            }


            return objFoodNutrients;
        }

        //Recall Diet Save
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static Object SaveSingleMealDetails(string MealID, string MealDays, string MealData, string MealTime, string Notes)
        {

            int clientID = Convert.ToInt32(HttpContext.Current.Session["PatientID"]);
            //DateTime mealTime=Convert.ToDateTime(MealTime);
            DateTime mealTime = Convert.ToDateTime(MealTime.ToString());
            int rowsAffected;

            //BusinessHelper<IRecallDiet>.Use(RecallDietManager =>
            //{
            //    rowsAffected = RecallDietManager.SaveSingleMealDetails(clientID, MealID, MealDays, MealData, mealTime, Notes);
            //});
            rowsAffected = new RecallDietManager().SaveSingleMealDetails(clientID, MealID, MealDays, MealData, mealTime, Notes);



            return new Object();
        }

        //Recommended Diet Save
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

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string[] GetRecommendedDietDetails()
        {
            return getRecommendedDiet();
        }

        public static string GetDaysTemplateForMealRecommended(string mealName, string delimitarSeperatedDays)
        {
            StringBuilder sbDaysTemplate = new StringBuilder();

            sbDaysTemplate.Append("<table>");
            sbDaysTemplate.Append("	<tbody>");
            sbDaysTemplate.Append("		<tr>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_0' type='checkbox' class='ace' value='Monday' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Monday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_1' type='checkbox' class='ace' value='Tuesday' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Tuesday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_2' type='checkbox' class='ace' value='Wednesday' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Wednesday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_3' type='checkbox' class='ace' value='Thursday' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Thursday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_4' type='checkbox' class='ace' value='Friday' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Friday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_5' type='checkbox' class='ace' value='Saturday' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)'>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Saturday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_6' type='checkbox' class='ace' value='Sunday' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)'>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Sunday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkAlldays{{ MealName }}' type='checkbox' class='ace' value='Alldays' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)'>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;All Days</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkWeekdays{{ MealName }}' type='checkbox' class='ace' value='Weekdays' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Week Days</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkWeekend{{ MealName }}' type='checkbox' class='ace' value='Weekend' onchange='selectRecommendedDays(this,&quot;{{ MealName }}&quot;)''>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Week End</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("		</tr>");
            sbDaysTemplate.Append("	</tbody>");
            sbDaysTemplate.Append("</table>");

            return sbDaysTemplate.Replace("{{ MealName }}", mealName).ToString();
        }

        public static string GetDaysTemplateForMealRecall(string mealName, string delimitarSeperatedDays)
        {
            StringBuilder sbDaysTemplate = new StringBuilder();

            sbDaysTemplate.Append("<table>");
            sbDaysTemplate.Append("	<tbody>");
            sbDaysTemplate.Append("		<tr>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_0' type='checkbox' class='ace' value='Monday' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Monday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_1' type='checkbox' class='ace' value='Tuesday' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Tuesday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_2' type='checkbox' class='ace' value='Wednesday' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Wednesday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_3' type='checkbox' class='ace' value='Thursday' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Thursday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_4' type='checkbox' class='ace' value='Friday' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Friday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_5' type='checkbox' class='ace' value='Saturday' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)'>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Saturday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkDays{{ MealName }}_6' type='checkbox' class='ace' value='Sunday' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)'>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Sunday</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkAlldays{{ MealName }}' type='checkbox' class='ace' value='Alldays' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)'>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;All Days</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkWeekdays{{ MealName }}' type='checkbox' class='ace' value='Weekdays' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)' checked>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Week Days</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("			<td>");
            sbDaysTemplate.Append("				<div class='checkbox'>");
            sbDaysTemplate.Append("					<label>");
            sbDaysTemplate.Append("						<input id='chkWeekend{{ MealName }}' type='checkbox' class='ace' value='Weekend' onchange='selectRecallDays(this,&quot;{{ MealName }}&quot;)''>");
            sbDaysTemplate.Append("						<span class='lbl'>&nbsp;Week End</span>");
            sbDaysTemplate.Append("					</label>");
            sbDaysTemplate.Append("				</div>");
            sbDaysTemplate.Append("			</td>");
            sbDaysTemplate.Append("		</tr>");
            sbDaysTemplate.Append("	</tbody>");
            sbDaysTemplate.Append("</table>");

            return sbDaysTemplate.Replace("{{ MealName }}", mealName).ToString();
        }
        public static string GetFoodTableRowTemplate(MealFoodDetails mealFoodDetails, int itemCount)
        {
            StringBuilder sbFoodTableRow = new StringBuilder();

            sbFoodTableRow.Append("<tr id='tr" + itemCount + "'>");
            sbFoodTableRow.Append("	<td class='mealInput hidden'>" + mealFoodDetails.ID + "</td>");
            sbFoodTableRow.Append("	<td colspan='2' class='editable'>" + mealFoodDetails.Name + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput editable'>" + mealFoodDetails.Qty + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput editable'>" + mealFoodDetails.Unit + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput editable'>" + mealFoodDetails.Remark + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Energy + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Protein + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Fat + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Fibre + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Carbs + "</td>");

            sbFoodTableRow.Append("	<td class='mealInput editable'>" + GetFoodConsumptionDaysRowTemplate(mealFoodDetails.ConsumptionDays ?? "1110001") + "</td>");

            sbFoodTableRow.Append("	<td class='action'>");
            sbFoodTableRow.Append("	    <div class='displayInlineFlex'>");
            sbFoodTableRow.Append("	        <button type='button' id='btnEditFoodRow" + itemCount + "' onclick='editRecommendedFoodRow(&quot;{{ MealName }}&quot;,this)'> <i class='fa fa-pencil fa-fw'></i> </button>");
            sbFoodTableRow.Append("	        <button type='button' id='btnRemoveFoodRow" + itemCount + "' onclick='removeRecommendedFoodRow(&quot;{{ MealName }}&quot;,this)'> <i class='fa fa-trash-o fa-fw'></i> </button");
            sbFoodTableRow.Append("	    </div>");
            sbFoodTableRow.Append("	 </td>");
            sbFoodTableRow.Append("</tr>");
            return sbFoodTableRow.ToString();
        }

        public static string GetFoodTableRowTemplateRecall(MealFoodDetails mealFoodDetails, int itemCount)
        {
            StringBuilder sbFoodTableRow = new StringBuilder();

            sbFoodTableRow.Append("<tr id='tr" + itemCount + "'>");
            sbFoodTableRow.Append("	<td class='mealInput hidden'>" + mealFoodDetails.ID + "</td>");
            sbFoodTableRow.Append("	<td colspan='2' class='editable'>" + mealFoodDetails.Name + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput editable'>" + mealFoodDetails.Qty + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput editable'>" + mealFoodDetails.Unit + "</td>");
            sbFoodTableRow.Append("	<td class='mealInput editable'>" + mealFoodDetails.Remark + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Energy + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Protein + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Fat + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Fibre + "</td>");
            sbFoodTableRow.Append("	<td class='rowDataSd mealInput'>" + mealFoodDetails.Carbs + "</td>");

            sbFoodTableRow.Append("	<td class='mealInput editable'>" + GetFoodConsumptionDaysRowTemplate(mealFoodDetails.ConsumptionDays ?? "1110001") + "</td>");

            sbFoodTableRow.Append("	<td class='action'>");
            sbFoodTableRow.Append("	    <div class='displayInlineFlex'>");
            sbFoodTableRow.Append("	        <button type='button' id='btnEditFoodRow" + itemCount + "' onclick='editFoodRow(&quot;{{ MealName }}&quot;,this)'> <i class='fa fa-pencil fa-fw'></i> </button>");
            sbFoodTableRow.Append("	        <button type='button' id='btnRemoveFoodRow" + itemCount + "' onclick='removeFoodRow(&quot;{{ MealName }}&quot;,this)'> <i class='fa fa-trash-o fa-fw'></i> </button");
            sbFoodTableRow.Append("	    </div>");
            sbFoodTableRow.Append("	 </td>");
            sbFoodTableRow.Append("</tr>");
            return sbFoodTableRow.ToString();
        }

        public static string GetFoodConsumptionDaysRowTemplate(string foodConsumptionDaysBits)
        {
            StringBuilder sbFoodConsumptionDaysRow = new StringBuilder();
            string tempActive = string.Empty;

            sbFoodConsumptionDaysRow.Append(" <div class='displayInlineFlex' data-food-consumption-days='" + foodConsumptionDaysBits + "' >");

            sbFoodConsumptionDaysRow.Append("<span class='" + ((foodConsumptionDaysBits.Substring(0, 1) == "1") ? "activeDay" : "inactiveDay") + "'>M</span>");
            sbFoodConsumptionDaysRow.Append("<span class='" + ((foodConsumptionDaysBits.Substring(1, 1) == "1") ? "activeDay" : "inactiveDay") + "'>T</span>");
            sbFoodConsumptionDaysRow.Append("<span class='" + ((foodConsumptionDaysBits.Substring(2, 1) == "1") ? "activeDay" : "inactiveDay") + "'>W</span>");
            sbFoodConsumptionDaysRow.Append("<span class='" + ((foodConsumptionDaysBits.Substring(3, 1) == "1") ? "activeDay" : "inactiveDay") + "'>T</span>");
            sbFoodConsumptionDaysRow.Append("<span class='" + ((foodConsumptionDaysBits.Substring(4, 1) == "1") ? "activeDay" : "inactiveDay") + "'>F</span>");
            sbFoodConsumptionDaysRow.Append("<span class='" + ((foodConsumptionDaysBits.Substring(5, 1) == "1") ? "activeDay" : "inactiveDay") + "'>S</span>");
            sbFoodConsumptionDaysRow.Append("<span class='" + ((foodConsumptionDaysBits.Substring(6, 1) == "1") ? "activeDay" : "inactiveDay") + "'>S</span>");


            sbFoodConsumptionDaysRow.Append(" </div>");
            return sbFoodConsumptionDaysRow.ToString();
        }

        private static string[] getRecommendedDiet()
        {
            string[] result = null;
            //Get Food Names with FoodID

            //BusinessHelper<IFoodMaster>.Use(FoodMasterManager =>
            //{
            //    dtFoodListWithID = FoodMasterManager.GetFoodListWithID();
            //});

            DataTable dtFoodListWithID = new DataTable();
            dtFoodListWithID = new FoodMasterManager().GetFoodListWithID();

            //Get Customer Recommended Diet Details
            int custID = Convert.ToInt32(HttpContext.Current.Session["PatientID"]);

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

                        var foodRows = dtFoodListWithID.Select("FoodID = " + Convert.ToInt16(strFoodItemDetail[0]));
                        string strFoodName = Convert.ToString(foodRows[0]["FoodName"]);



                        objMealFoodDetails.ID = Convert.ToInt16(strFoodItemDetail[0]);  //Food ID
                        objMealFoodDetails.Name = strFoodName ?? string.Empty;
                        objMealFoodDetails.Qty = Convert.ToDouble(strFoodItemDetail[1]); //Food Quantity
                        objMealFoodDetails.Unit = Convert.ToString(strFoodItemDetail[2]); //Measure Unit
                        objMealFoodDetails.Remark = Convert.ToString(strFoodItemDetail[3]); //Food Remark
                        objMealFoodDetails.Energy = Convert.ToDouble(strFoodItemDetail[4]);
                        objMealFoodDetails.Protein = Convert.ToDouble(strFoodItemDetail[5]);
                        objMealFoodDetails.Fat = Convert.ToDouble(strFoodItemDetail[6]);
                        objMealFoodDetails.Fibre = Convert.ToDouble(strFoodItemDetail[7]);
                        objMealFoodDetails.Carbs = Convert.ToDouble(strFoodItemDetail[8]);
                        objMealFoodDetails.ConsumptionDays = Convert.ToString(strFoodItemDetail[9]); //Food Consumption Bits


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
            sbSingleRecommendedDietDetailsTemplate.Append("                                  <input id='txtTimePicker{{ MealName }}' type='text' class='form-control' value='{{ MealTime }}' data-meal-name ='{{ MealName }}' data-meal-time ='{{ MealTime }}' />");
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
            sbSingleRecommendedDietDetailsTemplate.Append("                                      <input name='add_button' type='button' id='add_button' value='Add' onclick='addRecommendedFoodRow(&quot;{{ MealName }}&quot;)' class='btn btn-primary btn-sm' /></td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                              </tr>");
            sbSingleRecommendedDietDetailsTemplate.Append("                          </table>");
            sbSingleRecommendedDietDetailsTemplate.Append("                      </div>");
            sbSingleRecommendedDietDetailsTemplate.Append("                      {{ FoodTable }}");
            sbSingleRecommendedDietDetailsTemplate.Append("                  </td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                  <td>");
            sbSingleRecommendedDietDetailsTemplate.Append("                      <input type='button' id='btnSave{{ MealName }}' class='btn btn-primary btn-sm hidden' value='Save' onclick='saveRecommendedDietMeal(&quot;{{ MealName }}&quot;)'/>");
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




                foreach (MealDetails itemMealDetails in itemRecommendedDietDetails.MealDetails)
                {
                    mealName = itemMealDetails.MealName;
                    mealTime = itemMealDetails.Time.ToString("HH:mm");
                    mealDays = GetDaysTemplateForMealRecommended(mealName, itemMealDetails.Days);

                    if (RecallDiet48HourMeals.Contains(mealName))
                    {
                        roleRecallDiet48Hour = "role='RecallDiet48Hour'";
                    }
                    else
                    {
                        roleRecallDiet48Hour = string.Empty;
                    }

                    int rowCount = 100;
                    StringBuilder sbFoodTableRows = new StringBuilder();
                    double[] foodNutrientsWeekTotal = { 0, 0, 0, 0, 0 }; //sequence is Energy,Protein,Fat,Fibre,Carbs
                    double[] foodNutrientsWeekdayTotal = { 0, 0, 0, 0, 0 }; //sequence is Energy,Protein,Fat,Fibre,Carbs
                    double[] foodNutrientsWeekendTotal = { 0, 0, 0, 0, 0 }; //sequence is Energy,Protein,Fat,Fibre,Carbs

                    foreach (MealFoodDetails itemMealFoodDetails in itemMealDetails.MealFoodDetails)
                    {
                        var tmpConsumptionDays = itemMealFoodDetails.ConsumptionDays.ToCharArray();

                        //Calculating day wise total
                        for (int i = 0; i <= 6; i++)
                        {
                            //week total
                            if (tmpConsumptionDays[i] == '1')
                            {
                                foodNutrientsWeekTotal[0] += itemMealFoodDetails.Energy;
                                foodNutrientsWeekTotal[1] += itemMealFoodDetails.Protein;
                                foodNutrientsWeekTotal[2] += itemMealFoodDetails.Fat;
                                foodNutrientsWeekTotal[3] += itemMealFoodDetails.Fibre;
                                foodNutrientsWeekTotal[4] += itemMealFoodDetails.Carbs;
                            }

                            //weekday total
                            if (tmpConsumptionDays[i] == '1' && i <= 4)
                            {
                                foodNutrientsWeekdayTotal[0] += itemMealFoodDetails.Energy;
                                foodNutrientsWeekdayTotal[1] += itemMealFoodDetails.Protein;
                                foodNutrientsWeekdayTotal[2] += itemMealFoodDetails.Fat;
                                foodNutrientsWeekdayTotal[3] += itemMealFoodDetails.Fibre;
                                foodNutrientsWeekdayTotal[4] += itemMealFoodDetails.Carbs;
                            }

                            //weekend total
                            if (tmpConsumptionDays[i] == '1' && i > 4)
                            {
                                foodNutrientsWeekendTotal[0] += itemMealFoodDetails.Energy;
                                foodNutrientsWeekendTotal[1] += itemMealFoodDetails.Protein;
                                foodNutrientsWeekendTotal[2] += itemMealFoodDetails.Fat;
                                foodNutrientsWeekendTotal[3] += itemMealFoodDetails.Fibre;
                                foodNutrientsWeekendTotal[4] += itemMealFoodDetails.Carbs;
                            }
                        }


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
                    sbFoodTableTemplate.Append("                <th>Carbs (g)</th>");
                    sbFoodTableTemplate.Append("                <th>Consumption days</th>");
                    sbFoodTableTemplate.Append("                <th>Action</th>");
                    sbFoodTableTemplate.Append("            </tr>");
                    sbFoodTableTemplate.Append("        </thead>");
                    sbFoodTableTemplate.Append("        <tbody>");

                    sbFoodTableTemplate.Append(sbFoodTableRows.ToString());

                    sbFoodTableTemplate.Append("        </tbody>");
                    sbFoodTableTemplate.Append("        <tfoot>");

                    //week average
                    sbFoodTableTemplate.Append("            <tr class='totalRow'>");
                    sbFoodTableTemplate.Append("                <td colspan='2'></td>");
                    sbFoodTableTemplate.Append("                <td colspan='3'>Average for week</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[0] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[1] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[2] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[3] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[4] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("            </tr>");

                    //week day average
                    sbFoodTableTemplate.Append("            <tr class='totalRow'>");
                    sbFoodTableTemplate.Append("                <td colspan='2'></td>");
                    sbFoodTableTemplate.Append("                <td colspan='3'>Average for weekdays</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[0] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[1] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[2] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[3] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[4] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("            </tr>");

                    //weekend average
                    sbFoodTableTemplate.Append("            <tr class='totalRow'>");
                    sbFoodTableTemplate.Append("                <td colspan='2'></td>");
                    sbFoodTableTemplate.Append("                <td colspan='3'>Average for weekends</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[0] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[1] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[2] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[3] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[4] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("            </tr>");

                    sbFoodTableTemplate.Append("        </tfoot>");
                    sbFoodTableTemplate.Append("    </table>");
                    sbFoodTableTemplate.Append("</div>");

                    foodTable = sbFoodTableTemplate.Replace("{{ MealName }}", mealName).ToString();
                    sbRecommendedDietDetails.Append(sbSingleRecommendedDietDetailsTemplate).Replace("{{ MealName }}", mealName).Replace("{{ MealTime }}", mealTime).Replace("{{ MealDays }}", mealDays).Replace("{{ FoodTable }}", foodTable).Replace("{{ RecallDiet48Hour }}", roleRecallDiet48Hour);
                }

                //divRecommendedDietMeals.InnerHtml = sbRecommendedDietDetails.ToString();
                //txtRecallDietNotes.Text = itemRecommendedDietDetails.Notes ?? string.Empty; //Bind Notes Data to textbox
                result = new string[] { sbRecommendedDietDetails.ToString(), itemRecommendedDietDetails.Notes ?? string.Empty };
                break; // Since for single visit
            }

            return result;

        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string[] GetRecallDietDetails()
        {
            return getRecallDiet();
        }

        private static string[] getRecallDiet()
        {
            string[] result = null;
            //Get Food Names with FoodID

            //BusinessHelper<IFoodMaster>.Use(FoodMasterManager =>
            //{
            //    dtFoodListWithID = FoodMasterManager.GetFoodListWithID();
            //});

            DataTable dtFoodListWithID = new DataTable();
            dtFoodListWithID = new FoodMasterManager().GetFoodListWithID();

            //Get Customer Recall Diet Details
            int custID = Convert.ToInt32(HttpContext.Current.Session["PatientID"]);

            DataTable dtRecallDietDetail = new DataTable();

            //BusinessHelper<IRecallDiet>.Use(RecallDietManager =>
            //{
            //    dtRecallDietDetail = RecallDietManager.GetRecallDietDetails(custID);
            //});
            dtRecallDietDetail = new RecallDietManager().GetRecallDietDetails(custID);

            List<RecallDietDetails> lstRecallDietDetails = new List<RecallDietDetails>();

            foreach (DataRow drRecallDiet in dtRecallDietDetail.Rows)
            {
                RecallDietDetails objRecallDietDetails = new RecallDietDetails();

                objRecallDietDetails.CustomerID = custID;
                objRecallDietDetails.VisitDate = Convert.ToDateTime(drRecallDiet["VisitDate"]);
                objRecallDietDetails.Notes = Convert.ToString(drRecallDiet["Notes"]);

                List<MealDetails> lstMealDetails = new List<MealDetails>();

                for (int mealID = 1; mealID <= 12; mealID++)
                {
                    string mealName = "Meal" + mealID;
                    string[] mealDetailSeperatingChars = { "@@" };
                    char[] mealFoodItemSeperatingChars = { '~' };
                    char[] mealFoodItemDetailSeperatingChars = { '|' };


                    string[] strMealDetails = Convert.ToString(drRecallDiet[mealName]).Split(mealDetailSeperatingChars, StringSplitOptions.None);

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

                        var foodRows = dtFoodListWithID.Select("FoodID = " + Convert.ToInt16(strFoodItemDetail[0]));
                        string strFoodName = Convert.ToString(foodRows[0]["FoodName"]);



                        objMealFoodDetails.ID = Convert.ToInt16(strFoodItemDetail[0]);  //Food ID
                        objMealFoodDetails.Name = strFoodName ?? string.Empty;
                        objMealFoodDetails.Qty = Convert.ToDouble(strFoodItemDetail[1]); //Food Quantity
                        objMealFoodDetails.Unit = Convert.ToString(strFoodItemDetail[2]); //Measure Unit
                        objMealFoodDetails.Remark = Convert.ToString(strFoodItemDetail[3]); //Food Remark
                        objMealFoodDetails.Energy = Convert.ToDouble(strFoodItemDetail[4]);
                        objMealFoodDetails.Protein = Convert.ToDouble(strFoodItemDetail[5]);
                        objMealFoodDetails.Fat = Convert.ToDouble(strFoodItemDetail[6]);
                        objMealFoodDetails.Fibre = Convert.ToDouble(strFoodItemDetail[7]);
                        objMealFoodDetails.Carbs = Convert.ToDouble(strFoodItemDetail[8]);
                        objMealFoodDetails.ConsumptionDays = Convert.ToString(strFoodItemDetail[9]); //Food Consumption Bits


                        lstMealFoodDetails.Add(objMealFoodDetails);
                    }

                    objMealDetails.MealFoodDetails = lstMealFoodDetails;
                    lstMealDetails.Add(objMealDetails);
                }
                objRecallDietDetails.MealDetails = lstMealDetails;
                lstRecallDietDetails.Add(objRecallDietDetails);
            }

            /// Generate HTML for saved Meals Data

            StringBuilder sbSingleRecallDietDetailsTemplate = new StringBuilder();



            sbSingleRecallDietDetailsTemplate.Append("<div class='form-group' {{ RecallDiet48Hour }}>");
            sbSingleRecallDietDetailsTemplate.Append("  <div class='days-block pull-left'>");
            sbSingleRecallDietDetailsTemplate.Append("      <table id='diet-table-{{ MealName }}' class='table table-striped'>");
            sbSingleRecallDietDetailsTemplate.Append("          <tbody>");
            sbSingleRecallDietDetailsTemplate.Append("              <tr>");
            sbSingleRecallDietDetailsTemplate.Append("                  <td>");
            sbSingleRecallDietDetailsTemplate.Append("                      <label class='label-block control-label text-left' for='txtTimePicker{{ MealName }}'>{{ MealName }}</label>");
            sbSingleRecallDietDetailsTemplate.Append("                          <div class='time-block'>");
            sbSingleRecallDietDetailsTemplate.Append("                              <div class='input-group bootstrap-timepicker'>");
            sbSingleRecallDietDetailsTemplate.Append("                                  <input id='txtTimePicker{{ MealName }}' type='text' class='form-control' value='{{ MealTime }}' data-meal-name ='{{ MealName }}' data-meal-time ='{{ MealTime }}'  />");
            sbSingleRecallDietDetailsTemplate.Append("                                      <span class='input-group-addon'>");
            sbSingleRecallDietDetailsTemplate.Append("                                          <i class='fa fa-clock-o bigger-110'></i>");
            sbSingleRecallDietDetailsTemplate.Append("                                      </span>");
            sbSingleRecallDietDetailsTemplate.Append("                              </div>");
            sbSingleRecallDietDetailsTemplate.Append("                          </div>");
            sbSingleRecallDietDetailsTemplate.Append("                  </td>");
            sbSingleRecallDietDetailsTemplate.Append("                  <td>");
            sbSingleRecallDietDetailsTemplate.Append("                      {{ MealDays }}");
            sbSingleRecallDietDetailsTemplate.Append("                      <div style='margin-top: 10px;'>");

            sbSingleRecallDietDetailsTemplate.Append("                          <table class='table table-bordered table-striped dataTable'>");
            sbSingleRecallDietDetailsTemplate.Append("                              <tr>");
            sbSingleRecallDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecallDietDetailsTemplate.Append("                                      <input type='text' class='FoodItem scrollable typeahead' id='txtFoodItem{{ MealName }}' placeholder='Food' style='min-width: 175px; font-size: 16px;'></td>");
            sbSingleRecallDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecallDietDetailsTemplate.Append("                                      <input type='text' class='FoodQuantity scrollable' id='txtFoodQuantity{{ MealName }}' placeholder='Quantity'></td>");
            sbSingleRecallDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecallDietDetailsTemplate.Append("                                      <input type='text' class='FoodMeasure scrollable typeahead' id='txtFoodMeasure{{ MealName }}' placeholder='Measure' style='min-width: 175px; font-size: 16px;'></td>");
            sbSingleRecallDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecallDietDetailsTemplate.Append("                                      <input type='text' class='FoodRemark scrollable' id='txtFoodRemark{{ MealName }}' placeholder='Remark'></td>");
            sbSingleRecallDietDetailsTemplate.Append("                                  <td>");
            sbSingleRecallDietDetailsTemplate.Append("                                      <input name='add_button' type='button' id='add_button' value='Add' onclick='addFoodRow(&quot;{{ MealName }}&quot;)' class='btn btn-primary btn-sm' /></td>");
            sbSingleRecallDietDetailsTemplate.Append("                              </tr>");
            sbSingleRecallDietDetailsTemplate.Append("                          </table>");
            sbSingleRecallDietDetailsTemplate.Append("                      </div>");
            sbSingleRecallDietDetailsTemplate.Append("                      {{ FoodTable }}");
            sbSingleRecallDietDetailsTemplate.Append("                  </td>");
            sbSingleRecallDietDetailsTemplate.Append("                  <td>");
            sbSingleRecallDietDetailsTemplate.Append("                      <input type='button' id='btnSave{{ MealName }}' class='btn btn-primary btn-sm hidden' value='Save' onclick='saveMeal(&quot;{{ MealName }}&quot;)'/>");
            sbSingleRecallDietDetailsTemplate.Append("                  </td>");
            sbSingleRecallDietDetailsTemplate.Append("              </tr>");
            sbSingleRecallDietDetailsTemplate.Append("          </tbody>");
            sbSingleRecallDietDetailsTemplate.Append("      </table>");
            sbSingleRecallDietDetailsTemplate.Append("  </div>");
            sbSingleRecallDietDetailsTemplate.Append("</div>");

            string[] RecallDiet48HourMeals = { "Meal7", "Meal8", "Meal9", "Meal10", "Meal11", "Meal12" };
            string roleRecallDiet48Hour;

            foreach (RecallDietDetails itemRecallDietDetails in lstRecallDietDetails)
            {
                StringBuilder sbRecallDietDetails = new StringBuilder();
                string mealName = "", mealTime = "", mealDays = "", foodTable = "";




                foreach (MealDetails itemMealDetails in itemRecallDietDetails.MealDetails)
                {
                    mealName = itemMealDetails.MealName;
                    mealTime = itemMealDetails.Time.ToString("H:mm");
                    mealDays = GetDaysTemplateForMealRecall(mealName, itemMealDetails.Days);

                    if (RecallDiet48HourMeals.Contains(mealName))
                    {
                        roleRecallDiet48Hour = "role='RecallDiet48Hour'";
                    }
                    else
                    {
                        roleRecallDiet48Hour = string.Empty;
                    }

                    int rowCount = 100;
                    StringBuilder sbFoodTableRows = new StringBuilder();
                    double[] foodNutrientsWeekTotal = { 0, 0, 0, 0, 0 }; //sequence is Energy,Protein,Fat,Fibre,Carbs
                    double[] foodNutrientsWeekdayTotal = { 0, 0, 0, 0, 0 }; //sequence is Energy,Protein,Fat,Fibre,Carbs
                    double[] foodNutrientsWeekendTotal = { 0, 0, 0, 0, 0 }; //sequence is Energy,Protein,Fat,Fibre,Carbs

                    foreach (MealFoodDetails itemMealFoodDetails in itemMealDetails.MealFoodDetails)
                    {
                        var tmpConsumptionDays = itemMealFoodDetails.ConsumptionDays.ToCharArray();

                        //Calculating day wise total
                        for (int i = 0; i <= 6; i++)
                        {
                            //week total
                            if (tmpConsumptionDays[i] == '1')
                            {
                                foodNutrientsWeekTotal[0] += itemMealFoodDetails.Energy;
                                foodNutrientsWeekTotal[1] += itemMealFoodDetails.Protein;
                                foodNutrientsWeekTotal[2] += itemMealFoodDetails.Fat;
                                foodNutrientsWeekTotal[3] += itemMealFoodDetails.Fibre;
                                foodNutrientsWeekTotal[4] += itemMealFoodDetails.Carbs;
                            }

                            //weekday total
                            if (tmpConsumptionDays[i] == '1' && i <= 4)
                            {
                                foodNutrientsWeekdayTotal[0] += itemMealFoodDetails.Energy;
                                foodNutrientsWeekdayTotal[1] += itemMealFoodDetails.Protein;
                                foodNutrientsWeekdayTotal[2] += itemMealFoodDetails.Fat;
                                foodNutrientsWeekdayTotal[3] += itemMealFoodDetails.Fibre;
                                foodNutrientsWeekdayTotal[4] += itemMealFoodDetails.Carbs;
                            }

                            //weekend total
                            if (tmpConsumptionDays[i] == '1' && i > 4)
                            {
                                foodNutrientsWeekendTotal[0] += itemMealFoodDetails.Energy;
                                foodNutrientsWeekendTotal[1] += itemMealFoodDetails.Protein;
                                foodNutrientsWeekendTotal[2] += itemMealFoodDetails.Fat;
                                foodNutrientsWeekendTotal[3] += itemMealFoodDetails.Fibre;
                                foodNutrientsWeekendTotal[4] += itemMealFoodDetails.Carbs;
                            }
                        }


                        sbFoodTableRows.Append(GetFoodTableRowTemplateRecall(itemMealFoodDetails, rowCount));
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
                    sbFoodTableTemplate.Append("                <th>Carbs (g)</th>");
                    sbFoodTableTemplate.Append("                <th>Consumption days</th>");
                    sbFoodTableTemplate.Append("                <th>Action</th>");
                    sbFoodTableTemplate.Append("            </tr>");
                    sbFoodTableTemplate.Append("        </thead>");
                    sbFoodTableTemplate.Append("        <tbody>");

                    sbFoodTableTemplate.Append(sbFoodTableRows.ToString());

                    sbFoodTableTemplate.Append("        </tbody>");
                    sbFoodTableTemplate.Append("        <tfoot>");

                    //week average
                    sbFoodTableTemplate.Append("            <tr class='totalRow'>");
                    sbFoodTableTemplate.Append("                <td colspan='2'></td>");
                    sbFoodTableTemplate.Append("                <td colspan='3'>Average for week</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[0] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[1] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[2] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[3] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol week'>" + Math.Round((foodNutrientsWeekTotal[4] / 7), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("            </tr>");

                    //week day average
                    sbFoodTableTemplate.Append("            <tr class='totalRow'>");
                    sbFoodTableTemplate.Append("                <td colspan='2'></td>");
                    sbFoodTableTemplate.Append("                <td colspan='3'>Average for weekdays</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[0] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[1] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[2] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[3] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekday'>" + Math.Round((foodNutrientsWeekdayTotal[4] / 5), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("            </tr>");

                    //weekend average
                    sbFoodTableTemplate.Append("            <tr class='totalRow'>");
                    sbFoodTableTemplate.Append("                <td colspan='2'></td>");
                    sbFoodTableTemplate.Append("                <td colspan='3'>Average for weekends</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[0] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[1] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[2] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[3] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td class='totalCol weekend'>" + Math.Round((foodNutrientsWeekendTotal[4] / 2), 2) + "</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("                <td>&nbsp;</td>");
                    sbFoodTableTemplate.Append("            </tr>");

                    sbFoodTableTemplate.Append("        </tfoot>");
                    sbFoodTableTemplate.Append("    </table>");
                    sbFoodTableTemplate.Append("</div>");

                    foodTable = sbFoodTableTemplate.Replace("{{ MealName }}", mealName).ToString();
                    sbRecallDietDetails.Append(sbSingleRecallDietDetailsTemplate).Replace("{{ MealName }}", mealName).Replace("{{ MealTime }}", mealTime).Replace("{{ MealDays }}", mealDays).Replace("{{ FoodTable }}", foodTable).Replace("{{ RecallDiet48Hour }}", roleRecallDiet48Hour);
                }

                //divRecommendedDietMeals.InnerHtml = sbRecommendedDietDetails.ToString();
                //txtRecallDietNotes.Text = itemRecommendedDietDetails.Notes ?? string.Empty; //Bind Notes Data to textbox
                result = new string[] { sbRecallDietDetails.ToString(), itemRecallDietDetails.Notes ?? string.Empty };
                break; // Since for single visit
            }

            return result;

        }
    }
}