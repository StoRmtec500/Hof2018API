using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Belgrade.SqlClient;
using Belgrade.SqlClient.SqlDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Schaf.Models;
using Schaf.Services;

namespace Schaf
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
            services.AddCors();

            // const string ConnString = "Server=10.1.0.237;Database=schaf_2018;User Id=sa;Password=Stormtec1#";
            const string ConnString = "Server=remote.kuenz.co.at;Database=schaf_2018;User Id=sa;Password=Stormtec1#";
            services.AddTransient<IQueryPipe>(_ => new QueryPipe(new SqlConnection(ConnString)));
            services.AddTransient<ICommand>(_ => new Command(new SqlConnection(ConnString)));


            services.AddTransient<IEinstellungen, EinstellungenService>();
            services.AddDbContext<EinstellungenContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
            });

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePages();
                app.UseHsts();
            }

            app.UseCors(
            options => options.AllowAnyOrigin().AllowAnyHeader()
                                               .AllowAnyMethod()
                                               .AllowCredentials()
        );
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
