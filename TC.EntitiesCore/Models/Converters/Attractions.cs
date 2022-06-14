using System.Collections.Generic;
using System.Linq;
using TA.Domain.Attractions;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class Attractions
    {
        internal static Attraction ToAttraction(this AttractionsDb db)
        {
            return new(db.Id, db.Id_city, db.Name, db.Time, db.Price);
        }

        internal static Attraction[] ToAttractions(this IEnumerable<AttractionsDb> dbs)
        {
            return dbs.Select(ToAttraction).ToArray();
        }

        internal static AttractionsDb ToDb(this AttractionBlank blank)
        {
            return new AttractionsDb(blank.Id.Value, blank.Id_city, blank.Name, blank.Time, blank.Price);
        }
    }
}