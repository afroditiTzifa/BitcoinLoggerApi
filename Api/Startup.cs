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

            //services.AddDbContext<MyDBContext>(options => options.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")));
            
            var connectionString = Configuration["Connectionstrings:database"];
            /*var envVar = Environment.GetEnvironmentVariable("DATABASE_URL");
            if (!string.IsNullOrEmpty(envVar))
            {
               var uri = new Uri(envVar);
               var username = uri.UserInfo.Split(':')[0];
               var password = uri.UserInfo.Split(':')[1];
               connectionString =  "; Database=" + uri.AbsolutePath.Substring(1) + "; Username=" + username +
                                   "; Password=" + password +  "; Port=" + uri.Port + "; SSL Mode=Require; Trust Server Certificate=true;";
            }
            */
            services.AddDbContext<MyDBContext>(opt =>opt.UseNpgsql(connectionString));
            
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
