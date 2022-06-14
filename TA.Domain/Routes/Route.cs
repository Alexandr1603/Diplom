using System;

namespace TA.Domain.Routes
{
    public class Route
    {
        public Guid Id { get; }
        public Guid Id_tour { get; }
        public Guid Id_city { get; }
        public int Position { get; }
        public int Days { get; }
        public int Price { get; }

        public Route(Guid id, Guid id_tour, Guid id_city, int position, int days, int price)
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
