using System.Collections.Generic;
using System.Linq;
using TA.Domain.Cities;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class Cities
    {
        internal static City ToCity(this CititesDb db)
        {
            return new(db.Id, db.Name, db.Id_country, db.Width, db.Long);
        }

        internal static City[] ToCities(this IEnumerable<CititesDb> dbs)
        {
            return dbs.Select(ToCity).ToArray();
        }

        internal static CititesDb ToDb(this CityBlank blank)
        {
            return new CititesDb(blank.Id.Value, blank.Name, blank.Id_country, blank.Width.Value, blank.Long.Value);
        }
    }
}