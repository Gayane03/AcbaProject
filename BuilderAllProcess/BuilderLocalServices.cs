using AcbaProject.Services.BuisnessServices.BSForDeletes;
using AcbaProject.Services.BuisnessServices.BSForInserts;
using AcbaProject.Services.BuisnessServices.BSForSelects;
using AcbaProject.Services.BuisnessServices.BSForUpdates;
using AcbaProject.Services.DatabaseServices.DeleteServices;
using AcbaProject.Services.DatabaseServices.DMLCommandsService.InsertServices;
using AcbaProject.Services.DatabaseServices.DMLCommandsService.UpdateService;
using AcbaProject.Services.DatabaseServices.DMLCommandsService.UpdateServices;
using AcbaProject.Services.DatabaseServices.DQLCommandsServices;
using AcbaProject.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAllProcess
{
    public class BuilderLocalServices
    {
       
        public static void AddScopedAllBuisnessServices(WebApplicationBuilder builderBuisnesServices)
        {
            builderBuisnesServices.Services.AddScoped<IBSForSelect, BSForSelect>();
            builderBuisnesServices.Services.AddScoped<IBSForDelete, BSForDelete>();
            builderBuisnesServices.Services.AddScoped<IBSForInsert, BSForInsert>();
            builderBuisnesServices.Services.AddScoped<IBSForUpdate, BSForUpdate>();
            builderBuisnesServices.Services.AddScoped<IJwtService, JwtService>();
        }
        public static void AddScopedAllDatebaseServices(WebApplicationBuilder builderDatebaseServices)
        {
            builderDatebaseServices.Services.AddScoped<IDeleteService, DeleteService>();
            builderDatebaseServices.Services.AddScoped<IInsertService, InsertService>();
            builderDatebaseServices.Services.AddScoped<IUpdateService, UpdateService>();
            builderDatebaseServices.Services.AddScoped<ISelectService, SelectService>();
        }
        public static void AddScopedSingletonConnection(WebApplicationBuilder builderSingletonConnection)
        {
            builderSingletonConnection.Services.AddSingleton(builderSingletonConnection.Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
