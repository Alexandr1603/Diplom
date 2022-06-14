using System;
using System.ComponentModel.DataAnnotations.Schema;
using TA.Domain.Workers;

namespace TA.EntitiesCore.Models
{

    [Table("Workers")]
    public class WorkersDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("login")]
        public String Login { get; set; }

        [Column("password")]
        public String Password { get; set; }

        [Column("role")]
        public WorkerRole Role { get; set; }

        public WorkersDb() { }

        public WorkersDb(Guid id, String firstName, String lastName, WorkerRole role)
        {
            Id = id;
            Login = firstName;
            Password = lastName;
            Role = role;
        }
    }
}
