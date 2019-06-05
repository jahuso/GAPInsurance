using Insurance.Data.Models;
using Insurance.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InsuranceDBContext _DbContext;

        public PolicyRepository PolicyRepository { get; private set; }

        public UnitOfWork(InsuranceDBContext context)
        {
            this._DbContext = context;
            this.PolicyRepository = new PolicyRepository(this._DbContext);
        }
        public async Task Commit()
        {
            await this._DbContext.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            this._DbContext.Dispose();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
