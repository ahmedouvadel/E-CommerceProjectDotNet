using E_CommerceProject.Data;
using E_CommerceProject.Models;
using E_CommerceProject.Work.Managers;
using E_CommerceProject.Work.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace E_CommerceProject
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
            services.AddDbContext<ECommerceDB>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            // Add repositories as scoped services, this is usually the correct choice
            // for services that interact with the database context.
            services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
            services.AddScoped<IProductRepository, ProductRepositoryImpl>();
            services.AddScoped<IOrderRepository, OrderRepositoryImpl>();

            services.AddScoped<CategoryManager>();
            services.AddScoped<ProductManager>();
            services.AddScoped<ShoppingCart>(); // If this requires sessions, see next step
            services.AddScoped<OrderManager>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            // ... any other service configurations needed for your app
        }

        // Add other necessary middleware you use like sessions, etc.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // If you're using sessions, add session middleware here.
            // app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages(); // If you're using Razor Pages alongside MVC
            });
        }
    }
}
