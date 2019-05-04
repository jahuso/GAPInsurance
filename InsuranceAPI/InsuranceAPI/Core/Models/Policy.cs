using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Core.Models
{
    public class Policy
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverageType { get; set; }
        public string Coverage { get; set; }
        public DateTime VigencyStart { get; set; }
        public string CoveragePeriod { get; set; }
        public int Price { get; set; }
        public string RiskType { get; set; }
    }
}
