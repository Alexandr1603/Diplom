using System.Collections.Generic;
using System.Linq;
using TA.Domain.Tours;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class Tours
    {
        internal static Tour ToToure(this ToursDb db)
        {
            return new(db.Id, db.Id_worker, db.Discount, db.Price, db.Name, db.DateStart, db.DateEnd, db.Price_discount);
        }

        internal static Tour[] ToToures(this IEnumerable<ToursDb> dbs)
        {
            return dbs.Select(ToToure).ToArray();
        }

        internal static ToursDb ToDb(this TourBlank blank)
        {
            return new ToursDb(blank.Id.Value, blank.Id_worker, blank.Discount, blank.Price, blank.Name, blank.DateStart, blank.DateEnd, blank.Price_discount);
        }
    }
}
