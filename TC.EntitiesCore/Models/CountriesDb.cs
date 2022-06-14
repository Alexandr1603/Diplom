using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("Сountries")]
    public class CountriesDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public String Name { get; set; }

        public CountriesDb() { }

        public CountriesDb(Guid id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}
