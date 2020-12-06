using CloudComputing.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CloudComputing.Context
{
    public class CounterContext : DbContext
    {
        public DbSet<Counter> Counters { get; set; }
        public IConfiguration Configuration { get; }

        public CounterContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:CloudComputingConnection"]);

            // optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
