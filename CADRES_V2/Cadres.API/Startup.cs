using Cadres.Infrastructure;
using Cadres.Infrastructure.Repository;
using Cadres.Infrastructure.Repository.Interface;
using Cadres.Service;
using Cadres.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cadres.Api
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

            // IoC Context 
            services.AddDbContext<ApplicationDBContext>(option => option.UseLazyLoadingProxies().UseSqlServer(Configuration.GetSection("AppSettings").GetSection("ConnectionString").Value));

            // IoC repositories
            services.AddTransient<IRodRepository, RodRepository>();

            // IoC Services
            services.AddTransient<IFrameService, FrameService>();
            services.AddTransient<IRodService, RodService>();
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
