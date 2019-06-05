using Insurance.Data.Models;
using Insurance.Repos.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Repos
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InsuranceDBContext _context;

        public CustomerRepository(InsuranceDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public Customer GetCustomer(int Id)
        {
            return _context.Customers.Find(Id);
        }

        public Customer AssignPolicy(Customer customer)
        {

            try
            {
                _context.Customers.Update(customer);
                _context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer CancelPolicy(Customer customer)
        {
            _context.Customers.Remove(customer);
            return customer;
        }


        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
