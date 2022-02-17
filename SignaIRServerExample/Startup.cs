using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignaIRServerExample.Hubs;

namespace SignaIRServerExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //signaIR kullanmak i�in 
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Endpoints'i de�i�
                endpoints.MapHub<MyHub>("/myhub");//bundan sonra myhub'a bir istek geliyorsa MyHub taraf�ndan kar��lanacakt�r
            });
        }
    }
}
