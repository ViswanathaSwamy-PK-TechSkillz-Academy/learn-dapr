using eStoresCookies.ItemsReservationAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices();

var app = builder.Build();

app.ConfigureHttpRequestPipeline();

app.Run();
