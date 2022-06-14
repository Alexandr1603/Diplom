using System;

namespace TA.Domain.Attractions
{
    public class Attraction
    {
        public Guid Id { get; }
        public Guid Id_city { get; }
        public String Name { get; }
        public TimeSpan Time { get; }
        public int Price { get; }
        public Attraction(Guid id, Guid id_city, String name, TimeSpan time, int price)
        {
            Id = id;
            Id_city = id_city;
            Name = name;
            Time = time;
            Price = price;
        }
    }
}
