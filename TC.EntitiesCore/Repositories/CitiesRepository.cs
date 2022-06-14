using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Cities;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class CitiesRepository : BaseRepository
    {
        public City? GetCity(Guid cityId)
        {
            return UseContext(context =>
            {
                return context.Citites.FirstOrDefault(c => c.Id == cityId)?.ToCity();
            });
        }

        public City? GetCity(String cityName)
        {
            return UseContext(context =>
            {
                return context.Citites.FirstOrDefault(c => c.Name == cityName)?.ToCity();
            });
        }

        public City[] GetAllCities()
        {
            return UseContext(context =>
            {
                return context.Citites.ToCities();
            });
        }
        public City[] GetCountryCities(Guid countryId)
        {
            return UseContext(context =>
            {
                return context.Citites.Where(c => c.Id_country == countryId).ToCities();
            });
        }
        public void DeleteCity(Guid cityId)
        {
            UseContext(context =>
            {
                CititesDb db = context.Citites.FirstOrDefault(ce => ce.Id == cityId);
                if (db is null) return;

                context.Citites.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public void SaveCityEntry(CityBlank entryBlank)
        {
            UseContext(context =>
            {
                CititesDb db = entryBlank.ToDb();
                CititesDb existEntry = context.Citites.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.Citites.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Name = db.Name;
                    existEntry.Id_country = db.Id_country;
                    existEntry.Width = db.Width;
                    existEntry.Long = db.Long;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
