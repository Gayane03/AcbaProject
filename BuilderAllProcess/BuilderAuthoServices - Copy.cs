using AcbaProject.Validations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAllProcess
{
    internal class BuilderAuthoServices
    {
        public static void AddScopedAuthenticationServices(WebApplicationBuilder builderAuthentication)
        {
            IJwtService tokenValid = new JwtService();
            builderAuthentication.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValid.tokenValidationParameters();
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.HttpContext.WebSockets.IsWebSocketRequest)
                        {
                            var queryStringToken = context.Request.Query["access_token"];

                            if (!string.IsNullOrEmpty(queryStringToken))
                                context.Token = queryStringToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
        public static void AddScopedAuthorizationServices(WebApplicationBuilder builderAuthorization)
        {
            builderAuthorization.Services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy =>
                    policy.RequireRole("admin"));
            });
        }
    }
}
