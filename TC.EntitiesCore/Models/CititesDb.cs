using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("Cities")]
    public class CititesDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("id_country")]
        public Guid Id_country { get; set; }

        [Column("width")]
        public double Width { get; set; }

        [Column("long")]
        public double Long { get; set; }

        public CititesDb() { }

        public CititesDb(Guid id, String name, Guid id_country, double width, double llong)
        {
            Id = id;
            Name = name;
            Id_country = id_country;
            Width = width;
            Long = llong;
        }
    }
}
