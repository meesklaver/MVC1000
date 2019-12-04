using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC1000.Models;

[assembly: HostingStartup(typeof(MVC1000.Areas.Identity.IdentityHostingStartup))]
namespace MVC1000.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MVC1000Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MVC1000ContextConnection")));

                //services.AddDefaultIdentity<MVC1000User>(options => options.SignIn.RequireConfirmedAccount = false)
                //    .AddEntityFrameworkStores<MVC1000Context>();
            });
        }
    }
}