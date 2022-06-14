using System;
using System.Collections.Generic;
using TA.Domain.Results;
using TA.Domain.RouteAttractions;
using TA.Domain.RouteHotels;
using TA.Domain.Routes;
using TA.EntitiesCore.Repositories;

namespace TA.Services.Routes
{
    public class RoutesService
    {
        private readonly RoutesRepository _routesRepository;
        private readonly RouteAttractionsRepository _routeAttractionsRepository;
        private readonly RouteHotelsRepository _routeHotelsRepository;

        public RoutesService()
        {
            _routesRepository = new RoutesRepository();
            _routeAttractionsRepository = new RouteAttractionsRepository();
            _routeHotelsRepository = new RouteHotelsRepository();
        }
        public Route[] GetRoutesTour(Guid countryId)
        {
            return _routesRepository.GetRoutesTour(countryId);
        }
        public RouteAttraction[] GetAttractionRoute(Guid countryId)
        {
            return _routeAttractionsRepository.GetAttractionRoute(countryId);
        }
        public RouteHotel[] GetHotelRoute(Guid countryId)
        {
            return _routeHotelsRepository.GetHotelRoute(countryId);
        }
        public Result SaveRoutesEntry(List<RouteBlank> blanks, Guid tourId)
        {
            foreach (var item in blanks)
            {
                item.Id_tour = tourId;
                if (item.Id is null) item.Id = Guid.NewGuid();
                _routesRepository.SaveRouteEntry(item);
                foreach (var itemH in item.RouteHotels)
                {
                    itemH.Id_route = item.Id;
                    if (itemH.Id is null) itemH.Id = Guid.NewGuid();
                    _routeHotelsRepository.SaveRouteHotelEntry(itemH);
                }
                foreach (var itemA in item.RouteAttractions)
                {
                    itemA.Id_route = item.Id;
                    if (itemA.Id is null) itemA.Id = Guid.NewGuid();
                    _routeAttractionsRepository.SaveRouteAttractionEntry(itemA);
                }
            }
            return Result.Success();
        }
    }
}
