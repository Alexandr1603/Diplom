using System.Collections.Generic;
using System.Linq;
using TA.Domain.RouteHotels;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class RouteHotels
    {
        internal static RouteHotel ToRouteHotel(this RouteHotelDb db)
        {
            return new(db.Id, db.Id_route, db.Id_room);
        }

        internal static RouteHotel[] ToRouteHotels(this IEnumerable<RouteHotelDb> dbs)
        {
            return dbs.Select(ToRouteHotel).ToArray();
        }

        internal static RouteHotelDb ToDb(this RouteHotelBlank blank)
        {
            return new RouteHotelDb(blank.Id.Value, blank.Id_route.Value, blank.Id_room);
        }
    }
}
