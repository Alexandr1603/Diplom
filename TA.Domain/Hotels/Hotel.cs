using System;

namespace TA.Domain.Hotels
{
    public class Hotel
    {
        public Guid Id { get; }
        public Guid Id_city { get; }
        public String Name { get; }
        public int Stars { get; }
        public Hotel(Guid id, Guid id_city, String name, int stars)
        {
            Id = id;
            Id_city = id_city;
            Name = name;
            Stars = stars;
        }
    }
}
