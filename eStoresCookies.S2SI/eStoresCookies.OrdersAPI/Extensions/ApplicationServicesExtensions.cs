using System.Text.Json;

namespace eStoresCookies.OrdersAPI.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
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