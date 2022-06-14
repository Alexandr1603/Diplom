using System;
using System.Collections.Generic;
using TA.Domain.Cities;
using TA.Domain.RouteAttractions;
using TA.Domain.RouteHotels;
using TA.Domain.RouteTransport;

namespace TA.Domain.Routes
{
    public class RouteBlank
    {
        public Guid? Id { get; set; }
        public Guid? Id_tour { get; set; }
        public City City { get; set; }
        public int? Position { get; set; }
        public int Days { get; set; }
        public int Price { get; set; }
        public List<RouteAttractionBlank> RouteAttractions { get; set; }
        public List<RouteHotelBlank> RouteHotels { get; set; }
        public RouteBlank() { }
        public RouteBlank(Guid? id, Guid? id_tour, City city, int? position, int days, int price)
        {
            Id = id;
            Id_tour = id_tour;
            City = city;
            Position = position;
            Days = days;
            Price = price;
        }
    }
}
