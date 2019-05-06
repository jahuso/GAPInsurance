using Insurance.Data.Models;
using Insurance.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Business
{
    public class CustomerBL
    {
        private readonly InsuranceDBContext _DbContext;
        CustomerRepository repository;

        public CustomerBL()
        {
            repository = new CustomerRepository(_DbContext);
        }

        public string AssignPolicy(Customer customer)
        {
            repository.AssignPolicy(customer);
            return "OK";
        }

        public string CancelPolicy(Customer customer)
        {
            repository.CancelPolicy(customer);
            return "OK";
        }
    }
}
