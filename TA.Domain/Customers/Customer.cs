using System;

namespace TA.Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; }
        public String Name { get; }
        public String Surname { get; }
        public String Patronymic { get; }
        public int Discount { get; }
        public string Passport { get; }
        public string Phone { get; }
        public string Email { get; }

        public String Initials => String.Format("{0} {1} {2}", Surname + '.', Name.Substring(0, 1).ToUpper() + '.', String.IsNullOrWhiteSpace(Patronymic) ? "" : Patronymic?.Substring(0, 1).ToUpper() + '.');
        public Customer(Guid id, String name, string surname, string patronymic, int discount, string passport, string phone, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Discount = discount;
            Passport = passport;
            Phone = phone;
            Email = email;
        }
    }
}
