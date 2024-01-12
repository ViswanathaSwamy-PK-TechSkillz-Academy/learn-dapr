using Dapr.Client;
using eStoresCookies.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eStoresCookies.OrdersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(ILogger<OrdersController> logger) : ControllerBase
{

    private readonly ILogger<OrdersController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    [HttpPost("order")]
    public async Task<ActionResult<Guid>> SubmitOrder(Order order, [FromServices] DaprClient daprClient)
    {
        _logger.LogInformation("Starting OrderController::SubmitOrder().");

        order.Id = Guid.NewGuid();

        foreach (OrderItem item in order.Items!)
        {
            var data = new { sku = item.ProductCode, quantity = item.Quantity };

            var result = await daprClient.InvokeMethodAsync<object, dynamic>(HttpMethod.Post, "reservation-service", "reserve", data);

            _logger.LogInformation($"sku: {result.GetProperty("sku")} === new quantity: {result.GetProperty("quantity")}");
        }

        _logger.LogInformation($"Completed OrderController::SubmitOrder(). Order Id: {order.Id}");

        return order.Id;
    }
}
