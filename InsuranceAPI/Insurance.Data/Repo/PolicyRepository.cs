using Insurance.Data.Models;
using Insurance.Repos.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Repos
{
    public class PolicyRepository:IPolicyRepository
    {
        private readonly InsuranceDBContext _context;
        public PolicyRepository(InsuranceDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Policy> GetPolicies()
        {
            return _context.Policies;
        }

        public Policy GetPolicy(int Id)
        {
            return _context.Policies.Find(Id);
        }

        public Policy Delete(int Id)
        {
            Policy employee = _context.Policies.Find(Id);
            if (employee != null)
            {
                _context.Policies.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public Policy Update(Policy employee)
        {
            _context.Policies.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public bool PolicyExists(int id)
        {
            return _context.Policies.Any(e => e.Id== id);
        }

        public Policy Add(Policy policy)
        {
            _context.Add(policy);
            _context.SaveChanges();
            return policy;
        }
    }
}
