namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FatsAndOil
    {
        public int Operation { set; private get; }  //write only property

        public int FatOilID { get; set; }

        public string OilUseDetail { get; set; }

        public int OilQuantityForMonth { get; set; }

        public int NoOfMembersInFamily { get; set; }
        
        public DateTime CreatedOn { get; set; }

    }
}
