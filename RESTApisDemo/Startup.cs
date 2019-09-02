using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RESTApisDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;
using RESTApisDemo.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace RESTApisDemo
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
            services.AddMvc().AddXmlSerializerFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Adding swagger - swashbuckle.aspnetcore 1.1.0
            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new Info() { Title = "REST Apis", Version = "v1" }));

            services.AddDbContext<ProductsDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductsDB;"));
            //Aaspnetcore.Versioning 2.2.0
            services.AddApiVersioning(x => x.ApiVersionReader = new MediaTypeApiVersionReader());//header key ="Accept" & Value ="application/json;v=1.0"
            services.AddScoped<IProduct, ProductRepository>(); //DI
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ProductsDbContext productsDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Add swagger configs
            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "REST Apis Demo Swagger"));

            app.UseHttpsRedirection();
            app.UseMvc();
            productsDbContext.Database.EnsureCreated();
        }
    }
}
