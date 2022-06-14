using System;

namespace TA.Domain.Countries
{
    public class Country
    {
        public Guid Id { get; }
        public String Name { get; }
        public Country(Guid id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}
