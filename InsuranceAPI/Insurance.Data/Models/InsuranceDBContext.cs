using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Data.Models
{
    public class InsuranceDBContext: DbContext
    {
        public InsuranceDBContext(DbContextOptions<InsuranceDBContext> options) : base(options)
        {

        }

        public DbSet<Policy>Policies { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
