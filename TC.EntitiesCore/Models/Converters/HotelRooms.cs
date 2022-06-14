using System.Collections.Generic;
using System.Linq;
using TA.Domain.Rooms;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class HotelRooms
    {
        internal static HotelRoom ToHotelRoom(this HotelRoomsDb db)
        {
            return new(db.Id, db.Id_hotel, db.Name, db.Price, db.Count_room);
        }

        internal static HotelRoom[] ToHotelRooms(this IEnumerable<HotelRoomsDb> dbs)
        {
            return dbs.Select(ToHotelRoom).ToArray();
        }

        internal static HotelRoomsDb ToDb(this HotelRoomBlank blank)
        {
            return new HotelRoomsDb(blank.Id.Value, blank.Id_hotel.Value, blank.Name, blank.Price, blank.Count_room);
        }
    }
}
