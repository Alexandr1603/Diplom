using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.RouteHotels;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class RouteHotelsRepository : BaseRepository
    {
        public RouteHotel[] GetHotelRoute(Guid routeId)
        {
            return UseContext(context =>
            {
                return context.RouteHotels.Where(c => c.Id_route == routeId).ToRouteHotels();
            });
        }
        public void SaveRouteHotelEntry(RouteHotelBlank entryBlank)
        {
            UseContext(context =>
            {
                RouteHotelDb db = entryBlank.ToDb();
                RouteHotelDb existEntry = context.RouteHotels.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.RouteHotels.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Id_route = db.Id_route;
                    existEntry.Id_room = db.Id_room;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
