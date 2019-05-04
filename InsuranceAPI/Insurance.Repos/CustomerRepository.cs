using Insurance.Data.Models;
using Insurance.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Repos
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly InsuranceDBContext _DbContext;

        public CustomerRepository(InsuranceDBContext context) : base(context)
        {
            this._DbContext = context;
        }

        public void AssignPolicy(int id)
        {
            throw new NotImplementedException();
        }

        public void CancelPolicy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
