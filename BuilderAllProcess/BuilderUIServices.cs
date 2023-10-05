using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAllProcess
{
    internal class BuilderUIServices
    {
        public static void AddScopedSwagerUIServices(WebApplicationBuilder buildSwager)
        {
            buildSwager.Services.AddSwaggerGen(c =>
            {
                // info project
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AcpaProject",
                    Version = "6.0"
                });
                // Define a security scheme for JWT Bearer token
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter your JWT token in the 'Bearer' field.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                });
                // Define the security requirement for the Bearer token
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                },
                new List<string>()
            }
        });
            }
             );
        }
        public static void AddScopedEndpointsApiExplorerServices(WebApplicationBuilder buildSwager)
        {
            buildSwager.Services.AddEndpointsApiExplorer();
        }
        public static void AddScopedControllersServices(WebApplicationBuilder buildController)
        {
            buildController.Services.AddControllers();
        }
    }
}
