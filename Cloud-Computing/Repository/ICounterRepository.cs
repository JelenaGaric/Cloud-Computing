using CloudComputing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudComputing.Repository
{
    public interface ICounterRepository : IRepositoryBase<Counter>
    {
        Task<Counter> GetCounter(int id);

    }
}
