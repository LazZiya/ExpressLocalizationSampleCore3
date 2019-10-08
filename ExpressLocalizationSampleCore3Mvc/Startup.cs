using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ExpressLocalizationSampleCore3Mvc.LocalizationResources;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExpressLocalizationSampleCore3Mvc
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
            var cultures = new[]
            {
                new CultureInfo("ar"),
                new CultureInfo("en"),
                new CultureInfo("cs"),
                new CultureInfo("de"),
                new CultureInfo("es"),
                new CultureInfo("fa"),
                new CultureInfo("fr"),
                new CultureInfo("hi"),
                new CultureInfo("hu"),
                new CultureInfo("it"),
                new CultureInfo("ja"),
                new CultureInfo("ko"),
                new CultureInfo("nl"),
                new CultureInfo("pl"),
                new CultureInfo("pt"),
                new CultureInfo("pt-br"),
                new CultureInfo("ru"),
                new CultureInfo("sv"),
                new CultureInfo("tr"),
                new CultureInfo("uk"),
                new CultureInfo("vi"),
                new CultureInfo("zh")
            };

            services.AddControllersWithViews()
                .AddExpressLocalization<ExpressLocalizationResource,ViewLocalizationResource>(ops=>
                {
                    // uncomment and set to true to use only route culture provider
                    // ops.UseAllCultureProviders = false;
                    ops.ResourcesPath = "LocalizationResources";
                    ops.RequestLocalizationOptions = o =>
                    {
                        o.SupportedCultures = cultures;
                        o.SupportedUICultures = cultures;
                        o.DefaultRequestCulture = new RequestCulture("en");
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{culture=en}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
