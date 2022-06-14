using System;

namespace TA.Domain.Countries
{
    public class CountryBlank
    {
        public Guid? Id { get; set; }
        public String Name { get; set; }
        public CountryBlank() { }
        public CountryBlank(Guid id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}
