using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudComputing.Context;
using CloudComputing.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CloudComputing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Database connection string.
            var connection = @"Server=cloud-db;Database=master;User=sa;Password=CloudComputing46;";

            // This line uses 'UseSqlServer' in the 'options' parameter
            // with the connection string defined above.
            services.AddDbContext<CounterContext>(
                options => options.UseSqlServer(connection));

            services.AddIdentity<CounterContext, IdentityRole>()
                .AddDefaultTokenProviders();
           
            //services.AddDbContext<CounterContext>();
            //services.AddCors();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
