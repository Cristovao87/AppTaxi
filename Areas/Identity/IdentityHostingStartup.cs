using System;
using AppTaxi.Areas.Identity.Data;
using AppTaxi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AppTaxi.Areas.Identity.IdentityHostingStartup))]
namespace AppTaxi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppTaxiContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AppTaxiContextConnection")));

                services.AddDefaultIdentity<AppTaxiUser>(options =>
                {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                
                })
                    .AddEntityFrameworkStores<AppTaxiContext>();
            });
        }
    }
}