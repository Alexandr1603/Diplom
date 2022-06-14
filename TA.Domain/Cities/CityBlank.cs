using System;

namespace TA.Domain.Cities
{
    public class CityBlank
    {
        public Guid? Id { get; set; }
        public String Name { get; set; }
        public Guid Id_country { get; set; }
        public double? Width { get; set; }
        public double? Long { get; set; }
        public CityBlank() { }
        public CityBlank(Guid id, String name, Guid id_country, double width, double llong)
        {
            Id = id;
            Name = name;
            Id_country = id_country;
            Width = width;
            Long = llong;
        }
    }
}
