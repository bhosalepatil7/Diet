namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GastrointestinalProblems
    {
        public int Operation { set; private get; }  //write only property

        public int GastProbID { get; set; }

        public string Heartburn { get; set; }

        public string Bloating { get; set; }

        public string Gas { get; set; }

        public string Diarrhoea { get; set; }

        public string Vomiting { get; set; }

        public string Constipation { get; set; }

        public string LaxativeAntacide { get; set; }

        public string HomeRemedy { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
