using Insurance.Data.Models;
using Insurance.Repos.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Repos
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InsuranceDBContext _DbContext;

        public CustomerRepository(InsuranceDBContext context)
        {
            _DbContext = context;
        }

        public void AssignPolicy(Customer customer)
        {

            try
            {
                //_DbContext.Entry(customer).State = EntityState.Modified;
                _DbContext.Customers.Update(customer);
                _DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelPolicy(Customer customer)
        {
            _DbContext.Customers.Remove(customer);
        }
    }
}
