using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationInfo.Core;
using EducationInfo.Core.Entities;
using EducationInfo.Core.Services;
using EducationInfo.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationInfo.Web
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
            services.AddDbContextPool<EducationInfoContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EducationInoConnection")));
            //services.AddTransient<IUnitOfWorkForService, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IRepository<NoteInfo>, Repository<NoteInfo>>();
            services.AddTransient<INoteInfoService, NoteInfoService>();
            services.AddTransient<ICourseService, CourseService>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=NoteInfo}/{action=Index}/{id?}");
            });
        }
    }
}
