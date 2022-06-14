using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("Customers")]
    public class CustomersDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("surname")]
        public String Surname { get; set; }

        [Column("patronymic")]
        public String Patronymic { get; set; }

        [Column("discount")]
        public int Discount { get; set; }

        [Column("passport")]
        public string Passport { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        public CustomersDb() { }

        public CustomersDb(Guid id, String name, string surname, string patronymic, int discount, string passport, string phone, string email)
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
