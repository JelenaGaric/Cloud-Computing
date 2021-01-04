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
            try
            {
                this.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=cloud-db;Database=master;User=sa;Password=CloudComputing46;";
            optionsBuilder.UseSqlServer(connection);
            //optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:CloudComputingConnection"]);

            // optionsBuilder.UseLazyLoadingProxies();
           
        }
    }
}
