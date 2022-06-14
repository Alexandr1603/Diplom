using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("Route")]
    public class RouteDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_tour")]
        public Guid Id_tour { get; set; }

        [Column("id_city")]
        public Guid Id_city { get; set; }

        [Column("position")]
        public int Position { get; set; }

        [Column("days")]
        public int Days { get; set; }

        [Column("price")]
        public int Price { get; set; }

        public RouteDb() { }

        public RouteDb(Guid id, Guid id_tour, Guid id_city, int position, int days, int price)
        {
            Id = id;
            Id_tour = id_tour;
            Id_city = id_city;
            Position = position;
            Days = days;
            Price = price;
        }
    }
}
