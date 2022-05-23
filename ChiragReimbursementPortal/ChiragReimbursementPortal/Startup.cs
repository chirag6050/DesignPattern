using AutoMapper;
using BusinessLayer.Mapper;
using BusinessLayer.Services;
using ChiragReimbursementPortal.Mapper;
using DataAccessLayer.Data;
using DataAccessLayer.IdentityModel;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
using System.Threading.Tasks;

namespace ChiragReimbursementPortal
{
    public class Startup
    {
        private MapperConfiguration _mapperConfiguration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebMapper());
                cfg.AddProfile(new ProfileMapper());
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddControllers();
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChiragReimbursementPortal", Version = "v1" });
            });
            services.AddScoped<IMapper>(sp => _mapperConfiguration.CreateMapper());

            services.AddDbContext<ReimbDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")
            ));

            //This code used for add cors helps to resolve cross-origin error 
            services.AddCors(cors => cors.AddPolicy("MyPolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<ReimbDBContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<ReimbDBContext>().AddDefaultTokenProviders(); ;


            services.AddScoped<IReimbursementService, ReimbursementService>();
            services.AddScoped<IReimbursementRepository, ReimbursementRepository>();


            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChiragReimbursementPortal v1"));
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
