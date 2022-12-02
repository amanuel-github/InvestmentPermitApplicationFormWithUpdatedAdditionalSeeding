using AutoMapper;
using InvestmentPermit.Application.Mappers;
using InvestmentPermit.Application.Repository.InvestmentPermitDetails;
using InvestmentPermit.Application.Repository.PersonalInformationDetails;
using InvestmentPermit.Infrastructure.DBContext;
using InvestmentPermit.Infrastructure.Seed.InvestmentPermit.Infrastructure.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InvestmentPermit.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
           
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddCors();

            services.AddDbContext<InvestmentPermitDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly)));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                
                cfg.AddProfile(new AutoMapperProfile());
                cfg.ValidateInlineMaps = false;
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
              services.AddScoped<ZoneRepository>();
              services.AddScoped<KebelleRepository>();
             services.AddScoped<WoredaRepository>();
            services.AddScoped<RegionRepository>();
            services.AddScoped<NationalityRepository>();
            services.AddScoped<InvestmentPermissionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,InvestmentPermitDbContext context, ILogger<DatabaseInitializer> _logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            DatabaseInitializer db = new DatabaseInitializer(context,_logger);
            db.SeedAsync().Wait();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
