using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentTracker.Contracts.ServiceInterface;
using InvestmentTracker.DAL.Models;
using InvestmentTracker.Services.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace InvestmentTracker
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AzureAdIntegration(services);

            ResolveDependencies(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                 builder =>
                 {
                     builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                 });
            });

            IntegrateSwagger(services);

            // Auto Mapper Configurations
            SetupAutoMapper(services);

        }

        private static void SetupAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperSetup());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void IntegrateSwagger(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        private void AzureAdIntegration(IServiceCollection services)
        {
            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            .AddAzureADBearer(options => Configuration.Bind("ProjectConfig:AzureAd", options));
        }

        private void ResolveDependencies(IServiceCollection services)
        {
            var connectionString = Configuration.GetSection("ProjectConfig:ConnectionString")?.Value;
            var connection = Configuration["ProjectConfig.ConnectionString"];//  @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<InvestmentTrackerDatabaseContext>(options => options.UseSqlServer(connectionString));
            //services.AddScoped<IContactService>(x => new ContactService(x.GetService<InvestmentTrackerDatabaseContext>()));
            services.AddScoped<IContactService, ContactService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "api/{controller}/{id}");
            });

            

        }
    }
}
