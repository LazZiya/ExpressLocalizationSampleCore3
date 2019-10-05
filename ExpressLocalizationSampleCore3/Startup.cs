using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ExpressLocalizationSampleCore3.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using LazZiya.ExpressLocalization;
using ExpressLocalizationSampleCore3.LocalizationResources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

namespace ExpressLocalizationSampleCore3
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var cultures = new[]
            {
                new CultureInfo("ar"),
                new CultureInfo("cs"),
                new CultureInfo("de"),
                new CultureInfo("es"),
                new CultureInfo("en"),
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

            services.AddRazorPages()
                .AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
                {
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
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
