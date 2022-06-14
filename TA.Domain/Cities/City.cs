using System;

namespace TA.Domain.Cities
{
    public class City
    {
        public Guid Id { get; }
        public String Name { get; }
        public Guid Id_country { get; }
        public double Width { get; }
        public double Long { get; }
        public City(Guid id, String name, Guid id_country, double width, double llong)
        {
            Id = id;
            Name = name;
            Id_country = id_country;
            Width = width;
            Long = llong;
        }
    }
}
