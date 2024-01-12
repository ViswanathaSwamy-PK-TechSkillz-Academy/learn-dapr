namespace eStoresCookies.OrdersAPI.Extensions;

public static class HttpRequestPipelineExtensions
{

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}