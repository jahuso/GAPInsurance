using Insurance.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Repos.Contracts
{
    public interface ICustomerRepository
    {
        Customer AssignPolicy(Customer customer);
        Customer CancelPolicy(Customer customer);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        bool CustomerExists(int id);

    }
}
