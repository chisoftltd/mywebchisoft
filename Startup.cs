using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace mywebchisoft
{
    public class Startup
    {
        
        public IConfiguration Configuration {get; set;}
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddOptions();
            //services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc();
            //app.UseRouting();
        app.UseMvc();
        //app.UseStaticFiles();
        app.UseRouting();
        //app.UseCors();

        //app.UseEndpoints(endpoints =>
        //{
            //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("<b>Hello ChisoftMedia!</b>");
                });
            });

            //app.Run(async (context) => 
            //{
                //await context.Response.WriteAsync("<b>Hello ChisoftMedia!</b>");
            //});
        }
    }
}
