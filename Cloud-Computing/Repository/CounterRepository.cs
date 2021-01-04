using CloudComputing.Context;
using CloudComputing.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudComputing.Repository
{
    public class CounterRepository : RepositoryBase<Counter>, ICounterRepository
    {
        public CounterRepository(CounterContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Counter> GetCounter(int id)
        {
            return await FindByCondition(s => s.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
    }
}
