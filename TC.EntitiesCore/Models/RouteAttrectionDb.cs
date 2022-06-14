using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("RouteAttraction")]
    public class RouteAttractionDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_route")]
        public Guid Id_route { get; set; }

        [Column("id_attraction")]
        public Guid Id_attraction { get; set; }

        public RouteAttractionDb() { }

        public RouteAttractionDb(Guid id, Guid id_route, Guid id_attraction)
        {
            Id = id;
            Id_route = id_route;
            Id_attraction = id_attraction;
        }
    }
}
