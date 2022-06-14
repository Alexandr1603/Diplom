using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Workers;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class WorkersRepository : BaseRepository
    {
        public Worker? GetWorker(Guid workerId)
        {
            return UseContext(context =>
            {
                return context.Workers.FirstOrDefault(c => c.Id == workerId)?.ToWorker();
            });
        }

        public Worker? GetWorker(String workerLogin)
        {
            return UseContext(context =>
            {
                return context.Workers.FirstOrDefault(c => c.Login == workerLogin)?.ToWorker();
            });
        }

        public Worker[] GetAllWorkers()
        {
            return UseContext(context =>
            {
                return context.Workers.ToWorkers();
            });
        }
        public void DeleteWorker(Guid classId)
        {
            UseContext(context =>
            {
                WorkersDb db = context.Workers.FirstOrDefault(ce => ce.Id == classId);
                if (db is null) return;

                context.Workers.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public void SaveWorkerEntry(WorkerBlank entryBlank)
        {
            UseContext(context =>
            {
                WorkersDb db = entryBlank.ToDb();
                WorkersDb existEntry = context.Workers.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.Workers.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Login = db.Login;
                    existEntry.Password = db.Password;
                    existEntry.Role = db.Role;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
