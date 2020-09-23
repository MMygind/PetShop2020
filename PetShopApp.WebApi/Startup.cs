using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Services;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.SQLite.Data;
using PetShopApp.Infrastructure.SQLite.Data.Repositories;
using PetShopApp.Infrastructure.Static.Data;
using PetShopApp.Infrastructure.Static.Data.Repositories;

namespace PetShopApp.WebApi
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
            services.AddDbContext<PetShopAppLiteContext>(opt => opt.UseInMemoryDatabase("ThaDB"));

            services.AddDbContext<PetShopAppLiteContext>(opt => opt.UseSqlite("Data Source=petShopApp.db"));
            
            //services.AddSingleton<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            //services.AddSingleton<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddSingleton<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IPetRepository, PetDBRepository>();
            services.AddScoped<IOwnerRepository, OwnerDBRepository>();
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Demo API",
                        Description = "Demo API for showing swagger",
                        Version = "v1"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopAppLiteContext>();
                    DBInitializer.SeedDB(ctx);

                    var petRepo = scope.ServiceProvider.GetService<IPetRepository>();
                    var ownerRepo = scope.ServiceProvider.GetService<IOwnerRepository>();
                    var petTypeRepo = scope.ServiceProvider.GetService<IPetTypeRepository>();
                    //new DataInitializer(petRepo, ownerRepo, petTypeRepo).InitData();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
            });
        }
    }
}
