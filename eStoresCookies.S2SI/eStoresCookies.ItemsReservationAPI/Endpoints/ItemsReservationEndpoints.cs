﻿using Dapr.Client;
using eStoresCookies.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eStoresCookies.ItemsReservationAPI.Endpoints;

public static class ItemsReservationEndpoints
{

    public static void MapItemsReservationEndpoints(this IEndpointRouteBuilder routes)
    {
        _ = routes.MapPost("/reserve", ([FromServices] DaprClient client, [FromBody] Item item, [FromServices] ILogger logger) =>
        {
            logger.LogInformation($"Received the Item Reservation for {item.SKU}");

            Item storedItem = new()
            {
                SKU = item.SKU
            };
            storedItem.Quantity -= item.Quantity;

            logger.LogInformation($"Reservation of {storedItem.SKU} is now {storedItem.Quantity}");

            return Results.Ok(storedItem);
        })
        .WithOpenApi()
        .WithTags("ItemsReservationAPI")
        .WithName("Reserve Item"); ;

    }

}