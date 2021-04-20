using DevDe.UI.AppModel.Data;
using DevDe.UI.AppModel.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDe.UI.AppModel
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Code for to rename "Area" (ps. Modulos)
            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    options.AreaViewLocationFormats.Clear();
            //    options.AreaViewLocationFormats.Add(item: "/Modulos/{2}/{Views}/{1}/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add(item: "/Modulos/{2}/{Views}/Shared/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add(item: "/Views/Shared/{0}.cshtml");
            //});

            services.AddDbContext<MyDbContext>(optionsAction: options =>
                options.UseSqlServer(Configuration.GetConnectionString(name: "MyDbContext")));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(id: Guid.Empty));

            services.AddTransient<OperationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default","{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(name: "ProductsArea", areaName: "Products", template: "Products/{controller=Register}/{action=Index}/{id?}");
                routes.MapAreaRoute(name: "SalesArea", areaName: "Sales", template: "Sales/{controller=Orders}/{action=Index}/{id?}");
            });
        }
    }
}
