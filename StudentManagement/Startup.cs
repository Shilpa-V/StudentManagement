﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Models;

namespace StudentManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config )
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<StudentDbContext>(options => options.UseSqlServer(_config.GetConnectionString("StudentDBConnection")));
            services.AddMvc();
            services.AddScoped <IStudentRepository, SQLStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response
            //    .WriteAsync("Hello World!!");
            //});
        }
    }
}
