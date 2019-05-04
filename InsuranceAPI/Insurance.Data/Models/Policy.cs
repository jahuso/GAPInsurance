using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Insurance.Data.Models
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName="nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CoverageType { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,2)")]
        public float Coverage { get; set; }
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime VigencyStart { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CoveragePeriod { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Price { get; set; } 
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string RiskType { get; set; }
    }
}
