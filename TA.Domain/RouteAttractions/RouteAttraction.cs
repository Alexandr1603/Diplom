using System;

namespace TA.Domain.RouteAttractions
{
    public class RouteAttraction
    {
        public Guid Id { get; }
        public Guid Id_route { get; }
        public Guid Id_attraction { get; }
        public RouteAttraction(Guid id, Guid id_route, Guid id_attraction)
        {
            Id = id;
            Id_route = id_route;
            Id_attraction = id_attraction;
        }
    }
}
