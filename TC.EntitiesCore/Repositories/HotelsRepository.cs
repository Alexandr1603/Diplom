using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Hotels;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class HotelsRepository : BaseRepository
    {
        public Hotel? GetHotel(Guid hotelId)
        {
            return UseContext(context =>
            {
                return context.Hotels.FirstOrDefault(c => c.Id == hotelId)?.ToHotel();
            });
        }

        public Hotel? GetHotel(String hotelName)
        {
            return UseContext(context =>
            {
                return context.Hotels.FirstOrDefault(c => c.Name == hotelName)?.ToHotel();
            });
        }

        public Hotel[] GetAllHotels()
        {
            return UseContext(context =>
            {
                return context.Hotels.ToHotels();
            });
        }
        public void DeleteHotel(Guid hotelId)
        {
            UseContext(context =>
            {
                HotelsDb db = context.Hotels.FirstOrDefault(ce => ce.Id == hotelId);
                if (db is null) return;

                context.Hotels.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public Hotel[] GetCityHotels(Guid cityId)
        {
            return UseContext(context =>
            {
                return context.Hotels.Where(c => c.Id_city == cityId).ToHotels();
            });
        }
        public void SaveHotelEntry(HotelBlank entryBlank)
        {
            UseContext(context =>
            {
                HotelsDb db = entryBlank.ToDb();
                HotelsDb existEntry = context.Hotels.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.Hotels.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Name = db.Name;
                    existEntry.Id_city = db.Id_city;
                    existEntry.Stars = db.Stars;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}