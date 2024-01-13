using static eStoresCookies.Core.Common.Constants;

namespace eStoresCookies.ItemsReservationAPI.Endpoints;

public static class WelcomeEndpoints
{

    public static void MapWelcomeEndpoints(this IEndpointRouteBuilder routes)
    {
        const string WelcomeMessage = "eStoresCookies Items Reservation API. Please visit /swagger for full documentation";

        _ = routes
            .MapGet(WelcomeRoutes.Root, () => WelcomeMessage)
            .WithTags("eStoresCookies.ItemsReservationAPI")
            .WithName("GetRootWelcome");

        _ = routes
            .MapGet(WelcomeRoutes.Api, () => WelcomeMessage)
            .WithTags("eStoresCookies.ItemsReservationAPI")
            .WithName("GetApiWelcome");
    }

}