using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model.Configuration;
using Model.Interface;
using Model.Entities;
using Model.Repository;
using AutoMapper;
using Mapper.MapperProfiles;

namespace PortafolioAPI
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
            services.AddMvc();
            services.AddControllers();
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Post>, Repository<Post>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            
            services.AddAutoMapper(typeof(ModelProfile));

            services.AddDbContext<ApplicationContext>(options => 
                    options.UseSqlServer(
                        Configuration.GetConnectionString("portafolioDB"),
                        b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
