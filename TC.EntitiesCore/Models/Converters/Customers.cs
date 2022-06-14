using System.Collections.Generic;
using System.Linq;
using TA.Domain.Customers;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class Customers
    {
        internal static Customer ToCustomer(this CustomersDb db)
        {
            return new(db.Id, db.Name, db.Surname, db.Patronymic, db.Discount, db.Passport, db.Phone, db.Email);
        }

        internal static Customer[] ToCustomers(this IEnumerable<CustomersDb> dbs)
        {
            return dbs.Select(ToCustomer).ToArray();
        }

        internal static CustomersDb ToDb(this CustomerBlank blank)
        {
            return new CustomersDb(blank.Id.Value, blank.Name, blank.Surname, blank.Patronymic, blank.Discount, blank.Passport, blank.Phone, blank.Email);
        }
    }
}