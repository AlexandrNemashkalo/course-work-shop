using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.API.Configurations;
using Microsoft.Extensions.Logging;
using Shop.Core.Hubs;

namespace NewProject
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
            services
                 //.AddCorsConfiguration()
                .AddConnectionProvider(Configuration)
                .ConfigureIdentity()
                .ConfigureRepositories()
                .ConfigureAuth(Configuration)

                //.AddControllers()
                .AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors();
               //options => options.AddPolicy("CorsPolicy",
           /* builder =>
            {
                builder.AllowAnyMethod().AllowAnyHeader()
                       .WithOrigins("http://localhost:5000")
                       .AllowCredentials();
            }));*/

            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();



            /* var webSocketOptions = new WebSocketOptions()
             {
                 KeepAliveInterval = TimeSpan.FromSeconds(120),
                 ReceiveBufferSize = 16 * 1024
             };
             webSocketOptions.AllowedOrigins.Add("https://localhost:5000");
             //webSocketOptions.AllowedOrigins.Add("https://www.client.com");
             app.UseWebSockets(webSocketOptions);*/

            app.UseStatusCodePages();

            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            //.AllowAnyOrigin()
            .SetIsOriginAllowed(_ => true)
            .AllowCredentials()
            //.WithOrigins("http://localhost:5000")
            );

            app.UseAuthentication();
            app.UseAuthorization();


           
         

          
            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<AuthChatHub>("/authchat");
            });
        }
    }
}
