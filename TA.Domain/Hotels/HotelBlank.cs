using System;

namespace TA.Domain.Hotels
{
    public class HotelBlank
    {
        public Guid? Id { get; set; }
        public Guid Id_city { get; set; }
        public String Name { get; set; }
        public int Stars { get; set; }
        public HotelBlank() { }
        public HotelBlank(Guid id, Guid id_city, String name, int stars)
        {
            Id = id;
            Id_city = id_city;
            Name = name;
            Stars = stars;
        }
    }
}
