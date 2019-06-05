using Insurance.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Repos.Contracts
{
    public interface IPolicyRepository
    {
        IEnumerable<Policy> GetPolicies();
        Policy GetPolicy(int Id);
        Policy Add(Policy policy);
        Policy Delete(int Id);
        Policy Update(Policy policy);
        bool PolicyExists(int Id);
    }
}