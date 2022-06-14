using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.RouteAttractions;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;


namespace TA.EntitiesCore.Repositories
{
    public class RouteAttractionsRepository : BaseRepository
    {
        public RouteAttraction[] GetAttractionRoute(Guid routeId)
        {
            return UseContext(context =>
            {
                return context.RoteAttractions.Where(c => c.Id_route == routeId).ToRouteAttractions();
            });
        }
        public void SaveRouteAttractionEntry(RouteAttractionBlank entryBlank)
        {
            UseContext(context =>
            {
                RouteAttractionDb db = entryBlank.ToDb();
                RouteAttractionDb existEntry = context.RoteAttractions.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.RoteAttractions.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Id_route = db.Id_route;
                    existEntry.Id_attraction = db.Id_attraction;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
