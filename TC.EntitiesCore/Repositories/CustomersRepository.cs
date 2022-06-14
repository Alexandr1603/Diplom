using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Customers;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class CustomersRepository : BaseRepository
    {
        public Customer? GetCustomer(Guid customerId)
        {
            return UseContext(context =>
            {
                return context.Customers.FirstOrDefault(c => c.Id == customerId)?.ToCustomer();
            });
        }
        public Customer[] GetAllCustomers()
        {
            return UseContext(context =>
            {
                return context.Customers.ToCustomers();
            });
        }
        public void DeleteCustomer(Guid customerId)
        {
            UseContext(context =>
            {
                CustomersDb db = context.Customers.FirstOrDefault(ce => ce.Id == customerId);
                if (db is null) return;

                context.Customers.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public void SaveCustomerEntry(CustomerBlank entryBlank)
        {
            UseContext(context =>
            {
                CustomersDb db = entryBlank.ToDb();
                CustomersDb existEntry = context.Customers.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.Customers.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Name = db.Name;
                    existEntry.Surname = db.Surname;
                    existEntry.Patronymic = db.Patronymic;
                    existEntry.Discount = db.Discount;
                    existEntry.Passport = db.Passport;
                    existEntry.Phone = db.Phone;
                    existEntry.Email = db.Email;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
