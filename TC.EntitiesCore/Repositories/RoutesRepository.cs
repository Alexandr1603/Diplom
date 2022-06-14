using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Routes;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class RoutesRepository : BaseRepository
    {
        public Route[] GetRoutesTour(Guid tourId)
        {
            return UseContext(context =>
            {
                return context.Routs.Where(c => c.Id_tour == tourId).ToRoutes();
            });
        }
        public void SaveRouteEntry(RouteBlank entryBlank)
        {
            UseContext(context =>
            {
                RouteDb db = entryBlank.ToDb();
                RouteDb existEntry = context.Routs.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.Routs.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Id_tour = db.Id_tour;
                    existEntry.Id_city = db.Id_city;
                    existEntry.Position = db.Position;
                    existEntry.Days = db.Days;
                    existEntry.Price = db.Price;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
