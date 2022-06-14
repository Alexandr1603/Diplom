using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("Attractions")]
    public class AttractionsDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_city")]
        public Guid Id_city { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("time")]
        public TimeSpan Time { get; set; }

        [Column("price")]
        public int Price { get; set; }

        public AttractionsDb() { }

        public AttractionsDb(Guid id, Guid id_city, String name, TimeSpan time, int price)
        {
            Id = id;
            Id_city = id_city;
            Name = name;
            Time = time;
            Price = price;
        }
    }
}
