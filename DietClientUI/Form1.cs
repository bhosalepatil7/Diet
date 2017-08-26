using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diet.Common;
using Diet.Business.Contract;
using Diet.Business.Model;

namespace DietClientUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerDetail objCustDetail = new CustomerDetail();
            //objCustDetail.CustomerID = Convert.ToInt32(txtPatientID.Text);
            //objCustDetail.CustomerName = txtPatientName.Text;
            //objCustDetail.CustomerAge = Convert.ToInt32(txtPatientAge.Text);
            //objCustDetail.Gender=cmbGender.SelectedIndex;
            //objCustDetail.DOB = Convert.ToDateTime(txtDOB.Text);
            //objCustDetail.Address = txtAddress.Text;
            //objCustDetail.Profession = cmbProfession.SelectedItem.ToString();
            //objCustDetail.Email = txtEmail.Text;
            //objCustDetail.Contact = txtContact.Text;
            //objCustDetail.PresentExercise = txtPresentExcercise.Text;
            //objCustDetail.ExersizeActivity = txtExcerciseActivity.Text;
            //objCustDetail.NatureOfActivity = cmbNatureOfActivity.SelectedItem.ToString();

            objCustDetail.CustomerID = 1;
            objCustDetail.CustomerName = "Prashant";
            objCustDetail.CustomerAge = 25;
            objCustDetail.Gender = 0;
            objCustDetail.DOB = Convert.ToDateTime("5/8/1989");
            objCustDetail.Address = "Wadala";
            objCustDetail.Profession = "Farming";
            objCustDetail.Email = "pk@gmail.com";
            objCustDetail.Contact = "9867815161";
            objCustDetail.PresentExercise = "Yoga";
            objCustDetail.ExersizeActivity = "Padmasan";
            objCustDetail.NatureOfActivity = "a. Sedentary( little or no exercise)";

            BusinessHelper<ICustomerDetail>.Use(CustomerDetailManager =>
            {
                int i = CustomerDetailManager.ModifyCustomerDetail(objCustDetail);
            });
        }
    }
}
