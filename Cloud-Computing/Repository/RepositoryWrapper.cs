using CloudComputing.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudComputing.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CounterContext _repoContext;

        private ICounterRepository _counterRepository;

        public ICounterRepository Counter
        {
            get
            {
                if (_counterRepository == null)
                {
                    _counterRepository = new CounterRepository(_repoContext);
                }
                return _counterRepository;
            }
        }
        public RepositoryWrapper(CounterContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
