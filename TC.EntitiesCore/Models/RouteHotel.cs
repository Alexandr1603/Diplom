using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("RouteHotel")]
    public class RouteHotelDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_route")]
        public Guid Id_route { get; set; }

        [Column("id_room")]
        public Guid Id_room { get; set; }

        public RouteHotelDb() { }

        public RouteHotelDb(Guid id, Guid id_route, Guid id_room)
        {
            Id = id;
            Id_route = id_route;
            Id_room = id_room;
        }
    }
}
