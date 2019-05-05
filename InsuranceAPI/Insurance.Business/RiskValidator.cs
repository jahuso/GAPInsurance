using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Business
{
    public class RiskValidator:IValidator
    {
        public string Risk { get; set; }
        public double Coverage { get; set; }

        public RiskValidator(string risk, double coverage)
        {
            Risk = risk;
            Coverage = coverage;
        }

        public bool ValidateRisk()
        {
            //Validacion de riesgo
            return (Risk == "Alto") ? true : false;
        }
    }
}
