﻿using System.Text.Json;

namespace eStoresCookies.ItemsReservationAPI.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        _ = services.AddTransient<ILogger>(p =>
        {
            var loggerFactory = p.GetRequiredService<ILoggerFactory>();

            return loggerFactory.CreateLogger("eStoresCookies.ItemsReservationAPI");
        });

        _ = services.AddControllers().AddDapr(opt => opt.UseJsonSerializationOptions(new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        }));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        return services;
    }

}