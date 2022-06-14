using System.Collections.Generic;
using System.Linq;
using TA.Domain.RouteAttractions;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class RouteAttractions
    {
        internal static RouteAttraction ToRouteAttraction(this RouteAttractionDb db)
        {
            return new(db.Id, db.Id_route, db.Id_attraction);
        }

        internal static RouteAttraction[] ToRouteAttractions(this IEnumerable<RouteAttractionDb> dbs)
        {
            return dbs.Select(ToRouteAttraction).ToArray();
        }

        internal static RouteAttractionDb ToDb(this RouteAttractionBlank blank)
        {
            return new RouteAttractionDb(blank.Id.Value, blank.Id_route.Value, blank.Id_attraction);
        }
    }
}
