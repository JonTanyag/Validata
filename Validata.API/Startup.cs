using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Validata.API.Application.CommandHandlers;
using Validata.Domain.Repositories;
using Validata.Infrastructure;
using Validata.Infrastructure.Repositories;

namespace Validata.API
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
            services.AddControllers();




            //services.AddMediatR(typeof(CustomerCommandHandler).Assembly);
            services.AddDbContext<ValidataDbContext>(o => o.UseSqlServer("Server=localhost,1433\\Catalog=Validata;Database=Validata;User=sa;Password=m$sQlServ3rh4ck");
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerManagerRepository, CustomerManagerRepository>();



            services.AddMediatR(typeof(CustomerRepository).Assembly);
            services.AddMediatR(typeof(CustomerManagerRepository).Assembly);
            services.AddMediatR(typeof(CustomerCommandHandler).Assembly);
            services.AddSwaggerGen();

            //RegisterAutofacServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("../swagger/v1/swagger.json", "Valid Data API"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private AutofacServiceProvider RegisterAutofacServices(IServiceCollection services)
        {
            var container = IoC.LetThereBeIoc(services);
            return new AutofacServiceProvider(container);
        }
    }
}
