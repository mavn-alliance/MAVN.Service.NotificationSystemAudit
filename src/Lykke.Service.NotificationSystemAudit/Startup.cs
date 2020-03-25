using JetBrains.Annotations;
using Lykke.Sdk;
using Lykke.Service.NotificationSystemAudit.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using Lykke.Service.NotificationSystemAudit.Profiles;

namespace Lykke.Service.NotificationSystemAudit
{
    [UsedImplicitly]
    public class Startup
    {
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "NotificationSystemAudit API",
            ApiVersion = "v1"
        };

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
            {
                options.Extend = (serviceCollection, settings) =>
                {
                    serviceCollection.AddAutoMapper(new Type[]
                    {
                        typeof(ServiceProfile),
                        typeof(DomainServices.AutoMapperProfile)
                    });
                };

                options.SwaggerOptions = _swaggerOptions;

                options.Logs = logs =>
                {
                    logs.AzureTableName = "NotificationSystemAuditLog";
                    logs.AzureTableConnectionStringResolver = settings => settings.NotificationSystemAuditService.Db.LogsConnString;
                };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app)
        {
            app.UseLykkeConfiguration(options =>
            {
                options.SwaggerOptions = _swaggerOptions;
            });
        }
    }
}
