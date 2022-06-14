using System;

namespace TA.Domain.RouteHotels
{
    public class RouteHotelBlank
    {
        public Guid? Id { get; set; }
        public Guid? Id_route { get; set; }
        public Guid Id_room { get; set; }
        public RouteHotelBlank() { }
        public RouteHotelBlank(Guid? id, Guid? id_route, Guid id_room)
        {
            Id = id;
            Id_route = id_route;
            Id_room = id_room;
        }
    }
}
