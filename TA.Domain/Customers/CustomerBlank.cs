using System;

namespace TA.Domain.Customers
{
    public class CustomerBlank
    {
        public Guid? Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Patronymic { get; set; }
        public int Discount { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CustomerBlank() { }
        public CustomerBlank(Guid id, String name, string surname, string patronymic, int discount, string passport, string phone, string email)
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
