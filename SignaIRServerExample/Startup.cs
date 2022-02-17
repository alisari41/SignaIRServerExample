using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignaIRServerExample.Business;
using SignaIRServerExample.Hubs;

namespace SignaIRServerExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // cors policy lerine izin verdim
            services.AddCors(options => options.AddDefaultPolicy(policy =>
                policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(origin => true)
            ));

            //IHubContext kullanabilmek için
            services.AddTransient<MyBusiness>();
            //signaIR kullanmak için 
            services.AddSignalR();

            //Boþ bir asp.core kurduðum için Controllers ü belirtilmesi gerekir
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //UserRoutingde önce çaðýrýlmasý gerekir.
            app.UseCors();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Endpoints'i deðiþ
                //https://localhost:5001/myhub
                endpoints.MapHub<MyHub>("/myhub");//bundan sonra myhub'a bir istek geliyorsa MyHub tarafýndan karþýlanacaktýr
                endpoints.MapControllers();//Controller da yapýlan iþlemleri eþleþtirmesi için
            });
        }
    }
}
