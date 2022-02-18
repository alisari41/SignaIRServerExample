using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

namespace SignalRServerExample
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

            //IHubContext kullanabilmek i�in
            services.AddTransient<MyBusiness>();
            //signaIR kullanmak i�in 
            services.AddSignalR();

            //Bo� bir asp.core kurdu�um i�in Controllers � belirtilmesi gerekir
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //UserRoutingde �nce �a��r�lmas� gerekir.
            app.UseCors();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Endpoints'i de�i�
                //https://localhost:5001/myhub
                endpoints.MapHub<MyHub>("/myhub");//bundan sonra myhub'a bir istek geliyorsa MyHub taraf�ndan kar��lanacakt�r
                endpoints.MapHub<MessageHub>("/messagehub");
                endpoints.MapControllers();//Controller da yap�lan i�lemleri e�le�tirmesi i�in
            });
        }
    }
}
