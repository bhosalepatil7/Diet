namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CustomerDetail
    {
        public int Operation { set;  get; }  //write only property

        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string MiddleName { get; set; }
        public string LastName  { get; set; }

        public int CustomerAge { get; set; }

        public int Gender { get; set; }

        public DateTime DOB { get; set; }

        public string Address1 { get; set; }

        public string Locality  { get; set; }

        public string City  { get; set; }

        public string State  { get; set; }

        public string Country { get; set; }

        public string Pincode { get; set; }

        public string Profession { get; set; }
        public string ProfessionOthers  { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Landline  { get; set; }

        public string PresentExercise { get; set; }

        public string ExersizeActivity { get; set; }

        public string NatureOfActivity { get; set; }

        public string CustomerDetailNotes { get; set; }

        public string Session { get; set; }

    }
}
