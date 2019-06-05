using Insurance.Data.Models;
using Insurance.Repos.Contracts;

namespace Insurance.Repos
{
    public class PolicyRepository:GenericRepository<Policy>
    {
        private readonly InsuranceDBContext _DbContext;
        public PolicyRepository(InsuranceDBContext context): base(context)
        {
            this._DbContext = context;
        }

    }
}
