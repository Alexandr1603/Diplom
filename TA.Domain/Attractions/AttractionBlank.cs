using System;

namespace TA.Domain.Attractions
{
    public class AttractionBlank
    {
        public Guid? Id { get; set; }
        public Guid Id_city { get; set; }
        public String Name { get; set; }
        public TimeSpan Time { get; set; }
        public int Price { get; set; }
        public AttractionBlank() { }
        public AttractionBlank(Guid id, Guid id_city, String name, TimeSpan time, int price)
        {
            Id = id;
            Id_city = id_city;
            Name = name;
            Time = time;
            Price = price;
        }
    }
}
