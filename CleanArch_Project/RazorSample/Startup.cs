using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Services;
using Microsoft.Extensions.Configuration;
using ApplicationCore.Services;




namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            
            

            services.AddScoped<IProductRepository, ProductRepository>();
           // services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped< ProductListVmService>();
            services.AddScoped<ProductService>();
            // services.AddScoped<CustomerListVmService>();
            //  services.AddScoped<CustomerService>();


           
            services.AddDbContext<ProductContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Project_OnlineShopContext")));

            services.AddRazorPages();


            //  services.AddDbContext<WebContext>(options =>
            //         options.UseSqlServer(Configuration.GetConnectionString("WebContext")));
        }//

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

        }
    }
}