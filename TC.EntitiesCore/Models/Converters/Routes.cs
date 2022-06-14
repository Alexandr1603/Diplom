using System.Collections.Generic;
using System.Linq;
using TA.Domain.Routes;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class Routes
    {
        internal static Route ToRoute(this RouteDb db)
        {
            return new(db.Id, db.Id_tour, db.Id_city, db.Position, db.Days, db.Price);
        }

        internal static Route[] ToRoutes(this IEnumerable<RouteDb> dbs)
        {
            return dbs.Select(ToRoute).ToArray();
        }

        internal static RouteDb ToDb(this RouteBlank blank)
        {
            return new RouteDb(blank.Id.Value, blank.Id_tour.Value, blank.City.Id, blank.Position.Value, blank.Days, blank.Price);
        }
    }
}
