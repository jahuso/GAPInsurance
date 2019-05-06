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

        public string ValidateRisk()
        {
            //Validacion de riesgo
            return (Risk == "Alto" && Coverage>=0.5) ? "La cobertura no puede ser mayor al 50% si el riesgo es alto" : "OK";
        }
    }
}
