using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Tours;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class TourRepository : BaseRepository
    {
        public Tour? GetTour(Guid hotelId)
        {
            return UseContext(context =>
            {
                return context.Tours.FirstOrDefault(c => c.Id == hotelId)?.ToToure();
            });
        }

        public Tour? GetTour(String hotelName)
        {
            return UseContext(context =>
            {
                return context.Tours.FirstOrDefault(c => c.Name == hotelName)?.ToToure();
            });
        }

        public Tour[] GetAllTours()
        {
            return UseContext(context =>
            {
                return context.Tours.ToToures();
            });
        }
        public void DeleteTour(Guid hotelId)
        {
            UseContext(context =>
            {
                ToursDb db = context.Tours.FirstOrDefault(ce => ce.Id == hotelId);
                if (db is null) return;

                context.Tours.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public Tour[] GetWorkerTours(Guid workerid)
        {
            return UseContext(context =>
            {
                return context.Tours.Where(c => c.Id_worker == workerid).ToToures();
            });
        }
        public void SaveTourEntry(TourBlank entryBlank)
        {
            UseContext(context =>
            {
                ToursDb db = entryBlank.ToDb();
                ToursDb existEntry = context.Tours.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.Tours.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Name = db.Name;
                    existEntry.Price_discount = db.Price_discount;
                    existEntry.Discount = db.Discount;
                    existEntry.Price = db.Price;
                    existEntry.DateStart = db.DateStart;
                    existEntry.DateEnd = db.DateEnd;   
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
