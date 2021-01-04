using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudComputing.Repository
{
    public interface IRepositoryWrapper
    {
        ICounterRepository Counter { get; }
        void Save();
    }
}
