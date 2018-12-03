using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

namespace InvestmentTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("AllowAllOrigins",
        //         builder =>
        //        {
        //            builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        //        });
        //    });

        //    var connection = @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0";
        //    services.AddDbContext<InvestmentTrackerDatabaseContext>(options => options.UseSqlServer(connection));
        //    services.AddScoped<IContactService>(x => new ContactService(x.GetService<InvestmentTrackerDatabaseContext>()));

        //    // AD integration
        //    AzureADConfiguration(services);
        //}

        //private void AzureADConfiguration(IServiceCollection services)
        //{
        //    //services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
        //    //                .AddAzureAD(options => Configuration.Bind("AzureAd", options));

        //    services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
        //                .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

        //    //services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
        //    //{
        //    //    options.Authority = options.Authority + "/v2.0/";

        //    //    // Per the code below, this application signs in users in any Work and School
        //    //    // accounts and any Microsoft Personal Accounts.
        //    //    // If you want to direct Azure AD to restrict the users that can sign-in, change 
        //    //    // the tenant value of the appsettings.json file in the following way:
        //    //    // - only Work and School accounts => 'organizations'
        //    //    // - only Microsoft Personal accounts => 'consumers'
        //    //    // - Work and School and Personal accounts => 'common'

        //    //    // If you want to restrict the users that can sign-in to only one tenant
        //    //    // set the tenant value in the appsettings.json file to the tenant ID of this
        //    //    // organization, and set ValidateIssuer below to true.

        //    //    // If you want to restrict the users that can sign-in to several organizations
        //    //    // Set the tenant value in the appsettings.json file to 'organizations', set
        //    //    // ValidateIssuer, above to 'true', and add the issuers you want to accept to the
        //    //    // options.TokenValidationParameters.ValidIssuers collection
        //    //    options.TokenValidationParameters.ValidateIssuer = false;
        //    //});
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseMvc();
        //}

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = "c9c3f72e-f6a6-4d4c-9df9-4def1ba7a987", //tanent id
            //        ValidateAudience = true,
            //        ValidAudience = "7703799c-fbfe-4588-a9ea-67d312648da4", // app id
            //    };
            //    x.Audience = "7703799c-fbfe-4588-a9ea-67d312648da4"; // app id
            //    x.Audience = "https://sts.windows.net/c9c3f72e-f6a6-4d4c-9df9-4def1ba7a987";
            //});

            var connection = @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<InvestmentTrackerDatabaseContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IContactService>(x => new ContactService(x.GetService<InvestmentTrackerDatabaseContext>()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                 builder =>
                 {
                     builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                 });
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
