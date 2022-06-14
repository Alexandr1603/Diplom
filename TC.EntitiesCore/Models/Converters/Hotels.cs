using System.Collections.Generic;
using System.Linq;
using TA.Domain.Hotels;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class Hotels
    {
        internal static Hotel ToHotel(this HotelsDb db)
        {
            return new(db.Id, db.Id_city, db.Name, db.Stars);
        }

        internal static Hotel[] ToHotels(this IEnumerable<HotelsDb> dbs)
        {
            return dbs.Select(ToHotel).ToArray();
        }

        internal static HotelsDb ToDb(this HotelBlank blank)
        {
            return new HotelsDb(blank.Id.Value, blank.Id_city, blank.Name, blank.Stars);
        }
    }
}
