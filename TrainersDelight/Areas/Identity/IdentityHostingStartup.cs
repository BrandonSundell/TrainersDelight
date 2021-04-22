using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainersDelight.Areas.Identity.Data;
using TrainersDelight.Data;

[assembly: HostingStartup(typeof(TrainersDelight.Areas.Identity.IdentityHostingStartup))]
namespace TrainersDelight.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TrainersDelightAuthentication>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TrainersDelightAuthenticationConnection")));

                services.AddDefaultIdentity<TrainersDelightUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TrainersDelightAuthentication>();
            });
        }
    }
}