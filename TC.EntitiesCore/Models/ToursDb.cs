using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("Tours")]
    public class ToursDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_worker")]
        public Guid Id_worker { get; set; }

        [Column("discount")]
        public int Discount { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("dateStart")]
        public DateTime DateStart { get; set; }

        [Column("dateEnd")]
        public DateTime DateEnd { get; set; }

        [Column("price_discount")]
        public int? Price_discount { get; set; }
        public ToursDb() { }

        public ToursDb(Guid id, Guid id_worker, int discount, double price, string name, DateTime dateStart, DateTime dateEnd, int? price_discount)
        {
            Id = id;
            Id_worker = id_worker;
            Discount = discount;
            Price = price;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Price_discount = price_discount;
        }
    }
}
