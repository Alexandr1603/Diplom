using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Customers;
using TA.Domain.TourClients;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class TourClientsRepository : BaseRepository
    {
        public TourClient[] GetTourClients(Guid tourId)
        {
            return UseContext(context =>
            {
                return context.TourClients.Where(c => c.Id_tour == tourId).ToTourClients();
            });
        }
        public void DeleteTourClient(Guid clientId)
        {
            UseContext(context =>
            {
                TourClientsDb db = context.TourClients.FirstOrDefault(ce => ce.Id == clientId);
                if (db is null) return;

                context.TourClients.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public void SaveTourClientEntry(TourClientBlank entryBlank)
        {
            UseContext(context =>
            {
                TourClientsDb db = entryBlank.ToDb();
                TourClientsDb existEntry = context.TourClients.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.TourClients.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Id_client = db.Id_client;
                    existEntry.Id_tour = db.Id_tour;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
