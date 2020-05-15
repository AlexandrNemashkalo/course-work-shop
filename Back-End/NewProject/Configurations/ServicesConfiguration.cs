using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shop.Core.Interfaces;
using Shop.Core.Services;
using Shop.Core.EF;
using Shop.Core.Repositories;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IItemRepository, ItemRepository>()
                 .AddTransient<INewsRepository, NewsRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IEventRepository, EventRepository>()
                .AddTransient<ILikeRepository, LikeRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserItemRepository, UserItemRepository>()
                .AddTransient<IRoleRepository, RoleRepository>()
                .AddTransient<IOrderRepository, OrderRepository>()
                .AddTransient<IJwtGenerator, JwtGenerator>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IRatingRepository, RatingRepository>();

            return services;
        }
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole<Guid>>(o =>
                {
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<ShopContext>()
                .AddDefaultTokenProviders();



            return services;
        }
        /*public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
           
            services.AddCors(options => {
               options.AddPolicy("AllowAll", builder =>
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
           });*/

        public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(options =>
                    {
                        //options.RequireHttpsMetadata = true;
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true,
                            ValidAudience = configuration["Audience"],
                            ValidateIssuer = true,
                            ValidIssuer = configuration["Issuer"],
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"])),
                            ValidateLifetime = true
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                var token = context.Request.Query["access_token"];

                                var path = context.Request.Path;

                                if ((!string.IsNullOrEmpty(token)) &&
                                path.StartsWithSegments("/authchat"))
                                {
                                    context.Token = token;
                                }

                                return Task.CompletedTask;
                            }
                        };
                    });

            return services;
        }
    }


}

