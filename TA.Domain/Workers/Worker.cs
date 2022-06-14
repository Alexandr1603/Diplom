using System;

namespace TA.Domain.Workers
{
    public class Worker
    {
        public Guid Id { get; }
        public String Login { get; }
        public String Password { get; }
        public WorkerRole Role { get; }
        public Worker(Guid id, String firstName, String lastName, WorkerRole role)
        {
            Id = id;
            Login = firstName;
            Password = lastName;
            Role = role;
        }
    }
}