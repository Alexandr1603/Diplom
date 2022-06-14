using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("Hotels")]
    public class HotelsDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_city")]
        public Guid Id_city { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("stars")]
        public int Stars { get; set; }

        public HotelsDb() { }

        public HotelsDb(Guid id, Guid id_city, String name, int stars)
        {
            Id = id;
            Id_city = id_city;
            Name = name;
            Stars = stars;
        }
    }
}
