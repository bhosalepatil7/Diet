﻿namespace Diet.Business.Core
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

    [Export(typeof(IAnthropometrics))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class AnthropometricsManager : IAnthropometrics
    {
        public int ModifyAnthropometrics(Anthropometrics objAnthropometrics)
        {
            AnthropometricsDataManager objAnthropometricsDataManager = new AnthropometricsDataManager();

            try
            {
                return objAnthropometricsDataManager.ModifyAnthropometrics(objAnthropometrics);
            }
            catch
            {
                throw;
            }
        }
    }
}
