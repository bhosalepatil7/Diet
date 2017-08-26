namespace Diet.Business.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChronicDiseases
    {
        public int Operation { set; private get; }  //write only property

        public int ChronicDiseaseID { get; set; }

        public string DiabetesChronDis { get; set; }

        public string HypertensionChronDis { get; set; }

        public string CardiacDisorders { get; set; }

        public string KidneyDisorders { get; set; }

        public string LeverDisorders { get; set; }

        public string PepticUlser { get; set; }

        public string OtherChronicDiseases { get; set; }

        public string FollowedParticularDietForProb { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
