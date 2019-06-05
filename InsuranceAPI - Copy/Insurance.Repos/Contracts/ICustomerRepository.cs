using Insurance.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Repos.Contracts
{
    public interface ICustomerRepository
    {
        void AssignPolicy(Customer customer);
        void CancelPolicy(Customer customer);
    }
}
