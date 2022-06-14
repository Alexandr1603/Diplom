using System;

namespace TA.Domain.RouteAttractions
{
    public class RouteAttractionBlank
    {
        public Guid? Id { get; set; }
        public Guid? Id_route { get; set; }
        public Guid Id_attraction { get; set; }
        public RouteAttractionBlank() { }
        public RouteAttractionBlank(Guid? id, Guid? id_route, Guid id_attraction)
        {
            Id = id;
            Id_route = id_route;
            Id_attraction = id_attraction;
        }
    }
}
