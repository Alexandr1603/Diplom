using System;

namespace TA.Domain.Tours
{
    public class Tour
    {
        public Guid Id { get; }
        public Guid Id_worker { get; }
        public int Discount { get; }
        public double Price { get; }
        public string Name { get; }
        public DateTime DateStart { get; }
        public DateTime DateEnd { get; }
        public int? Price_discount { get; }
        public Tour(Guid id, Guid id_worker, int discount, double price, string name, DateTime dateStart, DateTime dateEnd, int? price_discount)
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
