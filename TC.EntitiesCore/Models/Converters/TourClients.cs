using System.Collections.Generic;
using System.Linq;
using TA.Domain.TourClients;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class TourClients
    {
        internal static TourClient ToTourClient(this TourClientsDb db)
        {
            return new(db.Id, db.Id_client, db.Id_tour);
        }

        internal static TourClient[] ToTourClients(this IEnumerable<TourClientsDb> dbs)
        {
            return dbs.Select(ToTourClient).ToArray();
        }

        internal static TourClientsDb ToDb(this TourClientBlank blank)
        {
            return new TourClientsDb(blank.Id.Value, blank.Id_client, blank.Id_tour.Value);
        }
    }
}
