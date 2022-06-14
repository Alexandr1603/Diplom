using System;

namespace TA.Domain.Tours
{
    public class TourBlank
    {
        public Guid? Id { get; set; }
        public Guid Id_worker { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int? Price_discount { get; set; }
        public TourBlank() { }
        public TourBlank(Guid id, Guid id_worker, int discount, double price, string name, DateTime dateStart, DateTime dateEnd, int? price_discount)
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
