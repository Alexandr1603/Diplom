using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Countries;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class CountriesRepository : BaseRepository
    {
        public Country? GetCountry(Guid countryId)
        {
            return UseContext(context =>
            {
                return context.Countries.FirstOrDefault(c => c.Id == countryId)?.ToCountry();
            });
        }

        public Country? GetCountry(String countryName)
        {
            return UseContext(context =>
            {
                return context.Countries.FirstOrDefault(c => c.Name == countryName)?.ToCountry();
            });
        }

        public Country[] GetAllCountries()
        {
            return UseContext(context =>
            {
                return context.Countries.ToCountries();
            });
        }
        public void DeleteCountry(Guid countryId)
        {
            UseContext(context =>
            {
                CountriesDb db = context.Countries.FirstOrDefault(ce => ce.Id == countryId);
                if (db is null) return;

                context.Countries.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public void SaveCountryEntry(CountryBlank entryBlank)
        {
            UseContext(context =>
            {
                CountriesDb db = entryBlank.ToDb();
                CountriesDb existEntry = context.Countries.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.Countries.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Name = db.Name;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
