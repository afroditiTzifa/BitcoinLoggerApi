using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using BitcoinLogger.Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace bitcoinlogger.Api
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
            services.AddCors(o => o.AddPolicy("CORS", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

             
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "production")
            {
                var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
                if (connectionString == null)
                    connectionString="Host=ec2-52-31-233-101.eu-west-1.compute.amazonaws.com;Port=5432;Username=ynbwflaaufszsr;Password=fa91c3f82bd80ecdfc023a849b38e1d39d6e0b359c8f10cbb298413dda81e5de;Database=dfkn0hst18sq2p; SSL Mode=Require; Trust Server Certificate=true;";
                services.AddDbContext<MyDBContext>(opt =>opt.UseNpgsql(connectionString));

            }
            else 
            {
                var connectionString = Configuration["Connectionstrings:database"];
                services.AddDbContext<MyDBContext>(opt =>opt.UseSqlServer(connectionString));
            }
                
            
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IRepository, SQLRepository> ();
            services.AddControllers();        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
           
            app.UseRouting();
            app.UseCors("CORS");

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
