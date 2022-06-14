using System;

namespace TA.Domain.RouteHotels
{
    public class RouteHotel
    {
        public Guid Id { get; }
        public Guid Id_route { get; }
        public Guid Id_room { get; }

        public RouteHotel(Guid id, Guid id_route, Guid id_room)
        {
            Id = id;
            Id_route = id_route;
            Id_room = id_room;
        }
    }
}
