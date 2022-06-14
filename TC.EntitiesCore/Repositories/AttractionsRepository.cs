using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Attractions;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class AttractionsRepository : BaseRepository
    {
        public Attraction? GetAttraction(Guid attractionId)
        {
            return UseContext(context =>
            {
                return context.Attractions.FirstOrDefault(c => c.Id == attractionId)?.ToAttraction();
            });
        }

        public Attraction? GetAttraction(String attractionName)
        {
            return UseContext(context =>
            {
                return context.Attractions.FirstOrDefault(c => c.Name == attractionName)?.ToAttraction();
            });
        }

        public Attraction[] GetAllAttractions()
        {
            return UseContext(context =>
            {
                return context.Attractions.ToAttractions();
            });
        }
        public void DeleteAttraction(Guid attractionId)
        {
            UseContext(context =>
            {
                AttractionsDb db = context.Attractions.FirstOrDefault(ce => ce.Id == attractionId);
                if (db is null) return;

                context.Attractions.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public Attraction[] GetCityAttractions(Guid attractionId)
        {
            return UseContext(context =>
            {
                return context.Attractions.Where(c => c.Id_city == attractionId).ToAttractions();
            });
        }
        public void SaveAttractionEntry(AttractionBlank entryBlank)
        {
            UseContext(context =>
            {
                AttractionsDb db = entryBlank.ToDb();
                AttractionsDb existEntry = context.Attractions.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.Attractions.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Name = db.Name;
                    existEntry.Id_city = db.Id_city;
                    existEntry.Time = db.Time;
                    existEntry.Price = db.Price;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}