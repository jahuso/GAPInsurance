using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Repos.Contracts
{
    public interface ICustomerRepository
    {
        void AssignPolicy(int id);
        void CancelPolicy(int id);
    }
}
